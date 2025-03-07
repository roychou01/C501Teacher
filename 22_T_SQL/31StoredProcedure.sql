--�w�s�{�� Stored Procedure
--�N�q:�w���g�n���@�q�{��,���ݭn�ɦA���楦,�D�`�������
--��Ƴq�`�Φb�n���o�@�Ӧ^�ǭ�,�w�s�{�ǳq�`�u�O����@�q�{��


--�إߤ@�ӹw�s�{�Ǫ���
create procedure getOrderListWithOtherData
as
begin
	select o.�q�渹�X,c.���q�W��,c.�s���H,c.�q��, o.�q����,o.�n�f���,o.�e�f���, e.�m�W,
	d.�f�B���q�W��, o.���f�H,o.�e�f�覡
	from �q���� as o inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
	inner join ���u as e on o.���u�s��=e.���u�s��
	inner join �f�B���q as d on o.�e�f�覡=d.�f�B���q�s��
end 

----------------------------------
--�w�s�{�Ǫ�����
execute getOrderListWithOtherData
----------------------------------


--�إߤ@�Ӧ��Ѽƪ��w�s�{�Ǫ���
--�ǤJ�q�渹�X,�Y�i�d�߸ӭq����

create proc getOrderListWithOtherDataByOrderID
	@orderid char(5)
as
begin
	select o.�q�渹�X,c.���q�W��,c.�s���H,c.�q��, o.�q����,o.�n�f���,o.�e�f���, e.�m�W,
	d.�f�B���q�W��, o.���f�H,o.�e�f�覡
	from �q���� as o inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
	inner join ���u as e on o.���u�s��=e.���u�s��
	inner join �f�B���q as d on o.�e�f�覡=d.�f�B���q�s��
	where o.�q�渹�X=@orderid
end 



----------------------------------
--�w�s�{�Ǫ�����
exec getOrderListWithOtherDataByOrderID '10263'
----------------------------------

--execute�`�Ϊ��a��
create proc getTableList
	@tableName nvarchar(30)
as
begin
	exec('select * from '+ @tableName)
end


----------------------------------
--�w�s�{�Ǫ�����
exec getTableList '���~���'
----------------------------------