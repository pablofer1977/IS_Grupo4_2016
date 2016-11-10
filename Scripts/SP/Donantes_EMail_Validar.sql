USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Donantes_EMail_Validar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Donantes_EMail_Validar]
GO

CREATE PROCEDURE Donantes_EMail_Validar (
	@pEMail		VARCHAR(150) = NULL)
AS

BEGIN 
	IF (dbo.FN_EMail_Validar (@pEMail) <> '')
		SELECT 1 AS EMail_Valido
	ELSE
		SELECT 0 AS EMail_Valido
END
GO
GRANT EXECUTE
  ON dbo.Donantes_EMail_Validar
TO Rol_SGD
GO