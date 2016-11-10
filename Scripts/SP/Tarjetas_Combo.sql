USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tarjetas_Combo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Tarjetas_Combo]
GO

CREATE PROCEDURE Tarjetas_Combo (
	@pTodos					BIT = NULL,
	@pBlanco				BIT = NULL,
	@pId_TipoPresentacion	INT = NULL)
AS
	CREATE TABLE #Combo (
		[Id] 	[char] (3) NOT NULL ,
		[Campo] [varchar] (50) NOT NULL 
	)

BEGIN 

	INSERT INTO #Combo
	SELECT 	t.Id, 
			'(' + t.Id + ') ' + t.Tarjeta
	FROM 	tblTarjetas t
	WHERE	(Id_TipoPresentacion = @pId_TipoPresentacion OR @pId_TipoPresentacion IS NULL)

	IF (@pTodos = 1)
		INSERT INTO	#Combo
		VALUES 		('-1', '[Todos]')

	IF (@pBlanco = 1)
		INSERT INTO	#Combo
		VALUES 		('0', '')

	SELECT	Id,
			Campo
	FROM	#Combo
	ORDER BY Id

	DROP TABLE #Combo
END
GO
GRANT EXECUTE
  ON dbo.Tarjetas_Combo
TO Rol_SGD
GO