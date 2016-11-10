USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Presentaciones_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Presentaciones_Listado]
GO

CREATE PROCEDURE Presentaciones_Listado (
	@pId					INT = NULL,
	@pId_TipoPresentacion	INT = NULL,
	@pId_Tarjeta			CHAR(3) = NULL,
	@pMes					INT = NULL,
	@pAnio					INT = NULL)
AS

BEGIN
	WITH PRESENTADO AS
		(
		SELECT	pd.Id_Presentacion,
				COUNT(pd.Id_Donacion) AS DonPres,
				SUM(d.Monto) AS MontoPres
		FROM	tblPresentacionesDetalles pd INNER JOIN
				tblDonaciones d ON pd.Id_Donacion = d.Id LEFT JOIN
				tblTarjetasRechazos tr ON pd.Id_Rechazo = tr.Id
		GROUP BY pd.Id_Presentacion
		), ACEPTADO AS
		(
		SELECT	pd.Id_Presentacion,
				COUNT(pd.Id_Donacion) AS DonAcep,
				SUM(d.Monto) AS MontoAcep
		FROM	tblPresentacionesDetalles pd INNER JOIN
				tblDonaciones d ON pd.Id_Donacion = d.Id INNER JOIN
				tblTarjetasRechazos tr ON pd.Id_Rechazo = tr.Id
		WHERE	tr.CausaOK = 1
		GROUP BY pd.Id_Presentacion
		), RECHAZADO AS
		(
		SELECT	pd.Id_Presentacion,
				COUNT(pd.Id_Donacion) AS DonRech,
				SUM(d.Monto) AS MontoRech
		FROM	tblPresentacionesDetalles pd INNER JOIN
				tblDonaciones d ON pd.Id_Donacion = d.Id INNER JOIN
				tblTarjetasRechazos tr ON pd.Id_Rechazo = tr.Id
		WHERE	ISNULL(tr.CausaOK, 0) = 0
		GROUP BY pd.Id_Presentacion
		)
	SELECT	p.Id,
			p.FechaPresentacion,
			tp.TipoPresentacion,
			m.Mes,
			p.Anio,
			t.Tarjeta,
			d.DonPres,
			d.MontoPres,
			d2.DonAcep,
			d2.MontoAcep,
			d3.DonRech,
			d3.MontoRech
	FROM	tblPresentaciones p INNER JOIN
			tblMeses m ON p.Mes = m.Id INNER JOIN
			tblTiposPresentaciones tp ON p.Id_TipoPresentacion = tp.Id LEFT JOIN
			tblTarjetas t ON p.Id_Tarjeta = t.Id INNER JOIN
			PRESENTADO d ON p.Id = d.Id_Presentacion LEFT JOIN
			ACEPTADO d2 ON p.Id = d2.Id_Presentacion LEFT JOIN
			RECHAZADO d3 ON p.Id = d3.Id_Presentacion 
	WHERE	(p.Id = @pId OR @pId IS NULL)
	AND		(p.Mes = @pMes OR @pMes IS NULL)
	AND		(p.Anio = @pAnio OR @pAnio IS NULL)
	AND		(p.Id_TipoPresentacion = @pId_TipoPresentacion OR @pId_TipoPresentacion IS NULL)
	AND		(p.Id_Tarjeta = @pId_Tarjeta OR @pId_Tarjeta IS NULL)
	ORDER BY p.Anio DESC, p.Mes DESC, p.Id_TipoPresentacion, p.Id_Tarjeta
END
GO
GRANT EXECUTE
  ON dbo.Presentaciones_Listado
TO Rol_SGD
GO