USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTiposValidaciones](
	[Id] [int] NOT NULL,
	[TipoValidacion] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblTiposValidaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTiposValidaciones (Id, TipoValidacion)
VALUES (1, 'OK'), (2, 'Advertencia'), (3, 'Error')
GO