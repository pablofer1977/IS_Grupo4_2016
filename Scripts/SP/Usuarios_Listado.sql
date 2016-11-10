USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Listado]
GO

CREATE PROCEDURE Usuarios_Listado (
	@pUsuario		VARCHAR(20) = NULL,
	@pNombre		VARCHAR(250) = NULL,
	@pId_TipoPerfil	INT = NULL,
	@pEstado		CHAR(1) = NULL)
AS

BEGIN
	SELECT 	u.Usuario,
			u.Nombre,
			u.Id_TipoPerfil,
			p.Perfil,
			u.Estado AS Id_Estado,
			CASE WHEN u.Estado = 'A' THEN 'Activo' WHEN u.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			u.FechaAlta,
			u.FechaBaja
	FROM 	tblUsuarios u INNER JOIN
			tblTiposPerfiles p ON u.Id_TipoPerfil = p.Id 
	WHERE	(u.Usuario LIKE @pUsuario  + '%' OR @pUsuario IS NULL)
	AND		(u.Nombre LIKE @pNombre  + '%' OR @pNombre IS NULL)
	AND		(u.Id_TipoPerfil = @pId_TipoPerfil OR @pId_TipoPerfil IS NULL)
	AND		(u.Estado = @pEstado OR @pEstado IS NULL)
	ORDER BY u.Usuario
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Listado
TO Rol_SGD
GO