CREATE DATABASE [TimeTracker]
GO

USE [TimeTracker]
GO

CREATE TABLE [dbo].[Users](
	[ID] [nvarchar](6) NULL,
	[FName] [nvarchar](25) NULL,
	[LName] [nvarchar](25) NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Activities](
	[ID] [nvarchar](6) NULL,
	[Name] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Assignments](
	[UserID] [nvarchar](6) NULL,
	[ActivityID] [nvarchar](6) NULL,
	[Active] [nvarchar](5) NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Hours](
	[UserID] [nvarchar](6) NULL,
	[ActivityID] [nvarchar](6) NULL,
	[Year] [int] NULL,
	[Week] [int] NULL,
	[Hours] [decimal](18, 2) NULL
) ON [PRIMARY]

GO


