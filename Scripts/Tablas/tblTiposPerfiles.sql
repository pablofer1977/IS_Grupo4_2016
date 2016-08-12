USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTiposPerfiles](
	[Id] [int] NOT NULL,
	[Perfil] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblTiposPerfiles] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTiposPerfiles (Id, Perfil)
VALUES (1, 'Administrador'), (2, 'Usuario de Consulta')
GO