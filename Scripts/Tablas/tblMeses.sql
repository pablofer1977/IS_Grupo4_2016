USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblMeses](
	[Id] [int] NOT NULL,
	[Mes] [varchar](20) NULL,
CONSTRAINT [PK_tblMeses] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblMeses (Id, Mes)
VALUES	(1, 'Enero'),
		(2, 'Febrero'),
		(3, 'Marzo'),
		(4, 'Abril'),
		(5, 'Mayo'),
		(6, 'Junio'),
		(7, 'Julio'),
		(8, 'Agosto'),
		(9, 'Septiembre'),
		(10, 'Octubre'),
		(11, 'Noviembre'),
		(12, 'Diciembre')
GO