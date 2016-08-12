USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Modificar]
GO

CREATE PROCEDURE Usuarios_Modificar (
	@pId			INT = NULL,
	@pNombre		VARCHAR(100) = NULL,
	@pId_TipoPerfil	INT = NULL)
AS

BEGIN
	UPDATE	tblUsuarios
	SET		Nombre = @pNombre,
			Id_TipoPerfil = @pId_TipoPerfil
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Modificar
TO Usuario_SGD
GO