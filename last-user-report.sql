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
		select top 1 reports.id from reports, processes
		where report_id = reports.id and processes.user_id = @user_id and machine_id = @machine_id
		and created = (
				select max(created) from reports
				join processes
				on report_id = reports.id
				where processes.user_id = @user_id
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
	join processes 
	on report_id = reports.id
	where user_id = @user_id
	group by name, machines.id, machines.name
	order by created desc
end
go;
create procedure get_process
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

use [task-spy];
declare @dt datetime = (
select created from reports where id = 12400
)
declare @userid bigint = 105;
declare @machineid bigint = 1;

declare @reports ReportTempTable;

insert into @reports
select distinct created, reports.id, total_cpu_load, total_memory_load, machines.name 'machine', ips.ip, null, null from reports
join processes
on user_id = @userid
join machines
on machine_id = machines.id
join ips
on ips.id = ip_id
where created > @dt and machine_id = @machineid

select * from @reports
declare @id bigint = (select min(id) from @reports);
declare @end bigint = (select max(id) from @reports);
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
			set has_unwhitelisted = 0
		end
	else
		begin
		update @reports
			set has_unwhitelisted = 1
		end
	set @id = @id + 1;
end
select * from @reports