USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Agregar]
GO

CREATE PROCEDURE Campanias_Agregar (
	@pCampania		VARCHAR(50) = NULL,
	@pDescripcion	VARCHAR(250) = NULL)
AS

BEGIN
	INSERT INTO tblCampanias (Campania, Descripcion, Estado, FechaAlta, FechaBaja)
	VALUES (@pCampania, @pDescripcion, 'A', GETDATE(), NULL)
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Agregar
TO Usuario_SGD
GO