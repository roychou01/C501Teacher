select * from 客戶


insert into 客戶
values('AAAAA',	'二川實業有限公司'	,'陳小姐'	,'業務',	'台北市忠孝東路四段32號',	'12209',	'(02) 968-9652',	'(02) 968-9651')


insert into 客戶
values('AAAAB',	'二川實業有限公司'	,'陳小姐'	,'業務',	'台北市忠孝東路四段32號',	'12209',	'(02) 968-9652',	'(02) 968-9651')


--新增客戶資料時,若該客戶資料已存在,則進行資料修改(insert → update)

--instead trigger

Create trigger add_CustermerCheck on 客戶
instead of insert
as
begin
	--如果PK存在,做修改資料,否則做新增資料

	--如果PK存在
	declare @CID nchar(5) =''
	select @CID=客戶編號 from 客戶 where 客戶編號=(select 客戶編號 from inserted)

	if  @CID = ''  --如果沒有找到重複的PK
	begin
		--做新增資料
		insert into 客戶
		select * from inserted
	end
	else
	begin
		--做修改資料

		update 客戶
		set 公司名稱=inserted.公司名稱,連絡人=inserted.連絡人,連絡人職稱=inserted.連絡人職稱,
		地址=inserted.地址,郵遞區號=inserted.郵遞區號,電話=inserted.電話,
		傳真電話=inserted.傳真電話
		from 客戶 inner join inserted on 客戶.客戶編號=inserted.客戶編號
	end

end



--測試

insert into 客戶
values('AAAAC',	'2342342342342344234234'	,'bb'	,'123',	'asdfdsf32號',	'12209',	'(02) 968-9652',	'(02) 968-9651')

