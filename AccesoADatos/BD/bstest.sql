USE [master]
GO
/****** Object:  Database [PruebaSD]    Script Date: 12/02/2021 11:06:16 a. m. ******/
CREATE DATABASE [PruebaSD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaSD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PruebaSD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaSD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PruebaSD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PruebaSD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaSD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaSD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaSD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaSD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaSD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaSD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaSD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaSD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaSD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaSD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaSD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaSD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaSD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaSD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaSD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaSD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaSD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaSD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaSD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaSD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaSD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaSD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaSD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaSD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PruebaSD] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaSD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaSD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaSD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaSD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaSD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaSD] SET QUERY_STORE = OFF
GO
USE [PruebaSD]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/02/2021 11:06:16 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [PruebaSD] SET  READ_WRITE 
GO
