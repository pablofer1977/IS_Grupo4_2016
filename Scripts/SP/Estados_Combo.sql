USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Estados_Combo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Estados_Combo]
GO

CREATE PROCEDURE Estados_Combo (
	@pTodos		BIT = NULL,
	@pBlanco	BIT = NULL)
AS
	CREATE TABLE #Combo (
		[Id] 	[varchar] (2) NOT NULL ,
		[Campo] [varchar] (50) NOT NULL 
	)

BEGIN 

	INSERT INTO #Combo
	VALUES ('A', 'Activa'), ('B', 'Baja')

	IF (@pTodos = 1)
		INSERT INTO	#Combo
		VALUES 		('-1', '[Todos]')

	IF (@pBlanco = 1)
		INSERT INTO	#Combo
		VALUES 		('0', '')

	SELECT	Id,
			Campo
	FROM	#Combo
	ORDER BY Campo

	DROP TABLE #Combo
END
GO
GRANT EXECUTE
  ON dbo.Estados_Combo
TO Rol_SGD
GO