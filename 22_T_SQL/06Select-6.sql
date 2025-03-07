--group by

select distinct 職稱
from 員工


select 職稱
from 員工
group by 職稱



select distinct 連絡人職稱
from 客戶


select 連絡人職稱
from 客戶
group by 連絡人職稱
--------------------------------------
--統計員工資料中每一種職稱各有多少人

select distinct 職稱
from 員工

select 職稱
from 員工
group by 職稱

select count(*)
from 員工

select 職稱, count(*) as 員工人數
from 員工
group by 職稱



select 連絡人職稱, COUNT(*) as 人數
from 客戶
group by 連絡人職稱


--每張訂單訂購了幾種商品(訂單號碼在訂單明細中出現的次數)
--訂單編號,幾種商品
select 訂單號碼,count(*) as 幾種商品
from 訂單明細
group by 訂單號碼

--每張訂單訂購的商品總量
select 訂單號碼, sum(數量) as 商品訂購量
from 訂單明細
group by 訂單號碼


--每張訂單的總額

select 訂單號碼,產品編號, 單價*數量*(1-折扣) as 小計
from 訂單明細

select 訂單號碼, round(  sum(單價*數量*(1-折扣)) , 2  ) as 訂單總金額
from 訂單明細
group by 訂單號碼



--列出訂單總額最高的前十筆資料
select top 10 with ties 訂單號碼, round(  sum(單價*數量*(1-折扣)) , 2  ) as 訂單總金額
from 訂單明細
group by 訂單號碼
order by 訂單總金額 desc

---------------------------------------------------------------------
--每一位客戶下單次數
select 客戶編號, COUNT(*) as 下單次數
from 訂單資料
group by 客戶編號
order by 下單次數 desc


--哪些客戶下單超過10次
--having
select 客戶編號, COUNT(*) as 下單次數
from 訂單資料
group by 客戶編號
having  COUNT(*) >10
order by 下單次數 desc



--統計每一位員工處理訂單的次數
select 員工編號, COUNT(*) as 處理次數
from 訂單資料
group by 員工編號
order by 處理次數 desc


--統計每一位員工處理每一位客戶的訂單的次數
select 員工編號, 客戶編號, count(*)
from 訂單資料
group by 員工編號, 客戶編號
order by 員工編號


-----------------------------------------
--找出前10名的銷售熱門商品(量最多)
select top 10 with ties 產品編號,sum(數量) as 銷售量
from 訂單明細
group by 產品編號
order by 銷售量 desc



--找出前10名的銷售熱門商品(營業額)
select top 10 with ties 產品編號, round(sum(數量*單價*(1-折扣)),0) as 營業額
from 訂單明細
group by 產品編號
order by 營業額 desc


--撰寫順序
--select 
--from
--where
--group by 
--having
--order by

--執行順序
--from
--where
--group by 
--having
--select
--order by

