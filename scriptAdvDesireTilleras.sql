USE [master]
GO
/****** Object:  Database [advDesireTilleras]    Script Date: 2021-04-11 14:02:10 ******/
CREATE DATABASE [advDesireTilleras]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'advDesireTilleras', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\advDesireTilleras.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'advDesireTilleras_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\advDesireTilleras_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [advDesireTilleras] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [advDesireTilleras].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [advDesireTilleras] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [advDesireTilleras] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [advDesireTilleras] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [advDesireTilleras] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [advDesireTilleras] SET ARITHABORT OFF 
GO
ALTER DATABASE [advDesireTilleras] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [advDesireTilleras] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [advDesireTilleras] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [advDesireTilleras] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [advDesireTilleras] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [advDesireTilleras] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [advDesireTilleras] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [advDesireTilleras] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [advDesireTilleras] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [advDesireTilleras] SET  ENABLE_BROKER 
GO
ALTER DATABASE [advDesireTilleras] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [advDesireTilleras] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [advDesireTilleras] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [advDesireTilleras] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [advDesireTilleras] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [advDesireTilleras] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [advDesireTilleras] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [advDesireTilleras] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [advDesireTilleras] SET  MULTI_USER 
GO
ALTER DATABASE [advDesireTilleras] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [advDesireTilleras] SET DB_CHAINING OFF 
GO
ALTER DATABASE [advDesireTilleras] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [advDesireTilleras] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [advDesireTilleras] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [advDesireTilleras] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [advDesireTilleras] SET QUERY_STORE = OFF
GO
USE [advDesireTilleras]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021-04-11 14:02:11 ******/
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
/****** Object:  Table [dbo].[Activities]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cages]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmountInCage] [int] NOT NULL,
 CONSTRAINT [PK_Cages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseAreas]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseAreas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmountInArea] [int] NOT NULL,
 CONSTRAINT [PK_ExerciseAreas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender_Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hamsters]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hamsters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hamster_Name] [nvarchar](max) NULL,
	[Age] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[GenderId] [int] NOT NULL,
	[ActivityId] [int] NULL,
	[CageId] [int] NULL,
	[CheckInTime] [datetime2](7) NULL,
	[StartTimeExercise] [datetime2](7) NULL,
	[EndTimeExercise] [datetime2](7) NULL,
	[TimeWaited] [time](7) NULL,
	[AmountOfExercises] [int] NOT NULL,
	[AmountOfSpaVisits] [int] NOT NULL,
	[StartTimeSpa] [datetime2](7) NULL,
	[ExerciseAreaId] [int] NULL,
	[SpaAreaId] [int] NULL,
 CONSTRAINT [PK_Hamsters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logg_Activities]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logg_Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[HamsterId] [int] NULL,
	[ActivityId] [int] NULL,
 CONSTRAINT [PK_Logg_Activities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpaAreas]    Script Date: 2021-04-11 14:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpaAreas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmountInArea] [int] NOT NULL,
 CONSTRAINT [PK_SpaAreas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210409091813_init', N'5.0.4')
GO
SET IDENTITY_INSERT [dbo].[Activities] ON 

INSERT [dbo].[Activities] ([Id], [Name]) VALUES (1, N'Arrival')
INSERT [dbo].[Activities] ([Id], [Name]) VALUES (2, N'DayCage')
INSERT [dbo].[Activities] ([Id], [Name]) VALUES (3, N'Exercise')
INSERT [dbo].[Activities] ([Id], [Name]) VALUES (4, N'PickUp')
INSERT [dbo].[Activities] ([Id], [Name]) VALUES (5, N'Spa')
SET IDENTITY_INSERT [dbo].[Activities] OFF
GO
SET IDENTITY_INSERT [dbo].[Cages] ON 

INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (1, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (2, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (3, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (4, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (5, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (6, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (7, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (8, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (9, 0)
INSERT [dbo].[Cages] ([Id], [AmountInCage]) VALUES (10, 0)
SET IDENTITY_INSERT [dbo].[Cages] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseAreas] ON 

INSERT [dbo].[ExerciseAreas] ([Id], [AmountInArea]) VALUES (1, 0)
SET IDENTITY_INSERT [dbo].[ExerciseAreas] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 

INSERT [dbo].[Genders] ([Id], [Gender_Type]) VALUES (1, N'Female')
INSERT [dbo].[Genders] ([Id], [Gender_Type]) VALUES (2, N'Male')
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[Hamsters] ON 

INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (1, N'Rufus', 4, 1, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (2, N'Lisa', 12, 1, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (3, N'Fluff', 11, 2, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (4, N'Nibbler', 10, 2, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (5, N'Sneaky', 9, 3, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (6, N'Sussi', 8, 3, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (7, N'Mulan', 7, 4, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (8, N'Miss Diggy', 6, 5, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (9, N'Kalle', 5, 6, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (10, N'Kurt', 4, 7, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (11, N'Starlight', 4, 7, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (12, N'Chivas', 3, 8, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (13, N'Malin', 3, 9, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (14, N'Bulle', 24, 10, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'06:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (15, N'Beppe', 23, 11, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (16, N'Bobo', 22, 12, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'05:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (17, N'Robin', 21, 13, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'05:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (18, N'Amber', 20, 14, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'05:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (19, N'Kimber', 19, 15, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'05:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (20, N'Ruby', 18, 16, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (21, N'Fiffi', 16, 17, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (22, N'Neko', 16, 18, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (23, N'Clint', 15, 19, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (24, N'Sauron', 14, 20, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'03:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (25, N'Gittan', 12, 21, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (26, N'Crawler', 110, 22, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'06:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (27, N'Mimmi', 9, 23, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'04:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (28, N'Marvel', 8, 24, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (29, N'Storm', 7, 25, 2, NULL, NULL, NULL, NULL, NULL, CAST(N'01:06:00' AS Time), 0, 0, NULL, NULL, NULL)
INSERT [dbo].[Hamsters] ([Id], [Hamster_Name], [Age], [OwnerId], [GenderId], [ActivityId], [CageId], [CheckInTime], [StartTimeExercise], [EndTimeExercise], [TimeWaited], [AmountOfExercises], [AmountOfSpaVisits], [StartTimeSpa], [ExerciseAreaId], [SpaAreaId]) VALUES (30, N'Busan', 6, 26, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'02:06:00' AS Time), 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Hamsters] OFF
GO
SET IDENTITY_INSERT [dbo].[Logg_Activities] ON 

INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (527, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (528, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 2, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (529, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 3, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (530, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 4, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (531, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (532, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 6, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (533, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 7, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (534, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 8, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (535, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 9, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (536, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 10, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (537, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 11, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (538, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 12, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (539, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 13, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (540, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 14, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (541, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 15, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (542, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 16, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (543, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 17, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (544, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 18, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (545, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 19, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (546, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 20, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (547, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 21, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (548, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 22, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (549, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 23, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (550, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 24, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (551, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 25, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (552, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 26, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (553, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 27, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (554, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 28, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (555, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 29, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (556, CAST(N'2021-03-26T07:12:00.0000000' AS DateTime2), 30, 1)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (557, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 13, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (558, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 11, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (559, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 8, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (560, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 30, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (561, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 7, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (562, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 6, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (563, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 27, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (564, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 2, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (565, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 25, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (566, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 21, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (567, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 22, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (568, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 20, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (569, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 19, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (570, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 18, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (571, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 17, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (572, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 16, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (573, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 12, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (574, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (575, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 10, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (576, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 9, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (577, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 29, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (578, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 28, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (579, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (580, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 4, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (581, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (582, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 24, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (583, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 23, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (584, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 15, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (585, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 14, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (586, CAST(N'2021-03-26T07:24:00.0000000' AS DateTime2), 26, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (587, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 12, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (588, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 10, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (589, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (590, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 9, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (591, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 29, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (592, CAST(N'2021-03-26T08:18:00.0000000' AS DateTime2), 28, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (593, CAST(N'2021-03-26T08:24:00.0000000' AS DateTime2), 5, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (594, CAST(N'2021-03-26T08:24:00.0000000' AS DateTime2), 4, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (595, CAST(N'2021-03-26T08:24:00.0000000' AS DateTime2), 3, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (596, CAST(N'2021-03-26T08:24:00.0000000' AS DateTime2), 24, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (597, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (598, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 9, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (599, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 10, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (600, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 12, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (601, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 28, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (602, CAST(N'2021-03-26T09:12:00.0000000' AS DateTime2), 29, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (603, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 13, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (604, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 11, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (605, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 8, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (606, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 30, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (607, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 7, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (608, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 6, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (609, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (610, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 4, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (611, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (612, CAST(N'2021-03-26T09:18:00.0000000' AS DateTime2), 24, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (613, CAST(N'2021-03-26T09:24:00.0000000' AS DateTime2), 12, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (614, CAST(N'2021-03-26T09:24:00.0000000' AS DateTime2), 10, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (615, CAST(N'2021-03-26T09:24:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (616, CAST(N'2021-03-26T09:24:00.0000000' AS DateTime2), 9, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (617, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 6, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (618, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 7, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (619, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 8, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (620, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 11, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (621, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 13, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (622, CAST(N'2021-03-26T10:12:00.0000000' AS DateTime2), 30, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (623, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 5, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (624, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 4, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (625, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 3, 3)
GO
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (626, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 24, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (627, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 23, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (628, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 15, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (629, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (630, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 9, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (631, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 10, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (632, CAST(N'2021-03-26T10:18:00.0000000' AS DateTime2), 12, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (633, CAST(N'2021-03-26T10:24:00.0000000' AS DateTime2), 29, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (634, CAST(N'2021-03-26T10:24:00.0000000' AS DateTime2), 28, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (635, CAST(N'2021-03-26T10:24:00.0000000' AS DateTime2), 14, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (636, CAST(N'2021-03-26T10:24:00.0000000' AS DateTime2), 26, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (637, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (638, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 4, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (639, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (640, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 15, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (641, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 23, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (642, CAST(N'2021-03-26T11:12:00.0000000' AS DateTime2), 24, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (643, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 27, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (644, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 25, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (645, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 2, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (646, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 21, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (647, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 22, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (648, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 20, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (649, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 14, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (650, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 26, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (651, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 28, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (652, CAST(N'2021-03-26T11:18:00.0000000' AS DateTime2), 29, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (653, CAST(N'2021-03-26T11:24:00.0000000' AS DateTime2), 13, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (654, CAST(N'2021-03-26T11:24:00.0000000' AS DateTime2), 11, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (655, CAST(N'2021-03-26T11:24:00.0000000' AS DateTime2), 8, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (656, CAST(N'2021-03-26T11:24:00.0000000' AS DateTime2), 30, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (657, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 2, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (658, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 20, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (659, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 21, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (660, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 22, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (661, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 25, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (662, CAST(N'2021-03-26T12:12:00.0000000' AS DateTime2), 27, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (663, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 19, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (664, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 18, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (665, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 17, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (666, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 16, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (667, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 7, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (668, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 6, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (669, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 8, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (670, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 11, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (671, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 13, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (672, CAST(N'2021-03-26T12:18:00.0000000' AS DateTime2), 30, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (673, CAST(N'2021-03-26T12:24:00.0000000' AS DateTime2), 27, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (674, CAST(N'2021-03-26T12:24:00.0000000' AS DateTime2), 25, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (675, CAST(N'2021-03-26T12:24:00.0000000' AS DateTime2), 2, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (676, CAST(N'2021-03-26T12:24:00.0000000' AS DateTime2), 21, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (677, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 6, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (678, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 7, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (679, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 16, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (680, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 17, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (681, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 18, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (682, CAST(N'2021-03-26T13:12:00.0000000' AS DateTime2), 19, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (683, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 14, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (684, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 26, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (685, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 12, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (686, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 10, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (687, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (688, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 9, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (689, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 2, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (690, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 21, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (691, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 25, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (692, CAST(N'2021-03-26T13:18:00.0000000' AS DateTime2), 27, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (693, CAST(N'2021-03-26T13:24:00.0000000' AS DateTime2), 7, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (694, CAST(N'2021-03-26T13:24:00.0000000' AS DateTime2), 6, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (695, CAST(N'2021-03-26T13:24:00.0000000' AS DateTime2), 22, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (696, CAST(N'2021-03-26T13:24:00.0000000' AS DateTime2), 20, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (697, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (698, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 9, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (699, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 10, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (700, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 12, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (701, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 14, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (702, CAST(N'2021-03-26T14:12:00.0000000' AS DateTime2), 26, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (703, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 29, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (704, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 28, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (705, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 5, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (706, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 4, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (707, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 3, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (708, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 24, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (709, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 6, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (710, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 7, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (711, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 20, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (712, CAST(N'2021-03-26T14:18:00.0000000' AS DateTime2), 22, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (713, CAST(N'2021-03-26T14:24:00.0000000' AS DateTime2), 19, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (714, CAST(N'2021-03-26T14:24:00.0000000' AS DateTime2), 18, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (715, CAST(N'2021-03-26T14:24:00.0000000' AS DateTime2), 17, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (716, CAST(N'2021-03-26T14:24:00.0000000' AS DateTime2), 16, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (717, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (718, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 4, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (719, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 5, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (720, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 24, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (721, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 28, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (722, CAST(N'2021-03-26T15:12:00.0000000' AS DateTime2), 29, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (723, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 13, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (724, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 11, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (725, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 8, 3)
GO
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (726, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 30, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (727, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 27, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (728, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 25, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (729, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 16, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (730, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 17, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (731, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 18, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (732, CAST(N'2021-03-26T15:18:00.0000000' AS DateTime2), 19, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (733, CAST(N'2021-03-26T15:24:00.0000000' AS DateTime2), 23, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (734, CAST(N'2021-03-26T15:24:00.0000000' AS DateTime2), 15, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (735, CAST(N'2021-03-26T15:24:00.0000000' AS DateTime2), 12, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (736, CAST(N'2021-03-26T15:24:00.0000000' AS DateTime2), 10, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (737, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 8, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (738, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 11, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (739, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 13, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (740, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 25, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (741, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 27, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (742, CAST(N'2021-03-26T16:12:00.0000000' AS DateTime2), 30, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (743, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 2, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (744, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 21, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (745, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 22, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (746, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 20, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (747, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 19, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (748, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 18, 3)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (749, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 10, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (750, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 12, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (751, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 15, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (752, CAST(N'2021-03-26T16:18:00.0000000' AS DateTime2), 23, 2)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (753, CAST(N'2021-03-26T16:24:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (754, CAST(N'2021-03-26T16:24:00.0000000' AS DateTime2), 9, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (755, CAST(N'2021-03-26T16:24:00.0000000' AS DateTime2), 29, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (756, CAST(N'2021-03-26T16:24:00.0000000' AS DateTime2), 28, 5)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (757, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (758, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 2, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (759, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 3, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (760, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 4, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (761, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 5, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (762, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 6, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (763, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 7, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (764, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 8, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (765, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 9, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (766, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 10, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (767, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 11, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (768, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 12, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (769, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 13, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (770, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 14, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (771, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 15, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (772, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 16, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (773, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 17, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (774, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 18, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (775, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 19, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (776, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 20, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (777, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 21, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (778, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 22, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (779, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 23, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (780, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 24, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (781, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 25, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (782, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 26, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (783, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 27, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (784, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 28, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (785, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 29, 4)
INSERT [dbo].[Logg_Activities] ([Id], [Timestamp], [HamsterId], [ActivityId]) VALUES (786, CAST(N'2021-03-26T17:06:00.0000000' AS DateTime2), 30, 4)
SET IDENTITY_INSERT [dbo].[Logg_Activities] OFF
GO
SET IDENTITY_INSERT [dbo].[Owners] ON 

INSERT [dbo].[Owners] ([Id], [Name]) VALUES (1, N'Kallegurra Aktersnurra')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (2, N'Carl Hamilton')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (3, N'Lisa Nilsson')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (4, N'Jan Hallgren')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (5, N'Ottilla Murkwood')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (6, N'Anfers Murkwood')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (7, N'Anna Book')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (8, N'Pernilla Wahlgren')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (9, N'Bianca Ingrosso')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (10, N'Lorenzo Lamas')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (11, N'Bobby Ewing')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (12, N'Hedy Lamar')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (13, N'Bette Davis')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (14, N'Kim Carnes')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (15, N'Mork of Ork')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (16, N'Mindy Mendel')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (17, N'GW Hansson')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (18, N'Pia Hansson')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (19, N'Bo Ek')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (20, N'Anna Al')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (21, N'Hans Björk')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (22, N'Carita Gran')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (23, N'Mia Eriksson')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (24, N'Anna Linström')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (25, N'Lennart Berg')
INSERT [dbo].[Owners] ([Id], [Name]) VALUES (26, N'Bo Bergman')
SET IDENTITY_INSERT [dbo].[Owners] OFF
GO
SET IDENTITY_INSERT [dbo].[SpaAreas] ON 

INSERT [dbo].[SpaAreas] ([Id], [AmountInArea]) VALUES (1, 0)
SET IDENTITY_INSERT [dbo].[SpaAreas] OFF
GO
/****** Object:  Index [IX_Hamsters_ActivityId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_ActivityId] ON [dbo].[Hamsters]
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_CageId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_CageId] ON [dbo].[Hamsters]
(
	[CageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_ExerciseAreaId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_ExerciseAreaId] ON [dbo].[Hamsters]
(
	[ExerciseAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_GenderId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_GenderId] ON [dbo].[Hamsters]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_OwnerId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_OwnerId] ON [dbo].[Hamsters]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_SpaAreaId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_SpaAreaId] ON [dbo].[Hamsters]
(
	[SpaAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Logg_Activities_ActivityId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Logg_Activities_ActivityId] ON [dbo].[Logg_Activities]
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Logg_Activities_HamsterId]    Script Date: 2021-04-11 14:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Logg_Activities_HamsterId] ON [dbo].[Logg_Activities]
(
	[HamsterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Activities_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Activities_ActivityId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Cages_CageId] FOREIGN KEY([CageId])
REFERENCES [dbo].[Cages] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Cages_CageId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_ExerciseAreas_ExerciseAreaId] FOREIGN KEY([ExerciseAreaId])
REFERENCES [dbo].[ExerciseAreas] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_ExerciseAreas_ExerciseAreaId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Genders_GenderId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Owners_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Owners_OwnerId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_SpaAreas_SpaAreaId] FOREIGN KEY([SpaAreaId])
REFERENCES [dbo].[SpaAreas] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_SpaAreas_SpaAreaId]
GO
ALTER TABLE [dbo].[Logg_Activities]  WITH CHECK ADD  CONSTRAINT [FK_Logg_Activities_Activities_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activities] ([Id])
GO
ALTER TABLE [dbo].[Logg_Activities] CHECK CONSTRAINT [FK_Logg_Activities_Activities_ActivityId]
GO
ALTER TABLE [dbo].[Logg_Activities]  WITH CHECK ADD  CONSTRAINT [FK_Logg_Activities_Hamsters_HamsterId] FOREIGN KEY([HamsterId])
REFERENCES [dbo].[Hamsters] ([Id])
GO
ALTER TABLE [dbo].[Logg_Activities] CHECK CONSTRAINT [FK_Logg_Activities_Hamsters_HamsterId]
GO
USE [master]
GO
ALTER DATABASE [advDesireTilleras] SET  READ_WRITE 
GO
