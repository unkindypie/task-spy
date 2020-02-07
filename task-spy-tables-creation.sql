use [task-spy];

drop table processes;
drop table reports;
drop table processEntries;
drop table users;
drop table ips;
drop table machines;

drop trigger reports_mutator_insert;
drop table reports_mutator;
drop trigger processes_mutator_trigger;
drop table processes_mutator;

create table processEntries
(
	id bigint primary key identity(1, 1),
	name nvarchar(255) not null,
	bin_path nvarchar(260) not null,
	in_whitelist bit not null,
)

create table ips (
    id bigint primary key identity(1, 1),
	ip varchar(16) not null
)
create table machines (
	id bigint primary key identity(1, 1),
	name nvarchar(255) not null,
)
create table users (
	id bigint primary key identity(1, 1),
	pseudonym nvarchar(16) null,
	local_username nvarchar(20) not null,
	is_real bit not null
)


create table reports (
	id bigint primary key identity(1, 1),
	machine_id bigint not null,
	created DATETIME null,
	total_memory_load bigint,
	total_cpu_load float,
	ip_id bigint,
	foreign key (ip_id) references ips(id),
	foreign key (machine_id) references machines(id)
)

create table processes (
	id bigint primary key identity(1, 1),
	entry_id bigint not null, 
	report_id bigint not null,
	cpu_load float,
	mem_load bigint,
	pid bigint,
	parent_pid bigint,
	is_system bit not null,
	user_id bigint not null
	foreign key (entry_id) references processEntries(id),
	foreign key (report_id) references reports(id),
	foreign key (user_id) references users(id)
)


create table reports_mutator (
	total_memory_load bigint,
	total_cpu_load float,
	machine_name nvarchar(255) not null,
	ip varchar(16) not null,
)


alter trigger reports_mutator_insert on reports_mutator
instead of insert
as
begin
	declare @ip_id bigint;
	set @ip_id = 
	(
		select id from ips, inserted where ips.ip = inserted.ip
	)
	if(@ip_id is null)
	begin
		insert into ips
		values ((select ip from inserted));
		set @ip_id = (SELECT SCOPE_IDENTITY());
	end
	declare @machine_id bigint;
	set @machine_id = (
		select id from machines, inserted
		where name = inserted.machine_name
	)
	if(@machine_id is null)
	begin
		insert into machines values ((select machine_name from inserted))
		set @machine_id = (SELECT SCOPE_IDENTITY());
	end

	insert into reports
	values (@machine_id, null, (select total_memory_load from inserted), 
	(select total_cpu_load from inserted), @ip_id)
	SELECT SCOPE_IDENTITY() as id
end

create table processes_mutator (
	report_id bigint not null,
	cpu_load float,
	mem_load bigint,
	pid bigint,
	parent_pid bigint,
	name nvarchar(255) not null,
	bin_path nvarchar(260) not null,
	is_system bit not null,
	local_username nvarchar(20) not null,
	is_user_real bit not null,
)




create procedure per_process_inserted 
	@report_id bigint,
	@cpu_load float,
	@mem_load bigint,
	@pid bigint,
	@parent_pid bigint,
	@name nvarchar(255),
	@bin_path nvarchar(260),
	@is_system bit,
	@local_username nvarchar(20),
	@is_user_real bit
as
begin
	declare @user_id bigint;
	set @user_id = 
	(
		select id from users
		where users.local_username = @local_username
			and users.is_real = @is_user_real
	)
	if(@user_id is null)
	begin
		insert into users
		values (null, @local_username, @is_user_real)
		set @user_id = (SELECT SCOPE_IDENTITY());
	end
	declare @entryId bigint;
	set @entryId = 
	(
		select id from processEntries
		where processEntries.bin_path = @bin_path
		and processEntries.name = @name
	)
	if(@entryId is null)
	begin
		insert into processEntries
		values (@name, @bin_path, 0)
		set @entryId = (SELECT SCOPE_IDENTITY());
	end
	
	insert into processes
	values (
		@entryId,
		@report_id,
		@cpu_load,
		@mem_load,
		@pid,
		@parent_pid,
		@is_system,
		@user_id
	)
end

CREATE TYPE ProcTempTable 
AS TABLE (
	id int identity(1, 1),
	report_id bigint not null,
	cpu_load float,
	mem_load bigint,
	pid bigint,
	parent_pid bigint,
	name nvarchar(255) not null,
	bin_path nvarchar(260) not null,
	is_system bit not null,
	local_username nvarchar(20) not null,
	is_user_real bit not null
	)


alter trigger processes_mutator_trigger
on processes_mutator instead of insert
as
begin

	declare @tempTable as ProcTempTable;

	insert into @tempTable
	select * from inserted

	declare @id int = 1;
	while(@id < (select max(id)+1 from @tempTable))
	begin
		declare @report_id bigint = (select report_id from @tempTable where id = @id)
		declare @cpu_load float = (select cpu_load from @tempTable where id = @id)
		declare @mem_load bigint = (select mem_load from @tempTable where id = @id)
		declare @pid bigint =(select pid from @tempTable where id = @id)
		declare @parent_pid bigint = (select parent_pid from @tempTable where id = @id)
		declare @name nvarchar(255) = (select name from @tempTable where id = @id)
		declare @bin_path nvarchar(260) = (select bin_path from @tempTable where id = @id)
		declare @is_system bit = (select is_system from @tempTable where id = @id)
		declare @local_username nvarchar(20) = (select local_username from @tempTable where id = @id)
		declare @is_user_real bit = (select is_user_real from @tempTable where id = @id)

		execute per_process_inserted @report_id, @cpu_load, @mem_load, @pid, @parent_pid, @name, @bin_path, @is_system, @local_username, @is_user_real

		set @id = @id + 1;
	end
end



ALTER TABLE
  reports
ALTER COLUMN
  created
    datetime null;



execute last_user_report 6, 0, 2;
