--DDL Trigger
--insert update delete ==>DML
--Create  alter  drop ==> DDL


--我要把這個資料庫裡所有的 table 都設定成唯讀

create trigger readOnlyTable on database
for drop_table, alter_table
as
begin

	rollback

end


drop table 客戶2
-------------------------------

disable trigger readOnlyTable on database


enable trigger readOnlyTable on database


enable trigger getUpdateDataTable on 客戶



disable trigger getUpdateDataTable on 客戶
