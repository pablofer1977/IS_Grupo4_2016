USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Obtener]
GO

CREATE PROCEDURE Tarjetas_Obtener (
	@pId	CHAR(3) = NULL)
AS

BEGIN
	SELECT 	UPPER(t.Id) AS Id,
			t.Tarjeta,
			t.Id_TipoPresentacion,
			tp.TipoPresentacion,
			t.NombreArchivo,
			t.NroComercio
	FROM 	tblTarjetas t INNER JOIN
			tblTiposPresentaciones tp ON t.Id_TipoPresentacion = tp.Id
	WHERE	t.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Obtener
TO Rol_SGD
GO