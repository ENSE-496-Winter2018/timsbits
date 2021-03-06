USE [master]
GO
/****** Object:  Database [BT]    Script Date: 2018-10-08 10:22:56 PM ******/
CREATE DATABASE [BT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BT] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BT] SET ARITHABORT OFF 
GO
ALTER DATABASE [BT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BT] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BT] SET  MULTI_USER 
GO
ALTER DATABASE [BT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BT] SET QUERY_STORE = OFF
GO
USE [BT]
GO
/****** Object:  Table [dbo].[BTUser]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BTUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [varbinary](50) NULL,
	[DivisionId] [int] NULL,
	[UnitId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_BTUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentUpDoot]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentUpDoot](
	[CommentId] [int] NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[DivisionId] [int] NOT NULL,
	[Division] [char](30) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idea]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idea](
	[IdeaId] [int] NOT NULL,
	[IdeaName] [nchar](200) NULL,
	[IdeaContent] [nvarchar](2000) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [nchar](10) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Idea] PRIMARY KEY CLUSTERED 
(
	[IdeaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdeaComment]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdeaComment](
	[CommentId] [int] NOT NULL,
	[IdeaId] [int] NULL,
	[UserId] [int] NULL,
	[CommentContent] [nchar](1000) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_IdeaComment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdeaSubscription]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdeaSubscription](
	[IdeaId] [int] NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdeaUpDoot]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdeaUpDoot](
	[IdeaId] [int] NULL,
	[UserId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamId] [int] NOT NULL,
	[TeamName] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamIdea]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamIdea](
	[TeamId] [int] NULL,
	[IdeaId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamManager]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamManager](
	[UserId] [int] NULL,
	[TeamId] [int] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 2018-10-08 10:22:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [int] NOT NULL,
	[Unit] [char](30) NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BT] SET  READ_WRITE 
GO
