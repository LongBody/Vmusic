USE [master]
GO
/****** Object:  Database [Vmusic]    Script Date: 4/2/2021 13:58:46 ******/
CREATE DATABASE [Vmusic]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vmusic', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vmusic.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Vmusic_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Vmusic_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Vmusic] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vmusic].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vmusic] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vmusic] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vmusic] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vmusic] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vmusic] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vmusic] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vmusic] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vmusic] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vmusic] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vmusic] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vmusic] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vmusic] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vmusic] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vmusic] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vmusic] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Vmusic] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vmusic] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vmusic] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vmusic] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vmusic] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vmusic] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vmusic] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vmusic] SET RECOVERY FULL 
GO
ALTER DATABASE [Vmusic] SET  MULTI_USER 
GO
ALTER DATABASE [Vmusic] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vmusic] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vmusic] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vmusic] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Vmusic] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Vmusic', N'ON'
GO
ALTER DATABASE [Vmusic] SET QUERY_STORE = OFF
GO
USE [Vmusic]
GO
/****** Object:  Table [dbo].[album]    Script Date: 4/2/2021 13:58:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NOT NULL,
	[artist_id] [int] NOT NULL,
	[release_date] [date] NOT NULL,
	[genre_id] [int] NOT NULL,
	[picture_url] [nchar](1000) NOT NULL,
 CONSTRAINT [PK_album] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[artist]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author] [nvarchar](max) NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[favourite]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favourite](
	[id] [int] NULL,
	[user_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre] [nchar](100) NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localMusic]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localMusic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](1000) NULL,
	[file] [nchar](1000) NULL,
	[duration] [int] NULL,
	[user_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[playlist]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[playlist](
	[song_id] [int] NULL,
	[user_id] [int] NULL,
	[title] [nchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[song]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[song](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[album_id] [int] NULL,
	[title] [nvarchar](100) NULL,
	[file] [nchar](1000) NOT NULL,
	[lyrics] [nchar](2000) NULL,
	[artist_id] [int] NULL,
	[genre_id] [int] NULL,
	[duration] [int] NULL,
	[urlDownload] [varchar](max) NULL,
	[keySearch] [nvarchar](255) NULL,
	[viewed] [int] NULL,
 CONSTRAINT [PK_song] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 4/2/2021 13:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nchar](100) NOT NULL,
	[username] [nchar](100) NOT NULL,
	[password] [nchar](100) NOT NULL,
	[gen] [bit] NOT NULL,
	[verify] [bit] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[album] ON 

INSERT [dbo].[album] ([id], [name], [artist_id], [release_date], [genre_id], [picture_url]) VALUES (1, N'Hãy Khóc Đi Em                                                                                      ', 1, CAST(N'2012-03-25' AS Date), 1, N'https://data.chiasenhac.com/data/cover/36/35555.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ')
INSERT [dbo].[album] ([id], [name], [artist_id], [release_date], [genre_id], [picture_url]) VALUES (2, N' Em Phải Quên Anh                                                                                   ', 2, CAST(N'2017-01-20' AS Date), 1, N'https://data.chiasenhac.com/data/cover/70/69896.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ')
INSERT [dbo].[album] ([id], [name], [artist_id], [release_date], [genre_id], [picture_url]) VALUES (3, N' My World Acoustic                                                                                  ', 12, CAST(N'2010-03-12' AS Date), 3, N'https://data.chiasenhac.com/data/cover/2/1973.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ')
INSERT [dbo].[album] ([id], [name], [artist_id], [release_date], [genre_id], [picture_url]) VALUES (4, N' Mất Cảm Giác Yêu                                                                                   ', 4, CAST(N'2011-02-12' AS Date), 1, N'https://data.chiasenhac.com/data/cover/3/2313.jpg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ')
SET IDENTITY_INSERT [dbo].[album] OFF
SET IDENTITY_INSERT [dbo].[artist] ON 

INSERT [dbo].[artist] ([id], [author], [image]) VALUES (1, N'Du Thiên', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2016/01/25/4/1/1/7/1453715854097.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (2, N'Châu Khải Phong', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/08/30/d/5/9/d/1567133656446.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (3, N'INNA', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2016/01/25/4/1/1/7/1453716632501.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (4, N'Khắc Việt', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2020/05/27/6/9/5/0/1590565041302.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (5, N'Ali Hoàng Dương', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2020/09/14/0/2/8/0/1600048599012.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (6, N'Binz', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/09/12/c/3/c/7/1568253936065.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (7, N'BlackPink', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2020/06/29/0/9/e/a/1593414639316.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (19, N'Ý Linh', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/02/23/5/c/a/2/1487836449444.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (8, N'BTS', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/07/02/8/a/7/0/1562040135194.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (9, N'Maroon5', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/02/08/d/9/d/9/1518102796944.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (10, N'Unknown', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/07/18/4/4/4/6/1500390891566.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (11, N'LK', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/06/04/f/5/a/b/1528106842297.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (12, N'Justin Bieber', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2021/03/18/7/5/f/f/1616035448415.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (13, N'Big Bang', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/01/12/4/7/c/7/1484193180755.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (14, N'Phan Mạnh Quỳnh', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/09/20/b/8/3/8/1505895112608.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (15, N'Alan Walker', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/07/19/8/1/6/a/1531967352055.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (16, N'Amee', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/02/20/b/f/b/d/1550638514193.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (17, N'Post Melone', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/02/23/5/c/a/2/1487836245321.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (18, N'Dương Ngọc Thái', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2016/06/16/f/9/d/4/1466072762039.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (20, N'Lệ Quyên', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/09/17/7/2/a/2/1568707006619.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (21, N'Lê Ngọc Thuý', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2017/09/19/e/d/8/1/1505796146235.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (22, N'Sơn Tùng MTP', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2019/07/17/d/e/0/2/1563332636822.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (23, N'Đạt G', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2020/01/06/f/e/3/f/1578283703422.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (24, N'Lê Bảo Bình', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/01/24/a/3/d/e/1516765405718.jpg')
INSERT [dbo].[artist] ([id], [author], [image]) VALUES (25, N'Min', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2020/11/05/2/2/0/3/1604563630516.jpg')
SET IDENTITY_INSERT [dbo].[artist] OFF
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (32, 24)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (17, 24)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (19, 24)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (1, 1051)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (17, 1051)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (41, 1053)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (42, 1053)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (4, 1056)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (17, 1056)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (19, 1056)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (19, 1057)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (27, 1057)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (41, 24)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (4, 1051)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (20, 1056)
INSERT [dbo].[favourite] ([id], [user_id]) VALUES (31, 1057)
SET IDENTITY_INSERT [dbo].[genre] ON 

INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (1, N'Vpop                                                                                                ', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2016/08/18/8/0/6/0/1471484657260.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (2, N'Kpop                                                                                                ', N'https://avatar-ex-swe.nixcdn.com/playlist/2013/11/06/c/c/a/8/1383708643011.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (3, N'US-UK                                                                                               ', N'https://avatar-ex-swe.nixcdn.com/playlist/2017/07/21/f/6/f/8/1500624898239.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (4, N'Rap                                                                                                 ', N'https://avatar-ex-swe.nixcdn.com/song/2020/08/11/6/d/1/5/1597154440865.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (5, N'Remix                                                                                               ', N'https://avatar-ex-swe.nixcdn.com/playlist/2020/09/28/b/4/3/0/1601283323202.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (6, N'EDM                                                                                                 ', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/02/06/c/8/f/4/1517890221437.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (7, N'Nhạc Trữ Tình                                                                                       ', N'https://avatar-ex-swe.nixcdn.com/singer/avatar/2018/05/22/c/2/d/9/1526961123391.jpg')
INSERT [dbo].[genre] ([id], [genre], [image]) VALUES (8, N'Nhạc Hoa                                                                                            ', N'https://avatar-ex-swe.nixcdn.com/playlist/2019/10/02/d/9/c/7/1570014057959.jpg')
SET IDENTITY_INSERT [dbo].[genre] OFF
SET IDENTITY_INSERT [dbo].[song] ON 

INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (1, 1, N'Xoá hết', N'http://docs.google.com/uc?export=open&id=1goVxu5cfuxMdy7eaMvompdlQUAsYDCJg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Em yêu ơi đôi mình cách xa
Để từ đây riêng anh phải lẻ loi
Ta chia tay không một lí do
Để giờ đây riêng anh với nỗi buồn.

Anh sẽ nhớ mãi những tháng ngày xưa ấy
Ta đi bên nhau trong hạnh phúc
Anh sẽ giữ mãi những nụ cười ngày ấy
Giờ đây đã không còn như trước.

Thời gian sẽ xoá hết đi những câu yêu thương đã trao
Và xoá hết đi những kỉ niệm xưa úa tàn
Dù đã cố níu kéo nhưng chẳng thể thay đổi
Người vẫn cất bước quay mặt đi.

Dù cho tình đó đã mất hết nhưng trong anh vẫn còn
Lòng vẫn mãi luyến tiếc bóng hình xưa đã xa
Cầu mong em bên ai sẽ luôn được hạnh phúc
Và nếu có lúc em buồn đau hãy về bên anh.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', 1, 1, 347, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1goVxu5cfuxMdy7eaMvompdlQUAsYDCJg', N'xoa het , du thien , du thiên', 110)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (4, NULL, N'Đường song song', N'http://docs.google.com/uc?export=open&id=1a4TdRLFHwQ4Udbv2G5oW4_Z5NIWNW8hc                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 1, 1, 340, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=11a4TdRLFHwQ4Udbv2G5oW4_Z5NIWNW8hc', N'duong song song , du thien , du thiên', 17)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (17, NULL, N'Ngắm Hoa Lệ Rơi', N'http://docs.google.com/uc?export=open&id=19Z6OAb2d3lkxMZmqMz6_mVsfGUyHWKPz                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 2, 1, 308, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=19JjdkuHtNwQ15CArrvtnfUsIdbh8ZIvy', N'ngam hoa le roi , chau khai phong , châu khải phong', 54)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (19, NULL, N'Hối Tiếc Muộn Màng', N'http://docs.google.com/uc?export=open&id=1REAM0uJAJ8_b1eGwRbtXfB1Ews6Ug9w_                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Có lẽ giờ anh mới hiểu ra
Tiếc nuối trong tim vẫn đây mà
Dù cố gắng xoá hết những giấc mơ mỗi đêm dài
Nhưng nỗi nhớ em trong lòng anh đâu thể vơi
Vì biết anh không thể có em
Chỉ dõi theo em những năm dài
Hạnh phúc phía trước ấy
Trong mắt em đâu còn anh
Bên cạnh em là một ai khác
Người mà em nay đã rất yêu!
Là anh đã cố chấp ôm giấc mơ yêu thương cùng em
Dù anh biết ta đã qua những ngọt ngào
Giờ nơi trái tim của em chỉ dành trọn cho ai mãi mãi
Nào còn nhớ mong chi đến tình anh
Là anh đã sai lúc xưa để em xa đôi vòng tay
Nào biết đâu anh sẽ mãi đánh mất em
Giờ ai đó đã ở bên khiến em cười xinh hơn lúc trước
Anh ngẩn ngơ mãi trông theo từ xa
Vì biết anh không thể có em
Chỉ dõi theo em những năm dài
Hạnh phúc phía trước ấy
Trong mắt em đâu còn anh
Bên cạnh em là một ai khác
Người mà em nay đã rất yêu!
Là anh đã cố chấp ôm giấc mơ yêu thương cùng em
Dù anh biết ta đã qua những ngọt ngào
Giờ nơi trái tim của em chỉ dành trọn cho ai mãi mãi
Nào còn nhớ mong chi đến tình anh
Là anh đã sai lúc xưa để em xa đôi vòng tay
Nào biết đâu anh sẽ mãi đánh mất em
Giờ ai đó đã ở bên khiến em cười xinh hơn lúc trước
Anh ngẩn ngơ mãi trông theo từ xa
Là anh đã cố chấp ôm giấc mơ yêu thương cùng em
Dù anh biết ta đã qua tình yêu ấy
Giờ nơi trái tim của em chỉ dành trọn cho ai mãi mãi
Nào còn nhớ mong chi đến tình anh
Là anh đã sai lúc xưa để em xa đôi vòng tay
Nào biết đâu anh sẽ mãi đánh mất em
Giờ ai đó đã ở bên khiến em cười xinh hơn lúc trước
Anh ngẩn ngơ mãi trông theo từ xa
Anh ngẩn ngơ mãi trông theo từ xa                                                                                                                                                                                                                                                                                                                                                                                                                                                            ', 2, 1, 296, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1REAM0uJAJ8_b1eGwRbtXfB1Ews6Ug9w_', N'hoi tiec muon mang , chau khai phong , châu khải phong', 70)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (20, NULL, N'Yalla', N'http://docs.google.com/uc?export=open&id=1XVZTSij9wVJUsXu4njBmHJUhNT6Fq0y7                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', N'Common ladies get ready
The music is playin''
One more time let''s go crazy
Tonight, tonight, tonight
I''m gonna take it so high
Can you hear my heart beating for you?
Dream wide awake, boy, make it true
Can you hear my heart beating for you?
Come on, come on, come on, come on, come on
يلا حبي يلا مش حتشركني بهواك
يا الغالي إنت و الكل يريد يكون معك
يلا حبي يلا مش حتشركني بهواك
يا الغالي إنت و الكل يريد يكون معك
Play it with no, my baby
Me and you, let''s get faded
Take a chance if you''re ready
Tonight, tonight, tonight
I''m gonna take you so high
Can you hear my heart beating for you?
Dream wide awake, boy, make it true
Can you hear my heart beating for you?
Come on, come on, come on, come on, come on
يلا حبي يلا مش حتشركني بهواك
يا الغالي إنت و الكل يريد يكون معك يلا…                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ', 3, 3, 196, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1XVZTSij9wVJUsXu4njBmHJUhNT6Fq0y7 ', N'yalla , inna', 22)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (27, NULL, N'Dynamite', N'http://docs.google.com/uc?export=open&id=19F749UNvUTu1UXXd6Mifp8P3GL4CAJDi                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 8, 2, 223, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=19F749UNvUTu1UXXd6Mifp8P3GL4CAJDi', N'Dynamite , bts', 67)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (28, NULL, N'Ice Cream', N'http://docs.google.com/uc?export=open&id=1VjXzGwRwSMOpPoumcNpABiseIG_AldMB                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 7, 2, 182, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1VjXzGwRwSMOpPoumcNpABiseIG_AldMB', N'ice cream, blackpink', 117)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (30, NULL, N'BANG BANG BANG', N'http://docs.google.com/uc?export=open&id=1DuIaomLiuZrz06JvK6iyaWUpogFrG_EK                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 13, 2, 229, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1DuIaomLiuZrz06JvK6iyaWUpogFrG_EK', N'bang bang bang , big bang', 51)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (31, NULL, N'Baby', N'http://docs.google.com/uc?export=open&id=161IWCw--mO4MpWqn10-4ovAAWggDWjVR                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 12, 3, 224, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=161IWCw--mO4MpWqn10-4ovAAWggDWjVR', N'baby , Justin Bieber', 1006)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (32, NULL, N'Payphone', N'http://docs.google.com/uc?export=open&id=1ctp4RlexVdkzhRCpjuMjr_vxqX0Cf0NR                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 9, 3, 279, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1ctp4RlexVdkzhRCpjuMjr_vxqX0Cf0NR', N'payphone , Maroon5', 1225)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (33, NULL, N'The River', N'http://docs.google.com/uc?export=open&id=1iwhR4LFHoZtM34JHACPZRGe7rEHsOwr5                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 15, 6, 212, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1iwhR4LFHoZtM34JHACPZRGe7rEHsOwr5', N'Alan Walker', 66)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (35, NULL, N'NGẪU HỨNG', N'http://docs.google.com/uc?export=open&id=1DGOkgrPs66jypcsgMDDg2qSpUTYrl4VO                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 10, 6, 195, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1DGOkgrPs66jypcsgMDDg2qSpUTYrl4VO', N'Unknown', 69)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (36, NULL, N'BIGCITYBOI', N'http://docs.google.com/uc?export=open&id=1yl3GTjmjsirzQ6xfEhzIYZBqZHIZ40xQ                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 6, 4, 223, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1yl3GTjmjsirzQ6xfEhzIYZBqZHIZ40xQ', N'Binz', 13)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (37, NULL, N'Hà Nội Xịn', N'http://docs.google.com/uc?export=open&id=1BwmfWVjcRnlqRwjf3f_rdaBBiA1Jin05                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 11, 4, 211, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1BwmfWVjcRnlqRwjf3f_rdaBBiA1Jin05', N'ha noi xin , LK', 69)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (38, NULL, N'SAO CHA KHÔNG NÓI', N'http://docs.google.com/uc?export=open&id=1XHAD6X5Zj-NfANpkETSMWhwe90VZNAfm                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 14, 1, 285, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1XHAD6X5Zj-NfANpkETSMWhwe90VZNAfm', N'sao cha khong noi , Phan Mạnh Quỳnh , phan manh quynh', 101)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (39, NULL, N'CHA GIÀ RỒI ĐÚNG KHÔNG', N'http://docs.google.com/uc?export=open&id=1CGyRl1Z29cNtkejbjD1u7UDTdRnwz5w7                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 5, 1, 318, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1CGyRl1Z29cNtkejbjD1u7UDTdRnwz5w7', N'cha gia roi dung khong , Ali Hoàng Dương , ali hoang duong', 14)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (40, NULL, N'Alone Remix', N'http://docs.google.com/uc?export=open&id=1zsmyx51KRaZMng7ecISBi2cw96DN9BX3                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 15, 5, 157, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1zsmyx51KRaZMng7ecISBi2cw96DN9BX3', N'Alan Walker', 100)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (41, NULL, N'TÌNH BẠN DIỆU KỲ', N'http://docs.google.com/uc?export=open&id=1GmTghNY6jcj1OnGeFN_t7jc7smQlZnTh                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 16, 5, 170, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1GmTghNY6jcj1OnGeFN_t7jc7smQlZnTh', N'tinh ban dieu ki, Amee', 52)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (42, NULL, N'Post', N'http://docs.google.com/uc?export=open&id=1Bw5XEL4tAQE07k7n_qC-TIn6XcgSX8Wd                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 17, 3, 226, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1Bw5XEL4tAQE07k7n_qC-TIn6XcgSX8Wd', N'Post Melone', 13)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (43, NULL, N'Gọi đò', N'http://docs.google.com/uc?export=open&id=1cAnM7qaI-7dcdce4YD7r-nF7En5xdgMq                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 18, 7, 326, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1cAnM7qaI-7dcdce4YD7r-nF7En5xdgMq', N'goi do , Dương Ngọc Thái , duong ngoc thai', 88)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (44, NULL, N'TÀU ĐÊM NĂM CŨ', N'http://docs.google.com/uc?export=open&id=1g8i0i0SxaHhIS4HeYi_5MW6Mo2Jn9xZl                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 18, 7, 293, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1g8i0i0SxaHhIS4HeYi_5MW6Mo2Jn9xZl', N'tau dem nam cu , Dương Ngọc Thái , duong ngoc thai', 46)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (48, NULL, N'Yêu Mà', N'http://docs.google.com/uc?export=open&id=1CteDCVLw5cujHRc9d_t6xg8fw8POqLn9                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 4, 1, 296, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1CteDCVLw5cujHRc9d_t6xg8fw8POqLn9', N'yeu ma, khac viet', 103)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (51, 1, N'Anh Sẽ Sống Tốt Hơn', N'http://docs.google.com/uc?export=open&id=1LdSXvTg3bDKQJNco6t4MYsOEgA3GvGjl                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 1, 1, 293, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1LdSXvTg3bDKQJNco6t4MYsOEgA3GvGjl', N'anh se song tot ma , du thien , du thiên', 34)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (53, 1, N'Tình Anh Không Đổi Thay', N'http://docs.google.com/uc?export=open&id=1isVQi1v__SL1hHO6TlCH5prfAvf0cbam                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 1, 1, 318, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1isVQi1v__SL1hHO6TlCH5prfAvf0cbam', N'tinh anh khong doi thay , doi thay , du thien , du thiên', 12)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (54, 1, N'Hãy Khóc Đi Em', N'http://docs.google.com/uc?export=open&id=17kWqmKI0rlLdMTUhbMWBo-i2aJgey2X2                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 1, 1, 267, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=17kWqmKI0rlLdMTUhbMWBo-i2aJgey2X2', N'hay khoc di em, du thien , Du thien ,du thiên', 44)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (56, 2, N'Em Phải Quên Anh', N'http://docs.google.com/uc?export=open&id=18jxxdjJNdgn0VveEyuDxjAc4RbN-oijg                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 2, 1, 320, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=18jxxdjJNdgn0VveEyuDxjAc4RbN-oijg', N'em phai quen anh , chau khai phong , khai phong', 22)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (57, 2, N'Những Ngày Vui Trở Lại', N'http://docs.google.com/uc?export=open&id=1AGrsEuJprslkKCU13sgZZd84E5pE5YSp                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 2, 1, 310, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1AGrsEuJprslkKCU13sgZZd84E5pE5YSp', N'nhung ngay vui tro lai , chau khai phong , khai phong', 21)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (58, 3, N'Somebody To Love', N'http://docs.google.com/uc?export=open&id=1KXcpUQsXLlRACQNz-cbuNQuOxZwgFTro                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 12, 3, 220, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1KXcpUQsXLlRACQNz-cbuNQuOxZwgFTro', N'Somebody To love , justin , justin bieber', 100)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (59, 3, N'Never Let You Go', N'http://docs.google.com/uc?export=open&id=1cY4YoQf8iMcnhYLTyHjmQKoca7t53XwZ                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 12, 3, 264, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1cY4YoQf8iMcnhYLTyHjmQKoca7t53XwZ  ', N'nerver let you go , justin , justin bieber', 21)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (60, 3, N'Stuck In The Moment', N'http://docs.google.com/uc?export=open&id=1Y0ZIb1CV68OF3kovtM27iJDowfb3OHpk                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 12, 3, 223, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1Y0ZIb1CV68OF3kovtM27iJDowfb3OHpk', N'stuck in the moment , justin , justin bieber', 33)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (61, 4, N'Anh Khác Hay Em Khác', N'http://docs.google.com/uc?export=open&id=1fNtKYJt-gFKkRIqccRchK_LHXtdKuPBo                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 4, 1, 258, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1fNtKYJt-gFKkRIqccRchK_LHXtdKuPBo', N'anh khac hay em khac , khac viet , khắc việt', 12)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (62, 4, N'Mất Cảm Giác Yêu', N'http://docs.google.com/uc?export=open&id=1FlTua-RndDcB7U7lYeVim1W_HZaxssPz                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 4, 1, 244, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1FlTua-RndDcB7U7lYeVim1W_HZaxssPz', N'mat cam giac yeu , khac viet , khắc việt', 2)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (63, 4, N'Anh Cần Em', N'http://docs.google.com/uc?export=open&id=1Jf56LsFZDKkYA9S_07Nf3KyTHLXm_HWl                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 4, 1, 249, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1Jf56LsFZDKkYA9S_07Nf3KyTHLXm_HWl', N'anh can em , khac viet', 3)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (67, NULL, N'Đồi Thông Hai Mộ', N'http://docs.google.com/uc?export=open&id=1e6Fn9rPnwas4xSgxRqz2lEMOaUE7B5u4                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 20, 7, 405, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1e6Fn9rPnwas4xSgxRqz2lEMOaUE7B5u4', N'doi thong hai mo , le quyen', 105)
INSERT [dbo].[song] ([id], [album_id], [title], [file], [lyrics], [artist_id], [genre_id], [duration], [urlDownload], [keySearch], [viewed]) VALUES (70, NULL, N'Về Quê', N'http://docs.google.com/uc?export=open&id=1w5iVfDbNqi8zaXci79fg2sC6ALOMCfQc                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ', NULL, 21, 7, 239, N'https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1w5iVfDbNqi8zaXci79fg2sC6ALOMCfQc', N've que , le ngoc thuy
', 103)
SET IDENTITY_INSERT [dbo].[song] OFF
USE [master]
GO
ALTER DATABASE [Vmusic] SET  READ_WRITE 
GO
