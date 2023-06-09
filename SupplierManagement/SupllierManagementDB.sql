USE [master]
GO
/****** Object:  Database [SupplierManagementDb]    Script Date: 4/10/2023 8:42:32 PM ******/
CREATE DATABASE [SupplierManagementDb] ON  PRIMARY 
( NAME = N'SupplierManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\SupplierManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SupplierManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\SupplierManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupplierManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupplierManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupplierManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupplierManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupplierManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupplierManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupplierManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [SupplierManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [SupplierManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupplierManagementDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SupplierManagementDb', N'ON'
GO
USE [SupplierManagementDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/10/2023 8:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 4/10/2023 8:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[ContactPhone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409184656_InitialCreate', N'7.0.4')
GO
INSERT [dbo].[Suppliers] ([Id], [Name], [ContactName], [ContactPhone], [Email], [Address]) VALUES (N'5f5014c3-c599-47e4-ddc9-08db39347f80', N'SKproducts', N'Ashan', N'0775281377', N'kg@gmail.com', N'Agalwatta')
GO
USE [master]
GO
ALTER DATABASE [SupplierManagementDb] SET  READ_WRITE 
GO
