--�p�G�q��ӫ~�q�ʼƶq�j��Ӱӫ~���w�s�q�ΰ���j��q��,�h�q�ʥ���
--�Y�q�ʦ��\,�h�����q�ʪ��w�s�q
--�Ȥ�b�U�q���,�|�ʥΨ�T�i��ƪ�-�q���ơB�q����ӡB���~���


select * from ���~���


--�s�W�@�i�q�ʳ�
--insert ��Ӹ�ƪ� - �q���ơB�q�����, ��s1�i��ƪ� - ���~���

create trigger checkOrderQtyPrice on �q�����
after insert
as
begin
	--�p�G�q��ӫ~�q�ʼƶq�j��Ӱӫ~���w�s�q�ΰ���j��q��,�h�q�ʥ���
	--�Y�q�ʦ��\,�h�����q�ʪ��w�s�q

	declare @ProductPrice money, @ProductQty int, @ProudctID int, 
	@OrderPrice money,@OrderQty int

	select  @ProudctID=���~�s��,@OrderPrice=���, @OrderQty=�ƶq from inserted


	select @ProudctID=���~�s��,  @ProductPrice=�q��,@ProductQty=�w�s�q from ���~��� 
	where ���~�s��=@ProudctID

	

	if @OrderPrice>@ProductPrice
		rollback
	else if @OrderQty>@ProductQty
		rollback
	else
	begin
		update ���~���
		set �w�s�q=�w�s�q-@OrderQty
		where ���~�s��=@ProudctID

	end

end

insert into �q����� values('10263',1,18,38,0)

select * from �q����� where �q�渹�X='10263'

----------------------------------------------------
