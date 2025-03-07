--更新資料
--update
--update一次只能對一個資料表做
--但可以一次更新1~N筆資料

update 貨運公司
set 貨運公司名稱='中榮貨運', 電話='(08)998-8777'
where 貨運公司編號=20


update 客戶
set 連絡人職稱='業務助理', 連絡人='小英'
where 客戶編號='KPPTR'

--------------------------------------------------
--把處理過100張(含)以上訂單的員工,附註欄位加上「勤奮」兩字

update 員工
set 附註=附註+', 勤奮'
where 員工編號 in (select 員工編號
from 訂單資料
group by 員工編號
having count(*)>=100)



--把從未處理過訂單的員工,附註欄位加上「米蟲」兩字
update 員工
set 附註=附註+', 米蟲'
from 訂單資料 as o right join 員工 as e on o.員工編號=e.員工編號
where o.員工編號 is null


