USE [master]
GO
/****** Object:  Database [MANAGEMENT_STORE]    Script Date: 6/29/2020 4:14:53 PM ******/
CREATE DATABASE [MANAGEMENT_STORE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MANAGEMENT_STORE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MANAGEMENT_STORE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MANAGEMENT_STORE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MANAGEMENT_STORE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MANAGEMENT_STORE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MANAGEMENT_STORE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ARITHABORT OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET  MULTI_USER 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MANAGEMENT_STORE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MANAGEMENT_STORE] SET QUERY_STORE = OFF
GO
USE [MANAGEMENT_STORE]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID_Customer] [char](10) NOT NULL,
	[Name_Cus] [nvarchar](50) NULL,
	[Address_Cus] [nvarchar](50) NULL,
	[Phone] [char](10) NULL,
	[Birthday] [datetime] NULL,
	[Email] [char](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detail_Product]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Product](
	[ID_Product] [char](10) NOT NULL,
	[ID_TypeProduct] [char](10) NOT NULL,
	[ID_Supplier] [char](10) NOT NULL,
	[Original_Price] [int] NULL,
	[NameProduct] [nvarchar](50) NULL,
	[Description_Pro] [nvarchar](max) NULL,
	[Image_Path] [nvarchar](max) NULL,
	[Amount_Current] [int] NULL,
 CONSTRAINT [PK_Detail_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Input_Form]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input_Form](
	[ID_Input] [char](10) NOT NULL,
	[ID_Product] [char](10) NULL,
	[ID_Sup] [char](10) NULL,
	[Input_Date] [datetime] NULL,
	[Amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Input] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[ID] [char](10) NOT NULL,
	[Pass] [char](20) NULL,
	[NameLog] [char](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Output_Form]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output_Form](
	[ID_Output] [char](10) NOT NULL,
	[ID_Product] [char](10) NULL,
	[ID_Customer] [char](10) NULL,
	[Amount] [int] NULL,
	[Output_Date] [datetime] NULL,
	[Event_] [nvarchar](max) NULL,
	[Price_Sale] [int] NULL,
	[Note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Output] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID_sup] [char](10) NOT NULL,
	[Name_Sup] [nvarchar](50) NULL,
	[Address_sup] [nvarchar](50) NULL,
	[Phone] [char](10) NULL,
	[Email] [char](50) NULL,
	[MoreInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_sup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_product]    Script Date: 6/29/2020 4:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_product](
	[ID] [char](10) NOT NULL,
	[Type_Product] [nchar](50) NULL,
	[Num_Of_Product] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MANAGEMENT_STORE] SET  READ_WRITE 
GO
