USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblPresentacionesDetalles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Presentacion] [int] NOT NULL,
	[Id_Donante] [int] NOT NULL,
	[Id_Donacion] [int] NOT NULL,
	[Id_Rechazo] [int] NULL,
 CONSTRAINT [PK_tblPresentacionesDetalles] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO


