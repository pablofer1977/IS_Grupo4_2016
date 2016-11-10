USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_DNI_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_DNI_Verificar]
GO

CREATE PROCEDURE Donantes_DNI_Verificar (
	@pAccion	INT,
	@pId		INT = NULL,
	@pDNI		VARCHAR(8) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonantes
		WHERE	DNI = @pDNI
	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonantes
		WHERE	DNI = @pDNI
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Donantes_DNI_Verificar
TO Rol_SGD
GO