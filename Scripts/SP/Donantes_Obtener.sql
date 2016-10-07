USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_Obtener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_Obtener]
GO

CREATE PROCEDURE Donantes_Obtener (
	@pId	INT = NULL)
AS

BEGIN
	SELECT	d.Id,
			d.FechaIng,
			d.Id_TipoDonante,
			d.Apellido,
			d.Nombre,
			d.Razon_Social,
			d.Direccion,
			d.Localidad,
			d.CP,
			d.Id_Provincia,
			d.DNI,
			d.CUIL_CUIT,
			d.TE_Linea,
			d.TE_Celular,
			d.TE_Laboral,
			d.EMail,
			d.Comentarios
	FROM 	tblDonantes d
	WHERE	d.Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Donantes_Obtener
TO Usuario_SGD
GO