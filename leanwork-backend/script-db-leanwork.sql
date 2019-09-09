USE [master]
GO
/****** Object:  Database [LeanWork]    Script Date: 09/09/2019 15:25:01 ******/
CREATE DATABASE [LeanWork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LeanWork', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LeanWork.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LeanWork_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\LeanWork_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LeanWork] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeanWork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeanWork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeanWork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeanWork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeanWork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeanWork] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeanWork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeanWork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeanWork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeanWork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeanWork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeanWork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeanWork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeanWork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeanWork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeanWork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LeanWork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeanWork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeanWork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeanWork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeanWork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeanWork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeanWork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeanWork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LeanWork] SET  MULTI_USER 
GO
ALTER DATABASE [LeanWork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeanWork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeanWork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeanWork] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LeanWork] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LeanWork] SET QUERY_STORE = OFF
GO
USE [LeanWork]
GO
/****** Object:  Table [dbo].[Candidato]    Script Date: 09/09/2019 15:25:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Curriculo] [varchar](255) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Candidato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidatoTecnologia]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidatoTecnologia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCandidato] [int] NULL,
	[IdTecnologia] [int] NULL,
 CONSTRAINT [PK_CandidatoTecnologia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidatoVaga]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidatoVaga](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCandidato] [int] NULL,
	[IdVaga] [int] NULL,
 CONSTRAINT [PK_CandidatoVaga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NULL,
	[QuantidadeVagas] [int] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaTecnologia]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaTecnologia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NULL,
	[IdTecnologia] [int] NULL,
	[Peso] [int] NULL,
 CONSTRAINT [PK_EmpresaTecnologia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpresaVaga]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpresaVaga](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NULL,
	[IdVaga] [int] NULL,
 CONSTRAINT [PK_EmpresaVaga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tecnologia]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tecnologia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NULL,
	[Peso] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Tecnologia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaga]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaga](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NULL,
	[Nome] [varchar](250) NULL,
	[Descricao] [varchar](1000) NULL,
	[Quantidade] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Vaga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VagaTecnologia]    Script Date: 09/09/2019 15:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VagaTecnologia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVaga] [int] NULL,
	[IdTecnologia] [int] NULL,
	[IdEmpresa] [int] NULL,
	[Peso] [int] NULL,
 CONSTRAINT [PK_VagaTecnologia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Candidato] ADD  CONSTRAINT [DF_Candidato_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Tecnologia] ADD  CONSTRAINT [DF_Tecnologia_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Vaga] ADD  CONSTRAINT [DF_Vaga_Status]  DEFAULT ((1)) FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [LeanWork] SET  READ_WRITE 
GO
