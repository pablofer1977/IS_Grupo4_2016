USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_Modificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_Modificar]
GO

CREATE PROCEDURE Donantes_Modificar (
	@pId				INT = NULL,
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

BEGIN
	UPDATE	tblDonantes
	SET		Id_TipoDonante = @pId_TipoDonante,
			Apellido = @pApellido,
			Nombre = @pNombre,
			Razon_Social = @pRazon_Social,
			Direccion = @pDireccion,
			Localidad = @pLocalidad,
			CP = @pCP,
			Id_Provincia = @pId_Provincia,
			DNI = @pDNI,
			CUIL_CUIT = @pCUIL_CUIT,
			TE_Linea = @pTE_Linea,
			TE_Celular = @pTE_Celular,
			TE_Laboral = @pTE_Laboral,
			EMail = @pEMail,
			Comentarios = @pComentarios
	WHERE	Id = @pId
END
GO
GRANT EXECUTE
  ON dbo.Donantes_Modificar
TO Rol_SGD
GO