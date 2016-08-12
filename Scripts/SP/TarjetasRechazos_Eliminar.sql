USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Eliminar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Eliminar]
GO

CREATE PROCEDURE TarjetasRechazos_Eliminar (
	@pId	INT = NULL)
AS

BEGIN
	DELETE
	FROM	tblTarjetasRechazos
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Eliminar
TO Usuario_SGD
GO