--�y�{����
--if/else

--�p�G����120�H�W����140�����R�b��
--140�����H�W�R����
--120�����H�U�K��


declare @height int
set @height = 130


if @height>=140
begin
	print '����'
end
else if @height>=120
	print '�b��'
else
	print '�K��'


