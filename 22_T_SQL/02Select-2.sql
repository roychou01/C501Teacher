--子句
--查詢哪些客戶下過訂單
--distinct 移除重複資料值
select distinct 客戶編號
from 訂單資料

--查詢哪些產品有被買過
select distinct 產品編號
from 訂單明細

--查詢哪些員工有處理過訂單
select distinct 員工編號
from 訂單資料

-------------------------------
--top子句

select top 10 *
from 訂單明細


select top 10 percent *
from 訂單明細

--配合排序一起使用
--order by
--遞增排序
select *
from 訂單明細
order by 單價


--遞減排序
select *
from 訂單明細
order by 單價 desc

select top 20 percent *
from 訂單明細
order by 數量 desc

select top 20  *
from 訂單明細
order by 數量 desc


select top 15 with ties *
from 訂單明細
order by 數量 desc

select top 20  *
from 訂單明細
order by 數量 desc







