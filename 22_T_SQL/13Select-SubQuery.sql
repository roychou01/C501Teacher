--�l�d��(Sub Query)
select * from �q����
where �Ȥ�s��='ERNSH'

select �Ȥ�s�� from �Ȥ�
where ���q�W��='�j�ث��x�_'

--�եX�u�F���Ȧ�v�Ȥ᪺�Ҧ��q�����
select * from �q����
where �Ȥ�s�� = (select �Ȥ�s�� from �Ȥ�
where ���q�W��='�F���Ȧ�')


--�եX�Y����u�B�z���Ҧ��q�����
select * from �q����
where ���u�s��=( select ���u�s�� from ���u where �m�W='�B�Ѥ�' )


--�X�֬d�ߪ��g�k
select o.* 
from �q���� as o  inner join �Ȥ� as c  on o.�Ȥ�s��=c.�Ȥ�s��
where c.���q�W��='�F���Ȧ�'


select o.* 
from �q���� as o inner join  ���u as e on o.���u�s��=e.���u�s��
where e.�m�W='�B�Ѥ�'

------------------------------------------------------------------
--�Ьd�߭��ǰӫ~������j������ӫ~���������
--�l�d��

select avg(�q��)
from ���~���

select *
from ���~���
where �q��>(select avg(�q��)
from ���~���)

--�X�֬d�ߪ��g�k
select p.���~�s��, p.���~, p.�q��, avg(p2.�q��)
from ���~��� as p inner join ���~��� as p2 on p.���~�s�� != p2.���~�s��
group by p.���~�s��, p.���~, p.�q��
having p.�q��>avg(p2.�q��)


--�۵M�X��
select p.���~�s��, p.���~, p.�q��, avg(p2.�q��)
from ���~��� as p, ���~��� as p2 
group by p.���~�s��, p.���~, p.�q��
having p.�q��>avg(p2.�q��)


--cross join (���d��n�B��)
select p.���~�s��, p.���~, p.�q��, avg(p2.�q��)
from ���~��� as p cross join ���~��� as p2
group by p.���~�s��, p.���~, p.�q��
having p.�q��>avg(p2.�q��)

-----------------------------------------
--���ǫȤ�R�L�ަ�
select * from �Ȥ�
where �Ȥ�s�� in (select �Ȥ�s�� from �q����
where �q�渹�X in (select �q�渹�X from �q�����
where ���~�s�� in (select ���~�s�� from ���~���
where ���~='�ަ�')))

select distinct c.*
from �Ȥ� as c inner join �q���� as o on c.�Ȥ�s��=o.�Ȥ�s��
inner join �q����� as od on o.�q�渹�X=od.�q�渹�X
inner join ���~��� as p on od.���~�s��=p.���~�s��
where p.���~='�ަ�'


--���ǭ��u�B�z�L�Ȥ�W�١u���H�귽�v���q��

select * from ���u
where ���u�s�� in (select distinct ���u�s��
from �q����
where �Ȥ�s�� in (select �Ȥ�s��
from �Ȥ�
where ���q�W��='���H�귽'))


--in �B��l
select *
from �Ȥ� 
where �Ȥ�s�� in (select distinct �Ȥ�s�� from �q����)

--exists�B��l
select *
from �Ȥ� as c
where exists ( select * from �q���� as o where  c.�Ȥ�s��=o.�Ȥ�s�� )



















