--建立資料表

--產品資料表
create table [Product](
	ProductID nchar(5) not null primary key,
	ProductName nvarchar(40) not null,
	Price money not null,
	[Description] nvarchar(200),
	Picture nvarchar(12) not null
)



--會員資料表
create table [Member](
	MemberID nchar(6) not null primary key,
	[Name] nvarchar(27) not null,
	Gender bit not null,
	Point int not null default 0,
	Account nvarchar(12) not null unique,
	[Password] nvarchar(20) not null
)



--訂單資料表
create table [Order](
	OrderID nchar(12) not null primary key,
	OrderDate datetime not null default getdate(),
	MemberID nchar(6) not null,
	ContactName nvarchar(27) not null,
	ContactAddress nvarchar(60) not null,
	foreign key(MemberID) references [Member](MemberID)
)



--訂單明細資料表
create table OrderDetail(
	OrderID nchar(12) not null,
	ProductID nchar(5) not null,
	Qty int not null default 1,
	Price money not null,
	primary key(OrderID,ProductID),
	foreign key(OrderID) references [Order](OrderID)
)


--產品類別資料表
create table Category(
	CateID nchar(2) not null primary key,
	CateName nvarchar(20) not null
)
