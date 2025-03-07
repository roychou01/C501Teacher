create database MyStore2
go

use MyStore2
go

--���~��ƪ�
create table [Product](
	ProductID nchar(5) not null primary key,
	ProductName nvarchar(40) not null,
	Price money not null,
	[Description] nvarchar(200),
	Picture nvarchar(12) not null
)
go


--�|����ƪ�
create table [Member](
	MemberID nchar(6) not null primary key,
	[Name] nvarchar(27) not null,
	Gender bit not null,
	Point int not null default 0,
	Account nvarchar(12) not null unique,
	[Password] nvarchar(20) not null
)
go


--�q���ƪ�
create table [Order](
	OrderID nchar(12) not null primary key,
	OrderDate datetime not null default getdate(),
	MemberID nchar(6) not null,
	ContactName nvarchar(27) not null,
	ContactAddress nvarchar(60) not null,
	foreign key(MemberID) references [Member](MemberID)
)
go


--�q����Ӹ�ƪ�
create table OrderDetail(
	OrderID nchar(12) not null,
	ProductID nchar(5) not null,
	Qty int not null default 1,
	Price money not null,
	primary key(OrderID,ProductID),
	foreign key(OrderID) references [Order](OrderID)
)
go

--���~���O��ƪ�
create table Category(
	CateID nchar(2) not null primary key,
	CateName nvarchar(20) not null
)
go



alter table [Product]
	add CateID nchar(2) not null
go


alter table [Product]
	add foreign key(CateID) references Category(CateID)
go

alter table [OrderDetail]
	add foreign key(ProductID) references [Product](ProductID)
go