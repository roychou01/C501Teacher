--��ƫ��A�P�ഫ
--cast()
select pt.���O�s��, pt.���O�W��,  cast( count(*) as varchar   ) +'��' as ���~�ƶq
from ���~��� as p inner join ���~���O as pt on p.���O�s��=pt.���O�s��
group by pt.���O�s��, pt.���O�W��

--------------------------------------------------------------
--convert()
select  convert( varchar , �q����, 111  ) as �q����, count(*) as �q���
from �q����
group by �q����



select  iif( �e�f��� is null  , '�|���X�f'   , convert( varchar ,�e�f���, 111  )  ) as �e�f��� , count(*) as �q���
from �q����
group by �e�f���


--isnull()
select isnull( convert( varchar , �e�f���, 111  ) , '�|���X�f') as �e�f���, count(*) as �q���
from �q����
group by �e�f���