--alter 修改資料表定義

--在Product資料表中增加一個CateID的欄位
alter table [Product]
	add CateID nchar(2) not null


--在Product資料表中建立與Category的關聯
alter table [Product]
	add foreign key(CateID) references Category(CateID)

--在OrderDetail資料表中建立與Product的關聯
alter table [OrderDetail]
	add foreign key(ProductID) references [Product](ProductID)
