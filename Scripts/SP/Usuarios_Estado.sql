USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Estado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Estado]
GO

CREATE PROCEDURE Usuarios_Estado (
	@pId		INT = NULL,
	@pEstado	CHAR(1) = NULL)
AS

BEGIN 
	IF (@pEstado = 'A')
		UPDATE	tblUsuarios
		SET		Estado = @pEstado,
				FechaAlta = GETDATE(),
				FechaBaja = NULL
		WHERE	Id = @pId		

	ELSE IF (@pEstado = 'B')
		UPDATE	tblUsuarios
		SET		Estado = @pEstado,
				FechaBaja = GETDATE()
		WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Usuarios_Estado
TO Usuario_SGD
GO