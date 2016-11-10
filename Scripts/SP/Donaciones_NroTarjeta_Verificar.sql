USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_NroTarjeta_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_NroTarjeta_Verificar]
GO

CREATE PROCEDURE Donaciones_NroTarjeta_Verificar (
	@pAccion		INT,
	@pId			INT = NULL,
	@pNroTarjeta	VARCHAR(16) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonaciones
		WHERE	NroTarjeta = @pNroTarjeta
	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblDonaciones
		WHERE	NroTarjeta = @pNroTarjeta
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_NroTarjeta_Verificar
TO Rol_SGD
GO