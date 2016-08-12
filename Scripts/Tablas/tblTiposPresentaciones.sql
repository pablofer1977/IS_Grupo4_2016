USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTiposPresentaciones](
	[Id] [int] NOT NULL,
	[TipoPresentacion] [varchar](10) NOT NULL,
 CONSTRAINT [PK_tblTiposPresentaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTiposPresentaciones (Id, TipoPresentacion)
VALUES (1, 'Tarjeta'), (2, 'CBU')
GO