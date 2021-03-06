USE [master]
GO
/****** Object:  Database [PersonAdresses]    Script Date: 8.3.14 22:23:39 ******/
CREATE DATABASE [PersonAdresses]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonAdresses', FILENAME = N'D:\MSSQL11.TTITTOLPT\MSSQL\DATA\PersonAdresses.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonAdresses_log', FILENAME = N'D:\MSSQL11.TTITTOLPT\MSSQL\DATA\PersonAdresses_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonAdresses] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonAdresses].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonAdresses] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonAdresses] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonAdresses] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonAdresses] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonAdresses] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonAdresses] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonAdresses] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PersonAdresses] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonAdresses] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonAdresses] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonAdresses] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonAdresses] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonAdresses] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonAdresses] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonAdresses] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonAdresses] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonAdresses] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonAdresses] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonAdresses] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonAdresses] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonAdresses] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonAdresses] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonAdresses] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonAdresses] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonAdresses] SET  MULTI_USER 
GO
ALTER DATABASE [PersonAdresses] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonAdresses] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonAdresses] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonAdresses] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonAdresses', N'ON'
GO
USE [PersonAdresses]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8.3.14 22:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nvarchar](200) NOT NULL,
	[town_id] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 8.3.14 22:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 8.3.14 22:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[continent_id] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 8.3.14 22:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[address_id] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 8.3.14 22:23:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (1, N'ул Булаир 15', 3)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (2, N'Уолстрийт 23 31', 2)
INSERT [dbo].[Address] ([id], [address_text], [town_id]) VALUES (3, N'Майер щрасе 18', 5)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([id], [name]) VALUES (1, N'Африка')
INSERT [dbo].[Continent] ([id], [name]) VALUES (2, N'Азия')
INSERT [dbo].[Continent] ([id], [name]) VALUES (3, N'Южна Америка')
INSERT [dbo].[Continent] ([id], [name]) VALUES (4, N'Австралия')
INSERT [dbo].[Continent] ([id], [name]) VALUES (5, N'Океания')
INSERT [dbo].[Continent] ([id], [name]) VALUES (6, N'Северна Америка')
INSERT [dbo].[Continent] ([id], [name]) VALUES (7, N'Европа')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (1, N'Германия', 7)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (2, N'САЩ', 6)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (3, N'Монголия', 2)
INSERT [dbo].[Country] ([id], [name], [continent_id]) VALUES (4, N'България', 1)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Тихомир', N'Проданов', 3)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Даниел', N'Кехайов', 1)
INSERT [dbo].[Person] ([id], [first_name], [last_name], [address_id]) VALUES (3, N'Панайот', N'Петранов', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (2, N'Ню Йорк', 2)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (3, N'София', 4)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (4, N'Улан Батор', 3)
INSERT [dbo].[Town] ([id], [name], [country_id]) VALUES (5, N'Мюнхен', 1)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([town_id])
REFERENCES [dbo].[Town] ([id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([continent_id])
REFERENCES [dbo].[Continent] ([id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([address_id])
REFERENCES [dbo].[Address] ([id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([country_id])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PersonAdresses] SET  READ_WRITE 
GO
