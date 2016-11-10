USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Presentaciones_Retornos_Agregar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Presentaciones_Retornos_Agregar]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'lPresentaciones_Retornos_Agregar' AND ss.name = N'dbo')
DROP TYPE [dbo].[lPresentaciones_Retornos_Agregar]
GO

CREATE TYPE [dbo].[lPresentaciones_Retornos_Agregar] AS TABLE(
	[Id_Donacion]	[int] NULL,
	[CodBanco]		[varchar](5) NULL
)
GO

CREATE PROCEDURE Presentaciones_Retornos_Agregar (
	@pId_TipoPresentacion	INT = NULL,
	@pId_Tarjeta			CHAR(3) = NULL,
	@pMes					INT = NULL,
	@pAnio					INT = NULL,
	@pListPresentaciones_Retornos_Agregar	lPresentaciones_Retornos_Agregar READONLY)
AS
	DECLARE @Id_Presentacion INT
BEGIN 
	SELECT	@Id_Presentacion = p.Id
	FROM	tblPresentaciones p
	WHERE	p.Mes = @pMes
	AND		p.Anio = @pAnio
	AND		p.Id_TipoPresentacion = @pId_TipoPresentacion
	AND		((p.Id_Tarjeta = @pId_Tarjeta
	AND		@pId_TipoPresentacion = 1)
	OR		@pId_TipoPresentacion = 2)

	;WITH COD_BANCOS AS
		(
		SELECT	@Id_Presentacion AS Id_Presentacion,
				t.Id_TipoPresentacion,
				CASE WHEN t.Id <> 'CBU' THEN t.Id ELSE NULL END AS Id_Tarjeta,
				tr.Id AS Id_Rechazo,
				tr.CodBanco
		FROM	tblTarjetas t INNER JOIN
				tblTarjetasRechazos tr ON t.Id = tr.Id_Tarjeta
		WHERE	t.Id_TipoPresentacion = @pId_TipoPresentacion
		AND		((t.Id = @pId_Tarjeta
		AND		@pId_TipoPresentacion = 1)
		OR		@pId_TipoPresentacion = 2)
		),
	RETORNOS AS
		(
		SELECT	c.Id_Presentacion,
				c.Id_TipoPresentacion,
				c.Id_Tarjeta,
				l.Id_Donacion,
				c.Id_Rechazo
		FROM	@pListPresentaciones_Retornos_Agregar l INNER JOIN
				COD_BANCOS c ON l.CodBanco = c.CodBanco 
		)
	UPDATE	tblPresentacionesDetalles
	SET		Id_Rechazo = r.Id_Rechazo
	FROM	tblPresentacionesDetalles pd INNER JOIN
			RETORNOS r ON pd.Id_Donacion = r.Id_Donacion
	WHERE	pd.Id_Presentacion = @Id_Presentacion
END
GO
GRANT EXECUTE
  ON dbo.Presentaciones_Retornos_Agregar
TO Rol_SGD
GO

GRANT CONTROL ON TYPE::[dbo].[lPresentaciones_Retornos_Agregar] TO [Rol_SGD]
GO