USE [master]
GO
/****** Object:  Database [ProductCatalogDB]    Script Date: 21/10/2024 01:11:38 p. m. ******/
CREATE DATABASE [ProductCatalogDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductCatalogDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProductCatalogDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductCatalogDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProductCatalogDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProductCatalogDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductCatalogDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductCatalogDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ProductCatalogDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductCatalogDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductCatalogDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductCatalogDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductCatalogDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductCatalogDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductCatalogDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductCatalogDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductCatalogDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductCatalogDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductCatalogDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductCatalogDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProductCatalogDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProductCatalogDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProductCatalogDB]
GO
/****** Object:  User [empleando]    Script Date: 21/10/2024 01:11:39 p. m. ******/
CREATE USER [empleando] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 21/10/2024 01:11:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 


INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (1, N'Laptop', N'Laptop with 16GB RAM and 512GB SSD', CAST(1200.50 AS Decimal(18, 2)), 10)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (2, N'Smartphone', N'Latest model with 5G support', CAST(899.99 AS Decimal(18, 2)), 25)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (3, N'Headphones', N'Noise-cancelling over-ear headphones', CAST(199.95 AS Decimal(18, 2)), 50)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (4, N'Gaming Console', N'Next-gen console with 1TB storage', CAST(499.99 AS Decimal(18, 2)), 15)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (5, N'Smartwatch', N'Fitness tracking and heart rate monitor', CAST(299.99 AS Decimal(18, 2)), 30)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (6, N'Tablet', N'10.5-inch display with 128GB storage', CAST(399.99 AS Decimal(18, 2)), 20)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (7, N'Camera', N'DSLR with 24MP resolution and 4K video', CAST(850.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (8, N'External Hard Drive', N'2TB USB 3.0 external hard drive', CAST(99.95 AS Decimal(18, 2)), 100)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (9, N'Wireless Mouse', N'Ergonomic wireless mouse with 2-year battery life', CAST(29.99 AS Decimal(18, 2)), 200)
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Stock]) VALUES (10, N'Bluetooth Speaker', N'Portable speaker with waterproof design', CAST(59.95 AS Decimal(18, 2)), 75)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
USE [master]
GO
ALTER DATABASE [ProductCatalogDB] SET  READ_WRITE 
GO
