--order by的子句 offset
--offset的子句 fetch next

--order by
select *
from 產品資料
order by 產品編號
offset 10 rows


select *
from 產品資料
order by 產品編號
offset 10 rows
fetch next 20 rows only

select *
from 產品資料
order by 產品編號
offset 0 rows
fetch next 5 rows only