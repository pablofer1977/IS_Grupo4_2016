USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Estado_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Estado_Verificar]
GO

CREATE PROCEDURE Usuarios_Estado_Verificar (
	@pUsuario	VARCHAR(20) = NULL,
	@pEstado	CHAR(1) = NULL)
AS

BEGIN 
	SELECT	COUNT(*) AS Cantidad
	FROM	tblUsuarios
	WHERE	Usuario = @pUsuario
	AND		Estado = @pEstado
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Estado_Verificar
TO Rol_SGD
GO