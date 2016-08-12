USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Obtener]
GO

CREATE PROCEDURE Tarjetas_Obtener (
	@pId	CHAR(3) = NULL)
AS

BEGIN
	SELECT 	t.Id,
			t.Tarjeta,
			t.Id_TipoPresentacion,
			t.NombreArchivo,
			t.NroComercio
	FROM 	tblTarjetas t
	WHERE	t.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Obtener
TO Usuario_SGD
GO