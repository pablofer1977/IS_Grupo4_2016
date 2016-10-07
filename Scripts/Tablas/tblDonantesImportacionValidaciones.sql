USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblDonantesImportacionValidaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Donante] [int] NOT NULL,
	[Id_TipoValidacion] [int] NOT NULL,
	[Validacion] [varchar](50) NULL,
CONSTRAINT [PK_tblDonantesImportacionValidaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO