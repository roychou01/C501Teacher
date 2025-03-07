--新增 Member 資料時,先檢查會員帳號(Account)是否存在
--因此將新增的方式做成預存程序



create proc InsertMemberData
	@memID nchar(6), @name nvarchar(27), @Gender bit,
	@account nvarchar(12), @password nvarchar(20)
as
begin

	--將資料寫入前, 先檢查會員帳號(Account)是否存在
	declare @result nchar(6) 

	select @result=MemberID from [Member] where Account=@account
	
	if  @result is null
		insert into [Member] values(@memID , @name,@Gender ,0 , @account,@password)
	else
		print '會員帳號重複'

end



--------------------------
--新增會員資料時,一律使用預存程序
exec  InsertMemberData  'M00002' , '陳小美',0 , 'abc123','1234567890'


	