--T-SQL �{���]�p
--�{�� = �t��k + ��Ƶ��c

--PL/SQL

print 'Hello World!!'

select 'Hello World!!' as ��� --���槹�����G�|�O�@��table

select tb1.*
from  (select 'Hello World!!' as col1) as tb1

--------------------------------------------------------
--�ܼ�
--1.�¶q���ܼ� 2.��ƪ���ܼ�

declare @MyName nvarchar(20) ='Jack Lee'

print @MyName
select @MyName
-------------------------------------
declare @Number int
set @Number=123
select @Number=456

print @Number
print @nuMBeR
--T-SQL �����j�p�g
-----------------------------

declare @EmpName nvarchar(20)

select @EmpName=�m�W
from ���u
where ���u�s��='E0007'


print '���u���m�W�s'+@EmpName
-------------------------------------------

declare @salary money=50000
print '�z���~���O'+ cast(@salary as varchar)

declare @birthday datetime ='2024-12-11'
print '�z���ͤ�O'+ convert(varchar,@birthday,111 )


declare @dDay datetime

select @dDay=�n�f���
from �q����
where �q�渹�X='10259'


print '���q�檺�n�f����O'+ convert(varchar,@dDay,111 )
-----------------------------------------------
--��ƪ���ܼ�
declare  @myTable table (
	name nvarchar(20),
	birthday datetime,
	tel varchar(20),
	note nvarchar(max)
)

insert into @myTable values('���p��','2024-12-11','07-8210171','�����ܥi�R')
insert into @myTable select �m�W,�X�ͤ��,�q�ܸ��X,���� from ���u

select * from @myTable








