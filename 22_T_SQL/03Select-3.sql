--資料篩選
select *
from 客戶
where 連絡人職稱 = '董事長'

select *
from 客戶
where 公司名稱 = '路福村'

select *
from 客戶
where 客戶編號 = 'DUMON'


--查1994年以後到職的員工
select *
from 員工
where 雇用日期 >= '1994-1-1'
--where year(雇用日期) >= '1994'
--where 雇用日期 >= '1994'


--查詢產品庫存量為0且未下架的資料
select *
from 產品資料
where 庫存量=0  and  已下架=0


--查詢產品安全存量小於10的資料
select *
from 產品資料
where 安全存量<10


--請查詢哪些產品的庫存量低於安全存量
select *
from 產品資料
where 庫存量<安全存量

--請查詢哪些產品需要採購
select *
from 產品資料
where 庫存量+已訂購量 < 安全存量


--請找出 尚未出貨 的訂單
select *
from 訂單資料
where 送貨日期 is null



