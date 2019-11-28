USE [DBDies]
GO

/****** Object:  UserDefinedTableType [dbo].[TCL0051Type]    Script Date: 28/11/2019 06:15:36 ******/
DROP TYPE [dbo].[TCL0051Type]
GO

/****** Object:  UserDefinedTableType [dbo].[TCL0051Type]    Script Date: 28/11/2019 06:15:36 ******/
CREATE TYPE [dbo].[TCL0051Type] AS TABLE(
	[lglin] [int] NULL,
	[lgnumi] [int] NULL,
	[lgtcl3cpro] [int] NULL,
	[descripcion] [nvarchar](100) NULL,
	[lgcant] [decimal](18, 2) NULL,
	[lgpc] [decimal](18, 2) NULL,
	[lgpv] [decimal](18, 2) NULL,
	[lgpvSocio] [decimal](18, 2) NULL,
	[lgpvInterno] [decimal](18, 2) NULL,
	[precioTotal] [decimal](18, 2) NULL,
	[lgstocka] [decimal](18, 2) NULL,
	[lgstockf] [decimal](18, 2) NULL,
	[estado] [int] NULL
)
GO


