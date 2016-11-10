USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Listado]
GO

CREATE PROCEDURE DonantesImportacion_Listado
AS

BEGIN
	;WITH VALIDACIONES AS
		(
		SELECT	v.Id_Donante,
				MAX(v.Id_TipoValidacion) AS Id_TipoValidacion
		FROM	tblDonantesImportacionValidaciones v
		GROUP BY v.Id_Donante
		)
	SELECT	d.Id,
			CASE WHEN v.Id_TipoValidacion IS NULL THEN 1 ELSE v.Id_TipoValidacion END AS Id_TipoValidacion,
			d.Id_TipoDonante,
			d.TipoDonante,
			d.Apellido,
			d.Nombre,
			d.Razon_Social,
			d.Direccion,
			d.Localidad,
			d.CP,
			d.Id_Provincia,
			d.Provincia,
			d.DNI,
			d.CUIL_CUIT,
			d.TE_Linea,
			d.TE_Celular,
			d.TE_Laboral,
			d.EMail,
			d.Id_TipoDonacion,
			d.TipoDonacion,
			d.Id_Tarjeta,
			d.Tarjeta,
			d.NroTarjeta,
			d.Banco,
			d.Vto,
			d.CBU,
			d.Monto,
			d.Tiempo,
			d.Id_Campania,
			d.Campania
	FROM	tblDonantesImportacion d LEFT JOIN
			VALIDACIONES v ON d.Id = v.Id_Donante
	ORDER BY d.Id
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Listado
TO Rol_SGD
GO