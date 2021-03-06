USE [DonacionesDB2]
GO
/****** Object:  Table [dbo].[Beneficiarios]    Script Date: 04/06/2019 10:55:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiarios](
	[BeneficiarioID] [nchar](5) NOT NULL,
	[Iglesia] [nvarchar](40) NOT NULL,
	[Contacto] [nvarchar](30) NULL,
	[Direccion] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[CodigoPostal] [nvarchar](10) NULL,
	[Pais] [nvarchar](15) NULL,
	[Telefono] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Beneficiarios] PRIMARY KEY CLUSTERED 
(
	[BeneficiarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 04/06/2019 10:55:38 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[OrdenID] [int] IDENTITY(1,1) NOT NULL,
	[BeneficiarioID] [nchar](5) NULL,
	[OrdenDate] [datetime] NULL,
	[FechaIngresada] [datetime] NULL,
	[FechaEntregada] [datetime] NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[OrdenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenesDetalle]    Script Date: 04/06/2019 10:55:38 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenesDetalle](
	[OrdenID] [int] NOT NULL,
	[ProductoID] [int] NOT NULL,
	[PrecioUnitario] [money] NOT NULL,
	[Cantidad] [smallint] NOT NULL,
 CONSTRAINT [PK_Orden_Detalles] PRIMARY KEY CLUSTERED 
(
	[OrdenID] ASC,
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 04/06/2019 10:55:38 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [nvarchar](40) NOT NULL,
	[CantidadPorUnidad] [money] NULL,
	[PrecioUnitario] [money] NULL,
	[Descontinuado] [bit] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrdenesDetalle] ADD  CONSTRAINT [DF_Orden_Detalles_PrecioUnitario]  DEFAULT ((0)) FOR [PrecioUnitario]
GO
ALTER TABLE [dbo].[OrdenesDetalle] ADD  CONSTRAINT [DF_Orden_Detalles_Cantidad]  DEFAULT ((1)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_PrecioUnitario]  DEFAULT ((0)) FOR [PrecioUnitario]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Descontinuado]  DEFAULT ((0)) FOR [Descontinuado]
GO
ALTER TABLE [dbo].[Ordenes]  WITH NOCHECK ADD  CONSTRAINT [FK_Ordenes_Beneficiarios] FOREIGN KEY([BeneficiarioID])
REFERENCES [dbo].[Beneficiarios] ([BeneficiarioID])
GO
ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Beneficiarios]
GO
ALTER TABLE [dbo].[OrdenesDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_Orden_Detalles_Ordenes] FOREIGN KEY([OrdenID])
REFERENCES [dbo].[Ordenes] ([OrdenID])
GO
ALTER TABLE [dbo].[OrdenesDetalle] CHECK CONSTRAINT [FK_Orden_Detalles_Ordenes]
GO
ALTER TABLE [dbo].[OrdenesDetalle]  WITH NOCHECK ADD  CONSTRAINT [FK_Orden_Detalles_Productos] FOREIGN KEY([ProductoID])
REFERENCES [dbo].[Productos] ([ProductoID])
GO
ALTER TABLE [dbo].[OrdenesDetalle] CHECK CONSTRAINT [FK_Orden_Detalles_Productos]
GO
ALTER TABLE [dbo].[OrdenesDetalle]  WITH NOCHECK ADD  CONSTRAINT [CK_Cantidad] CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [dbo].[OrdenesDetalle] CHECK CONSTRAINT [CK_Cantidad]
GO
ALTER TABLE [dbo].[OrdenesDetalle]  WITH NOCHECK ADD  CONSTRAINT [CK_PrecioUnitario] CHECK  (([PrecioUnitario]>=(0)))
GO
ALTER TABLE [dbo].[OrdenesDetalle] CHECK CONSTRAINT [CK_PrecioUnitario]
GO
ALTER TABLE [dbo].[Productos]  WITH NOCHECK ADD  CONSTRAINT [CK_Productos_PrecioUnitario] CHECK  (([PrecioUnitario]>=(0)))
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [CK_Productos_PrecioUnitario]
GO
