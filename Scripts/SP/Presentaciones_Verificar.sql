USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Presentaciones_Verificar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Presentaciones_Verificar]
GO

CREATE PROCEDURE Presentaciones_Verificar (
	@pId_TipoPresentacion	INT = NULL,
	@pId_Tarjeta			CHAR(3) = NULL,
	@pMes					INT = NULL,
	@pAnio					INT = NULL)
AS

BEGIN 
	SELECT	COUNT(*) AS Cantidad
	FROM	tblPresentaciones
	WHERE	Id_TipoPresentacion = @pId_TipoPresentacion
	AND		((Id_Tarjeta = @pId_Tarjeta AND @pId_TipoPresentacion = 1)
	OR		@pId_TipoPresentacion = 2)
	AND		Mes = @pMes
	AND		Anio = @pAnio
END
GO
GRANT EXECUTE
  ON dbo.Presentaciones_Verificar
TO Rol_SGD
GO