USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Password_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Password_Verificar]
GO

CREATE PROCEDURE Usuarios_Password_Verificar (
	@pUsuario	VARCHAR(20) = NULL,
	@pPassword	VARCHAR(50) = NULL)
AS

BEGIN 
	SELECT	COUNT(*) AS Cantidad
	FROM	tblUsuarios
	WHERE	Usuario = @pUsuario COLLATE SQL_Latin1_General_CP1_CS_AS
	AND		Password = @pPassword COLLATE SQL_Latin1_General_CP1_CS_AS
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Password_Verificar
TO Rol_SGD
GO