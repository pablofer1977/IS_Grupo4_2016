USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Presentaciones_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Presentaciones_Agregar]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'lPresentaciones_Agregar' AND ss.name = N'dbo')
DROP TYPE [dbo].[lPresentaciones_Agregar]
GO

CREATE TYPE [dbo].[lPresentaciones_Agregar] AS TABLE(
	[Id]			[int] NULL,
	[Id_Donacion]	[int] NULL,
	[Id_Donante]	[int] NULL,
	[Monto]			[decimal](10, 2) NULL,
	[Nro]			[varchar](22) NULL,
	[CantPres]		[int] NULL
)
GO

CREATE PROCEDURE Presentaciones_Agregar (
	@pId_TipoPresentacion	INT = NULL,
	@pId_Tarjeta			CHAR(3) = NULL,
	@pMes					INT = NULL,
	@pAnio					INT = NULL,
	@pListPresentaciones_Agregar	lPresentaciones_Agregar READONLY)
AS
	DECLARE @Id_Presentacion INT
BEGIN 
	INSERT INTO	tblPresentaciones (	FechaPresentacion,
									Mes,
									Anio,
									Id_TipoPresentacion,
									Id_Tarjeta)
	VALUES (GETDATE(),
			@pMes,
			@pAnio,
			@pId_TipoPresentacion,
			@pId_Tarjeta)

	SET @Id_Presentacion = SCOPE_IDENTITY()

	INSERT INTO tblPresentacionesDetalles
	SELECT	@Id_Presentacion,
			l.Id_Donante,
			l.Id_Donacion,
			NULL
	FROM	@pListPresentaciones_Agregar l
END
GO
GRANT EXECUTE
  ON dbo.Presentaciones_Agregar
TO Rol_SGD
GO

GRANT CONTROL ON TYPE::[dbo].[lPresentaciones_Agregar] TO [Rol_SGD]
GO