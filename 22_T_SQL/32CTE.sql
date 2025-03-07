--CTE查詢
--聯集 union ,交集 intersect, 差集except
--第1層
select 員工編號,姓名, 1 as 階層
from 員工
where 主管 is null  --這位員工的編號是E0001

union all

--第2層
select 員工編號,姓名, 2 as 階層
from 員工
where 主管 ='E0001'  --找到E0004和E0013


union all

--第3層
select 員工編號,姓名, 3 as 階層
from 員工
where 主管 in ('E0004','E0013')   --找到E0005

union all
--第4層
select 員工編號,姓名, 4 as 階層
from 員工
where 主管 in ('E0005')   --找到E0002和E0006和E0007和E0009
union all

--第5層
select 員工編號,姓名, 5 as 階層
from 員工
where 主管 in ('E0002','E0006','E0007','E0009')     --找到E0003和E0008和E0012和E0014

union all

--第6層
select 員工編號,姓名, 6 as 階層
from 員工
where 主管 in ('E0003','E0008','E0012','E0014')  --到第6層就沒有任何員工,因此為程式結束點

-------------------------------------------------------------------------------------------------

--子查詢
select 訂單號碼,公司名稱, 連絡人
from 
(select o.訂單號碼,c.公司名稱,c.連絡人,c.電話, o.訂單日期,o.要貨日期,o.送貨日期, e.姓名,
	d.貨運公司名稱, o.收貨人,o.送貨方式
	from 訂單資料 as o inner join 客戶 as c on o.客戶編號=c.客戶編號
	inner join 員工 as e on o.員工編號=e.員工編號
	inner join 貨運公司 as d on o.送貨方式=d.貨運公司編號) as myTable

--CTE語法
with myTable
as
(select o.訂單號碼,c.公司名稱,c.連絡人,c.電話, o.訂單日期,o.要貨日期,o.送貨日期, e.姓名,
	d.貨運公司名稱, o.收貨人,o.送貨方式
	from 訂單資料 as o inner join 客戶 as c on o.客戶編號=c.客戶編號
	inner join 員工 as e on o.員工編號=e.員工編號
	inner join 貨運公司 as d on o.送貨方式=d.貨運公司編號
)

select 訂單號碼,公司名稱, 連絡人 from myTable

--------------------------------------------------------------------------------
--CTE遞迴
with getLevelTable
as
(
	select 員工編號,姓名, 1 as 階層
	from 員工
	where 主管 is null  --這位員工的編號是E0001
	union all
	select 員工.員工編號,員工.姓名, 階層+1 as 階層
	from 員工 inner join getLevelTable on 員工.主管=getLevelTable.員工編號
)


select * from getLevelTable


--將上列CTE查詢式建立成預存程序
create proc getLevelTable
as
begin
	with getLevelTable
	as
	(
		select 員工編號,姓名, 1 as 階層
		from 員工
		where 主管 is null  --這位員工的編號是E0001
		union all
		select 員工.員工編號,員工.姓名, 階層+1 as 階層
		from 員工 inner join getLevelTable on 員工.主管=getLevelTable.員工編號
	)


	select * from getLevelTable

end



-------------------------------
exec getLevelTable
