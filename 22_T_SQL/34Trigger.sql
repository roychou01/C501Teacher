--Ĳ�o�{�� Trigger
--�P�w�s�{�Ǥ@�ˬO�@�ӹw���g�n���{��
--�����L�k�����I�s����A�ӬO�b�Y�Ӯɾ��I�|�ۤvĲ�o����
--�@��O�Φb��Y�Ӹ�ƪ�Inert�BUpdate�BDelete ����i��Ĳ�o

--�b����Insert�BUpdate�BDelete�o�T�ط|���Ƴy�����ܪ�DML��
--�q����즨�\commit�A�����|�g�L�@�s���K���ˬd�A�u�O�ڭ̬ݤ����Ӥw


--�إ߳f�B���q��ƪ�Trigger,�Ψ�Ū�XInserted
create trigger getInsertedTable on �f�B���q
after insert
as
begin
	
	select * from inserted

end


--����s�W����

--���\Ĳ�oTrigger
insert into �f�B���q(�f�B���q�W��, �q��) 
values('¾�V���߳f�B', '(07)8210171')

--�|�]���Jnull�ȳQnot null�W�h�פU,�]�����|Ĳ�oTrigger
insert into �f�B���q(�f�B���q�W��, �q��) 
values('¾�V���߳f�B2', null)

-------------------------------------------------------------------------------------

create trigger getUpdateDataTable on �Ȥ�
after update
as
begin
	select * from inserted
	select * from deleted

end



update �Ȥ�
set �s���H='�L�p�j' ,�s���H¾��='�Ʋz'
where �Ȥ�s��='ALFKI'