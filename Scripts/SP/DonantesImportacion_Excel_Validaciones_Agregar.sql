USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Excel_Validaciones_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Excel_Validaciones_Agregar]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'lExcel_Validaciones_Agregar' AND ss.name = N'dbo')
DROP TYPE [dbo].[lExcel_Validaciones_Agregar]
GO

CREATE TYPE [dbo].[lExcel_Validaciones_Agregar] AS TABLE(
	[Id_Donante]		[int] NULL,
	[Id_TipoValidacion]	[int] NULL,
	[Validacion]		[varchar](50) NULL
)
GO

CREATE PROCEDURE DonantesImportacion_Excel_Validaciones_Agregar (
	@pListExcel_Validaciones_Agregar	lExcel_Validaciones_Agregar READONLY)
AS

BEGIN
	TRUNCATE TABLE tblDonantesImportacionValidaciones
	
	INSERT INTO tblDonantesImportacionValidaciones
	SELECT	l.Id_Donante,
			l.Id_TipoValidacion,
			l.Validacion
	FROM	@pListExcel_Validaciones_Agregar l
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Excel_Validaciones_Agregar
TO Usuario_SGD
GO

GRANT CONTROL ON TYPE::[dbo].[lExcel_Validaciones_Agregar] TO [Usuario_SGD]
GO