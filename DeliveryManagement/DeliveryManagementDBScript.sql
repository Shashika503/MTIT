USE [master]
GO
/****** Object:  Database [DeliveryManagementDb]    Script Date: 4/10/2023 8:45:19 PM ******/
CREATE DATABASE [DeliveryManagementDb] ON  PRIMARY 
( NAME = N'DeliveryManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\DeliveryManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeliveryManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\DeliveryManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeliveryManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeliveryManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeliveryManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeliveryManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DeliveryManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeliveryManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeliveryManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [DeliveryManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [DeliveryManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeliveryManagementDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DeliveryManagementDb', N'ON'
GO
USE [DeliveryManagementDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/10/2023 8:45:19 PM ******/
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
/****** Object:  Table [dbo].[Deliveries]    Script Date: 4/10/2023 8:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliveries](
	[Id] [uniqueidentifier] NOT NULL,
	[DeliveryPersonName] [nvarchar](max) NOT NULL,
	[DeliveryVehicleNumber] [nvarchar](max) NOT NULL,
	[DeliveryDate] [datetime2](7) NOT NULL,
	[DeliveryStatus] [nvarchar](100) NOT NULL,
	[DeliveryAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Deliveries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409210410_DeliveryManagement', N'7.0.4')
GO
INSERT [dbo].[Deliveries] ([Id], [DeliveryPersonName], [DeliveryVehicleNumber], [DeliveryDate], [DeliveryStatus], [DeliveryAddress]) VALUES (N'731b42d2-cbc5-4b28-ce1a-08db39424427', N'shashika', N'KA-XXXX', CAST(N'2023-04-09T21:34:13.0750000' AS DateTime2), N'delivered', N'Colombo')
GO
USE [master]
GO
ALTER DATABASE [DeliveryManagementDb] SET  READ_WRITE 
GO
