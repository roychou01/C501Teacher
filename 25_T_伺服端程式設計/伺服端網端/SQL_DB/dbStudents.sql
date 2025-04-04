USE [master]
GO
/****** Object:  Database [dbStudents]    Script Date: 2025/3/12 上午 11:36:15 ******/
CREATE DATABASE [dbStudents]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbStudents', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbStudents.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbStudents_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbStudents_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbStudents] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbStudents].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbStudents] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbStudents] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbStudents] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbStudents] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbStudents] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbStudents] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbStudents] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbStudents] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbStudents] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbStudents] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbStudents] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbStudents] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbStudents] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbStudents] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbStudents] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbStudents] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbStudents] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbStudents] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbStudents] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbStudents] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbStudents] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbStudents] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbStudents] SET RECOVERY FULL 
GO
ALTER DATABASE [dbStudents] SET  MULTI_USER 
GO
ALTER DATABASE [dbStudents] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbStudents] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbStudents] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbStudents] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbStudents] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbStudents] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbStudents', N'ON'
GO
ALTER DATABASE [dbStudents] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbStudents] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbStudents]
GO
/****** Object:  User [abc]    Script Date: 2025/3/12 上午 11:36:16 ******/
CREATE USER [abc] FOR LOGIN [abc] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [abc]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2025/3/12 上午 11:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DeptID] [char](2) NOT NULL,
	[DeptName] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tStudent]    Script Date: 2025/3/12 上午 11:36:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tStudent](
	[fStuId] [char](6) NOT NULL,
	[fName] [nvarchar](30) NOT NULL,
	[fEmail] [nvarchar](40) NULL,
	[fScore] [int] NULL,
	[DeptID] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[fStuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([DeptID], [DeptName]) VALUES (N'01', N'資工系')
INSERT [dbo].[Department] ([DeptID], [DeptName]) VALUES (N'02', N'資管系')
INSERT [dbo].[Department] ([DeptID], [DeptName]) VALUES (N'03', N'工管系')
INSERT [dbo].[Department] ([DeptID], [DeptName]) VALUES (N'04', N'企管系')
INSERT [dbo].[Department] ([DeptID], [DeptName]) VALUES (N'05', N'國貿系')
GO
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112001', N'王普丁', N'ding@gmail.com', 92, N'01')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112002', N'習維尼', N'nee@gmail.com', 68, N'01')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112003', N'金小胖', N'kim@gmail.com', 88, N'01')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112004', N'Mary', N'mary@abc.com', 77, N'04')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112005', N'王大保', NULL, 66, N'03')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'112009', N'William', N'william@aonline.com', 66, N'01')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'113001', N'Jack', N'jack@gmail.com', 88, N'02')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'113004', N'mike', N'mike@gmail.com', 77, N'04')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'113005', N'Mary', N'Mary@yahoo.com', 74, N'01')
INSERT [dbo].[tStudent] ([fStuId], [fName], [fEmail], [fScore], [DeptID]) VALUES (N'114110', N'john', N'john@gmail.com', 66, N'01')
GO
ALTER TABLE [dbo].[tStudent] ADD  DEFAULT ('01') FOR [DeptID]
GO
ALTER TABLE [dbo].[tStudent]  WITH CHECK ADD FOREIGN KEY([DeptID])
REFERENCES [dbo].[Department] ([DeptID])
GO
USE [master]
GO
ALTER DATABASE [dbStudents] SET  READ_WRITE 
GO
