--�y�{����
--case
select ���u�s��,�m�W,iif(�ʧO=0,'�p�j','����'),�X�ͤ�� from ���u

--²��case
select ���u�s��,�m�W,
	case �ʧO
		when 0 then '�p�j'
		when 1 then '����'
	end as �ٿ�
,�X�ͤ�� from ���u

go
-----------------------
--�j�Mcase
declare @gender int, @result nvarchar(5)

set @gender=4

set @result=
case
	when @gender=1 then '����'
	when @gender=0 then '�p�j'
	else '����'
end

print @result
go
---------------------------
--�p�G����120�H�W����140�����R�b��
--140�����H�W�R����
--120�����H�U�K��

declare @height int, @result nvarchar(5)
set @height = 150

set @result=
case
	when @height>=140 then '����'
	when @height<120 then '�K��'
	else '�b��'
end
print @result


