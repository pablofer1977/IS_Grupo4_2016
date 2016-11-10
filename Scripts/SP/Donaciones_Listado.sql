USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_Listado]
GO

CREATE PROCEDURE Donaciones_Listado (
	@pId_Donacion	INT = NULL,
	@pId_Donante	INT = NULL)
AS

BEGIN
	SELECT	d.Id,
			d.Id_TipoDonacion,
			td.TipoDonacion,
			UPPER(d.Id_Tarjeta) AS Id_Tarjeta,
			t.Tarjeta,
			d.NroTarjeta,
			d.CBU,
			d.Monto,
			d.Tiempo,
			d.Id_Campania,
			c.Campania,
			d.Estado AS Id_Estado,
			CASE WHEN d.Estado = 'A' THEN 'Activo' WHEN d.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			d.FechaDon,
			d.FechaBaja
	FROM 	tblDonaciones d INNER JOIN
			tblTiposDonaciones td ON d.Id_TipoDonacion = td.Id LEFT JOIN
			tblTarjetas t ON d.Id_Tarjeta = t.Id LEFT JOIN
			tblCampanias c ON d.Id_Campania = c.Id
	WHERE	(d.Id = @pId_Donacion OR @pId_Donacion IS NULL)
	AND		d.Id_Donante = @pId_Donante
	ORDER BY d.Id DESC
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_Listado
TO Rol_SGD
GO