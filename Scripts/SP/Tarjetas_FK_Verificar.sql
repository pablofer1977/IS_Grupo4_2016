USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_FK_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_FK_Verificar]
GO

CREATE PROCEDURE Tarjetas_FK_Verificar (
	@pId	CHAR(3) = NULL)
AS

BEGIN
	SELECT	COUNT(*) AS Cantidad
	FROM	tblDonaciones
	WHERE	Id_Tarjeta = @pId
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_FK_Verificar
TO Usuario_SGD
GO