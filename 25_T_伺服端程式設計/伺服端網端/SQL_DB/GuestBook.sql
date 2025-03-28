USE [master]
GO
/****** Object:  Database [GuestBook]    Script Date: 2025/3/12 上午 11:34:55 ******/
CREATE DATABASE [GuestBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GuestBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GuestBook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GuestBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GuestBook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GuestBook] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GuestBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GuestBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GuestBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GuestBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GuestBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GuestBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [GuestBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GuestBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GuestBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GuestBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GuestBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GuestBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GuestBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GuestBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GuestBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GuestBook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GuestBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GuestBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GuestBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GuestBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GuestBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GuestBook] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GuestBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GuestBook] SET RECOVERY FULL 
GO
ALTER DATABASE [GuestBook] SET  MULTI_USER 
GO
ALTER DATABASE [GuestBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GuestBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GuestBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GuestBook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GuestBook] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GuestBook] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GuestBook', N'ON'
GO
ALTER DATABASE [GuestBook] SET QUERY_STORE = ON
GO
ALTER DATABASE [GuestBook] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GuestBook]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2025/3/12 上午 11:34:55 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2025/3/12 上午 11:34:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [nvarchar](36) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](20) NOT NULL,
	[Photo] [nvarchar](44) NULL,
	[ImageType] [nvarchar](max) NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2025/3/12 上午 11:34:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Account] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReBook]    Script Date: 2025/3/12 上午 11:34:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReBook](
	[ReBookID] [nvarchar](36) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](20) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[BookID] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_ReBook] PRIMARY KEY CLUSTERED 
(
	[ReBookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241227034337_InitialCreate', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250107005445_AddLoginTable', N'8.0.11')
GO
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'0028f7bd-58fc-478a-8c62-cfe1b50a6943', N'Taipei夜市Top10', N'台北夜市
Top10
誰敢爭鋒', N'Taipei人', N'0028f7bd-58fc-478a-8c62-cfe1b50a6943.jpg', N'image/jpeg', CAST(N'2025-01-06T15:28:06.9433097' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'0173afab-1359-4514-8bb3-a52d56ce93ec', N'夜市王爭霸戰', N'夜市的聲量', N'吃夜市', N'0173afab-1359-4514-8bb3-a52d56ce93ec.jpg', N'image/jpeg', CAST(N'2025-01-06T15:33:13.5988852' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'1b292eb1-8ded-47c4-9d13-d183d02bfb23', N'山水有相逢', N'美景如畫，山高水清。', N'Map', N'1b292eb1-8ded-47c4-9d13-d183d02bfb23.jpg', N'image/jpeg', CAST(N'2025-01-02T16:27:24.5690403' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'3ee146c9-b6c1-4d05-8c47-2e80e4a78343', N'鴨油麻婆豆腐', N'這太下飯了！可以吃好幾碗白飯', N'王小花', N'3ee146c9-b6c1-4d05-8c47-2e80e4a78343.jpg', N'image/jpeg', CAST(N'2024-12-27T11:44:23.3803599' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'554d8130-52d4-48dc-b29a-727a4ea43468', N'櫻桃鴨', N'看起來好好吃哦!', N'Jack', N'554d8130-52d4-48dc-b29a-727a4ea43468.jpg', N'image/jpeg', CAST(N'2024-12-27T11:44:23.3580713' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'842aeffc-8d25-45f3-8093-e32b33d62b0c', N'櫻桃鴨握壽司', N'握壽司就是好吃！', N'王小花', N'842aeffc-8d25-45f3-8093-e32b33d62b0c.jpg', N'image/jpeg', CAST(N'2024-12-27T11:44:23.3803603' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'8703c6e2-d9aa-47d8-8d54-6d78d363c28c', N'測試', N'測試
測試1
測試2
換行測試
結尾。', N'測試人', NULL, NULL, CAST(N'2024-12-31T08:41:52.4369166' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'b2dd8b38-117f-4c7e-9e05-d679e5020cef', N'三杯鴨', N'鴨肉鮮甜', N'Jack', N'b2dd8b38-117f-4c7e-9e05-d679e5020cef.jpg', N'image/jpeg', CAST(N'2024-12-27T11:44:23.3803606' AS DateTime2))
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Author], [Photo], [ImageType], [TimeStamp]) VALUES (N'dcaa80aa-bbec-44a7-aa25-73c8030b3d61', N'鴨油高麗菜', N'好像稍微有點油....', N'Mary', N'dcaa80aa-bbec-44a7-aa25-73c8030b3d61.jpg', N'image/jpeg', CAST(N'2024-12-27T11:44:23.3803574' AS DateTime2))
GO
INSERT [dbo].[Login] ([Account], [Password]) VALUES (N'abcd123', N'12345678')
INSERT [dbo].[Login] ([Account], [Password]) VALUES (N'admin', N'12345678')
GO
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'0b0da1e8-bd05-4c95-8d9a-eec45cb29b85', N'佛跳牆是什麼遠古時代的食物', N'00後', CAST(N'2025-01-06T15:28:53.3978222' AS DateTime2), N'0028f7bd-58fc-478a-8c62-cfe1b50a6943')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'2d4929fc-ddd8-443d-bb69-4f7f2c8fe41e', N'123
1245
45887
1234', N'3號', CAST(N'2025-01-06T15:40:59.0574742' AS DateTime2), N'0173afab-1359-4514-8bb3-a52d56ce93ec')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'2d813946-7a79-4a10-8a7b-ccd1498636d9', N'我也是喜歡生魚片的握壽司，但這個也不錯', N'王小花', CAST(N'2024-12-27T11:44:23.6754920' AS DateTime2), N'842aeffc-8d25-45f3-8093-e32b33d62b0c')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'38ab68a2-5edc-4ddd-9d23-6230d99a3d0b', N'我也覺得好吃', N'小蘭', CAST(N'2024-12-27T11:44:23.6754290' AS DateTime2), N'554d8130-52d4-48dc-b29a-727a4ea43468')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'3947ec22-721c-4a99-ba77-0f11af8a4f40', N'12345', N'123', CAST(N'2025-01-06T15:40:31.6481429' AS DateTime2), N'0173afab-1359-4514-8bb3-a52d56ce93ec')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'440f939e-ae7a-4d75-af6b-1b79e9398c92', N'我還是喜歡生魚片的握壽司', N'嫩嫩', CAST(N'2024-12-27T11:44:23.6754918' AS DateTime2), N'842aeffc-8d25-45f3-8093-e32b33d62b0c')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'459ca882-6ba7-473e-beef-2c008593d5ac', N'上面都什麼人留言', N'純人類', CAST(N'2025-01-06T15:43:25.8160151' AS DateTime2), N'1b292eb1-8ded-47c4-9d13-d183d02bfb23')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'4b61ca04-88df-4f19-8ffa-2e29fb9654db', N'又香又油', N'小黑', CAST(N'2024-12-27T11:44:23.6754914' AS DateTime2), N'dcaa80aa-bbec-44a7-aa25-73c8030b3d61')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'4fda899e-5ba2-474d-a8fb-6b01aa933952', N'吃一個鴨香四溢，吃第二個，油膩的想吐。', N'David', CAST(N'2025-01-02T13:26:46.7546461' AS DateTime2), N'842aeffc-8d25-45f3-8093-e32b33d62b0c')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'5f05164f-2683-4311-ac71-8013f249a87d', N'以購買，孩子很喜歡', N'地方的媽媽', CAST(N'2025-01-06T15:31:30.0734854' AS DateTime2), N'0028f7bd-58fc-478a-8c62-cfe1b50a6943')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'798b0ff2-ebb7-46dc-9980-1defee803b49', N'協助測試
協助   測試
協助      測試



測試
結尾。', N'未王人', CAST(N'2024-12-31T11:43:08.7214843' AS DateTime2), N'8703c6e2-d9aa-47d8-8d54-6d78d363c28c')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'79bfa000-24b1-45bc-a475-27a01471192b', N'山高水深', N'想跳', CAST(N'2025-01-06T15:41:34.9707819' AS DateTime2), N'1b292eb1-8ded-47c4-9d13-d183d02bfb23')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'8173badf-81dc-459c-8d6a-132b2b03e887', N'在台南人眼裡都是噴', N'抬南人', CAST(N'2025-01-06T15:31:03.1942293' AS DateTime2), N'0028f7bd-58fc-478a-8c62-cfe1b50a6943')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'9b2cfa01-ed2b-4a03-afa8-7c6287a3c4a7', N'已購買，小孩很喜翻', N'地方的阿嘛', CAST(N'2025-01-06T15:32:11.6568749' AS DateTime2), N'0028f7bd-58fc-478a-8c62-cfe1b50a6943')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'a0816114-ac15-462b-bc05-84575b90423c', N'麻糬真的好Q好吃', N'QQ好吃妹噗茶', CAST(N'2025-01-06T15:30:08.9156280' AS DateTime2), N'0028f7bd-58fc-478a-8c62-cfe1b50a6943')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'a4069f1f-4ec1-432f-9571-aefa15689e5f', N'終於找到入口處了', N'穿越者', CAST(N'2025-01-06T15:42:26.4962096' AS DateTime2), N'1b292eb1-8ded-47c4-9d13-d183d02bfb23')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'b2dd8b38-117f-4c7e-9e05-d679e5020cef', N'你最好餓死', N'小蘭', CAST(N'2024-12-27T11:44:23.6754911' AS DateTime2), N'554d8130-52d4-48dc-b29a-727a4ea43468')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'c8d66fa1-6290-4dc5-9c0d-d1f2cc66bdf6', N'我不喜歡...', N'柯南', CAST(N'2024-12-27T11:44:23.6754903' AS DateTime2), N'554d8130-52d4-48dc-b29a-727a4ea43468')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'd12dad34-13e1-4672-b1a3-eb7d3c7dc2f1', N'1234', N'123456', CAST(N'2025-01-02T16:30:20.0481596' AS DateTime2), N'8703c6e2-d9aa-47d8-8d54-6d78d363c28c')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'd34790b9-1d36-44e7-8efa-a6861bbe5e2a', N'有靈異現象', N'通靈王', CAST(N'2025-01-06T15:41:56.5212214' AS DateTime2), N'1b292eb1-8ded-47c4-9d13-d183d02bfb23')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'd66bc7ac-3cde-4256-9490-b3f336449264', N'比豬油香', N'灰原', CAST(N'2024-12-27T11:44:23.6754916' AS DateTime2), N'dcaa80aa-bbec-44a7-aa25-73c8030b3d61')
INSERT [dbo].[ReBook] ([ReBookID], [Description], [Author], [TimeStamp], [BookID]) VALUES (N'eb2ec300-98cc-4d0a-8490-869794bd1284', N'我比較喜歡三杯雞', N'小蘭', CAST(N'2024-12-27T11:44:23.6754908' AS DateTime2), N'b2dd8b38-117f-4c7e-9e05-d679e5020cef')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ReBook_BookID]    Script Date: 2025/3/12 上午 11:34:55 ******/
CREATE NONCLUSTERED INDEX [IX_ReBook_BookID] ON [dbo].[ReBook]
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReBook]  WITH CHECK ADD  CONSTRAINT [FK_ReBook_Book_BookID] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReBook] CHECK CONSTRAINT [FK_ReBook_Book_BookID]
GO
USE [master]
GO
ALTER DATABASE [GuestBook] SET  READ_WRITE 
GO
