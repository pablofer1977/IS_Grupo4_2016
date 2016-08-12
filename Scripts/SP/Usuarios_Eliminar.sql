USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Eliminar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Eliminar]
GO

CREATE PROCEDURE Usuarios_Eliminar (
	@pId	INT = NULL)
AS

BEGIN
	DELETE
	FROM	tblUsuarios
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Eliminar
TO Usuario_SGD
GO