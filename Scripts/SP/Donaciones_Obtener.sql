USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_Obtener]
GO

CREATE PROCEDURE Donaciones_Obtener (
	@pId	INT = NULL)
AS

BEGIN
	SELECT	d.Id,
			d.Id_Donante,
			d.Id_TipoDonacion,
			d.Id_Tarjeta,
			d.NroTarjeta,
			d.Banco,
			d.Vto,
			d.CBU,
			d.Monto,
			d.Tiempo,
			d.Id_Campania,
			d.Estado AS Id_Estado,
			CASE WHEN d.Estado = 'A' THEN 'Activo' WHEN d.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado,
			d.FechaDon,
			d.FechaBaja
	FROM 	tblDonaciones d
	WHERE	d.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_Obtener
TO Usuario_SGD
GO