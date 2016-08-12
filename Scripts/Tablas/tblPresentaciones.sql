USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblPresentaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaPresentacion] [smalldatetime] NOT NULL,
	[Mes] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[Id_TipoPresentacion] [int] NOT NULL,
	[Id_Tarjeta] [char](3) NULL,
 CONSTRAINT [PK_tblPresentaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO