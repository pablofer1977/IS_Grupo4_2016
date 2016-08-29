USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Perfiles_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Perfiles_Obtener]
GO

CREATE PROCEDURE Usuarios_Perfiles_Obtener (
	@pUsuario	VARCHAR(20) = NULL)
AS

BEGIN
	SELECT 	u.Usuario,
			u.Id_TipoPerfil,
			p.Perfil
	FROM 	tblUsuarios u INNER JOIN
			tblTiposPerfiles p ON u.Id_TipoPerfil = p.Id
	WHERE	u.Usuario = @pUsuario
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Perfiles_Obtener
TO Usuario_SGD
GO