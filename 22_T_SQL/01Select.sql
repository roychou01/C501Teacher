--SQL_DML
--select
--insert
--update
--delete
--------------------------------------------------------

use �_��
go
--�򥻬d�ߦ�
select * from �Ȥ�

select �Ȥ�s��, ���q�W��, �s���H, �s���H¾�� from �Ȥ�
----------------------------------------------------------

--���O�W
select �Ȥ�s��, ���q�W�� as �Ȥ�W��, �s���H¾��+�s���H as ���f, �l���ϸ�+�a�} as �a�}
from �Ȥ� 

-----------------------------------------------------------
--�ƭȹB��

select �q�渹�X,���~�s��, ��� as ���, �ƶq as �ʶR�q, ���*�ƶq*(1-�馩) as �p�p
from �q�����

------------------------------------------------
--����ɶ�
select ���u�s��,�m�W,�X�ͤ��,  datediff( year  , �X�ͤ��   ,   getdate() )  as �~��
--,datediff( MONTH  , �X�ͤ��   ,   getdate() ),datediff( DAY  , �X�ͤ��   ,   getdate() )
from ���u

------------------------------------------------
select ���u�s��,�m�W
,datediff( year  , �X�ͤ��   ,   getdate() )  as �~��
,datediff( year  , ���Τ��   ,   getdate() )  as �~��
,datediff( year  , �X�ͤ��   ,  ���Τ��)  as ��¾�ɦ~��
from ���u

 
 