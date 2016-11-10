USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donaciones_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donaciones_Modificar]
GO

CREATE PROCEDURE Donaciones_Modificar (
	@pId				INT = NULL,
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
	DECLARE @Tiempo INT
BEGIN
	SELECT	@Tiempo = COUNT(pd.Id_Presentacion)
	FROM	tblPresentacionesDetalles pd
	WHERE	pd.Id_Donacion = @pId
	
	UPDATE	tblDonaciones
	SET		Estado = 'B',
			FechaBaja = GETDATE()
	WHERE	Id = @pId
	
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
			@pTiempo - ISNULL(@Tiempo, 0),
			@pId_Campania)
END
GO
GRANT EXECUTE
  ON dbo.Donaciones_Modificar
TO Rol_SGD
GO