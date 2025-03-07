--SQL_DML
--select
--insert
--update
--delete
--------------------------------------------------------

use 北風
go
--基本查詢式
select * from 客戶

select 客戶編號, 公司名稱, 連絡人, 連絡人職稱 from 客戶
----------------------------------------------------------

--取別名
select 客戶編號, 公司名稱 as 客戶名稱, 連絡人職稱+連絡人 as 窗口, 郵遞區號+地址 as 地址
from 客戶 

-----------------------------------------------------------
--數值運算

select 訂單號碼,產品編號, 單價 as 售價, 數量 as 購買量, 單價*數量*(1-折扣) as 小計
from 訂單明細

------------------------------------------------
--日期時間
select 員工編號,姓名,出生日期,  datediff( year  , 出生日期   ,   getdate() )  as 年齡
--,datediff( MONTH  , 出生日期   ,   getdate() ),datediff( DAY  , 出生日期   ,   getdate() )
from 員工

------------------------------------------------
select 員工編號,姓名
,datediff( year  , 出生日期   ,   getdate() )  as 年齡
,datediff( year  , 雇用日期   ,   getdate() )  as 年資
,datediff( year  , 出生日期   ,  雇用日期)  as 任職時年齡
from 員工

 
 