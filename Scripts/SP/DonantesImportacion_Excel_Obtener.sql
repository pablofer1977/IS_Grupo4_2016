USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Excel_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Excel_Obtener]
GO

CREATE PROCEDURE DonantesImportacion_Excel_Obtener
AS

BEGIN
	SELECT	d.Id,
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
	FROM	tblDonantesImportacion d
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Excel_Obtener
TO Rol_SGD
GO