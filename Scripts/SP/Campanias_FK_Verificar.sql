USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_FK_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_FK_Verificar]
GO

CREATE PROCEDURE Campanias_FK_Verificar (
	@pId		INT = NULL)
AS

BEGIN
	SELECT	COUNT(*) AS Cantidad
	FROM	tblDonaciones
	WHERE	Id_Campania = @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_FK_Verificar
TO Usuario_SGD
GO