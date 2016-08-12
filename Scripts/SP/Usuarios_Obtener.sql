USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Obtener]
GO

CREATE PROCEDURE Usuarios_Obtener (
	@pId	INT = NULL)
AS

BEGIN
	SELECT 	u.Id,
			u.Usuario,
			u.Password,
			u.Nombre,
			u.Id_TipoPerfil,
			u.Estado,
			u.FechaAlta,
			u.FechaBaja
	FROM 	tblUsuarios u
	WHERE	u.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Obtener
TO Usuario_SGD
GO