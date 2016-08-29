USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblUsuarios](
	[Usuario] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Id_TipoPerfil] [int] NOT NULL,
	[Estado] [char](1) NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
 CONSTRAINT [PK_tblUsuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario]
)
) ON [PRIMARY]
GO