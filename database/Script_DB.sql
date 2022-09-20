CREATE DATABASE El_Sabroso_DB




USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[PERMISOS]    Script Date: 9/11/2022 10:15:25 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[PERMISOS](
    [Id_permiso] [int] NOT NULL,
    [nombre] [varchar](50) NULL,
    [descripcion] [varchar](50) NULL,
CONSTRAINT [PK_PERMISOS] PRIMARY KEY CLUSTERED
(
    [Id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[PRODUCTOS]    Script Date: 9/11/2022 10:16:48 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO


USE [El_Sabroso_DB]
GO


CREATE TABLE [dbo].[PRODUCTOS](
    [Id_producto] [int] IDENTITY (1,1) NOT NULL,
    [nombre] [varchar](250) NULL,
    [descripcion] [varchar](250) NULL,
    [precio] [float] NULL,
    [categoria] [varchar](50) NULL,
    [id_proveedor] [int] NULL,
	[activo] [varchar](1) NULL,
	FOREIGN KEY (Id_proveedor) REFERENCES dbo.PROVEEDORES(Id_proveedor),

CONSTRAINT [PK_PRODUCTOS] PRIMARY KEY CLUSTERED
(
    [Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[PROVEEDORES]    Script Date: 9/11/2022 10:17:01 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO

USE [El_Sabroso_DB]
GO

CREATE TABLE [dbo].[PROVEEDORES](
    [Id_proveedor] [int] IDENTITY (1,1) NOT NULL,
    [nombre] [varchar](250) NULL,
    [apellido] [varchar](250) NULL,
    [email] [varchar](250) NULL,
    [telefono] [varchar](250) NULL,
    [direccion] [varchar](250) NULL,
    [ciudad] [varchar](250) NULL,
    [fecha_alta] [date] NULL,
    [activo] [bit] NULL,
CONSTRAINT [PK_PROVEEDORES] PRIMARY KEY CLUSTERED
(
    [Id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO


USE [El_Sabroso_DB]
GO


CREATE TABLE [dbo].[PRODUCTOS](
    [Id_producto] [int] IDENTITY (1,1) NOT NULL,
    [nombre] [varchar](250) NULL,
    [descripcion] [varchar](250) NULL,
    [precio] [float] NULL,
    [categoria] [varchar](50) NULL,
    [id_proveedor] [int] NULL,
	[activo] [varchar](1) NULL,
	FOREIGN KEY (Id_proveedor) REFERENCES dbo.PROVEEDORES(Id_proveedor),

CONSTRAINT [PK_PRODUCTOS] PRIMARY KEY CLUSTERED
(
    [Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[STOCK]    Script Date: 9/11/2022 10:17:23 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[STOCK](
    [Id_stock] [int] NOT NULL,
    [fecha] [date] NULL,
    [Id_producto] [int] NULL,
    [stock_actual] [varchar](50) NULL,
CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED
(
    [Id_stock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[USUARIOS]    Script Date: 9/11/2022 10:17:36 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[USUARIOS](
    [Id_usuario] [int] NOT NULL,
    [Id_permiso] [int] NULL,
    [usuario] [varchar](50) NULL,
    [password] [varchar](20) NULL,
    [email] [varchar](50) NULL,
    [activo] [bit] NULL,
CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED
(
    [Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [El_Sabroso_DB]
GO



/** Object:  Table [dbo].[VENTAS]    Script Date: 9/11/2022 10:17:48 PM **/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[VENTAS](
    [Id_venta] [int] NOT NULL,
    [fecha] [date] NULL,
    [cantidad] [varchar](50) NULL,
    [monto] [varchar](20) NULL,
    [nombre_cliente] [varchar](50) NULL,
    [apellido_cliente] [varchar](50) NULL,
    [email_cliente] [varchar](50) NULL,
    [telefono_cliente] [varchar](50) NULL,
    [id_producto] [int] NULL,
    [id_usuario] [int] NULL,
    [id_stock] [int] NULL,
CONSTRAINT [PK_VENTAS] PRIMARY KEY CLUSTERED
(
    [Id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [El_Sabroso_DB]
GO

INSERT INTO dbo.PROVEEDORES(nombre,apellido,email,telefono,direccion,ciudad,fecha_alta,activo)
VALUES
('Ruben','Diaz','rdiaz@gmail.com','351777432','oncativo 1320','Cordoba','12-08-2022','1'),
('Renzo','Andres','rdiaz@gmail.com','351777432','oncativo 1320','Cordoba','12-08-2022','1'),
('Gonzalo','Catrina','rdiaz@gmail.com','351777432','oncativo 1320','Cordoba','12-08-2022','1'),
('Nicolas','Cirilo','rdiaz@gmail.com','351777432','oncativo 1320','Cordoba','12-08-2022','1')
USE [El_Sabroso_DB]
GO
INSERT INTO dbo.PRODUCTOS(nombre,descripcion,precio,categoria,id_proveedor,activo)
VALUES
('Factura','crema','50','dulce',1,'S'),
('sandwich','doble','220','Salado',1,'N'),
('alfajor','doble','150','dulce',1,'S'),
('alfajor','triple','300','dulce',4,'S'),
('alfajor','cuadruple','400','dulce',2,'S'),
('medialuna','triple','300','dulce',3,'N'),
('medialuna','cuadruple','400','dulce',2,'N')



select * from dbo.PRODUCTOS
select * from dbo.PROVEEDORES

SELECT P.nombre as "Nombre producto" ,C.nombre As "Nombre proveedor"
from PRODUCTOS P
Left Join PROVEEDORES C
on P.Id_proveedor = C.Id_proveedor;



INSERT INTO dbo.USUARIOS (Id_usuario,Id_permiso,usuario,password,email,activo)
VALUES
('3','3','ADMIN','123','admin@elsabroso.com','true')



