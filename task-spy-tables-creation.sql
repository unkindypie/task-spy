use [task-spy];

--drop table processes;
--drop table reports;
--drop table processEntries;
--drop table bin_paths;
--drop table process_names;
--drop table users;
--drop table ips;
--drop table machines;

--drop trigger reports_mutator_insert;
--drop table reports_mutator;
--drop trigger processes_mutator_trigger;
--drop table processes_mutator;


create table bin_paths
(
	id bigint primary key identity(1, 1),
	bin_path nvarchar(260) not null
)
create table process_names
(
	id bigint primary key identity(1, 1),
	name nvarchar(255) not null
)

create table processEntries
(
	id bigint primary key identity(1, 1),
	in_whitelist bit not null,
	bin_path_id bigint not null,
	process_name_id bigint not null,
    foreign key (bin_path_id) references bin_paths(id),
    foreign key (process_name_id) references process_names(id)
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

insert into reports_mutator values (1515, 15, 'effe', '12.2121.465');

go
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
go
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

	declare @bin_path_id bigint;
	declare @process_name_id bigint;

	set @process_name_id = 
	(
		select id from process_names
		where name = @name
	)
	if(@process_name_id is null)
	begin
		insert into process_names
		values (@name)
		set @process_name_id = (SELECT SCOPE_IDENTITY());
	end

	set @bin_path_id = 
	(
		select id from bin_paths
		where bin_path = @bin_path
	)
	if(@bin_path_id is null)
	begin
		insert into bin_paths
		values (@bin_path)
		set @bin_path_id = (SELECT SCOPE_IDENTITY());
	end

	declare @entryId bigint;
	set @entryId = 
	(
		select id from processEntries
		where processEntries.bin_path_id = @bin_path_id
		and processEntries.process_name_id = @process_name_id
	)
	if(@entryId is null)
	begin
		insert into processEntries
		values (0, @bin_path_id, @process_name_id)
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
go;
create TYPE ProcTempTable 
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



create trigger processes_mutator_trigger
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
go

select * from reports;

--ALTER TABLE
--  reports
--ALTER COLUMN
--  created
--    datetime null;



--execute last_user_report 6, 0, 2;




--alter table processEntries
--add bin_path_id bigint null;

--alter table processEntries
--add process_name_id bigint null;

--insert into bin_paths
--select distinct bin_path from processEntries;

--insert into process_names
--select distinct name from processEntries;

--select * from processEntries;

--UPDATE processEntries
--SET process_name_id = process_names.id
--FROM processEntries
--    INNER JOIN process_names
--    ON process_names.name = processEntries.name


--UPDATE processEntries
--SET bin_path_id = bin_paths.id
--FROM processEntries
--    INNER JOIN bin_paths
--    ON bin_paths.bin_path = processEntries.bin_path

--ALTER TABLE processEntries DROP COLUMN bin_path;
--ALTER TABLE processEntries DROP COLUMN name;
--ALTER TABLE processEntries add foreign key (bin_path_id) references bin_paths(id)
--ALTER TABLE processEntries add foreign key (process_name_id) references process_names(id)




--select * from reports;

--insert into processes_mutator values (10405, 10, 212321, 2634, 454, 'test-proc', 'c/path/to/proc.exe', 0, 'owner', 0);

--select * from users
--where local_username like '%ir%'