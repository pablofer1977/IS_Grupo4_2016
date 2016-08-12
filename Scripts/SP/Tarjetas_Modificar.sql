USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Modificar]
GO

CREATE PROCEDURE Tarjetas_Modificar (
	@pId					CHAR(3) = NULL,
	@pTarjeta				VARCHAR(30) = NULL,
	@pId_TipoPresentacion	INT = NULL,
	@pNombreArchivo			VARCHAR(100) = NULL,
	@pNroComercio			VARCHAR(15) = NULL)
AS

BEGIN
	UPDATE	tblTarjetas
	SET		Tarjeta = @pTarjeta,
			Id_TipoPresentacion = @pId_TipoPresentacion,
			NombreArchivo = @pNombreArchivo,
			NroComercio = @pNroComercio
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Modificar
TO Usuario_SGD
GO