use [task-spy];

go
create procedure last_user_report
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
--create procedure update_pseudonym
--	@userId bigint,
--	@pseudonym nvarchar(16)
--as
--begin
--	update users
--	set pseudonym = @pseudonym
--	where id = @userId
--end
--go;
<<<<<<< HEAD


update processEntries
set in_whitelist = 1
from processEntries
join processes
on entry_id = processEntries.id
where user_id = 105


select top 1 processEntries.id from processEntries, processes
where entry_id = processEntries.id 
	and user_id = 105 and in_whitelist = 0
=======
select * from users;
select * from reports;
>>>>>>> 4f9d2d1baff8746623f54778c3c9090d9d966543
