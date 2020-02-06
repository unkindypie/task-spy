use [task-spy];


alter procedure last_user_report
	@user_id bigint,
	@show_every_user bit,
	@machine_id bigint
as
begin
	select processEntries.name as procname, local_username 'username',
	cpu_load, mem_load, pid, parent_pid, is_system, processes.id from processes
	join processEntries
	on processEntries.id = entry_id
	join users on users.id = processes.user_id
	--если процесс пришел из последнего отчета, в котором присутствовали процессы пользователя
	where report_id = (
		select top 1 reports.id from reports, processes
		where report_id = reports.id and processes.user_id = @user_id and machine_id = @machine_id
		and created = (
				select max(created) from reports
				join processes
				on report_id = reports.id
				where processes.user_id = @user_id
		)
		and (@show_every_user = 1 or (is_real = 0 or users.id = @user_id))
	)
end

execute last_user_report 3, 1, 2

execute last_user_report 3, 0, 0, 1, 3

select * from users;

create procedure get_user_machines
	@user_id bigint
as
begin
select distinct machines.name, created, machine_id from machines, reports
join processes on
report_id = reports.id
where user_id = @user_id
and machine_id = machines.id
and created = (
	select max(created) from machines, reports
	join processes on
	report_id = reports.id
	where user_id = @user_id
	and machine_id = machines.id
)
end

execute get_user_machines 6