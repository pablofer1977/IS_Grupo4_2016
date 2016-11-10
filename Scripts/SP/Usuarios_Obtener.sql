USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Obtener]
GO

CREATE PROCEDURE Usuarios_Obtener (
	@pUsuario	VARCHAR(20) = NULL)
AS

BEGIN
	SELECT 	u.Usuario,
			u.Password,
			u.Nombre,
			u.Id_TipoPerfil,
			u.Estado AS Id_Estado,
			CASE WHEN u.Estado = 'A' THEN 'Activo' WHEN u.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			u.FechaAlta,
			u.FechaBaja
	FROM 	tblUsuarios u
	WHERE	u.Usuario = @pUsuario
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Obtener
TO Rol_SGD
GO