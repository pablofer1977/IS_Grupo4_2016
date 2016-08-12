USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblCampanias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Campania] [varchar](50) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Estado] [char](1) NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
 CONSTRAINT [PK_tblCampanias] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

