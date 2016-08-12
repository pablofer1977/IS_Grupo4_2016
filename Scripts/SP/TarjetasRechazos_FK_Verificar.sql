USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_FK_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_FK_Verificar]
GO

CREATE PROCEDURE TarjetasRechazos_FK_Verificar (
	@pId	INT = NULL)
AS

BEGIN
	SELECT	COUNT(*) AS Cantidad
	FROM	tblPresentacionesDetalles
	WHERE	Id_Rechazo = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_FK_Verificar
TO Usuario_SGD
GO