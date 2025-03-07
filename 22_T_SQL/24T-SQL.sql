--T-SQL 程式設計
--程式 = 演算法 + 資料結構

--PL/SQL

print 'Hello World!!'

select 'Hello World!!' as 欄位 --執行完的結果會是一個table

select tb1.*
from  (select 'Hello World!!' as col1) as tb1

--------------------------------------------------------
--變數
--1.純量值變數 2.資料表值變數

declare @MyName nvarchar(20) ='Jack Lee'

print @MyName
select @MyName
-------------------------------------
declare @Number int
set @Number=123
select @Number=456

print @Number
print @nuMBeR
--T-SQL 不分大小寫
-----------------------------

declare @EmpName nvarchar(20)

select @EmpName=姓名
from 員工
where 員工編號='E0007'


print '員工的姓名叫'+@EmpName
-------------------------------------------

declare @salary money=50000
print '您的薪水是'+ cast(@salary as varchar)

declare @birthday datetime ='2024-12-11'
print '您的生日是'+ convert(varchar,@birthday,111 )


declare @dDay datetime

select @dDay=要貨日期
from 訂單資料
where 訂單號碼='10259'


print '此訂單的要貨日期是'+ convert(varchar,@dDay,111 )
-----------------------------------------------
--資料表值變數
declare  @myTable table (
	name nvarchar(20),
	birthday datetime,
	tel varchar(20),
	note nvarchar(max)
)

insert into @myTable values('王小明','2024-12-11','07-8210171','長的很可愛')
insert into @myTable select 姓名,出生日期,電話號碼,附註 from 員工

select * from @myTable








