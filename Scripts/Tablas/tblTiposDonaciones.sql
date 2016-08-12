USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTiposDonaciones](
	[Id] [int] NOT NULL,
	[TipoDonacion] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblTiposDonaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTiposDonaciones (Id, TipoDonacion)
VALUES (1, 'Tarjeta'), (2, 'CBU')