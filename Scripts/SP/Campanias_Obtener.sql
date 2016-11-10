USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Obtener]
GO

CREATE PROCEDURE Campanias_Obtener (
	@pId	INT = NULL)
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
	WHERE	c.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Obtener
TO Rol_SGD
GO