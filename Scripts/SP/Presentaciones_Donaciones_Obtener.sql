USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Presentaciones_Donaciones_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Presentaciones_Donaciones_Obtener]
GO

CREATE PROCEDURE Presentaciones_Donaciones_Obtener (
	@pId_TipoPresentacion	INT = NULL,
	@pId_Tarjeta			CHAR(3) = NULL)
AS

BEGIN
	IF (@pId_TipoPresentacion = 1) --tarjeta
		WITH CANT_PRES AS
			(
			SELECT	pd.Id_Donacion,
					COUNT(pd.Id_Donacion) AS CantPres
			FROM	tblPresentaciones p INNER JOIN
					tblPresentacionesDetalles pd ON p.Id = pd.Id_Presentacion
			WHERE	p.Id_TipoPresentacion = 1
			AND		p.Id_Tarjeta = @pId_Tarjeta
			GROUP BY pd.Id_Donacion
			)
		SELECT	ROW_NUMBER() OVER (ORDER BY d.Id) AS Id,
				d.Id AS Id_Donacion,
				d.Id_Donante,
				d.Monto,
				d.NroTarjeta AS Nro,
				ISNULL(p.CantPres, 0) AS CantPres
		FROM	tblDonaciones d LEFT JOIN
				CANT_PRES p ON d.Id = p.Id_Donacion
		WHERE	d.Estado = 'A'
		AND		d.Id_TipoDonacion = 1
		AND		d.Id_Tarjeta = @pId_Tarjeta
		ORDER BY d.Id
		
	ELSE IF (@pId_TipoPresentacion = 2) --cbu
		SELECT	ROW_NUMBER() OVER (ORDER BY d.Id) AS Id,
				d.Id AS Id_Donacion,
				d.Id_Donante,
				d.Monto,
				d.CBU AS Nro,
				0 AS CantPres
		FROM	tblDonaciones d
		WHERE	d.Estado = 'A'
		AND		d.Id_TipoDonacion = 2
		ORDER BY d.Id
END
GO
GRANT EXECUTE
  ON dbo.Presentaciones_Donaciones_Obtener
TO Rol_SGD
GO