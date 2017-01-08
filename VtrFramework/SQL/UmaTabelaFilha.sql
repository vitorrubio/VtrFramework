create table UmaTabelaFilha
(

	Id int not null identity(1,1),
	IdUmaTabelaQualquer int,
	Nome varchar(20),

	LoginUsuarioUltimaAlteracao varchar(20)		not null, 
	DataUltimaAlteracao	datetime				not null	default getdate(),

	constraint Pk_UmaTabelaFilha primary key (Id),
	constraint Fk_UmaTabelaFilha_UmaTabelaQualquer foreign key (IdUmaTabelaQualquer) references UmaTabelaQualquer(Id)

)