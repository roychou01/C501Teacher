--CTE�d��
--�p�� union ,�涰 intersect, �t��except
--��1�h
select ���u�s��,�m�W, 1 as ���h
from ���u
where �D�� is null  --�o����u���s���OE0001

union all

--��2�h
select ���u�s��,�m�W, 2 as ���h
from ���u
where �D�� ='E0001'  --���E0004�ME0013


union all

--��3�h
select ���u�s��,�m�W, 3 as ���h
from ���u
where �D�� in ('E0004','E0013')   --���E0005

union all
--��4�h
select ���u�s��,�m�W, 4 as ���h
from ���u
where �D�� in ('E0005')   --���E0002�ME0006�ME0007�ME0009
union all

--��5�h
select ���u�s��,�m�W, 5 as ���h
from ���u
where �D�� in ('E0002','E0006','E0007','E0009')     --���E0003�ME0008�ME0012�ME0014

union all

--��6�h
select ���u�s��,�m�W, 6 as ���h
from ���u
where �D�� in ('E0003','E0008','E0012','E0014')  --���6�h�N�S��������u,�]�����{�������I

-------------------------------------------------------------------------------------------------

--�l�d��
select �q�渹�X,���q�W��, �s���H
from 
(select o.�q�渹�X,c.���q�W��,c.�s���H,c.�q��, o.�q����,o.�n�f���,o.�e�f���, e.�m�W,
	d.�f�B���q�W��, o.���f�H,o.�e�f�覡
	from �q���� as o inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
	inner join ���u as e on o.���u�s��=e.���u�s��
	inner join �f�B���q as d on o.�e�f�覡=d.�f�B���q�s��) as myTable

--CTE�y�k
with myTable
as
(select o.�q�渹�X,c.���q�W��,c.�s���H,c.�q��, o.�q����,o.�n�f���,o.�e�f���, e.�m�W,
	d.�f�B���q�W��, o.���f�H,o.�e�f�覡
	from �q���� as o inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
	inner join ���u as e on o.���u�s��=e.���u�s��
	inner join �f�B���q as d on o.�e�f�覡=d.�f�B���q�s��
)

select �q�渹�X,���q�W��, �s���H from myTable

--------------------------------------------------------------------------------
--CTE���j
with getLevelTable
as
(
	select ���u�s��,�m�W, 1 as ���h
	from ���u
	where �D�� is null  --�o����u���s���OE0001
	union all
	select ���u.���u�s��,���u.�m�W, ���h+1 as ���h
	from ���u inner join getLevelTable on ���u.�D��=getLevelTable.���u�s��
)


select * from getLevelTable


--�N�W�CCTE�d�ߦ��إߦ��w�s�{��
create proc getLevelTable
as
begin
	with getLevelTable
	as
	(
		select ���u�s��,�m�W, 1 as ���h
		from ���u
		where �D�� is null  --�o����u���s���OE0001
		union all
		select ���u.���u�s��,���u.�m�W, ���h+1 as ���h
		from ���u inner join getLevelTable on ���u.�D��=getLevelTable.���u�s��
	)


	select * from getLevelTable

end



-------------------------------
exec getLevelTable
