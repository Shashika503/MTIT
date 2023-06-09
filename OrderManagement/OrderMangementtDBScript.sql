USE [master]
GO
/****** Object:  Database [RestaurantDb]    Script Date: 4/10/2023 8:40:40 PM ******/
CREATE DATABASE [RestaurantDb] ON  PRIMARY 
( NAME = N'RestaurantDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\RestaurantDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestaurantDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER2016\MSSQL\DATA\RestaurantDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RestaurantDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantDb] SET RECOVERY FULL 
GO
ALTER DATABASE [RestaurantDb] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RestaurantDb', N'ON'
GO
USE [RestaurantDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/10/2023 8:40:40 PM ******/
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
/****** Object:  Table [dbo].[OrderItems]    Script Date: 4/10/2023 8:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ItemName] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/10/2023 8:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[DeliveryAddress] [nvarchar](max) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[DiscountedTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409014937_InitialCreate', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409030712_updateindebcontext', N'7.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230409151025_Adddiscount', N'7.0.4')
GO
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ItemName], [Quantity], [UnitPrice]) VALUES (N'4ad29ce9-cc19-43a5-abd1-08db38e46471', N'8dd17068-eb22-40db-5fcc-08db38e4645f', N'Mix masala chicken rice', 2, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ItemName], [Quantity], [UnitPrice]) VALUES (N'a5f28122-0912-4151-3efa-08db390236b3', N'b82af966-36b2-4ed4-8d34-08db390236ae', N'Ice Milo', 1, CAST(700.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ItemName], [Quantity], [UnitPrice]) VALUES (N'76d61f95-f180-4617-7233-08db390dcd5f', N'120d06b2-6d26-4996-ec19-08db390dcd5b', N'string', 3, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ItemName], [Quantity], [UnitPrice]) VALUES (N'fa752be1-a2aa-462e-453c-08db3912ca04', N'176f2e3e-87ef-409b-745f-08db3912c9f5', N'stringhoppers', 6, CAST(230.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerName], [DeliveryAddress], [Discount], [DiscountedTotal]) VALUES (N'8dd17068-eb22-40db-5fcc-08db38e4645f', CAST(N'2023-04-09T02:05:56.2420000' AS DateTime2), N'Adarsha', N'Colombo', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerName], [DeliveryAddress], [Discount], [DiscountedTotal]) VALUES (N'b82af966-36b2-4ed4-8d34-08db390236ae', CAST(N'2023-04-09T13:55:11.1140000' AS DateTime2), N'Ashan', N'Negambo', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerName], [DeliveryAddress], [Discount], [DiscountedTotal]) VALUES (N'120d06b2-6d26-4996-ec19-08db390dcd5b', CAST(N'2023-04-09T15:18:20.4330000' AS DateTime2), N'Lasith', N'Malabe', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerName], [DeliveryAddress], [Discount], [DiscountedTotal]) VALUES (N'176f2e3e-87ef-409b-745f-08db3912c9f5', CAST(N'2023-04-09T15:54:08.5760000' AS DateTime2), N'Shashika', N'Colombo', CAST(15.00 AS Decimal(18, 2)), CAST(1173.00 AS Decimal(18, 2)))
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 4/10/2023 8:40:41 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [DiscountedTotal]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
USE [master]
GO
ALTER DATABASE [RestaurantDb] SET  READ_WRITE 
GO
