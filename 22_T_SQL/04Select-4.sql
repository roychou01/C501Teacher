--like�B��l(�ҽk�d��)
--%:�N��0~n�ӥ��N�r��
--_:�N��ӥ��N1�Ӧr��
--[]:��b�����̪����@�Ӧr

--�䦬�f�H�O�m����
select *
from �q����
where ���f�H like '��%'


select *
from �q����
where ���f�H like '��_'

select *
from �q����
where ���f�H like '��__'

select *
from �q����
where ���f�H like '��___'


--[]:��b�����̪����@�Ӧr
select *
from �q����
where ���f�H like '��%' or ���f�H like '�L%' or ���f�H like '��%' or ���f�H like '��%'
or ���f�H like '��%'


select *
from �q����
where ���f�H like '[���L������]%'

--��
select *
from �q����
where ���f�H like '[^���L������]%'

---------------------------------------------
--between...and...

select *
from ���~���
where �q��>=10 and �q��<=20


select *
from ���~���
where �q��  between 10 and 20


--in
select *
from �Ȥ�
where �s���H¾��='���ƪ�' or �s���H¾��='��o�H��' or �s���H¾��='�~��'

select *
from �Ȥ�
where �s���H¾�� in ('���ƪ�','��o�H��','�~��','aaaaa')
