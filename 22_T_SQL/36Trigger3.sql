select * from �Ȥ�


insert into �Ȥ�
values('AAAAA',	'�G�t��~�������q'	,'���p�j'	,'�~��',	'�x�_�������F���|�q32��',	'12209',	'(02) 968-9652',	'(02) 968-9651')


insert into �Ȥ�
values('AAAAB',	'�G�t��~�������q'	,'���p�j'	,'�~��',	'�x�_�������F���|�q32��',	'12209',	'(02) 968-9652',	'(02) 968-9651')


--�s�W�Ȥ��Ʈ�,�Y�ӫȤ��Ƥw�s�b,�h�i���ƭק�(insert �� update)

--instead trigger

Create trigger add_CustermerCheck on �Ȥ�
instead of insert
as
begin
	--�p�GPK�s�b,���ק���,�_�h���s�W���

	--�p�GPK�s�b
	declare @CID nchar(5) =''
	select @CID=�Ȥ�s�� from �Ȥ� where �Ȥ�s��=(select �Ȥ�s�� from inserted)

	if  @CID = ''  --�p�G�S����쭫�ƪ�PK
	begin
		--���s�W���
		insert into �Ȥ�
		select * from inserted
	end
	else
	begin
		--���ק���

		update �Ȥ�
		set ���q�W��=inserted.���q�W��,�s���H=inserted.�s���H,�s���H¾��=inserted.�s���H¾��,
		�a�}=inserted.�a�},�l���ϸ�=inserted.�l���ϸ�,�q��=inserted.�q��,
		�ǯu�q��=inserted.�ǯu�q��
		from �Ȥ� inner join inserted on �Ȥ�.�Ȥ�s��=inserted.�Ȥ�s��
	end

end



--����

insert into �Ȥ�
values('AAAAC',	'2342342342342344234234'	,'bb'	,'123',	'asdfdsf32��',	'12209',	'(02) 968-9652',	'(02) 968-9651')

