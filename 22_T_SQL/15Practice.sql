--1. �иռg�@�X�֬d�ߡA�d�ߥX�q�ʤ�����b1996�~7��ë��w�e�f���q���u�տߦv��K�v�����q�椧�q�f���Ӹ�ơA
--�æC�X �q�渹�X�B���~���O�W�١B���~�W�١B���~�q�ʳ���B���~�q�ʼƶq�B���~�����p�p�B�Ȥ�s���B�Ȥ�W�١B
--���f�H�W�r�B�q�ʤ���B�B�z�q����u���m�W�B�f�B���q�B�����ӦW�� ����ƶ��ءA
--�䤤���~�����p�p�ХH�|�ˤ��J�p��ܾ�Ʀ�C


select o.�q�渹�X, pt.���O�W��, p.���~, od.���, od.�ƶq, round(od.���*od.�ƶq*(1-od.�馩),0)as ���~�����p�p,
cu.�Ȥ�s��, cu.���q�W��, o.���f�H, o.�q����, e.�m�W, c.�f�B���q�W��,s.������
from �q����� as od inner join �q���� as o on od.�q�渹�X=o.�q�渹�X
inner join �f�B���q as c on o.�e�f�覡=c.�f�B���q�s��
inner join ���~��� as p on p.���~�s��=od.���~�s��
inner join ���~���O as pt on p.���O�s��=pt.���O�s��
inner join �Ȥ� as cu on cu.�Ȥ�s��=o.�Ȥ�s��
inner join ���u as e on e.���u�s��=o.���u�s��
inner join ������ as s on s.�����ӽs��=p.�����ӽs��
where o.�q���� between '1996-07-01' and '1996-07-31' and c.�f�B���q�W��='�տߦv��K'



--2. �иռg�@�X�֬d�ߡA�d�߫Ȥ�u�s�s�Ȧ�v���~�өҭq�ʪ��Ҧ����~�A�òέp�X�U�ز��~���q�ʼƶq
--��X��߬��Ȥ�s���B���q�W�١B�p���H�B���~�W�١B�q�ʼƶq

select c.�Ȥ�s��,c.���q�W��, c.�s���H, p.���~, sum(od.�ƶq) as �q�ʼƶq
from ���~��� as p inner join �q����� as od on p.���~�s��=od.���~�s��
inner join �q���� as o on o.�q�渹�X=od.�q�渹�X
inner join �Ȥ� as c on c.�Ȥ�s��=o.�Ȥ�s��
where c.���q�W��='�s�s�Ȧ�'
group by c.�Ȥ�s��,c.���q�W��, c.�s���H, p.���~


--3. �ЧQ��exists�B��l�t�X�l�d�ߦ��A��X���ǫȤ�q���U�L�q��A�æC�X�Ȥ᪺�Ҧ����C
--(���i�Ψ�in�B��A�礣�i�ΦX�֬d�ߦ�) 
select c.*
from �Ȥ� as c 
where not  exists  (select * from �q���� as o where o.�Ȥ�s��=c.�Ȥ�s��)

	

--4. �ЧQ��in�B��l�t�X�l�d�ߦ��A�d�߭��ǭ��u���B�z�L�q��A�æC�X���u�����u�s���B�m�W�B¾�١B�����������X�B
--�������C(���i�Ψ�exists�B��A�礣�i�ΦX�֬d�ߦ�) 

select e.���u�s��, e.�m�W,e.¾��,e.�����������X,e.����
from ���u as e
where e.���u�s�� in ( select distinct ���u�s�� from �q����)


--5. �ЦX�֬d�߻P�l�d�ߨ�ؼg�k�A�C�X1998�~�שҦ��Q�q�ʹL�����~��ơA�æC�X���~���Ҧ����A�B�̲��~�s���Ѥp��j�ƧǡC
--(�g�X�֬d�߮ɤ��o�Υ���l�d�ߦ��A�g�l�d�߮ɤ��o�Υ���X�֬d�ߦ�)

select distinct p.*
from ���~��� as p inner join �q����� as od on p.���~�s��=od.���~�s��
inner join �q���� as o on o.�q�渹�X=od.�q�渹�X
where o.�q���� between '1998-1-1' and '1998-12-31'
order by p.���~�s��


select * from ���~���
where ���~�s�� in
(select ���~�s�� from �q�����
where �q�渹�X in 
(select �q�渹�X from �q���� where �q���� between '1998-1-1' and '1998-12-31'))
order by ���~�s��