print getdate()

declare @t datetime = getdate()
set @t+=30
select @t

-------------------------------------------
--�ۭq���(function)

--�I�s��Ʈɥi�H��ܫȤ᪺�Ҧ����



create function fnGetList()
	returns table
return
(select * from �Ȥ�)

go
-------------------------------
select * from fnGetList()
------------------------------

--�ΫȤ�W�ٶi������r�d��

create function fnGetListByKeyword( @keyword nvarchar(20) )
	returns table
return
(select * from �Ȥ� where ���q�W�� like '%'+@keyword+'%')
--------------------------------

select * from fnGetListByKeyword('��')
-----------------------------------------

--�ΫȤ�s���d�ߤ��q�W��

create function fnGetNameByID(@id nchar(5))
	returns nvarchar(40)
as
begin
	declare @Name nvarchar(40)

	select @Name=���q�W��
	from �Ȥ�
	where �Ȥ�s��=@id

	if @Name is null
		return '�d�L�ӫȤ���'

	return @Name

end

----------------------------------------

print dbo.fnGetNameByID('HUNGC')
