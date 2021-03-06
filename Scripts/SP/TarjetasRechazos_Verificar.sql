USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Verificar]
GO

CREATE PROCEDURE TarjetasRechazos_Verificar (
	@pAccion		INT,
	@pId			INT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL,
	@pCodBanco		VARCHAR(5) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetasRechazos
		WHERE	Id_Tarjeta = @pId_Tarjeta
		AND		CodBanco = @pCodBanco

	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetasRechazos
		WHERE	Id_Tarjeta = @pId_Tarjeta
		AND		CodBanco = @pCodBanco
		AND		Id <> @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Verificar
TO Rol_SGD
GO