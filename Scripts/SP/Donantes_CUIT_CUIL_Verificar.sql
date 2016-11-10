USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_CUIT_CUIL_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_CUIT_CUIL_Verificar]
GO

CREATE PROCEDURE Donantes_CUIT_CUIL_Verificar (
	@pAccion	INT,
	@pId		INT = NULL,
	@pCUIL_CUIT	VARCHAR(11) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonantes
		WHERE	CUIL_CUIT = @pCUIL_CUIT
	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonantes
		WHERE	CUIL_CUIT = @pCUIL_CUIT
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Donantes_CUIT_CUIL_Verificar
TO Rol_SGD
GO