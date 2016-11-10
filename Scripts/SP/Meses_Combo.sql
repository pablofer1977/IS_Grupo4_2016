USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Meses_Combo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Meses_Combo]
GO

CREATE PROCEDURE Meses_Combo (
	@pTodos		BIT = NULL,
	@pBlanco	BIT = NULL)
AS
	CREATE TABLE #Combo (
		[Id] 	[int] NOT NULL ,
		[Campo] [varchar] (20) NOT NULL 
	)

BEGIN 

	INSERT INTO #Combo
	SELECT	t.Id,
			t.Mes
	FROM	tblMeses t

	IF (@pTodos = 1)
		INSERT INTO	#Combo
		VALUES 		(-1, '[Todos]')

	IF (@pBlanco = 1)
		INSERT INTO	#Combo
		VALUES 		(0, '')

	SELECT	Id,
			Campo
	FROM	#Combo
	ORDER BY Id

	DROP TABLE #Combo
END
GO
GRANT EXECUTE
  ON dbo.Meses_Combo
TO Rol_SGD
GO