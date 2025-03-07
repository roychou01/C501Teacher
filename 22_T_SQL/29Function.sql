--情境:在新增訂單時，使用者不能自己鍵入訂單編號，因此必須由系統自己按照編號規則產生一個訂單編號
--我們決定在資料庫端建立一個函數，使其在新增訂單資料時能透過函數抓到一個訂單編號

--建立一個名為「getOrderID」的函數
--其功能為新增訂單時可呼叫此函數自動取得一個新的訂單編號
--訂單編號的編碼規則為訂單當天日期西元年月日(8碼)+4碼流水號
--(例如202412212015為2024/12/12第15張訂單的編號)

alter function getOrderID()
	returns nchar(12)
as
begin

	--取得當天日期西元年月日(8碼)
	declare @today char(8) = convert(varchar,getdate(),112)


	--四碼流水號規則
	
	declare @lastID char(12), @newID char(12)
	
	--抓取今天最後一張訂單號碼
	select top 1 @lastID=OrderID
	from [Order]
	where convert(varchar,OrderDate,112)=convert(varchar,getdate(),112)
	order by OrderDate desc

	--如果今天沒有任何訂單,則為0001
	if @lastID is null
		set	@newID= @today+'0001' --今天的第一張訂單編號
	else 
		set	@newID=cast(Cast(@lastID as bigint)+1 as varchar) --否則為今天最後一張訂單的號碼加1	
		
	return @newID

end


print dbo.getOrderID()

insert into [order] values(dbo.getOrderID(),getdate(), 'M00001' ,'余俊德','高雄市後德路100號')

