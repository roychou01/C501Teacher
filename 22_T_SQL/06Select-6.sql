--group by

select distinct ¾��
from ���u


select ¾��
from ���u
group by ¾��



select distinct �s���H¾��
from �Ȥ�


select �s���H¾��
from �Ȥ�
group by �s���H¾��
--------------------------------------
--�έp���u��Ƥ��C�@��¾�٦U���h�֤H

select distinct ¾��
from ���u

select ¾��
from ���u
group by ¾��

select count(*)
from ���u

select ¾��, count(*) as ���u�H��
from ���u
group by ¾��



select �s���H¾��, COUNT(*) as �H��
from �Ȥ�
group by �s���H¾��


--�C�i�q��q�ʤF�X�ذӫ~(�q�渹�X�b�q����Ӥ��X�{������)
--�q��s��,�X�ذӫ~
select �q�渹�X,count(*) as �X�ذӫ~
from �q�����
group by �q�渹�X

--�C�i�q��q�ʪ��ӫ~�`�q
select �q�渹�X, sum(�ƶq) as �ӫ~�q�ʶq
from �q�����
group by �q�渹�X


--�C�i�q�檺�`�B

select �q�渹�X,���~�s��, ���*�ƶq*(1-�馩) as �p�p
from �q�����

select �q�渹�X, round(  sum(���*�ƶq*(1-�馩)) , 2  ) as �q���`���B
from �q�����
group by �q�渹�X



--�C�X�q���`�B�̰����e�Q�����
select top 10 with ties �q�渹�X, round(  sum(���*�ƶq*(1-�馩)) , 2  ) as �q���`���B
from �q�����
group by �q�渹�X
order by �q���`���B desc

---------------------------------------------------------------------
--�C�@��Ȥ�U�榸��
select �Ȥ�s��, COUNT(*) as �U�榸��
from �q����
group by �Ȥ�s��
order by �U�榸�� desc


--���ǫȤ�U��W�L10��
--having
select �Ȥ�s��, COUNT(*) as �U�榸��
from �q����
group by �Ȥ�s��
having  COUNT(*) >10
order by �U�榸�� desc



--�έp�C�@����u�B�z�q�檺����
select ���u�s��, COUNT(*) as �B�z����
from �q����
group by ���u�s��
order by �B�z���� desc


--�έp�C�@����u�B�z�C�@��Ȥ᪺�q�檺����
select ���u�s��, �Ȥ�s��, count(*)
from �q����
group by ���u�s��, �Ȥ�s��
order by ���u�s��


-----------------------------------------
--��X�e10�W���P������ӫ~(�q�̦h)
select top 10 with ties ���~�s��,sum(�ƶq) as �P��q
from �q�����
group by ���~�s��
order by �P��q desc



--��X�e10�W���P������ӫ~(��~�B)
select top 10 with ties ���~�s��, round(sum(�ƶq*���*(1-�馩)),0) as ��~�B
from �q�����
group by ���~�s��
order by ��~�B desc


--���g����
--select 
--from
--where
--group by 
--having
--order by

--���涶��
--from
--where
--group by 
--having
--select
--order by

