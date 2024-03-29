USE [VideoKlub]
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi] DROP CONSTRAINT [FK__Iznajmlje__FilmI__5DCAEF64]
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi] DROP CONSTRAINT [FK__Iznajmlje__BrojK__5CD6CB2B]
GO
/****** Object:  Index [UQ__Iznajmlj__56DC9CBD8B65CA39]    Script Date: 11/18/2019 02:09:38 AM ******/
ALTER TABLE [dbo].[IznajmljeniFilmovi] DROP CONSTRAINT [UQ__Iznajmlj__56DC9CBD8B65CA39]
GO
/****** Object:  Table [dbo].[IznajmljeniFilmovi]    Script Date: 11/18/2019 02:09:38 AM ******/
DROP TABLE [dbo].[IznajmljeniFilmovi]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 11/18/2019 02:09:38 AM ******/
DROP TABLE [dbo].[Film]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 11/18/2019 02:09:38 AM ******/
DROP TABLE [dbo].[Clan]
GO
USE [master]
GO
/****** Object:  Database [VideoKlub]    Script Date: 11/18/2019 02:09:38 AM ******/
DROP DATABASE [VideoKlub]
GO
/****** Object:  Database [VideoKlub]    Script Date: 11/18/2019 02:09:38 AM ******/
CREATE DATABASE [VideoKlub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoKlub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VideoKlub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideoKlub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VideoKlub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VideoKlub] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoKlub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoKlub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoKlub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoKlub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoKlub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoKlub] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoKlub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideoKlub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoKlub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoKlub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoKlub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoKlub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoKlub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoKlub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoKlub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoKlub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideoKlub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoKlub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoKlub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoKlub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoKlub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoKlub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoKlub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoKlub] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VideoKlub] SET  MULTI_USER 
GO
ALTER DATABASE [VideoKlub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoKlub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoKlub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoKlub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideoKlub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VideoKlub] SET QUERY_STORE = OFF
GO
USE [VideoKlub]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 11/18/2019 02:09:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clan](
	[BrojKarte] [char](7) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[DatumOd] [date] NULL,
	[DatumDo] [date] NULL,
	[FilmID] [int] NULL,
 CONSTRAINT [PK_Clan] PRIMARY KEY CLUSTERED 
(
	[BrojKarte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 11/18/2019 02:09:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[FilmID] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Zanr] [nvarchar](50) NOT NULL,
	[Godina] [date] NOT NULL,
 CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IznajmljeniFilmovi]    Script Date: 11/18/2019 02:09:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IznajmljeniFilmovi](
	[BrojKarte] [char](7) NOT NULL,
	[FilmID] [int] NOT NULL,
	[DatumOd] [date] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Clan] ([BrojKarte], [Ime], [Prezime], [DatumRodjenja], [DatumOd], [DatumDo], [FilmID]) VALUES (N'A1     ', N'Nikola', N'Milovanovic', CAST(N'1999-02-06' AS Date), CAST(N'2019-11-15' AS Date), CAST(N'2019-11-16' AS Date), NULL)
INSERT [dbo].[Clan] ([BrojKarte], [Ime], [Prezime], [DatumRodjenja], [DatumOd], [DatumDo], [FilmID]) VALUES (N'A2     ', N'Marko', N'Milosevic', CAST(N'1998-01-03' AS Date), CAST(N'2019-11-19' AS Date), CAST(N'2019-11-21' AS Date), NULL)
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [Godina]) VALUES (1, N'The Shawshank Redemption
', N'Drama', CAST(N'1994-09-22' AS Date))
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [Godina]) VALUES (2, N'The Green Mile
', N'Drama', CAST(N'1999-12-06' AS Date))
INSERT [dbo].[Film] ([FilmID], [Naziv], [Zanr], [Godina]) VALUES (3, N'Pulp Fiction
', N'Krimi', CAST(N'1994-09-10' AS Date))
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Iznajmlj__56DC9CBD8B65CA39]    Script Date: 11/18/2019 02:09:38 AM ******/
ALTER TABLE [dbo].[IznajmljeniFilmovi] ADD  CONSTRAINT [UQ__Iznajmlj__56DC9CBD8B65CA39] UNIQUE NONCLUSTERED 
(
	[BrojKarte] ASC,
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi]  WITH CHECK ADD  CONSTRAINT [FK__Iznajmlje__BrojK__5CD6CB2B] FOREIGN KEY([BrojKarte])
REFERENCES [dbo].[Clan] ([BrojKarte])
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi] CHECK CONSTRAINT [FK__Iznajmlje__BrojK__5CD6CB2B]
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi]  WITH CHECK ADD  CONSTRAINT [FK__Iznajmlje__FilmI__5DCAEF64] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([FilmID])
GO
ALTER TABLE [dbo].[IznajmljeniFilmovi] CHECK CONSTRAINT [FK__Iznajmlje__FilmI__5DCAEF64]
GO
USE [master]
GO
ALTER DATABASE [VideoKlub] SET  READ_WRITE 
GO
