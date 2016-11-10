USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Excel_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Excel_Agregar]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'lExcel_Agregar' AND ss.name = N'dbo')
DROP TYPE [dbo].[lExcel_Agregar]
GO

CREATE TYPE [dbo].[lExcel_Agregar] AS TABLE(
	[TipoDonante]	[varchar](50) NULL,
	[Apellido]		[varchar](50) NULL,
	[Nombre]		[varchar](50) NULL,
	[Razon_Social]	[varchar](100) NULL,
	[Direccion]		[varchar](100) NULL,
	[Localidad]		[varchar](50) NULL,
	[CP]			[varchar](10) NULL,
	[Provincia]		[varchar](20) NULL,
	[DNI]			[varchar](8) NULL,
	[CUIL_CUIT]		[varchar](11) NULL,
	[TE_Linea]		[varchar](15) NULL,
	[TE_Celular]	[varchar](15) NULL,
	[TE_Laboral]	[varchar](15) NULL,
	[EMail]			[varchar](150) NULL,
	[TipoDonacion]	[varchar](10) NULL,
	[Tarjeta]		[varchar](30) NULL,
	[NroTarjeta]	[varchar](16) NULL,
	[Banco]			[varchar](50) NULL,
	[Vto]			[varchar](10) NULL,
	[CBU]			[varchar](22) NULL,
	[Monto]			[varchar](15) NULL,
	[Tiempo]		[varchar](15) NULL,
	[Campania]		[varchar](50) NULL
)
GO

CREATE PROCEDURE DonantesImportacion_Excel_Agregar (
	@pListExcel_Agregar	lExcel_Agregar READONLY)
AS

BEGIN
	TRUNCATE TABLE tblDonantesImportacionValidaciones
	TRUNCATE TABLE tblDonantesImportacion
	
	INSERT INTO tblDonantesImportacion
	SELECT	t.Id AS Id_TipoDonante,
			l.TipoDonante,
			l.Apellido,
			l.Nombre,
			l.Razon_Social,
			l.Direccion,
			l.Localidad,
			l.CP,
			p.Id AS Id_Provincia,
			l.Provincia,
			l.DNI,
			l.CUIL_CUIT,
			l.TE_Linea,
			l.TE_Celular,
			l.TE_Laboral,
			l.EMail,
			t2.Id AS Id_TipoDonacion,
			l.TipoDonacion,
			i.Id AS Id_Tarjeta,
			l.Tarjeta,
			l.NroTarjeta,
			l.Banco,
			l.Vto,
			l.CBU,
			l.Monto,
			l.Tiempo,
			c.Id AS Id_Campania,
			l.Campania
	FROM	@pListExcel_Agregar l LEFT JOIN
			tblTiposDonantes t ON l.TipoDonante = t.TipoDonante LEFT JOIN
			tblTiposDonaciones t2 ON l.TipoDonacion = t2.TipoDonacion LEFT JOIN
			tblProvincias p ON l.Provincia = p.Provincia LEFT JOIN
			tblTarjetas i ON l.Tarjeta = i.Tarjeta LEFT JOIN
			tblCampanias c ON l.Campania = c.Campania
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Excel_Agregar
TO Rol_SGD
GO

GRANT CONTROL ON TYPE::[dbo].[lExcel_Agregar] TO [Rol_SGD]
GO