USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Validaciones_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Validaciones_Listado]
GO

CREATE PROCEDURE DonantesImportacion_Validaciones_Listado (
	@pId	INT = NULL)
AS

BEGIN
	SELECT	tv.TipoValidacion,
			v.Validacion
	FROM	tblDonantesImportacionValidaciones v INNER JOIN
			tblTiposValidaciones tv ON tv.Id = v.Id_TipoValidacion
	WHERE	v.Id_Donante = @pId
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Validaciones_Listado
TO Rol_SGD
GO