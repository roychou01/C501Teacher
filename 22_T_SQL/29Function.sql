--����:�b�s�W�q��ɡA�ϥΪ̤���ۤv��J�q��s���A�]�������Ѩt�Φۤv���ӽs���W�h���ͤ@�ӭq��s��
--�ڭ̨M�w�b��Ʈw�ݫإߤ@�Ө�ơA�Ϩ�b�s�W�q���Ʈɯ�z�L��Ƨ��@�ӭq��s��

--�إߤ@�ӦW���ugetOrderID�v�����
--��\�ର�s�W�q��ɥi�I�s����Ʀ۰ʨ��o�@�ӷs���q��s��
--�q��s�����s�X�W�h���q���Ѥ���褸�~���(8�X)+4�X�y����
--(�Ҧp202412212015��2024/12/12��15�i�q�檺�s��)

alter function getOrderID()
	returns nchar(12)
as
begin

	--���o��Ѥ���褸�~���(8�X)
	declare @today char(8) = convert(varchar,getdate(),112)


	--�|�X�y�����W�h
	
	declare @lastID char(12), @newID char(12)
	
	--������ѳ̫�@�i�q�渹�X
	select top 1 @lastID=OrderID
	from [Order]
	where convert(varchar,OrderDate,112)=convert(varchar,getdate(),112)
	order by OrderDate desc

	--�p�G���ѨS������q��,�h��0001
	if @lastID is null
		set	@newID= @today+'0001' --���Ѫ��Ĥ@�i�q��s��
	else 
		set	@newID=cast(Cast(@lastID as bigint)+1 as varchar) --�_�h�����ѳ̫�@�i�q�檺���X�[1	
		
	return @newID

end


print dbo.getOrderID()

insert into [order] values(dbo.getOrderID(),getdate(), 'M00001' ,'�E�T�w','��������w��100��')

