USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Estado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Estado]
GO

CREATE PROCEDURE TarjetasRechazos_Estado (
	@pId		INT = NULL,
	@pEstado	CHAR(1) = NULL)
AS

BEGIN 
	IF (@pEstado = 'A')
		UPDATE	tblTarjetasRechazos
		SET		Estado = @pEstado,
				FechaAlta = GETDATE(),
				FechaBaja = NULL
		WHERE	Id = @pId		

	ELSE IF (@pEstado = 'B')
		UPDATE	tblTarjetasRechazos
		SET		Estado = @pEstado,
				FechaBaja = GETDATE()
		WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Estado
TO Rol_SGD
GO