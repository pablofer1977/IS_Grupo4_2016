USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblDonantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaIng] [smalldatetime] NOT NULL,
	[Id_TipoDonante] [int] NOT NULL,
	[Apellido] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Razon_Social] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
	[Localidad] [varchar](50) NULL,
	[CP] [varchar](10) NULL,
	[Id_Provincia] [int] NULL,
	[DNI] [varchar](8) NULL,
	[CUIL_CUIT] [varchar](11) NULL,
	[TE_Linea] [varchar](15) NULL,
	[TE_Celular] [varchar](15) NULL,
	[TE_Laboral] [varchar](15) NULL,
	[EMail] [varchar](100) NULL,
	[Comentarios] [varchar](250) NULL,
CONSTRAINT [PK_tblDonantes] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO