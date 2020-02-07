use [task-spy];

go
alter procedure last_user_report
	@user_id bigint,
	@show_every_user bit,
	@machine_id bigint
as
begin
	select process_names.name as procname, local_username 'username',
	ROUND(cpu_load, 1) 'cpu_load', mem_load, pid, parent_pid, is_system, processes.id from processes
	join processEntries
	on processEntries.id = entry_id
	join users on users.id = processes.user_id
	join process_names on processEntries.process_name_id = process_names.id
	--join bin_paths on processEntries.bin_path_id = bin_paths.id
	--���� ������� ������ �� ���������� ������, � ������� �������������� �������� ������������
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
create procedure get_user_machines
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
