--alter �ק��ƪ�w�q

--�bProduct��ƪ��W�[�@��CateID�����
alter table [Product]
	add CateID nchar(2) not null


--�bProduct��ƪ��إ߻PCategory�����p
alter table [Product]
	add foreign key(CateID) references Category(CateID)

--�bOrderDetail��ƪ��إ߻PProduct�����p
alter table [OrderDetail]
	add foreign key(ProductID) references [Product](ProductID)
