USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Agregar]
GO

CREATE PROCEDURE TarjetasRechazos_Agregar (
	@pId_Tarjeta	CHAR(3) = NULL,
	@pCodBanco		VARCHAR(5) = NULL,
	@pCausaRechazo	VARCHAR(150) = NULL,
	@pCausaOK		BIT = NULL)
AS

BEGIN
	INSERT INTO tblTarjetasRechazos (Id_Tarjeta, CodBanco, CausaRechazo, CausaOK, Estado, FechaAlta, FechaBaja)
	VALUES (UPPER(@pId_Tarjeta), UPPER(@pCodBanco), @pCausaRechazo, @pCausaOK, 'A', GETDATE(), NULL)
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Agregar
TO Rol_SGD
GO