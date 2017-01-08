
CREATE TABLE UmaTabelaQualquer
(
	Id					int IDENTITY(1,1)		NOT NULL,
	Nome				nvarchar(50)			NULL		default '',
	
	Valor				float					NULL		default 0,
	ValorFloat			float					null		default 0,
	ValorDecimal		decimal(12,2)			null		default 0, 
	ValorNumerico		numeric(12,2)			null		default 0, 
	ValorReal			real					null		default 0,
	ValorDouble			double precision		null		default 0,
	ValorInt			integer					null		default 0,
	ValorTinyInt		tinyint					null		default 0,
	ValorBigInt			bigint					null		default 0,

	ValorGuid			UniqueIdentifier		null		default newid(),

	Observacao			nvarchar(max)			NULL,
	Arquivo				varbinary(max)			null,

	DataRevisao			datetime				NULL		default getdate(),
	DataEvento			datetime2				null		default getdate(),

	LoginUsuarioUltimaAlteracao varchar(20)		not null, 
	DataUltimaAlteracao	datetime				not null	default getdate(),

	CONSTRAINT PK_Tabela PRIMARY KEY CLUSTERED (Id)
)

GO


