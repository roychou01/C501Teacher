--�R�����
--Delete
--Delete�@���u���@�Ӹ�ƪ�
--���i�H�@���R��1~N�����

delete from �f�B���q
where �f�B���q�s�� = 14

--------------------------------------------------------------------
delete from ���u
where ���u�s�� in (select ���u�s��
from �q����
group by ���u�s��
having count(*)>=100)


delete ���u
from �q���� as o right join ���u as e on o.���u�s��=e.���u�s��
where o.���u�s�� is null
