--��s���
--update
--update�@���u���@�Ӹ�ƪ�
--���i�H�@����s1~N�����

update �f�B���q
set �f�B���q�W��='���a�f�B', �q��='(08)998-8777'
where �f�B���q�s��=20


update �Ȥ�
set �s���H¾��='�~�ȧU�z', �s���H='�p�^'
where �Ȥ�s��='KPPTR'

--------------------------------------------------
--��B�z�L100�i(�t)�H�W�q�檺���u,�������[�W�u�Ծġv��r

update ���u
set ����=����+', �Ծ�'
where ���u�s�� in (select ���u�s��
from �q����
group by ���u�s��
having count(*)>=100)



--��q���B�z�L�q�檺���u,�������[�W�u���Ρv��r
update ���u
set ����=����+', ����'
from �q���� as o right join ���u as e on o.���u�s��=e.���u�s��
where o.���u�s�� is null


