--��ƿz��
select *
from �Ȥ�
where �s���H¾�� = '���ƪ�'

select *
from �Ȥ�
where ���q�W�� = '���֧�'

select *
from �Ȥ�
where �Ȥ�s�� = 'DUMON'


--�d1994�~�H���¾�����u
select *
from ���u
where ���Τ�� >= '1994-1-1'
--where year(���Τ��) >= '1994'
--where ���Τ�� >= '1994'


--�d�߲��~�w�s�q��0�B���U�[�����
select *
from ���~���
where �w�s�q=0  and  �w�U�[=0


--�d�߲��~�w���s�q�p��10�����
select *
from ���~���
where �w���s�q<10


--�Ьd�߭��ǲ��~���w�s�q�C��w���s�q
select *
from ���~���
where �w�s�q<�w���s�q

--�Ьd�߭��ǲ��~�ݭn����
select *
from ���~���
where �w�s�q+�w�q�ʶq < �w���s�q


--�Ч�X �|���X�f ���q��
select *
from �q����
where �e�f��� is null



