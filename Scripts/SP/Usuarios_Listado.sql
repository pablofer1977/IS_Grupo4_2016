USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Listado]
GO

CREATE PROCEDURE Usuarios_Listado (
	@pId			INT = NULL,
	@pUsuario		VARCHAR(50) = NULL,
	@pNombre		VARCHAR(250) = NULL,
	@pId_TipoPerfil	INT = NULL,
	@pEstado		CHAR(1) = NULL)
AS

BEGIN
	SELECT 	u.Id AS [Nro.],
			u.Usuario,
			u.Nombre,
			p.Perfil,
			CASE WHEN u.Estado = 'A' THEN 'Activo' WHEN u.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			u.FechaAlta AS [Fecha Alta],
			u.FechaBaja AS [Fecha Baja]
	FROM 	tblUsuarios u INNER JOIN
			tblTiposPerfiles p ON u.Id_TipoPerfil = p.Id 
	WHERE	(u.Id = @pId OR @pId IS NULL)
	AND		(u.Usuario LIKE @pUsuario  + '%' OR @pUsuario IS NULL)
	AND		(u.Nombre LIKE @pNombre  + '%' OR @pNombre IS NULL)
	AND		(u.Id_TipoPerfil = @pId_TipoPerfil OR @pId_TipoPerfil IS NULL)
	AND		(u.Estado = @pEstado OR @pEstado IS NULL)
	ORDER BY u.Id
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Listado
TO Usuario_SGD
GO