USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DonantesImportacion_Excel_Validaciones_Grabar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DonantesImportacion_Excel_Validaciones_Grabar]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'lExcel_Validaciones_Grabar' AND ss.name = N'dbo')
DROP TYPE [dbo].[lExcel_Validaciones_Grabar]
GO

CREATE TYPE [dbo].[lExcel_Validaciones_Grabar] AS TABLE(
	[Id_Donante]	[int] NULL
)
GO

CREATE PROCEDURE DonantesImportacion_Excel_Validaciones_Grabar (
	@pListExcel_Validaciones_Grabar	lExcel_Validaciones_Grabar READONLY)
AS
	DECLARE @Donantes TABLE(Id INT, Id_Donante INT)
BEGIN
	--INSERT INTO tblDonantes
	--OUTPUT l.Id, inserted.$identity
	--INTO @Donantes(Id, Id_Donante)
	--SELECT	GETDATE(),
	--		l.Id_TipoDonante,
	--		l.Apellido,
	--		l.Nombre,
	--		l.Razon_Social,
	--		l.Direccion,
	--		l.Localidad,
	--		l.CP,
	--		l.Id_Provincia,
	--		l.DNI,
	--		l.CUIL_CUIT,
	--		l.TE_Linea,
	--		l.TE_Celular,
	--		l.TE_Laboral,
	--		l.EMail,
	--		NULL
	--FROM	tblDonantesImportacion l
	--WHERE	l.Id IN (SELECT Id_Donante FROM @pListExcel_Validaciones_Grabar)


	MERGE INTO tblDonantes d USING
		(SELECT	l.Id,
				l.Id_TipoDonante,
				l.Apellido,
				l.Nombre,
				l.Razon_Social,
				l.Direccion,
				l.Localidad,
				l.CP,
				l.Id_Provincia,
				l.DNI,
				l.CUIL_CUIT,
				l.TE_Linea,
				l.TE_Celular,
				l.TE_Laboral,
				l.EMail
		FROM	tblDonantesImportacion l
		WHERE	l.Id IN (SELECT Id_Donante FROM @pListExcel_Validaciones_Grabar)) p ON 1 = 0
	WHEN NOT MATCHED THEN
		INSERT (FechaIng,
				Id_TipoDonante,
				Apellido,
				Nombre,
				Razon_Social,
				Direccion,
				Localidad,
				CP,
				Id_Provincia,
				DNI,
				CUIL_CUIT,
				TE_Linea,
				TE_Celular,
				TE_Laboral,
				EMail)
		VALUES (GETDATE(),
				p.Id_TipoDonante,
				p.Apellido,
				p.Nombre,
				p.Razon_Social,
				p.Direccion,
				p.Localidad,
				p.CP,
				p.Id_Provincia,
				p.DNI,
				p.CUIL_CUIT,
				p.TE_Linea,
				p.TE_Celular,
				p.TE_Laboral,
				p.EMail)
		OUTPUT	p.Id, inserted.Id
		INTO	@Donantes(Id, Id_Donante);

	INSERT INTO tblDonaciones
	SELECT	d.Id_Donante,
			GETDATE(),
			'A',
			NULL,
			l.Id_TipoDonacion,
			l.Id_Tarjeta,
			l.NroTarjeta,
			l.Banco,
			l.Vto,
			l.CBU,
			l.Monto,
			l.Tiempo,
			l.Id_Campania
	FROM	tblDonantesImportacion l INNER JOIN
			@Donantes d ON l.Id = d.Id
	WHERE	l.Id IN (SELECT Id_Donante FROM @pListExcel_Validaciones_Grabar)

	TRUNCATE TABLE tblDonantesImportacionValidaciones
	TRUNCATE TABLE tblDonantesImportacion
END
GO
GRANT EXECUTE
  ON dbo.DonantesImportacion_Excel_Validaciones_Grabar
TO Rol_SGD
GO

GRANT CONTROL ON TYPE::[dbo].[lExcel_Validaciones_Grabar] TO [Rol_SGD]
GO