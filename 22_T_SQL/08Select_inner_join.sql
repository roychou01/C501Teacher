

select *
from �q�����


select *
from ���~���


select *
from ���~���O

----------------------
--inner join �X�֬d�ߨ��k
select �q�����.�q�渹�X, �q�����.���~�s��, ���~���.���~, �q�����.���,�q�����.�ƶq,�q�����.�馩
from �q����� inner join ���~��� on �q�����.���~�s��=���~���.���~�s��


--�Q�ΧO�W�Y�u DML
select od.�q�渹�X, od.���~�s��, p.���~, od.���,od.�ƶq,od.�馩
from �q����� as od inner join ���~��� as p on od.���~�s��=p.���~�s��


--�[�J��Q�����(��N�B��)
select od.�q�渹�X,  od.���~�s��, p.���~, od.���, p.�q��, p.�q��-od.��� as ����Q,  
(p.�q��-od.���)*od.�ƶq as ��Q,(p.�q��-od.���)*od.�ƶq*(1-od.�馩) as �b�Q,  od.�ƶq,od.�馩
from �q����� as od inner join ���~��� as p on od.���~�s��=p.���~�s��


--�X�ֲ��~���O��ƪ���o���O�W��
select od.�q�渹�X, p.���O�s��,  pt.���O�W��  ,od.���~�s��, p.���~, od.���, p.�q��, p.�q��-od.��� as ����Q,  
(p.�q��-od.���)*od.�ƶq as ��Q,(p.�q��-od.���)*od.�ƶq*(1-od.�馩) as �b�Q,     od.�ƶq,od.�馩
from �q����� as od inner join ���~��� as p on od.���~�s��=p.���~�s��
inner join ���~���O as pt on pt.���O�s��=p.���O�s��

------------------------------------------------------------------------

select *
from �q����� as od
inner join �q���� as o on od.�q�渹�X=o.�q�渹�X
inner join ���~��� as p on od.���~�s��=p.���~�s��
inner join ������ as sp on sp.�����ӽs��=p.�����ӽs��
inner join ���~���O as pt on pt.���O�s��=p.���O�s��
inner join ���u as e on e.���u�s��=o.���u�s��
inner join �Ȥ� as c on c.�Ȥ�s��=o.�Ȥ�s��
inner join �f�B���q as ca on ca.�f�B���q�s��=o.�e�f�覡
--------------------------------------------------------------
-------------------------------------------------------------
--�έp�C��Ȥ᪺�U�榸��
--�ЦC�X �Ȥ�s��, �Ȥ�W��, �s���H, �s���H¾��, �U�榸��

select o.�Ȥ�s��, c.���q�W�� as �Ȥ�W��, c.�s���H, c.�s���H¾��  ,count(*) as �U�榸��
from �q���� as o inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
group by o.�Ȥ�s��, c.���q�W��, c.�s���H, c.�s���H¾��


--��X���O�`�B >=3�U�����Ȥ�
--�C�X �Ȥ�s��, �Ȥ�W��, �s���H, �s���H¾��, �U�榸��, ���O�`�B, �����P�O�B
--�åH ���O�`�B ����Ƨ�,�Y���O�`�B�ۦP�h�H �U�榸�� ����Ƨ�

select o.�Ȥ�s��, c.���q�W�� as �Ȥ�W��, c.�s���H, c.�s���H¾��  ,count(*) as �U�榸��,
round(sum(od.���*od.�ƶq*(1-od.�馩)),0) as ���O�`�B, round(sum(od.���*od.�ƶq*(1-od.�馩))/count(*),0) as �����P�O�B
from �q���� as o 
inner join �Ȥ� as c on o.�Ȥ�s��=c.�Ȥ�s��
inner join �q����� as od on o.�q�渹�X=od.�q�渹�X
group by o.�Ȥ�s��, c.���q�W��, c.�s���H, c.�s���H¾��
having sum(od.���*od.�ƶq*(1-od.�馩)) >=30000
order by ���O�`�B desc, �U�榸�� desc

-------------------------------------------

select o.���u�s��,e.�m�W, DATEDIFF( year , e.���Τ�� , getdate() ) as �~�� ,  count(*) as �B�z�q���,
count(*) / DATEDIFF( year , e.���Τ�� , getdate() ) as �C�~�����B�z�q���
from �q���� as o inner join ���u as e on o.���u�s��=e.���u�s��
group by o.���u�s��,e.�m�W,e.���Τ��
order by �B�z�q��� desc, �~��



