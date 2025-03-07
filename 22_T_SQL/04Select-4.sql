--like運算子(模糊查詢)
--%:代表0~n個任意字元
--_:代表個任意1個字元
--[]:放在中刮號裡的任一個字

--找收貨人是姓陳的
select *
from 訂單資料
where 收貨人 like '陳%'


select *
from 訂單資料
where 收貨人 like '陳_'

select *
from 訂單資料
where 收貨人 like '陳__'

select *
from 訂單資料
where 收貨人 like '陳___'


--[]:放在中刮號裡的任一個字
select *
from 訂單資料
where 收貨人 like '陳%' or 收貨人 like '林%' or 收貨人 like '王%' or 收貨人 like '李%'
or 收貨人 like '趙%'


select *
from 訂單資料
where 收貨人 like '[陳林王李趙]%'

--反
select *
from 訂單資料
where 收貨人 like '[^陳林王李趙]%'

---------------------------------------------
--between...and...

select *
from 產品資料
where 訂價>=10 and 訂價<=20


select *
from 產品資料
where 訂價  between 10 and 20


--in
select *
from 客戶
where 連絡人職稱='董事長' or 連絡人職稱='研發人員' or 連絡人職稱='業務'

select *
from 客戶
where 連絡人職稱 in ('董事長','研發人員','業務','aaaaa')
