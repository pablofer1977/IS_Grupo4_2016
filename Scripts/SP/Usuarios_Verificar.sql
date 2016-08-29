USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Verificar]
GO

CREATE PROCEDURE Usuarios_Verificar (
	@pAccion	INT,
	@pUsuario	VARCHAR(20) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblUsuarios
		WHERE	Usuario = @pUsuario

	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblUsuarios
		WHERE	Usuario = @pUsuario
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Verificar
TO Usuario_SGD
GO