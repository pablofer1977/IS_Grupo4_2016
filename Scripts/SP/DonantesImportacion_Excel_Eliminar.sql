USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Excel_Eliminar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Excel_Eliminar]
GO

CREATE PROCEDURE DonantesImportacion_Excel_Eliminar
AS

BEGIN
	TRUNCATE TABLE tblDonantesImportacionValidaciones
	TRUNCATE TABLE tblDonantesImportacion
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Excel_Eliminar
TO Rol_SGD
GO