

select *
from 訂單明細


select *
from 產品資料


select *
from 產品類別

----------------------
--inner join 合併查詢言法
select 訂單明細.訂單號碼, 訂單明細.產品編號, 產品資料.產品, 訂單明細.單價,訂單明細.數量,訂單明細.折扣
from 訂單明細 inner join 產品資料 on 訂單明細.產品編號=產品資料.產品編號


--利用別名縮短 DML
select od.訂單號碼, od.產品編號, p.產品, od.單價,od.數量,od.折扣
from 訂單明細 as od inner join 產品資料 as p on od.產品編號=p.產品編號


--加入毛利的欄位(算術運算)
select od.訂單號碼,  od.產品編號, p.產品, od.單價, p.訂價, p.訂價-od.單價 as 單位毛利,  
(p.訂價-od.單價)*od.數量 as 毛利,(p.訂價-od.單價)*od.數量*(1-od.折扣) as 淨利,  od.數量,od.折扣
from 訂單明細 as od inner join 產品資料 as p on od.產品編號=p.產品編號


--合併產品類別資料表取得類別名稱
select od.訂單號碼, p.類別編號,  pt.類別名稱  ,od.產品編號, p.產品, od.單價, p.訂價, p.訂價-od.單價 as 單位毛利,  
(p.訂價-od.單價)*od.數量 as 毛利,(p.訂價-od.單價)*od.數量*(1-od.折扣) as 淨利,     od.數量,od.折扣
from 訂單明細 as od inner join 產品資料 as p on od.產品編號=p.產品編號
inner join 產品類別 as pt on pt.類別編號=p.類別編號

------------------------------------------------------------------------

select *
from 訂單明細 as od
inner join 訂單資料 as o on od.訂單號碼=o.訂單號碼
inner join 產品資料 as p on od.產品編號=p.產品編號
inner join 供應商 as sp on sp.供應商編號=p.供應商編號
inner join 產品類別 as pt on pt.類別編號=p.類別編號
inner join 員工 as e on e.員工編號=o.員工編號
inner join 客戶 as c on c.客戶編號=o.客戶編號
inner join 貨運公司 as ca on ca.貨運公司編號=o.送貨方式
--------------------------------------------------------------
-------------------------------------------------------------
--統計每位客戶的下單次數
--請列出 客戶編號, 客戶名稱, 連絡人, 連絡人職稱, 下單次數

select o.客戶編號, c.公司名稱 as 客戶名稱, c.連絡人, c.連絡人職稱  ,count(*) as 下單次數
from 訂單資料 as o inner join 客戶 as c on o.客戶編號=c.客戶編號
group by o.客戶編號, c.公司名稱, c.連絡人, c.連絡人職稱


--找出消費總額 >=3萬元的客戶
--列出 客戶編號, 客戶名稱, 連絡人, 連絡人職稱, 下單次數, 消費總額, 平均銷費額
--並以 消費總額 遞減排序,若消費總額相同則以 下單次數 遞減排序

select o.客戶編號, c.公司名稱 as 客戶名稱, c.連絡人, c.連絡人職稱  ,count(*) as 下單次數,
round(sum(od.單價*od.數量*(1-od.折扣)),0) as 消費總額, round(sum(od.單價*od.數量*(1-od.折扣))/count(*),0) as 平均銷費額
from 訂單資料 as o 
inner join 客戶 as c on o.客戶編號=c.客戶編號
inner join 訂單明細 as od on o.訂單號碼=od.訂單號碼
group by o.客戶編號, c.公司名稱, c.連絡人, c.連絡人職稱
having sum(od.單價*od.數量*(1-od.折扣)) >=30000
order by 消費總額 desc, 下單次數 desc

-------------------------------------------

select o.員工編號,e.姓名, DATEDIFF( year , e.雇用日期 , getdate() ) as 年資 ,  count(*) as 處理訂單數,
count(*) / DATEDIFF( year , e.雇用日期 , getdate() ) as 每年平均處理訂單數
from 訂單資料 as o inner join 員工 as e on o.員工編號=e.員工編號
group by o.員工編號,e.姓名,e.雇用日期
order by 處理訂單數 desc, 年資



