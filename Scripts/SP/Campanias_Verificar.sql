USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Verificar]
GO

CREATE PROCEDURE Campanias_Verificar (
	@pAccion	INT,
	@pId		INT = NULL,
	@pCampania	VARCHAR(50) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblCampanias
		WHERE	Campania = @pCampania

	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblCampanias
		WHERE	Campania = @pCampania
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Verificar
TO Usuario_SGD
GO