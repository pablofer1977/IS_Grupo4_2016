USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblProvincias](
	[Id] [int] NOT NULL,
	[Provincia] [varchar](20) NULL,
CONSTRAINT [PK_tblProvincias] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblProvincias (Id, Provincia)
VALUES (1, 'CABA'),
(2, 'Buenos Aires'),
(3, 'Catamarca'),
(4, 'Chaco'),
(5, 'Chubut'),
(6, 'Córdoba'),
(7, 'Corrientes'),
(8, 'Entre Ríos'),
(9, 'Formosa'),
(10, 'Jujuy'),
(11, 'La Pampa'),
(12, 'La Rioja'),
(13, 'Mendoza'),
(14, 'Misiones'),
(15, 'Neuquén'),
(16, 'Río Negro'),
(17, 'Salta'),
(18, 'San Juan'),
(19, 'San Luis'),
(20, 'Santa Cruz'),
(21, 'Santa Fe'),
(22, 'Santiago del Estero'),
(23, 'Tierra del Fuego'),
(24, 'Tucumán')
GO