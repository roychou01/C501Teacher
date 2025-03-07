print getdate()

declare @t datetime = getdate()
set @t+=30
select @t

-------------------------------------------
--自訂函數(function)

--呼叫函數時可以顯示客戶的所有資料



create function fnGetList()
	returns table
return
(select * from 客戶)

go
-------------------------------
select * from fnGetList()
------------------------------

--用客戶名稱進行關鍵字查詢

create function fnGetListByKeyword( @keyword nvarchar(20) )
	returns table
return
(select * from 客戶 where 公司名稱 like '%'+@keyword+'%')
--------------------------------

select * from fnGetListByKeyword('中')
-----------------------------------------

--用客戶編號查詢公司名稱

create function fnGetNameByID(@id nchar(5))
	returns nvarchar(40)
as
begin
	declare @Name nvarchar(40)

	select @Name=公司名稱
	from 客戶
	where 客戶編號=@id

	if @Name is null
		return '查無該客戶資料'

	return @Name

end

----------------------------------------

print dbo.fnGetNameByID('HUNGC')
