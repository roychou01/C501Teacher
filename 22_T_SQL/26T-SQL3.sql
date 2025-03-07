--流程控制
--case
select 員工編號,姓名,iif(性別=0,'小姐','先生'),出生日期 from 員工

--簡單case
select 員工編號,姓名,
	case 性別
		when 0 then '小姐'
		when 1 then '先生'
	end as 稱謂
,出生日期 from 員工

go
-----------------------
--搜尋case
declare @gender int, @result nvarchar(5)

set @gender=4

set @result=
case
	when @gender=1 then '先生'
	when @gender=0 then '小姐'
	else '未知'
end

print @result
go
---------------------------
--如果身高120以上未滿140公分買半票
--140公分以上買全票
--120公分以下免票

declare @height int, @result nvarchar(5)
set @height = 150

set @result=
case
	when @height>=140 then '全票'
	when @height<120 then '免票'
	else '半票'
end
print @result


