USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblDonaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Donante] [int] NOT NULL,
	[FechaDon] [smalldatetime] NOT NULL,
	[Estado] [char](1) NOT NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Id_TipoDonacion] [int] NOT NULL,
	[Id_Tarjeta] [char](3) NULL,
	[NroTarjeta] [varchar](16) NULL,
	[Banco] [varchar](50) NULL,
	[Vto] [varchar](10) NULL,
	[CBU] [varchar](22) NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[Tiempo] [int] NULL,
	[Id_Campania] [int] NULL,
 CONSTRAINT [PK_tblDonaciones] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO