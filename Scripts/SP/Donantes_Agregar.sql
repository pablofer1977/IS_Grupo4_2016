USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_Agregar]
GO

CREATE PROCEDURE Donantes_Agregar (
	@pId_TipoDonante	INT = NULL,
	@pApellido			VARCHAR(50) = NULL,
	@pNombre			VARCHAR(50) = NULL,
	@pRazon_Social		VARCHAR(100) = NULL,
	@pDireccion			VARCHAR(100) = NULL,
	@pLocalidad			VARCHAR(50) = NULL,
	@pCP				VARCHAR(10) = NULL,
	@pId_Provincia		INT = NULL,
	@pDNI				VARCHAR(8) = NULL,
	@pCUIL_CUIT			VARCHAR(11) = NULL,
	@pTE_Linea			VARCHAR(15) = NULL,
	@pTE_Celular		VARCHAR(15) = NULL,
	@pTE_Laboral		VARCHAR(15) = NULL,
	@pEMail				VARCHAR(100) = NULL,
	@pComentarios		VARCHAR(250) = NULL)
AS
	DECLARE @Id_Donante INT
BEGIN
	INSERT INTO tblDonantes (FechaIng,
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
							EMail,
							Comentarios)
	VALUES (GETDATE(),
			@pId_TipoDonante,
			@pApellido,
			@pNombre,
			@pRazon_Social,
			@pDireccion,
			@pLocalidad,
			@pCP,
			@pId_Provincia,
			@pDNI,
			@pCUIL_CUIT,
			@pTE_Linea,
			@pTE_Celular,
			@pTE_Laboral,
			@pEMail,
			@pComentarios)
			
	SET @Id_Donante = SCOPE_IDENTITY()
	
	SELECT	@Id_Donante AS NroDonante
END
GO
GRANT EXECUTE
  ON dbo.Donantes_Agregar
TO Usuario_SGD
GO