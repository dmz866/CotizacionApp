USE [master]
GO
/****** Object:  Database [CotizacionApp]    Script Date: 16/07/2020 19:52:18 ******/
CREATE DATABASE [CotizacionApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CotizacionApp', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CotizacionApp.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CotizacionApp_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\CotizacionApp_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CotizacionApp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CotizacionApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CotizacionApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CotizacionApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CotizacionApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CotizacionApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CotizacionApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [CotizacionApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CotizacionApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CotizacionApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CotizacionApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CotizacionApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CotizacionApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CotizacionApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CotizacionApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CotizacionApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CotizacionApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CotizacionApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CotizacionApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CotizacionApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CotizacionApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CotizacionApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CotizacionApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CotizacionApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CotizacionApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CotizacionApp] SET  MULTI_USER 
GO
ALTER DATABASE [CotizacionApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CotizacionApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CotizacionApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CotizacionApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CotizacionApp] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CotizacionApp]
GO
/****** Object:  Table [dbo].[LookUp]    Script Date: 16/07/2020 19:52:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookUp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
	[Label] [nvarchar](100) NOT NULL,
	[Group] [nvarchar](20) NULL,
 CONSTRAINT [PK_LookUp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaccion]    Script Date: 16/07/2020 19:52:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [money] NOT NULL,
	[Moneda] [nvarchar](20) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Transaccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[LookUp] ON 

INSERT [dbo].[LookUp] ([Id], [Value], [Label], [Group]) VALUES (1, N'dolar', N'Dolar', N'moneda')
INSERT [dbo].[LookUp] ([Id], [Value], [Label], [Group]) VALUES (2, N'real', N'Real', N'moneda')
SET IDENTITY_INSERT [dbo].[LookUp] OFF
USE [master]
GO
ALTER DATABASE [CotizacionApp] SET  READ_WRITE 
GO
