--合併查詢
--外部合併

--找出從未處理訂單的員工資料
select e.*
from 訂單資料 as o right outer join 員工 as e on o.員工編號=e.員工編號
where o.訂單號碼 is null


--找出從未下過訂單的客戶資料
select c.*
from 客戶 as c  left join 訂單資料 as o on o.客戶編號=c.客戶編號
where o.訂單號碼 is null


--找出從未被買過的商品資料
select p.*
from 訂單明細 as od right join 產品資料 as p on od.產品編號=p.產品編號
where od.訂單號碼 is null


