USE [master]
GO
/****** Object:  Database [CandyMarket]    Script Date: 5/21/2020 8:06:26 AM ******/
CREATE DATABASE [CandyMarket]

GO
USE [CandyMarket]
GO
/****** Object:  Table [dbo].[Candies]    Script Date: 5/21/2020 8:06:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candies](
	[CandyId] [int] IDENTITY(1,1) NOT NULL,
	[CandyName] [varchar](60) NOT NULL,
	[Manufacturer] [varchar](60) NOT NULL,
	[FlavorCategory] [varchar](60) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCandies]    Script Date: 5/21/2020 8:06:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCandies](
	[UserCandyId] [int] IDENTITY(1,1) NOT NULL,
	[CandyId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DateReceived] [datetime] NOT NULL,
	[isConsumed] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/21/2020 8:06:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](60) NOT NULL,
	[LastName] [varchar](60) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Candies] ON 

INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (1, N'Skittles Original', N'Mars, Inc.', N'Fruity')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (2, N'Skittles Sour', N'Mars, Inc.', N'Sour Fruit')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (3, N'M&M Original', N'Mars, Inc.', N'Chocolate')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (4, N'M&M Caramel', N'Mars, Inc.', N'Chocolate')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (5, N'Snickers', N'Mars, Inc.', N'Chocolate')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (6, N'Jelly Belly Original Jelly Beans', N'Jelly Belly', N'Jelly Beans')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (7, N'Bean Boozled', N'Jelly Belly', N'Weird and Unusual')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (8, N'Laffy Taffy', N'Nestle', N'Fruity')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (9, N'Life Saver Gummy Rings Original', N'Wrigley', N'Gummies')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (10, N'Sour Patch Kids', N'Mondelez', N'Sour')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (11, N'Jolly Rancher Original', N'Hershey', N'Hard Candy')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (12, N'Haribo Goldbears', N'Haribo', N'Gummies')
INSERT [dbo].[Candies] ([CandyId], [CandyName], [Manufacturer], [FlavorCategory]) VALUES (13, N'Haribo Starmix', N'Haribo', N'Gummies')
SET IDENTITY_INSERT [dbo].[Candies] OFF
SET IDENTITY_INSERT [dbo].[UserCandies] ON 

INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (1, 3, 3, CAST(N'2020-03-30T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (2, 3, 4, CAST(N'2020-04-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (3, 2, 4, CAST(N'2020-04-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (4, 4, 4, CAST(N'2020-04-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (5, 5, 4, CAST(N'2020-04-04T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (6, 3, 5, CAST(N'2020-05-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (7, 3, 5, CAST(N'2020-05-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (8, 3, 5, CAST(N'2020-05-05T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[UserCandies] ([UserCandyId], [CandyId], [UserId], [DateReceived], [isConsumed]) VALUES (9, 2, 5, CAST(N'2020-05-05T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[UserCandies] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName]) VALUES (1, N'Janet', N'Jackson')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName]) VALUES (2, N'Cyndi', N'Lauper')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName]) VALUES (3, N'Madonna', N'Ciccone')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName]) VALUES (4, N'Cherilyn', N'Sarkisian')
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName]) VALUES (5, N'Tina', N'Turner')
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [CandyMarket] SET  READ_WRITE 
GO
