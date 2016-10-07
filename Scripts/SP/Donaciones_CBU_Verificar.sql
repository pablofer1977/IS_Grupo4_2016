USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_CBU_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_CBU_Verificar]
GO

CREATE PROCEDURE Donaciones_CBU_Verificar (
	@pAccion	INT,
	@pId		INT = NULL,
	@pCBU		VARCHAR(22) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonaciones
		WHERE	CBU = @pCBU
	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonaciones
		WHERE	CBU = @pCBU
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_CBU_Verificar
TO Usuario_SGD
GO