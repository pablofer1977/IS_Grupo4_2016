use dbsSGD
go

truncate table tbldonantes
truncate table tbldonaciones
go

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblDonantes
	(
	Id int NOT NULL,
	FechaIng smalldatetime NOT NULL,
	Id_TipoDonante int NOT NULL,
	Apellido varchar(50) NULL,
	Nombre varchar(50) NULL,
	Razon_Social varchar(100) NULL,
	Direccion varchar(100) NULL,
	Localidad varchar(50) NULL,
	CP varchar(10) NULL,
	Id_Provincia int NULL,
	DNI varchar(8) NULL,
	CUIL_CUIT varchar(11) NULL,
	TE_Linea varchar(15) NULL,
	TE_Celular varchar(15) NULL,
	TE_Laboral varchar(15) NULL,
	EMail varchar(100) NULL,
	Comentarios varchar(250) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblDonantes SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblDonantes)
	 EXEC('INSERT INTO dbo.Tmp_tblDonantes (Id, FechaIng, Id_TipoDonante, Apellido, Nombre, Razon_Social, Direccion, Localidad, CP, Id_Provincia, DNI, CUIL_CUIT, TE_Linea, TE_Celular, TE_Laboral, EMail, Comentarios)
		SELECT Id, FechaIng, Id_TipoDonante, Apellido, Nombre, Razon_Social, Direccion, Localidad, CP, Id_Provincia, DNI, CUIL_CUIT, TE_Linea, TE_Celular, TE_Laboral, EMail, Comentarios FROM dbo.tblDonantes WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.tblDonantes
GO
EXECUTE sp_rename N'dbo.Tmp_tblDonantes', N'tblDonantes', 'OBJECT' 
GO
ALTER TABLE dbo.tblDonantes ADD CONSTRAINT
	PK_tblDonantes PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblDonaciones
	(
	Id int NOT NULL,
	Id_Donante int NOT NULL,
	FechaDon smalldatetime NOT NULL,
	Estado char(1) NOT NULL,
	FechaBaja smalldatetime NULL,
	Id_TipoDonacion int NOT NULL,
	Id_Tarjeta char(3) NULL,
	NroTarjeta varchar(16) NULL,
	Banco varchar(50) NULL,
	Vto varchar(10) NULL,
	CBU varchar(22) NULL,
	Monto decimal(10, 2) NOT NULL,
	Tiempo int NULL,
	Id_Campania int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblDonaciones SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblDonaciones)
	 EXEC('INSERT INTO dbo.Tmp_tblDonaciones (Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania)
		SELECT Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania FROM dbo.tblDonaciones WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.tblDonaciones
GO
EXECUTE sp_rename N'dbo.Tmp_tblDonaciones', N'tblDonaciones', 'OBJECT' 
GO
ALTER TABLE dbo.tblDonaciones ADD CONSTRAINT
	PK_tblDonaciones PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT

--SELECT TOP 1000 [Id],[FechaIng],[Id_TipoDonante],[Apellido],[Nombre],[Razon_Social],[Direccion]
--      ,[Localidad],[CP],[Id_Provincia],[DNI],[CUIL_CUIT]
--      ,[TE_Linea],[TE_Celular],[TE_Laboral],[EMail],[Comentarios]
--  FROM [dbsSGD].[dbo].[tblDonantes]

insert into tbldonaciones
select top 100 Id, IdDonante,FechaDon,Estado,FechaBaja,IdTipoDon,IdTarjetaPres,NroTarjeta,null,VtoTarjeta, cbu,importe,
case when TiempoDon is null then 24 else TiempoDon end,convert(int,right(convert(varchar, id),1))+1
from dbsSALES.dbo.tblDonaciones 
where (IdTarjetaPres in ('VIS','AME','MAS') or not cbu is null)
order by id desc

insert into tbldonantes
select d.id,FechaIng,1,Apellido,Nombre,null,Calle + ' ' + isnull(NroCalle,'') + ' ' + isnull(Piso,'') + ' ' + isnull(Dto,''),
l.Localidad , l.cp, d.IdProvincia,d.NroDocumento,d.CUIL,left(TE,15),left(TE2,15),left(TE3,15),EMail,null
from dbsSALES.dbo.tblDonantes d left join
dbssales.dbo.tblLocalidades l on d.IdLocalidad = l.Id left join
dbssales.dbo.tblProvincias p on d.IdProvincia = p.Id 
where d.id in (select d2.id_donante from tbldonaciones d2)


/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblDonaciones
	(
	Id int NOT NULL,
	Id_Donante int NOT NULL,
	FechaDon smalldatetime NOT NULL,
	Estado char(1) NOT NULL,
	FechaBaja smalldatetime NULL,
	Id_TipoDonacion int NOT NULL,
	Id_Tarjeta char(3) NULL,
	NroTarjeta varchar(16) NULL,
	Banco varchar(50) NULL,
	Vto varchar(10) NULL,
	CBU varchar(22) NULL,
	Monto decimal(10, 2) NOT NULL,
	Tiempo int NULL,
	Id_Campania int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblDonaciones SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblDonaciones)
	 EXEC('INSERT INTO dbo.Tmp_tblDonaciones (Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania)
		SELECT Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania FROM dbo.tblDonaciones WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.tblDonaciones
GO
EXECUTE sp_rename N'dbo.Tmp_tblDonaciones', N'tblDonaciones', 'OBJECT' 
GO
ALTER TABLE dbo.tblDonaciones ADD CONSTRAINT
	PK_tblDonaciones PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblDonaciones
	(
	Id int NOT NULL IDENTITY (1, 1),
	Id_Donante int NOT NULL,
	FechaDon smalldatetime NOT NULL,
	Estado char(1) NOT NULL,
	FechaBaja smalldatetime NULL,
	Id_TipoDonacion int NOT NULL,
	Id_Tarjeta char(3) NULL,
	NroTarjeta varchar(16) NULL,
	Banco varchar(50) NULL,
	Vto varchar(10) NULL,
	CBU varchar(22) NULL,
	Monto decimal(10, 2) NOT NULL,
	Tiempo int NULL,
	Id_Campania int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblDonaciones SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblDonaciones ON
GO
IF EXISTS(SELECT * FROM dbo.tblDonaciones)
	 EXEC('INSERT INTO dbo.Tmp_tblDonaciones (Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania)
		SELECT Id, Id_Donante, FechaDon, Estado, FechaBaja, Id_TipoDonacion, Id_Tarjeta, NroTarjeta, Banco, Vto, CBU, Monto, Tiempo, Id_Campania FROM dbo.tblDonaciones WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblDonaciones OFF
GO
DROP TABLE dbo.tblDonaciones
GO
EXECUTE sp_rename N'dbo.Tmp_tblDonaciones', N'tblDonaciones', 'OBJECT' 
GO
ALTER TABLE dbo.tblDonaciones ADD CONSTRAINT
	PK_tblDonaciones PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT