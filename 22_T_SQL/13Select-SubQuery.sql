--子查詢(Sub Query)
select * from 訂單資料
where 客戶編號='ERNSH'

select 客戶編號 from 客戶
where 公司名稱='大華城台北'

--調出「東遠銀行」客戶的所有訂單紀錄
select * from 訂單資料
where 客戶編號 = (select 客戶編號 from 客戶
where 公司名稱='東遠銀行')


--調出某位員工處理的所有訂單紀錄
select * from 訂單資料
where 員工編號=( select 員工編號 from 員工 where 姓名='劉天王' )


--合併查詢的寫法
select o.* 
from 訂單資料 as o  inner join 客戶 as c  on o.客戶編號=c.客戶編號
where c.公司名稱='東遠銀行'


select o.* 
from 訂單資料 as o inner join  員工 as e on o.員工編號=e.員工編號
where e.姓名='劉天王'

------------------------------------------------------------------
--請查詢哪些商品的單價大於全部商品的平均單價
--子查詢

select avg(訂價)
from 產品資料

select *
from 產品資料
where 訂價>(select avg(訂價)
from 產品資料)

--合併查詢的寫法
select p.產品編號, p.產品, p.訂價, avg(p2.訂價)
from 產品資料 as p inner join 產品資料 as p2 on p.產品編號 != p2.產品編號
group by p.產品編號, p.產品, p.訂價
having p.訂價>avg(p2.訂價)


--自然合併
select p.產品編號, p.產品, p.訂價, avg(p2.訂價)
from 產品資料 as p, 產品資料 as p2 
group by p.產品編號, p.產品, p.訂價
having p.訂價>avg(p2.訂價)


--cross join (做卡氏積運算)
select p.產品編號, p.產品, p.訂價, avg(p2.訂價)
from 產品資料 as p cross join 產品資料 as p2
group by p.產品編號, p.產品, p.訂價
having p.訂價>avg(p2.訂價)

-----------------------------------------
--哪些客戶買過豬肉
select * from 客戶
where 客戶編號 in (select 客戶編號 from 訂單資料
where 訂單號碼 in (select 訂單號碼 from 訂單明細
where 產品編號 in (select 產品編號 from 產品資料
where 產品='豬肉')))

select distinct c.*
from 客戶 as c inner join 訂單資料 as o on c.客戶編號=o.客戶編號
inner join 訂單明細 as od on o.訂單號碼=od.訂單號碼
inner join 產品資料 as p on od.產品編號=p.產品編號
where p.產品='豬肉'


--哪些員工處理過客戶名稱「正人資源」的訂單

select * from 員工
where 員工編號 in (select distinct 員工編號
from 訂單資料
where 客戶編號 in (select 客戶編號
from 客戶
where 公司名稱='正人資源'))


--in 運算子
select *
from 客戶 
where 客戶編號 in (select distinct 客戶編號 from 訂單資料)

--exists運算子
select *
from 客戶 as c
where exists ( select * from 訂單資料 as o where  c.客戶編號=o.客戶編號 )



















