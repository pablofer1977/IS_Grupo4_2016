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
	IF @pCausaOK = 1
		UPDATE	tblTarjetasRechazos
		SET		CausaOK = 0
		WHERE	Id_Tarjeta = @pId_Tarjeta
		AND		CausaOK = 1

	UPDATE	tblTarjetasRechazos
	SET		Id_Tarjeta = UPPER(@pId_Tarjeta),
			CodBanco = UPPER(@pCodBanco),
			CausaRechazo = @pCausaRechazo,
			CausaOK = @pCausaOK
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Modificar
TO Rol_SGD
GO