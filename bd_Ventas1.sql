USE [Ventas]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[cod_cat] [int] NOT NULL,
	[descripcion] [nvarchar](30) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[cod_cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ciudad]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ciudad](
	[cod_ciu] [int] NOT NULL,
	[nom_ciu] [nvarchar](20) NULL,
 CONSTRAINT [PK_ciudad] PRIMARY KEY CLUSTERED 
(
	[cod_ciu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[cod_client] [int] NULL,
	[ced_client] [nvarchar](10) NOT NULL,
	[nom_client] [nvarchar](30) NULL,
	[ape_client] [nvarchar](30) NULL,
	[email_client] [nvarchar](25) NOT NULL,
	[telf_client] [nvarchar](12) NULL,
	[dir_client] [nvarchar](50) NULL,
	[cod_ciu] [int] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[ced_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compras]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras](
	[cod_cmpra] [nvarchar](10) NOT NULL,
	[ced_ruc_prov] [nvarchar](12) NULL,
	[ced_empl] [nvarchar](12) NULL,
	[fecha_pedido] [date] NULL,
	[fecha_entrega] [date] NULL,
	[estado_cmpra] [nvarchar](30) NULL,
	[subtotal] [decimal](18, 2) NULL,
	[iva_cmpra] [decimal](18, 2) NULL,
	[desc_cmpra] [decimal](18, 2) NULL,
	[total_cmpra] [decimal](18, 2) NULL,
 CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED 
(
	[cod_cmpra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[det_compra]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[det_compra](
	[cod_cmpra] [nvarchar](10) NOT NULL,
	[cant_prod] [int] NULL,
	[cod_prod] [int] NULL,
	[prec_cmpra] [decimal](18, 2) NULL,
	[iva_cmpra] [decimal](18, 2) NULL,
	[desc_cmpra] [decimal](18, 2) NULL,
	[total_cmpra] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_vnta]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_vnta](
	[cod_vnta] [nvarchar](10) NOT NULL,
	[cant] [int] NULL,
	[cod_prod] [int] NULL,
	[prec_unit] [decimal](18, 2) NULL,
	[det_iva] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[cod_marca] [int] NOT NULL,
	[desc_marca] [nvarchar](30) NULL,
 CONSTRAINT [PK_marca] PRIMARY KEY CLUSTERED 
(
	[cod_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permisos]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permisos](
	[id_permiso] [int] NOT NULL,
	[ced_usu] [nvarchar](12) NULL,
	[registrar] [int] NULL,
	[upadate] [int] NULL,
	[delet] [int] NULL,
 CONSTRAINT [PK_permisos] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[cod_prod] [int] NOT NULL,
	[nom_prod] [nvarchar](40) NULL,
	[cod_marca] [int] NULL,
	[prec_compra] [decimal](18, 2) NULL,
	[prec_vnta] [decimal](18, 2) NULL,
	[iva_prod] [decimal](18, 2) NULL,
	[cant_prod] [int] NULL,
	[cod_cat] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[cod_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[cod_prov] [int] NULL,
	[ruc_ced] [nvarchar](12) NOT NULL,
	[nom_prov] [nvarchar](40) NULL,
	[direccion] [nvarchar](50) NULL,
	[id_ciudad] [int] NULL,
	[telf] [nvarchar](12) NULL,
	[email] [nvarchar](30) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[ruc_ced] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[cod_rol] [int] NOT NULL,
	[nom_rol] [nvarchar](50) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[cod_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[cod_usuario] [int] NULL,
	[cod_rol] [int] NULL,
	[ced_usua] [nvarchar](12) NOT NULL,
	[nom_usua] [nvarchar](30) NULL,
	[ape_usua] [nvarchar](30) NULL,
	[email_usua] [nvarchar](30) NULL,
	[telf_usua] [nvarchar](12) NULL,
	[dir_usua] [nvarchar](50) NULL,
	[cod_ciu] [int] NULL,
	[passward] [nvarchar](30) NULL,
	[aux] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[ced_usua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 26/02/2020 20:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[cod_vnta] [nvarchar](10) NOT NULL,
	[ced_client] [nvarchar](10) NULL,
	[ced_empl] [nvarchar](12) NULL,
	[fecha] [date] NULL,
	[form_pago] [nvarchar](30) NULL,
	[estado_vnta] [nvarchar](30) NULL,
	[subtotal] [decimal](18, 2) NULL,
	[iva] [decimal](18, 2) NULL,
	[descuento] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[cod_vnta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_ciudad] FOREIGN KEY([cod_ciu])
REFERENCES [dbo].[ciudad] ([cod_ciu])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_ciudad]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_proveedor] FOREIGN KEY([ced_ruc_prov])
REFERENCES [dbo].[proveedor] ([ruc_ced])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_proveedor]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_usuario] FOREIGN KEY([ced_empl])
REFERENCES [dbo].[usuario] ([ced_usua])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_usuario]
GO
ALTER TABLE [dbo].[det_compra]  WITH CHECK ADD  CONSTRAINT [FK_det_compra_compras] FOREIGN KEY([cod_cmpra])
REFERENCES [dbo].[compras] ([cod_cmpra])
GO
ALTER TABLE [dbo].[det_compra] CHECK CONSTRAINT [FK_det_compra_compras]
GO
ALTER TABLE [dbo].[det_compra]  WITH CHECK ADD  CONSTRAINT [FK_det_compra_producto] FOREIGN KEY([cod_prod])
REFERENCES [dbo].[producto] ([cod_prod])
GO
ALTER TABLE [dbo].[det_compra] CHECK CONSTRAINT [FK_det_compra_producto]
GO
ALTER TABLE [dbo].[detalle_vnta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_vnta_producto] FOREIGN KEY([cod_prod])
REFERENCES [dbo].[producto] ([cod_prod])
GO
ALTER TABLE [dbo].[detalle_vnta] CHECK CONSTRAINT [FK_detalle_vnta_producto]
GO
ALTER TABLE [dbo].[detalle_vnta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_vnta_ventas] FOREIGN KEY([cod_vnta])
REFERENCES [dbo].[ventas] ([cod_vnta])
GO
ALTER TABLE [dbo].[detalle_vnta] CHECK CONSTRAINT [FK_detalle_vnta_ventas]
GO
ALTER TABLE [dbo].[permisos]  WITH CHECK ADD  CONSTRAINT [FK_permisos_usuario] FOREIGN KEY([ced_usu])
REFERENCES [dbo].[usuario] ([ced_usua])
GO
ALTER TABLE [dbo].[permisos] CHECK CONSTRAINT [FK_permisos_usuario]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_categoria] FOREIGN KEY([cod_cat])
REFERENCES [dbo].[categoria] ([cod_cat])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_categoria]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_marca] FOREIGN KEY([cod_marca])
REFERENCES [dbo].[marca] ([cod_marca])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_marca]
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD  CONSTRAINT [FK_proveedor_ciudad] FOREIGN KEY([id_ciudad])
REFERENCES [dbo].[ciudad] ([cod_ciu])
GO
ALTER TABLE [dbo].[proveedor] CHECK CONSTRAINT [FK_proveedor_ciudad]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_ciudad] FOREIGN KEY([cod_ciu])
REFERENCES [dbo].[ciudad] ([cod_ciu])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_ciudad]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([cod_rol])
REFERENCES [dbo].[rol] ([cod_rol])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_rol]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_cliente] FOREIGN KEY([ced_client])
REFERENCES [dbo].[cliente] ([ced_client])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_cliente]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_usuario] FOREIGN KEY([ced_empl])
REFERENCES [dbo].[usuario] ([ced_usua])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_usuario]
GO
