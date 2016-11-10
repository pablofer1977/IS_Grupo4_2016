USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PresentacionesDetalles_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PresentacionesDetalles_Listado]
GO

CREATE PROCEDURE PresentacionesDetalles_Listado (
	@pId_Presentacion	INT = NULL)
AS

BEGIN
	SELECT	tr.CodBanco,
			tr.CausaRechazo,
			pd.Id_Donacion,
			pd.Id_Donante,
			td.TipoDonacion,
			UPPER(d.Id_Tarjeta) AS Id_Tarjeta,
			d.NroTarjeta,
			d.CBU,
			d.Monto,
			d.Tiempo,
			CASE WHEN d.Estado = 'A' THEN 'Activo' WHEN d.Estado = 'B' THEN 'Baja' ELSE '' END AS Estado
	FROM	tblPresentacionesDetalles pd INNER JOIN
			tblDonaciones d ON pd.Id_Donacion = d.Id INNER JOIN
			tblTiposDonaciones td ON d.Id_TipoDonacion = td.Id LEFT JOIN
			tblTarjetasRechazos tr ON pd.Id_Rechazo = tr.Id 
	WHERE	pd.Id_Presentacion = @pId_Presentacion
	ORDER BY pd.Id_Donacion
END
GO
GRANT EXECUTE
  ON dbo.PresentacionesDetalles_Listado
TO Rol_SGD
GO