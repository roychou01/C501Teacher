--新增資料
--insert into
--insert一次只能對一個資料表做
--但可以一次新增1~N筆資料

--insert into 資料表(欄位1, 欄位2, 欄位3, ....) values(值1, 值2, 值3, ....)

insert into 貨運公司(貨運公司名稱, 電話) values('大榮貨運', '(07)888-9999')

--一次在同一個資料表中新增多筆資料
insert into 貨運公司(貨運公司名稱, 電話) 
values('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999'),
('大榮貨運', '(07)888-9999')

--我只要填貨運公司名稱沒有電話
insert into 貨運公司(貨運公司名稱) values('小榮貨運')--會報錯

insert into 貨運公司(貨運公司名稱,電話) values('小榮貨運','')--使用空字串

--省略欄位名稱的寫法
--值的順序要照原資料表的欄位順序
--每一個欄位都要給值
insert into 客戶 values('KPPTR','高屏澎東分署','小美','櫃?人員','高雄市前鎮區凱旋四路105號','806','07-8210171', NULL)

insert into 貨運公司 values(21,'中榮貨運','07-88888888')--會報錯,有identity欄位時不得省略欄位
--------------------------------------------
--我想複製客戶資料表成為另一個資料表並儲存
--select...into....(此指令僅能對不存在的資料表做新增)
--複製員工資料表,另存為「員工2」資料表

select * into 員工2  from 員工

--複製客戶資料表,另存為「客戶2」資料表

select * into 客戶2  from 客戶


--insert into...select....(此指令僅能對已存在的資料表做新增)
insert into 員工2
select * from 員工

