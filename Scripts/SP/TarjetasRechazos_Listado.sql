USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Listado]
GO

CREATE PROCEDURE TarjetasRechazos_Listado (
	@pId			INT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL)
AS

BEGIN
	SELECT	r.Id,
			UPPER(r.Id_Tarjeta) AS Id_Tarjeta,
			t.Tarjeta,
			UPPER(r.CodBanco) AS CodBanco,
			r.CausaRechazo,
			CASE WHEN r.CausaOK = 1 THEN 'SI' ELSE '' END AS CausaOK,
			r.Estado AS Id_Estado,
			CASE WHEN r.Estado = 'A' THEN 'Activo' WHEN r.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			r.FechaAlta,
			r.FechaBaja
	FROM 	tblTarjetasRechazos r INNER JOIN
			tblTarjetas t ON r.Id_Tarjeta = t.Id 
	WHERE	(r.Id = @pId OR @pId IS NULL)
	AND		r.Id_Tarjeta = @pId_Tarjeta
	ORDER BY r.CodBanco
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Listado
TO Rol_SGD
GO