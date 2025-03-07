--drop

drop table [Member]  --這裡會發生關聯問題的錯誤 (F.K 條件約束)

--1. 刪掉Member與Order之間的關聯(解除 F.K 條件約束)
alter table [Order]
	drop Constraint FK__Order__MemberID__3E52440B

--2. 刪掉[Member]資料表
drop table [Member] 


alter table [Member]
	drop column Point
------------------------------------------------------

--刪除資料庫
drop database MyStore
	


