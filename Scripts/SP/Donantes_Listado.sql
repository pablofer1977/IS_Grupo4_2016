USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_Listado]
GO

CREATE PROCEDURE Donantes_Listado (
	@pId_Donante		INT = NULL,
	@pId_TipoDonante	INT = NULL,
	@pNombre			VARCHAR(100) = NULL,
	@pDireccion			VARCHAR(100) = NULL,
	@pLocalidad			VARCHAR(50) = NULL,
	@pCP				VARCHAR(10) = NULL,
	@pId_Provincia		INT = NULL,
	@pDNI_CUIL_CUIT		VARCHAR(11) = NULL,
	@pTE				VARCHAR(15) = NULL,
	@pEMail				VARCHAR(100) = NULL,
	@pId_Donacion		INT = NULL,
	@pEstado			CHAR(1) = NULL,
	@pId_TipoDonacion	INT = NULL,
	@pId_Tarjeta		CHAR(3) = NULL,
	@pNroTarjeta_CBU	VARCHAR(22) = NULL,
	@pId_Campania		INT = NULL)
AS

BEGIN
	;WITH DONACIONES AS
		(
		SELECT	d2.Id AS Id_Donante
		FROM	tblDonantes d2 LEFT JOIN
				tblDonaciones d ON d2.Id = d.Id_Donante
		WHERE	(d.Id = @pId_Donacion OR @pId_Donacion IS NULL)
		AND		(d2.Id = @pId_Donante OR @pId_Donante IS NULL)
		AND		(d.Estado = @pEstado OR @pEstado IS NULL)
		AND		(d.Id_TipoDonacion = @pId_TipoDonacion OR @pId_TipoDonacion IS NULL)
		AND		(d.Id_Tarjeta = @pId_Tarjeta OR @pId_Tarjeta IS NULL)
		AND		(d.NroTarjeta LIKE @pNroTarjeta_CBU  + '%' OR d.CBU LIKE @pNroTarjeta_CBU  + '%' OR @pNroTarjeta_CBU IS NULL)
		AND		(d.Id_Campania = @pId_Campania OR @pId_Campania IS NULL)
		)
	SELECT	d.Id,
			d.FechaIng,
			d.Id_TipoDonante,
			td.TipoDonante,
			CASE
				WHEN d.Id_TipoDonante = 1 THEN d.Apellido + ', ' + d.Nombre
				WHEN d.Id_TipoDonante = 2 THEN d.Razon_Social
				ELSE ''
			END AS Nombre,
			d.Direccion,
			d.Localidad,
			d.CP,
			d.Id_Provincia,
			p.Provincia,
			d.DNI,
			d.CUIL_CUIT,
			CASE WHEN NOT d.TE_Linea IS NULL THEN d.TE_Linea ELSE '' END + ' ' +
			CASE WHEN NOT d.TE_Celular IS NULL THEN d.TE_Celular ELSE '' END + ' ' +
			CASE WHEN NOT d.TE_Laboral IS NULL THEN d.TE_Laboral ELSE '' END + ' ' AS TE,
			d.EMail
	FROM	tblDonantes d INNER JOIN
			tblTiposDonantes td ON d.Id_TipoDonante = td.Id LEFT JOIN
			tblProvincias p ON d.Id_Provincia = p.Id
	WHERE	(d.Id = @pId_Donante OR @pId_Donante IS NULL)
	AND		(d.Id_TipoDonante = @pId_TipoDonante OR @pId_TipoDonante IS NULL)
	AND		(d.Apellido LIKE @pNombre  + '%' OR d.Nombre LIKE @pNombre  + '%' OR d.Razon_Social LIKE @pNombre  + '%' OR @pNombre IS NULL)
	AND		(d.Direccion LIKE @pDireccion  + '%' OR @pDireccion IS NULL)
	AND		(d.Localidad LIKE @pLocalidad  + '%' OR @pLocalidad IS NULL)
	AND		(d.CP LIKE @pCP  + '%' OR @pCP IS NULL)
	AND		(d.Id_Provincia = @pId_Provincia OR @pId_Provincia IS NULL)
	AND		(d.DNI LIKE @pDNI_CUIL_CUIT  + '%' OR d.CUIL_CUIT LIKE @pDNI_CUIL_CUIT  + '%' OR @pDNI_CUIL_CUIT IS NULL)
	AND		(d.TE_Linea LIKE @pTE  + '%' OR d.TE_Celular LIKE @pTE  + '%' OR d.TE_Laboral LIKE @pTE  + '%' OR @pTE IS NULL)
	AND		(d.EMail LIKE @pEMail  + '%' OR @pEMail IS NULL)
	AND		d.Id IN (SELECT do.Id_Donante FROM DONACIONES do)
	ORDER BY d.Id
END
GO
GRANT EXECUTE
  ON dbo.Donantes_Listado
TO Usuario_SGD
GO