USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblDonantesImportacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoDonante] [int] NOT NULL,
	[TipoDonante] [varchar](10) NULL,
	[Apellido] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Razon_Social] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
	[Localidad] [varchar](50) NULL,
	[CP] [varchar](10) NULL,
	[Id_Provincia] [int] NULL,
	[Provincia] [varchar](20) NULL,
	[DNI] [varchar](8) NULL,
	[CUIL_CUIT] [varchar](11) NULL,
	[TE_Linea] [varchar](15) NULL,
	[TE_Celular] [varchar](15) NULL,
	[TE_Laboral] [varchar](15) NULL,
	[EMail] [varchar](150) NULL,
	[Id_TipoDonacion] [int] NOT NULL,
	[TipoDonacion] [varchar](10) NULL,
	[Id_Tarjeta] [char](3) NULL,
	[Tarjeta] [varchar](30) NULL,
	[NroTarjeta] [varchar](16) NULL,
	[Banco] [varchar](50) NULL,
	[Vto] [varchar](10) NULL,
	[CBU] [varchar](22) NULL,
	[Monto] [varchar](15) NULL,
	[Tiempo] [varchar](15) NULL,
	[Id_Campania] [int] NULL,
	[Campania] [varchar](50) NULL,
CONSTRAINT [PK_tblDonantesImportacion] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO