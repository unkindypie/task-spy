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
	created DATETIME not null,
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


create trigger reports_mutator_insert on reports_mutator
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
	values (@machine_id, GETDATE(), (select total_memory_load from inserted), 
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

create trigger processes_mutator_trigger
on processes_mutator instead of insert
as
begin
	declare @user_id bigint;
	set @user_id = 
	(
		select id from users, inserted
		where users.local_username = inserted.local_username
			and users.is_real = inserted.is_user_real
	)
	if(@user_id is null)
	begin
		insert into users
		values (null, (select local_username from inserted), (select is_user_real from inserted))
		set @user_id = (SELECT SCOPE_IDENTITY());
	end
	declare @entryId bigint;
	set @entryId = 
	(
		select id from processEntries, inserted
		where processEntries.bin_path = inserted.bin_path
		and processEntries.name = inserted.name
	)
	if(@entryId is null)
	begin
		insert into processEntries
		values ((select name from inserted), (select bin_path from inserted), 0)
		set @entryId = (SELECT SCOPE_IDENTITY());
	end
	
	insert into processes
	values (
		@entryId,
		(select report_id from inserted),
		(select cpu_load from inserted),
		(select mem_load from inserted),
		(select pid from inserted),
		(select parent_pid from inserted),
		(select is_system from inserted),
		@user_id
	)
end

insert into machines values ('machine23123');
insert into reports_mutator values (1215451,10.75, 'the machine@323', '121.45.232.12');

insert into processes_mutator values (1, 55.41, 1455, 21, 45, 'chrom!', 'E:\apps\Chrome\chroe.exe', 0, 'vasyan', 0);

select * from ips;
select * from machines;
select * from processEntries;
select * from processes;
select * from reports;




use [task-spy];
select * from reports order by created desc;
select * from users;
select * from ips;
select * from machines;

select processEntries.name, users.local_username, created from processes
join users on user_id = users.id
join processEntries on processEntries.id = processes.entry_id
join reports on reports.id = report_id
where processes.report_id = (select id from reports where created = (select max(created) from reports));

--delete from processes;
--delete from processEntries;
--delete from reports;
--delete from users;
--delete from ips;
--delete from machines;

select local_username, pseudonym, id from users where is_real = 1;