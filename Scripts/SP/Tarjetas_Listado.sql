USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Listado]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Listado]
GO

CREATE PROCEDURE Tarjetas_Listado (
	@pId					CHAR(3) = NULL,
	@pTarjeta				VARCHAR(30) = NULL,
	@pId_TipoPresentacion	INT = NULL,
	@pNombreArchivo			VARCHAR(100) = NULL,
	@pNroComercio			VARCHAR(15) = NULL)
AS

BEGIN
	SELECT 	t.Id AS Tarjeta,
			t.Tarjeta AS Nombre,
			tp.TipoPresentacion AS [Tipo Presentación],
			t.NombreArchivo AS [Nombre Archivo],
			t.NroComercio AS [Nro. Comercio]
	FROM 	tblTarjetas t INNER JOIN
			tblTiposPresentaciones tp ON t.Id_TipoPresentacion = tp.Id
	WHERE	(t.Id = @pId OR @pId IS NULL)
	AND		(t.Tarjeta LIKE @pTarjeta  + '%' OR @pTarjeta IS NULL)
	AND		(t.Id_TipoPresentacion = @pId_TipoPresentacion OR @pId_TipoPresentacion IS NULL)
	AND		(t.NombreArchivo LIKE @pNombreArchivo  + '%' OR @pNombreArchivo IS NULL)
	AND		(t.NroComercio LIKE @pNroComercio  + '%' OR @pNroComercio IS NULL)
	ORDER BY t.Id
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Listado
TO Usuario_SGD
GO