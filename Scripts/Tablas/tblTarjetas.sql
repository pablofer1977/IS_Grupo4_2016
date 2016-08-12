USE [dbsSGD]
GO

CREATE TABLE [dbo].[tblTarjetas](
	[Id] [char](3) NOT NULL,
	[Tarjeta] [varchar](30) NOT NULL,
	[Id_TipoPresentacion] [int] NOT NULL,
	[NombreArchivo] [varchar](100) NULL,
	[NroComercio] [varchar](15) NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[Id]
)
) ON [PRIMARY]
GO

INSERT INTO tblTarjetas (Id, Tarjeta, Id_TipoPresentacion, NombreArchivo, NroComercio)
VALUES ('AME','American Express',1,'AME.txt','9906116439'),
('VIS','Visa Argentina',1,'VIS.txt','0002841989'),
('MAS','Mastercard',1,'MAS.txt','03804917'),
('CBU','Débito Bancario',2,'CBU.txt','06785')
GO