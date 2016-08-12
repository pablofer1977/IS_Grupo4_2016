USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Listado]
GO

CREATE PROCEDURE TarjetasRechazos_Listado (
	@pId			INT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL)
AS

BEGIN
	SELECT	t.CodBanco AS [Código Banco],
			t.CausaRechazo AS [Causa Rechazo],
			t.CausaOK AS [Causa OK],
			t.Estado,
			t.FechaAlta AS [Fecha Alta],
			t.FechaBaja AS [Fecha Baja]
	FROM 	tblTarjetasRechazos t
	WHERE	(t.Id = @pId OR @pId IS NULL)
	AND		(t.Id_Tarjeta = @pId_Tarjeta OR @pId_Tarjeta IS NULL)
	ORDER BY t.CodBanco
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Listado
TO Usuario_SGD
GO