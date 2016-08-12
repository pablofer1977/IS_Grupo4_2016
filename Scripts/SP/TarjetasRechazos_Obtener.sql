USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Obtener]
GO

CREATE PROCEDURE TarjetasRechazos_Obtener (
	@pId	INT = NULL)
AS

BEGIN
	SELECT 	t.Id_Tarjeta,
			t.CodBanco,
			t.CausaRechazo,
			t.CausaOK,
			t.Estado,
			t.FechaAlta,
			t.FechaBaja
	FROM 	tblTarjetasRechazos t
	WHERE	t.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Obtener
TO Usuario_SGD
GO