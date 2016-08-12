USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Modificar]
GO

CREATE PROCEDURE TarjetasRechazos_Modificar (
	@pId			INT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL,
	@pCodBanco		VARCHAR(5) = NULL,
	@pCausaRechazo	VARCHAR(150) = NULL,
	@pCausaOK		BIT = NULL)
AS

BEGIN
	UPDATE	tblTarjetasRechazos
	SET		Id_Tarjeta = @pId_Tarjeta,
			CodBanco = @pCodBanco,
			CausaRechazo = @pCausaRechazo,
			CausaOK = @pCausaOK
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Modificar
TO Usuario_SGD
GO