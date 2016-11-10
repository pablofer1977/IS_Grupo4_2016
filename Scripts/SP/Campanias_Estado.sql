USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Campanias_Estado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Campanias_Estado]
GO

CREATE PROCEDURE Campanias_Estado (
	@pId		INT = NULL,
	@pEstado	CHAR(1) = NULL)
AS

BEGIN 
	IF (@pEstado = 'A')
		UPDATE	tblCampanias
		SET		Estado = @pEstado,
				FechaAlta = GETDATE(),
				FechaBaja = NULL
		WHERE	Id = @pId		

	ELSE IF (@pEstado = 'B')
		UPDATE	tblCampanias
		SET		Estado = @pEstado,
				FechaBaja = GETDATE()
		WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Campanias_Estado
TO Rol_SGD
GO