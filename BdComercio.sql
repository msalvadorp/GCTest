USE [master]
GO
/****** Object:  Database [TestComercioBD]    Script Date: 13/06/2017 08:49:28 a.m. ******/
CREATE DATABASE [TestComercioBD]
GO
USE [TestComercioBD]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[IdBanco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FlgEliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[IdBanco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[IdOrdenPago] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[Monto] [decimal](9, 2) NOT NULL,
	[Moneda] [int] NOT NULL,
	[Situacion] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[FlgEliminado] [bit] NOT NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[IdOrdenPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[FlgEliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[IdTipo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[IdGrupoTipo] [int] NOT NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Banco] ON 

GO
INSERT [dbo].[Banco] ([IdBanco], [Nombre], [Direccion], [FechaRegistro], [FlgEliminado]) VALUES (1, N'BANCO BCP', N'LA MOLINA 2', CAST(N'2017-02-28 15:10:11.000' AS DateTime), 0)
GO
INSERT [dbo].[Banco] ([IdBanco], [Nombre], [Direccion], [FechaRegistro], [FlgEliminado]) VALUES (2, N'BANCO FINANDIERO', N'RICARDO PALMA', CAST(N'2017-02-28 15:16:06.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Banco] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenPago] ON 

GO
INSERT [dbo].[OrdenPago] ([IdOrdenPago], [IdSucursal], [Monto], [Moneda], [Situacion], [FechaPago], [FlgEliminado]) VALUES (1, 1, CAST(1200.00 AS Decimal(9, 2)), 100001, 101001, CAST(N'2017-02-15 00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[OrdenPago] ([IdOrdenPago], [IdSucursal], [Monto], [Moneda], [Situacion], [FechaPago], [FlgEliminado]) VALUES (2, 3, CAST(120.00 AS Decimal(9, 2)), 100002, 101003, CAST(N'2017-06-12 00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[OrdenPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursal] ON 

GO
INSERT [dbo].[Sucursal] ([IdSucursal], [IdBanco], [Nombre], [Direccion], [FechaRegistro], [FlgEliminado]) VALUES (1, 1, N'LA MOLINA', N'RAUL FERRERO', CAST(N'2017-02-28 00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[Sucursal] ([IdSucursal], [IdBanco], [Nombre], [Direccion], [FechaRegistro], [FlgEliminado]) VALUES (2, 1, N'CAMACHO', N'JAVIER PRADO', CAST(N'2017-02-28 00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[Sucursal] ([IdSucursal], [IdBanco], [Nombre], [Direccion], [FechaRegistro], [FlgEliminado]) VALUES (3, 2, N'MIRAFLORES 2', N'RICARDO PALMA', CAST(N'2017-02-28 00:00:00.000' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (100000, N'TIPO DE MONEDA', 100000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (100001, N'SOLES', 100000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (100002, N'DOLARES', 100000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (101000, N'SITUACION  ORDEN PAGO', 101000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (101001, N'PAGADA', 101000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (101002, N'DECLINADA', 101000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (101003, N'FALLIDA', 101000)
GO
INSERT [dbo].[Tipo] ([IdTipo], [Nombre], [IdGrupoTipo]) VALUES (101004, N'ANULADA', 101000)
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Actualizar un regitro a la tabla Banco
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ActualizarBanco]
(
    @IdBanco int, 
	@Nombre nvarchar(50), 
	@Direccion nvarchar(50), 
	@FechaRegistro datetime, 
	@FlgEliminado bit
) 
AS
BEGIN   
    UPDATE dbo.Banco
    SET 
        Nombre = @Nombre, Direccion = @Direccion, FechaRegistro = @FechaRegistro, FlgEliminado = @FlgEliminado
    WHERE 
        IdBanco = @IdBanco    
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarOrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Actualizar un regitro a la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ActualizarOrdenPago]
(
    @IdOrdenPago int, 
	@IdSucursal int, 
	@Monto decimal(9,2), 
	@Moneda int, 
	@Situacion int, 
	@FechaPago datetime, 
	@FlgEliminado bit
) 
AS
BEGIN   
    UPDATE dbo.OrdenPago
    SET 
        IdSucursal = @IdSucursal, Monto = @Monto, Moneda = @Moneda, Situacion = @Situacion, FechaPago = @FechaPago, FlgEliminado = @FlgEliminado
    WHERE 
        IdOrdenPago = @IdOrdenPago    
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarSucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Actualizar un regitro a la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ActualizarSucursal]
(
    @IdSucursal int, 
	@IdBanco int, 
	@Nombre nvarchar(50), 
	@Direccion nvarchar(50), 
	@FechaRegistro datetime, 
	@FlgEliminado bit
) 
AS
BEGIN   
    UPDATE dbo.Sucursal
    SET 
        IdBanco = @IdBanco, Nombre = @Nombre, Direccion = @Direccion, FechaRegistro = @FechaRegistro, FlgEliminado = @FlgEliminado
    WHERE 
        IdSucursal = @IdSucursal    
END

GO
/****** Object:  StoredProcedure [dbo].[usp_BorrarBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Eliminar un regitro a la tabla Banco
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_BorrarBanco]
(
    @IdBanco int
) 
AS
BEGIN
    UPDATE Banco 
	SET FlgEliminado = '1'
    WHERE 
    IdBanco = @IdBanco 
        
END

GO
/****** Object:  StoredProcedure [dbo].[usp_BorrarOrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Eliminar un regitro a la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_BorrarOrdenPago]
(
    @IdOrdenPago int
) 
AS
BEGIN
    
    UPDATE dbo.OrdenPago
	SET FlgEliminado = '1'
    WHERE 
    IdOrdenPago = @IdOrdenPago 
        
END

GO
/****** Object:  StoredProcedure [dbo].[usp_BorrarSucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Eliminar un regitro a la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_BorrarSucursal]
(
    @IdSucursal int
) 
AS
BEGIN
    
    UPDATE dbo.Sucursal
	SET FlgEliminado = '1'
    WHERE 
    IdSucursal = @IdSucursal 
        
END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Agregar un regitro a la tabla Banco
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_InsertarBanco]
(
    @Nombre nvarchar(50), 
	@Direccion nvarchar(50), 
	@FechaRegistro datetime, 
	@FlgEliminado bit
) 
AS
BEGIN
    INSERT INTO dbo.Banco
    (
        Nombre, Direccion, FechaRegistro, FlgEliminado
    )
    VALUES
    (
        @Nombre, @Direccion, @FechaRegistro, @FlgEliminado
    )
    SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarOrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Agregar un regitro a la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_InsertarOrdenPago]
(
    @IdSucursal int, 
	@Monto decimal(9,2), 
	@Moneda int, 
	@Situacion int, 
	@FechaPago datetime, 
	@FlgEliminado bit
) 
AS
BEGIN
    INSERT INTO dbo.OrdenPago
    (
        IdSucursal, Monto, Moneda, Situacion, FechaPago, FlgEliminado
    )
    VALUES
    (
        @IdSucursal, @Monto, @Moneda, @Situacion, @FechaPago, @FlgEliminado
    )
    SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarSucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Agregar un regitro a la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_InsertarSucursal]
(
    @IdBanco int, 
	@Nombre nvarchar(50), 
	@Direccion nvarchar(50), 
	@FechaRegistro datetime, 
	@FlgEliminado bit
) 
AS
BEGIN
    INSERT INTO dbo.Sucursal
    (
        IdBanco, Nombre, Direccion, FechaRegistro, FlgEliminado
    )
    VALUES
    (
        @IdBanco, @Nombre, @Direccion, @FechaRegistro, @FlgEliminado
    )
    SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ListarBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla Banco
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarBanco]
(
@Filtro NVARCHAR(25)
)
AS
BEGIN
	DECLARE @Parametro NVARCHAR(150)
	SET @Parametro = '%' + @Filtro + '%'
       SELECT TOP 100 IdBanco, Nombre, Direccion, FechaRegistro, FlgEliminado 
       FROM dbo.Banco
       WHERE FlgEliminado = '0' AND 
	 Nombre LIKE @Parametro
	
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ListarOrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarOrdenPago]
(
	@IdSucursal INT,
	@TipoMoneda INT,
	@TipoSituacion INT
)
AS
BEGIN    
       SELECT TOP 100 A.IdOrdenPago, A.IdSucursal, A.Monto, A.Moneda, A.Situacion, A.FechaPago, A.FlgEliminado,
	   'Banco: ' + C.Nombre + ' - Sucursal: ' + B.Nombre AS NombreSucursalCompleta, 
	   D.Nombre AS NombreMoneda,
	   E.Nombre AS NombreSituacion
       FROM dbo.OrdenPago A 
       INNER JOIN Sucursal B 
       ON (A.IdSucursal = b.IdSucursal)
       INNER JOIN Banco C
       ON (B.IdBanco = C.IdBanco)
       INNER JOIN Tipo D
	   ON (A.Moneda = D.IdTipo)
	   INNER JOIN Tipo E
	   ON (A.Situacion = E.IdTipo)
       WHERE A.FlgEliminado = '0'
       AND (A.IdSucursal = @IdSucursal OR @IdSucursal = 0)
       AND (A.Moneda = @TipoMoneda OR @TipoMoneda = 0 )
       AND (A.Situacion = @TipoSituacion OR @TipoSituacion = 0)
END


GO
/****** Object:  StoredProcedure [dbo].[usp_ListarOrdenPago_LocalMoneda]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarOrdenPago_LocalMoneda]
(
@IdSucursal INT,
@Moneda INT
)
AS
BEGIN    
       SELECT TOP 100 IdOrdenPago, IdSucursal, Monto, Moneda, Situacion, FechaPago, FlgEliminado 
       FROM dbo.OrdenPago
       WHERE 
	   (IdSucursal = @IdSucursal OR @IdSucursal = 0)
	   AND (Moneda = @Moneda OR @Moneda = 0)
	   AND FlgEliminado = '0'
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ListarSucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarSucursal]
AS
BEGIN    
       SELECT A.IdSucursal, A.IdBanco, A.Nombre, A.Direccion, A.FechaRegistro, A.FlgEliminado, B.Nombre AS NombreBanco
       FROM dbo.Sucursal A INNER JOIN Banco B
       ON (A.IdBanco = B.IdBanco)
       WHERE A.FlgEliminado = '0'

END

GO
/****** Object:  StoredProcedure [dbo].[usp_ListarSucursalPorBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarSucursalPorBanco]
(
@IdBanco INT
)
AS
BEGIN    
       SELECT TOP 100 IdSucursal, IdBanco, Nombre, Direccion, FechaRegistro, FlgEliminado 
       FROM dbo.Sucursal
	   WHERE 
	   (IdBanco = @IdBanco OR @IdBanco = 0)
       AND FlgEliminado = '0'
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ListarTipoPorGrupo]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Listar los registros de la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ListarTipoPorGrupo]
(
@IdGrupoTipo INT

)
AS
BEGIN    
     SELECT [IdTipo]
      ,[Nombre]
      ,[IdGrupoTipo]
  FROM [TestComercioBD].[dbo].[Tipo]
WHERE IdGrupoTipo = @IdGrupoTipo
AND IdTipo > IdGrupoTipo

END


GO
/****** Object:  StoredProcedure [dbo].[usp_ObtenerBanco]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Obtener un regitro a la tabla Banco
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ObtenerBanco]
(
    @IdBanco int
) 
AS
BEGIN
    
        SELECT IdBanco, Nombre, Direccion, FechaRegistro, FlgEliminado 
        FROM dbo.Banco 
        WHERE IdBanco = @IdBanco 
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ObtenerOrdenPago]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Obtener un regitro a la tabla OrdenPago
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ObtenerOrdenPago]
(
    @IdOrdenPago int
) 
AS
BEGIN
    
        SELECT IdOrdenPago, IdSucursal, Monto, Moneda, Situacion, FechaPago, FlgEliminado 
        FROM dbo.OrdenPago 
        WHERE IdOrdenPago = @IdOrdenPago 
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ObtenerSucursal]    Script Date: 13/06/2017 08:49:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Sistema         :   SISTEMA INTEGRADO DE GESTION
Modulo          :   MODULO DE GESTION INTEGRADO
Objetivo        :   Obtener un regitro a la tabla Sucursal
Desarrollado por:   Miguel
Fecha Creacion  :   27/02/2017
*/
CREATE PROCEDURE [dbo].[usp_ObtenerSucursal]
(
    @IdSucursal int
) 
AS
BEGIN
    
        SELECT IdSucursal, IdBanco, Nombre, Direccion, FechaRegistro, FlgEliminado 
        FROM dbo.Sucursal 
        WHERE IdSucursal = @IdSucursal 
END