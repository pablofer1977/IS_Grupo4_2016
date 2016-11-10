USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_Agregar]
GO

CREATE PROCEDURE Donaciones_Agregar (
	@pId_Donante		INT = NULL,
	@pId_TipoDonacion	INT = NULL,
	@pId_Tarjeta		CHAR(3) = NULL,
	@pNroTarjeta		VARCHAR(16) = NULL,
	@pBanco				VARCHAR(50) = NULL,
	@pVto				VARCHAR(10) = NULL,
	@pCBU				VARCHAR(22) = NULL,
	@pMonto				DECIMAL(10, 2) = NULL,
	@pTiempo			INT = NULL,
	@pId_Campania		INT = NULL)
AS
	DECLARE @Id_Donacion INT
BEGIN
	INSERT INTO tblDonaciones (	Id_Donante,
								FechaDon,
								Estado,
								FechaBaja,
								Id_TipoDonacion,
								Id_Tarjeta,
								NroTarjeta,
								Banco,
								Vto,
								CBU,
								Monto,
								Tiempo,
								Id_Campania)
	VALUES (@pId_Donante,
			GETDATE(),
			'A',
			NULL,
			@pId_TipoDonacion,
			@pId_Tarjeta,
			@pNroTarjeta,
			@pBanco,
			@pVto,
			@pCBU,
			@pMonto,
			@pTiempo,
			@pId_Campania)
			
	SET @Id_Donacion = SCOPE_IDENTITY()
	
	SELECT	@Id_Donacion AS NroDonacion
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_Agregar
TO Rol_SGD
GO