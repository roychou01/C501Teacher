--�s�W Member ��Ʈ�,���ˬd�|���b��(Account)�O�_�s�b
--�]���N�s�W���覡�����w�s�{��



create proc InsertMemberData
	@memID nchar(6), @name nvarchar(27), @Gender bit,
	@account nvarchar(12), @password nvarchar(20)
as
begin

	--�N��Ƽg�J�e, ���ˬd�|���b��(Account)�O�_�s�b
	declare @result nchar(6) 

	select @result=MemberID from [Member] where Account=@account
	
	if  @result is null
		insert into [Member] values(@memID , @name,@Gender ,0 , @account,@password)
	else
		print '�|���b������'

end



--------------------------
--�s�W�|����Ʈ�,�@�ߨϥιw�s�{��
exec  InsertMemberData  'M00002' , '���p��',0 , 'abc123','1234567890'


	