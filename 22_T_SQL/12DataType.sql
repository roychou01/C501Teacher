--資料型態與轉換
--cast()
select pt.類別編號, pt.類別名稱,  cast( count(*) as varchar   ) +'種' as 產品數量
from 產品資料 as p inner join 產品類別 as pt on p.類別編號=pt.類別編號
group by pt.類別編號, pt.類別名稱

--------------------------------------------------------------
--convert()
select  convert( varchar , 訂單日期, 111  ) as 訂單日期, count(*) as 訂單數
from 訂單資料
group by 訂單日期



select  iif( 送貨日期 is null  , '尚未出貨'   , convert( varchar ,送貨日期, 111  )  ) as 送貨日期 , count(*) as 訂單數
from 訂單資料
group by 送貨日期


--isnull()
select isnull( convert( varchar , 送貨日期, 111  ) , '尚未出貨') as 送貨日期, count(*) as 訂單數
from 訂單資料
group by 送貨日期