USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Verificar]
GO

CREATE PROCEDURE Tarjetas_Verificar (
	@pAccion		INT,
	@pId			CHAR(3) = NULL,
	@pTarjeta		VARCHAR(30) = NULL,
	@pNombreArchivo	VARCHAR(100) = NULL,
	@pNroComercio	VARCHAR(15) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetas
		WHERE	(Tarjeta = @pTarjeta AND NOT @pTarjeta IS NULL)
		OR		(NombreArchivo = @pNombreArchivo AND NOT @pNombreArchivo IS NULL)
		OR		(NroComercio = @pNroComercio AND NOT @pNroComercio IS NULL)

	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetas
		WHERE	((Tarjeta = @pTarjeta AND NOT @pTarjeta IS NULL)
		OR		(NombreArchivo = @pNombreArchivo AND NOT @pNombreArchivo IS NULL)
		OR		(NroComercio = @pNroComercio AND NOT @pNroComercio IS NULL))
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Verificar
TO Usuario_SGD
GO