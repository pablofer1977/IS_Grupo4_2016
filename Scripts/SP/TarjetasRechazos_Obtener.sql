USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Obtener]
GO

CREATE PROCEDURE TarjetasRechazos_Obtener (
	@pId	INT = NULL)
AS

BEGIN
	SELECT 	r.Id,
			UPPER(r.Id_Tarjeta) AS Id_Tarjeta,
			t.Tarjeta,
			t.Id_TipoPresentacion,
			tp.TipoPresentacion,
			UPPER(r.CodBanco) AS CodBanco,
			r.CausaRechazo,
			ISNULL(r.CausaOK, 0) AS CausaOK,
			r.Estado AS Id_Estado,
			CASE WHEN r.Estado = 'A' THEN 'Activo' WHEN r.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			r.FechaAlta,
			r.FechaBaja
	FROM 	tblTarjetasRechazos r INNER JOIN
			tblTarjetas t ON r.Id_Tarjeta = t.Id INNER JOIN
			tblTiposPresentaciones tp ON t.Id_TipoPresentacion = tp.Id
	WHERE	r.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Obtener
TO Rol_SGD
GO