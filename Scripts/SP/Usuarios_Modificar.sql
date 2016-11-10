USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Modificar]
GO

CREATE PROCEDURE Usuarios_Modificar (
	@pUsuario		VARCHAR(20) = NULL,
	@pNombre		VARCHAR(100) = NULL,
	@pId_TipoPerfil	INT = NULL)
AS

BEGIN
	UPDATE	tblUsuarios
	SET		Nombre = @pNombre,
			Id_TipoPerfil = @pId_TipoPerfil
	WHERE	Usuario = @pUsuario
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Modificar
TO Rol_SGD
GO