USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Agregar]
GO

CREATE PROCEDURE Usuarios_Agregar (
	@pUsuario		VARCHAR(20) = NULL,
	@pPassword		VARCHAR(500) = NULL,
	@pNombre		VARCHAR(100) = NULL,
	@pId_TipoPerfil	INT = NULL)
AS

BEGIN
	INSERT INTO tblUsuarios (Usuario, Password, Nombre, Id_TipoPerfil, Estado, FechaAlta, FechaBaja)
	VALUES (@pUsuario, @pPassword, @pNombre, @pId_TipoPerfil, 'A', GETDATE(), NULL)
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Agregar
TO Usuario_SGD
GO