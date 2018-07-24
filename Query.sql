create schema [Hotel]
go

create schema [Client]
go

create table [Hotel].[Hotel]
(
	[Guid] uniqueidentifier not null,
	[Name] varchar(200) null,
	[Address] varchar(200) null,
	constraint [Hotel_pk] primary key ([Guid])
) ON [PRIMARY]
go

create table [Hotel].[Housing]
(
	[Guid] uniqueidentifier not null,
	[SortNumber] int default(0),
	[Name] varchar(200) null,
	[HotelGuid] uniqueidentifier null,
	constraint [Housing_pk] primary key ([Guid]),
	constraint [Housing_Hotel_fk] foreign key ([HotelGuid]) references [Hotel].[Hotel]([Guid])
) on [PRIMARY]
go

create table [Hotel].[Room]
(
	[Guid] uniqueidentifier not null,
	[Name] varchar(200) null,
	[Status] int default(0),
	[CostPerDay] float null,
	[CostService] float null,
	[HousingGuid] uniqueidentifier null,
	constraint [Room_pk] primary key ([Guid]),
	constraint [Room_Housing_fk] foreign key ([HousingGuid]) references [Hotel].[Housing]([Guid])
) on [PRIMARY]
go

create table [Client].[Client]
(
	[Guid] uniqueidentifier not null,
	[FirstName] varchar(200) null,
	[LastName] varchar(200) null,
	[MiddleName] varchar(200) null,
	[Birthday] date null,
	constraint [Client_pk] primary key ([Guid])
) on [PRIMARY]
go

create table [Hotel].[Residence]
(
	[Id] int identity(1,1),
	[RoomGuid] uniqueidentifier not null,
	[ClientGuid] uniqueidentifier not null,
	[BeginDate] datetime null,
	[EndDate] datetime null,
	constraint [Residence_pk] primary key ([Id]),
	constraint [Residence_Room_fk] foreign key ([RoomGuid]) references [Hotel].[Room]([Guid]),
	constraint [Residence_Client_fk] foreign key ([ClientGuid]) references [Client].[Client]([Guid])
)on [PRIMARY]
go

insert into [Hotel].[Hotel] values
('{DFD6C51B-3F9D-44CB-8481-8767C07EE0E8}', 'Отель Гранд Торино', 'г.Томск, ул.Советская 99')

insert into [Hotel].[Housing] values
(newid(), 0, 'Корпус А', '{DFD6C51B-3F9D-44CB-8481-8767C07EE0E8}'),
(newid(), 1, 'Корпус Прима', '{DFD6C51B-3F9D-44CB-8481-8767C07EE0E8}'),
(newid(), 2, 'Корпус Green', '{DFD6C51B-3F9D-44CB-8481-8767C07EE0E8}')

declare @HousingGuid uniqueidentifier

select
	@HousingGuid = [Guid]
from [Hotel].[Housing]
where [Name] = 'Корпус А'

insert into [Hotel].[Room] ([Guid], [Name], [CostPerDay], [CostService], [HousingGuid]) values
(newid(), '100', 100, 20, @HousingGuid),
(newid(), '101', 100, 20, @HousingGuid),
(newid(), '102', 100, 20, @HousingGuid)

select
	@HousingGuid = [Guid]
from [Hotel].[Housing]
where [Name] = 'Корпус Прима'

insert into [Hotel].[Room] ([Guid], [Name], [CostPerDay], [CostService], [HousingGuid]) values
(newid(), 'Люкс', 1000, 100, @HousingGuid),
(newid(), 'Президентский Люкс', 10000, 5000, @HousingGuid)

select
	@HousingGuid = [Guid]
from [Hotel].[Housing]
where [Name] = 'Корпус Green'

insert into [Hotel].[Room] ([Guid], [Name], [CostPerDay], [CostService], [HousingGuid]) values
(newid(), 'Sun', 120, 20, @HousingGuid),
(newid(), 'Apple', 200, 200, @HousingGuid),
(newid(), 'Flower', 150, 20, @HousingGuid),
(newid(), 'Berry', 500, 100, @HousingGuid)