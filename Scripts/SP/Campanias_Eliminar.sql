USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Eliminar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Eliminar]
GO

CREATE PROCEDURE Campanias_Eliminar (
	@pId	INT = NULL)
AS

BEGIN
	DELETE
	FROM	tblCampanias
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Eliminar
TO Rol_SGD
GO