Create the Database
######################################################################
Create a database named "BlogDB"

######################################################################
Run the following scripts to create database tables Blog, BlogUser, Comment, Lookup_Type

USE [BlogDB]
GO
--Blog Table
CREATE TABLE [dbo].[Blog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[BlogText] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL
)
ALTER TABLE [dbo].[Blog] ADD CONSTRAINT PK_BlogID PRIMARY KEY(BlogID)
GO

--BlogUser Table
CREATE TABLE [dbo].[BlogUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](10) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Comment Table
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[BlogID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[CommentText] [varchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL
)
GO

--Lookup_Type Table
CREATE TABLE [dbo].[Lookup_Type](
	[TypeID] [int] NOT NULL,
	[Type] [varchar](50) NOT NULL
)
GO

INSERT INTO [dbo].[Lookup_Type]
VALUES
(1, 'Admin User'),
(2, 'Standard User')
GO
######################################################################
Solution level settings

1. Download the project from Git repo
2. Change the connection string "DemoContext" in \demoblog.service\web.config with your sql server information





