USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTiposDonantes](
	[Id] [int] NOT NULL,
	[TipoDonante] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblTiposDonantes] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTiposDonantes (Id, TipoDonante)
VALUES (1, 'F�sico'), (2, 'Jur�dico')