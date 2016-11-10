USE [dbsSGD]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Usuarios_Combo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Usuarios_Combo]
GO

CREATE PROCEDURE Usuarios_Combo (
	@pEstado	CHAR(1) = NULL,
	@pTodos		BIT = NULL,
	@pBlanco	BIT = NULL)
AS
	CREATE TABLE #Combo (
		[Id] 	[varchar] (20) NOT NULL ,
		[Campo] [varchar] (150) NOT NULL 
	)

BEGIN 

	INSERT INTO #Combo
	SELECT 	u.Usuario, 
			u.Usuario + ' - ' + u.Nombre
	FROM 	tblUsuarios u
	WHERE 	(u.Estado = @pEstado OR @pEstado IS NULL)

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
  ON dbo.Usuarios_Combo
TO Rol_SGD
GO