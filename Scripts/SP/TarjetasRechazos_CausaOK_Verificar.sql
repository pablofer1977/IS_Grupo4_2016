USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_CausaOK_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_CausaOK_Verificar]
GO

CREATE PROCEDURE TarjetasRechazos_CausaOK_Verificar (
	@pAccion		INT,
	@pId			INT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL)
AS

BEGIN 
	IF (@pAccion = 1) --alta
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetasRechazos
		WHERE	CausaOK = 1
		AND		Id_Tarjeta = @pId_Tarjeta
	ELSE IF (@pAccion = 2) --modificacion
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetasRechazos
		WHERE	CausaOK = 1
		AND		Id_Tarjeta = @pId_Tarjeta
		AND		Id <> @pId
	ELSE IF (@pAccion = 3) --Actualizar Estado
		SELECT	COUNT(*) AS Cantidad
		FROM	tblTarjetasRechazos
		WHERE	CausaOK = 1
		AND		Id_Tarjeta = @pId_Tarjeta
		AND		Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_CausaOK_Verificar
TO Usuario_SGD
GO