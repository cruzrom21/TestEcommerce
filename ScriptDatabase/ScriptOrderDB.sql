USE [master]
GO
/****** Object:  Database [OrderManagementDB]    Script Date: 21/10/2024 01:10:38 p. m. ******/
CREATE DATABASE [OrderManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OrderManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OrderManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OrderManagementDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OrderManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [OrderManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OrderManagementDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [OrderManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OrderManagementDB]
GO
/****** Object:  User [empleando]    Script Date: 21/10/2024 01:10:38 p. m. ******/
CREATE USER [empleando] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 21/10/2024 01:10:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 21/10/2024 01:10:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (1, 3, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (2, 3, 2, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (3, 4, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (4, 4, 2, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (5, 5, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (6, 5, 2, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (7, 6, 1, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (8, 6, 2, 2, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (9, 1, 1, 1, CAST(1200.50 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (10, 1, 3, 2, CAST(199.95 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (11, 1, 10, 1, CAST(59.95 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (12, 2, 7, 1, CAST(850.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (13, 3, 6, 1, CAST(399.99 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (14, 3, 9, 2, CAST(29.99 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (15, 4, 5, 1, CAST(299.99 AS Decimal(18, 2)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [UnitPrice]) VALUES (16, 5, 9, 1, CAST(29.99 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (1, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-05-05T12:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (2, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-05-05T12:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (3, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-10-20T23:27:11.027' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (4, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-10-20T23:27:11.027' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (5, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-10-20T23:27:11.027' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (6, 1, CAST(500.00 AS Decimal(18, 2)), N'Create', CAST(N'2024-10-20T23:27:11.027' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (7, 1, CAST(1499.90 AS Decimal(18, 2)), N'Pending', CAST(N'2024-10-20T10:00:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (8, 2, CAST(850.00 AS Decimal(18, 2)), N'Shipped', CAST(N'2024-10-19T14:30:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (9, 3, CAST(999.95 AS Decimal(18, 2)), N'Completed', CAST(N'2024-10-18T16:15:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (10, 4, CAST(299.99 AS Decimal(18, 2)), N'Cancelled', CAST(N'2024-10-17T12:45:00.000' AS DateTime))
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [TotalAmount], [Status], [OrderDate]) VALUES (11, 5, CAST(49.99 AS Decimal(18, 2)), N'Pending', CAST(N'2024-10-21T09:20:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
USE [master]
GO
ALTER DATABASE [OrderManagementDB] SET  READ_WRITE 
GO
