USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TarjetasRechazos_Combo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TarjetasRechazos_Combo]
GO

CREATE PROCEDURE TarjetasRechazos_Combo (
	@pTodos			BIT = NULL,
	@pBlanco		BIT = NULL,
	@pId_Tarjeta	CHAR(3) = NULL)
AS
	CREATE TABLE #Combo (
		[Id] 	[int] NOT NULL ,
		[Campo] [varchar] (200) NOT NULL 
	)

BEGIN 

	INSERT INTO #Combo
	SELECT 	t.Id, 
			'(' + t.CodBanco + ') ' + t.CausaRechazo
	FROM 	tblTarjetasRechazos t
	WHERE	(Id_Tarjeta = @pId_Tarjeta OR @pId_Tarjeta IS NULL)

	IF (@pTodos = 1)
		INSERT INTO	#Combo
		VALUES 		(-1, '[Todos]')

	IF (@pBlanco = 1)
		INSERT INTO	#Combo
		VALUES 		(0, '')

	SELECT	Id,
			Campo
	FROM	#Combo
	ORDER BY Campo

	DROP TABLE #Combo
END
GO
GRANT EXECUTE
  ON dbo.TarjetasRechazos_Combo
TO Rol_SGD
GO