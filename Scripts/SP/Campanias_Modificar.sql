USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Modificar]
GO

CREATE PROCEDURE Campanias_Modificar (
	@pId			INT = NULL,
	@pCampania		VARCHAR(50) = NULL,
	@pDescripcion	VARCHAR(250) = NULL)
AS

BEGIN
	UPDATE	tblCampanias
	SET		Campania = @pCampania,
			Descripcion = @pDescripcion
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Modificar
TO Rol_SGD
GO