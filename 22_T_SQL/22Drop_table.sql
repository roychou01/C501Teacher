--drop

drop table [Member]  --�o�̷|�o�����p���D�����~ (F.K �������)

--1. �R��Member�POrder���������p(�Ѱ� F.K �������)
alter table [Order]
	drop Constraint FK__Order__MemberID__3E52440B

--2. �R��[Member]��ƪ�
drop table [Member] 


alter table [Member]
	drop column Point
------------------------------------------------------

--�R����Ʈw
drop database MyStore
	


