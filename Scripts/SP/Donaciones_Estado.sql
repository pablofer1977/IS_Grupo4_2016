USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_Estado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_Estado]
GO

CREATE PROCEDURE Donaciones_Estado (
	@pId		INT = NULL,
	@pEstado	CHAR(1) = NULL)
AS

BEGIN 
	IF (@pEstado = 'A')
		UPDATE	tblDonaciones
		SET		Estado = @pEstado,
				FechaDon = GETDATE(),
				FechaBaja = NULL
		WHERE	Id = @pId		

	ELSE IF (@pEstado = 'B')
		UPDATE	tblDonaciones
		SET		Estado = @pEstado,
				FechaBaja = GETDATE()
		WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_Estado
TO Usuario_SGD
GO