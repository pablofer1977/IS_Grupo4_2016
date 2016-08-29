USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Listado]
GO

CREATE PROCEDURE Campanias_Listado (
	@pId			INT = NULL,
	@pCampania		VARCHAR(50) = NULL,
	@pDescripcion	VARCHAR(250) = NULL,
	@pEstado		CHAR(1) = NULL)
AS

BEGIN
	SELECT 	c.Id,
			c.Campania,
			c.Descripcion,
			c.Estado AS Id_Estado,
			CASE WHEN c.Estado = 'A' THEN 'Activo' WHEN c.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			c.FechaAlta,
			c.FechaBaja
	FROM 	tblCampanias c
	WHERE	(c.Id = @pId OR @pId IS NULL)
	AND		(c.Campania LIKE @pCampania  + '%' OR @pCampania IS NULL)
	AND		(c.Descripcion LIKE @pDescripcion  + '%' OR @pDescripcion IS NULL)
	AND		(c.Estado = @pEstado OR @pEstado IS NULL)
	ORDER BY c.Campania
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Listado
TO Usuario_SGD
GO