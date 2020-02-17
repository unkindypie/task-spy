use [task-spy];

go
alter procedure last_user_report
	@user_id bigint,
	@show_every_user bit,
	@machine_id bigint
as
begin
	select process_names.name as procname, local_username 'username',
	ROUND(cpu_load, 1) 'cpu_load', mem_load, pid, parent_pid, is_system, processes.id, in_whitelist from processes
	join processEntries
	on processEntries.id = entry_id
	join users on users.id = processes.user_id
	join process_names on processEntries.process_name_id = process_names.id
	--join bin_paths on processEntries.bin_path_id = bin_paths.id
	--если процесс пришел из последнего отчета, в котором присутствовали процессы пользователя
	where report_id = (
		select top 1 reports.id from reports
		where machine_id = @machine_id
		and created = (
				select max(created) from reports
				join report_user
				on report_id = reports.id
				where report_user.user_id = @user_id
				and machine_id = @machine_id
		)
		and (@show_every_user = 1 or (is_real = 0 or users.id = @user_id))
	)
end


go
alter procedure get_user_machines
	@user_id bigint
as
begin
	select distinct max(created) as created, machines.id as machine_id, machines.name from machines
	join reports on 
	machine_id = machines.id
	join report_user
	on report_id = reports.id
	where user_id = @user_id
	group by name, machines.id, machines.name
	order by created desc
end
go;
alter procedure get_process
 @pid int,
 @machine_id bigint
as
begin
	select process_names.name, bin_path, ROUND(cpu_load, 2) 'cpu_load', 
	mem_load, parent_pid, pid, created, is_system, in_whitelist, users.local_username, users.is_real, processes.id from processes 
	join reports
	on report_id = reports.id
	join processEntries
	on processEntries.id = entry_id
	join process_names 
	on processEntries.process_name_id = process_names.id
	join bin_paths
	on bin_paths.id = bin_path_id
	join users
	on user_id = users.id
	where created = (
		select max(created) from processes 
		join reports
		on report_id = reports.id
		where pid = @pid and machine_id = @machine_id
	) and pid = @pid and machine_id = @machine_id
end
go;

create procedure set_proc_whitelist
 @processId bigint,
 @value bit
as
begin
	declare @entry_id bigint = (
		select processEntries.id
		from processes
		join processEntries
		on processEntries.id = entry_id	
		where processes.id = @processId
	);
	update processEntries set in_whitelist = @value
	where id = @entry_id
end
go;

--declare	@user_id bigint = 105;
--declare @show_every_user bit = 1;
--declare @machine_id bigint = 1;

--select distinct reports.id, created from processes
--	join reports on processes.report_id = reports.id
--	join users on users.id = processes.user_id
--where (@show_every_user = 1 or (is_real = 0 or users.id = @user_id)) 
--	and user_id = @user_id and reports.machine_id = @machine_id


use [task-spy];
create type ReportTempTable
as table (
	created datetime,
	id bigint,
	total_cpu_load int,
	total_memory_load bigint,
	machine nvarchar(255),
	ip varchar(16),
	has_unwhitelisted bit,
	process_count int
)


go;

select * from users;
select * from reports order by created desc;

use [task-spy];
create function  hasUnvitelisted ( @report_id bigint )
returns bit
as
begin
	declare @res bit = (select top 1 in_whitelist from processes
			join processEntries
			on entry_id = processEntries.id
			where report_id = @report_id and in_whitelist = 0)
	if(@res = 0)
	begin
		return 1
	end
	return 0
end

exec dbo.hasUnvitelisted(4584);
select * from dbo.hasUnvitelisted (4584)


alter procedure get_report_list
 @from datetime,
 @userid bigint,
 @limit int,
 @including_from bit,
 @to datetime,
 @only_unwhitelisted bit
as
begin

	declare @reports ReportTempTable;

	insert into @reports
	select distinct created, reps.id, total_cpu_load,
	 total_memory_load, machines.name 'machine',
	  ips.ip, null, null from (
			select top (@limit) created, reports.id, total_cpu_load, total_memory_load, machine_id, ip_id from reports
			join report_user on report_user.report_id = reports.id
			where user_id = @userid and ((@including_from = 0 and created < @from) or (@including_from = 1 and created <= @from)) 
				and ((@to is null and 1 < 2) or (@to is not null and created >= @to)) 
				and ((@only_unwhitelisted = 0 and 1 < 2) or (@only_unwhitelisted = 1 and 0 = (select top 1 in_whitelist from processes
							join processEntries
							on entry_id = processEntries.id
							where report_id = reports.id and in_whitelist = 0)
							))
			order by created desc
		) as reps
		--join processes
		--on user_id = @userid
		join machines
		on machine_id = machines.id
		join ips
		on ips.id = ip_id
			--where created <= @from--(@including_from = 0 and created < @from) or (@including_from = 1 and created <= @from);

	declare @id bigint; 
	set @id = (select min(id) from @reports);
	declare @end bigint;
	set @end = (select max(id) from @reports);
	while (@id <= @end)
	begin
		update @reports
		set process_count = (
			select count(*) from processes
			where report_id = @id
		)
		if((
			select top 1 in_whitelist from processes
			join processEntries
			on entry_id = processEntries.id
			where report_id = @id and in_whitelist = 0
		) = 0)
			begin
				update @reports
				set has_unwhitelisted = 1
			end
		else
			begin
			update @reports
				set has_unwhitelisted = 0
			end
		set @id = @id + 1;
	end

	select * from @reports order by created desc;
end


--select * from reports order by created desc
--select * from processes
--join processEntries
--on processEntries.id = entry_id
--where report_id = 19331 and in_whitelist = 0

----declare @dt datetime = (select created from reports where id = 19331);
--declare @dt datetime = (select max(created) as created from reports join processes on report_id = reports.id where user_id = 105);
----declare @todt datetime = (select created from reports where id = 18000);
--declare @todt datetime = (select min(created) as created from reports join processes on report_id = reports.id where user_id = 105);
--execute get_report_list @dt, 105, 8, 1, @todt, 0

----execute get_report_list @dt, 105, 1331, 0, @todt, 0

--select top (15) created, reps.id, total_cpu_load, total_memory_load, machine_id, ip_id from (select top 100000 * from reports order by created desc) as reps
--			where created <= @dt and 0 = (select top 1 in_whitelist from processes
--							join processEntries
--							on entry_id = processEntries.id
--							where report_id = reps.id and in_whitelist = 0)
							



alter procedure get_report
	@user_id bigint,
	@machine_id bigint,
	@show_every_user bit,
	@report_id bigint
as
begin
	select process_names.name as procname, local_username 'username',
	ROUND(cpu_load, 1) 'cpu_load', mem_load, pid, parent_pid, is_system, processes.id, in_whitelist from processes
	join processEntries on processEntries.id = entry_id
	join users on users.id = processes.user_id
	join process_names on processEntries.process_name_id = process_names.id
	join reports
	on report_id = reports.id
	where report_id = @report_id and @machine_id = reports.machine_id and (@show_every_user = 1 or (is_real = 0 or users.id = @user_id))
end



alter procedure whitelist_report 
	@report_id bigint,
	@value bit
as
begin
	update processEntries
	set in_whitelist = @value
	from processEntries
	join processes
	on entry_id = processEntries.id
	where report_id = @report_id
end


select * from processEntries
join process_names on process_names.id = process_name_id
join bin_paths on bin_path_id = bin_paths.id
order by name

select * from processes where entry_id = 137

alter procedure get_process_history
	@user_id bigint,
	@process_id bigint,
	@machine_id bigint
--	@from datetime,
--	@to datetime
as
begin
	declare @entry_id bigint = (select entry_id from processes where id = @process_id);

	select created, sum(cpu_load) cpu_load--, sum(mem_load) mem_load 
	from processes
	join processEntries
	on entry_id = processEntries.id
	join reports on report_id = reports.id
	join report_user on report_user.report_id = reports.id
	where created is not null and machine_id = @machine_id
	 and  --created <= @to and created >= @from and
	--(
	--	select top 1 user_id from processes
	--	where processes.report_id = reports.id
	--	and user_id = @user_id
	--)  is not null
	report_user.user_id = @user_id
	and entry_id = @entry_id
	group by created
	order by created
end

select * from machines;
select * from processes;
execute get_process_history 2, 791165, 1

		