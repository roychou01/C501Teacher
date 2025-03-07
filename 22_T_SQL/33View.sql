--檢視表(View)物件
create view v_getOrderListWithOtherData
as

	select o.訂單號碼,c.公司名稱,c.連絡人,c.電話, o.訂單日期,o.要貨日期,o.送貨日期, e.姓名,
	d.貨運公司名稱, o.收貨人,o.送貨方式
	from 訂單資料 as o inner join 客戶 as c on o.客戶編號=c.客戶編號
	inner join 員工 as e on o.員工編號=e.員工編號
	inner join 貨運公司 as d on o.送貨方式=d.貨運公司編號

-------------------------------------------


select 公司名稱, 連絡人 from v_getOrderListWithOtherData

select * 
from v_getOrderListWithOtherData
where 訂單號碼='120123'