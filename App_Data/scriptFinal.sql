USE [master]
GO
/****** Object:  Database [FourQuaterMVC]    Script Date: 08/02/2015 05:06:19 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'FourQuaterMVC')
BEGIN
CREATE DATABASE [FourQuaterMVC] ON  PRIMARY 
( NAME = N'FourQuaterMVC', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FourQuaterMVC.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FourQuaterMVC_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\FourQuaterMVC_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [FourQuaterMVC] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FourQuaterMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FourQuaterMVC] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [FourQuaterMVC] SET ANSI_NULLS OFF
GO
ALTER DATABASE [FourQuaterMVC] SET ANSI_PADDING OFF
GO
ALTER DATABASE [FourQuaterMVC] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [FourQuaterMVC] SET ARITHABORT OFF
GO
ALTER DATABASE [FourQuaterMVC] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [FourQuaterMVC] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [FourQuaterMVC] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [FourQuaterMVC] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [FourQuaterMVC] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [FourQuaterMVC] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [FourQuaterMVC] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [FourQuaterMVC] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [FourQuaterMVC] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [FourQuaterMVC] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [FourQuaterMVC] SET  DISABLE_BROKER
GO
ALTER DATABASE [FourQuaterMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [FourQuaterMVC] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [FourQuaterMVC] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [FourQuaterMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [FourQuaterMVC] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [FourQuaterMVC] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [FourQuaterMVC] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [FourQuaterMVC] SET  READ_WRITE
GO
ALTER DATABASE [FourQuaterMVC] SET RECOVERY SIMPLE
GO
ALTER DATABASE [FourQuaterMVC] SET  MULTI_USER
GO
ALTER DATABASE [FourQuaterMVC] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [FourQuaterMVC] SET DB_CHAINING OFF
GO
USE [FourQuaterMVC]
GO
/****** Object:  Table [dbo].[PageMaster]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PageMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logoPath] [nvarchar](1000) NULL,
	[logoTitle1] [nvarchar](500) NULL,
	[logoTitle2] [nvarchar](500) NULL,
	[welcomeTitle] [nvarchar](500) NULL,
	[welcomeBody] [nvarchar](500) NULL,
	[videoURL] [nvarchar](1000) NULL,
	[thinkingTitle] [nvarchar](500) NULL,
	[chiefThinkTitle1] [nvarchar](500) NULL,
	[chiefThinkBody1] [varchar](5000) NULL,
	[chiefThinkTitle2] [nvarchar](500) NULL,
	[chiefThinkBody2] [varchar](5000) NULL,
	[filmPrintTitle] [nvarchar](500) NULL,
	[filmPrintHeading] [nvarchar](500) NULL,
	[filmPrintDesc] [nvarchar](500) NULL,
	[filmPrintBottomDesc1] [varchar](5000) NULL,
	[filmPrintBottomDesc2] [varchar](5000) NULL,
	[filmPrintBottomDesc3] [varchar](5000) NULL,
	[digitalTitle] [nvarchar](500) NULL,
	[digitalHeading] [nvarchar](500) NULL,
	[digitalDesc] [nvarchar](500) NULL,
	[speakTitle] [nvarchar](500) NULL,
	[speakHeading] [nvarchar](500) NULL,
	[speakDesc] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PageMaster] ON
INSERT [dbo].[PageMaster] ([id], [logoPath], [logoTitle1], [logoTitle2], [welcomeTitle], [welcomeBody], [videoURL], [thinkingTitle], [chiefThinkTitle1], [chiefThinkBody1], [chiefThinkTitle2], [chiefThinkBody2], [filmPrintTitle], [filmPrintHeading], [filmPrintDesc], [filmPrintBottomDesc1], [filmPrintBottomDesc2], [filmPrintBottomDesc3], [digitalTitle], [digitalHeading], [digitalDesc], [speakTitle], [speakHeading], [speakDesc]) VALUES (1, N'aff4da31-1f5a-4d4b-903f-d9807d837887logo.png', N'WELCOME TO <span style="color:rgb(255,255,0);">IM</span>POSSIBILITIES', N'FOUR QUARTERS', N'Welcome to <span style="color:rgb(255,255,0);">im</span>possibilities', N'We''ve had the privilege to co-create imposibilities for some of the world-class brands like Braun, Delonghi, HCL, Usha, Wonderfloor, Dr Morepen, Reve Systems, Telenor and also trusted by dozens of small businesses, startups, &nbsp;NGOs &amp; individuals.', N'69b9c854-3a1c-41b4-ae76-b9cfdb7b12e9rickshaw-drivie-through-the-traffic-congestion-and-street-life-in-the-city-_byicg007r__D.mp4', N'Developing communication for any brand is our passion.', N'Chief Design Thinkers', N'<p style="text-align: left;">A creative professional by training. Mrinal was introduced to design very early in life. At the age of 13, he was the youngest one to win the Soviet-land Nehru award for Art along with Om Puri, Kaifi Azmi and many more.<br style="text-align: left;"></p><p style="text-align: left;">He has worked for Ogilvy, FCB, Triton, Rediffusion and Cheil Worldwide (Korea). He was in the core global team of Cheil which re-positioned Samsung with the "imagine" campaign. Besides advertising, he is also a watch enthusiast.<br></p>', N'Chief Design Thinkers 2', N'<p style="text-align: left;"><p>A creative professional by training. &lt;strong&gt;Mrinal &lt;/strong&gt;was introduced to design very early in life. At the age of 13, he was the youngest one to win the Soviet-land Nehru award for Art along with Om Puri, Kaifi Azmi and many more.</p><p>He has worked for Ogilvy, FCB, Triton, Rediffusion and Cheil Worldwide (Korea). He was in the core global team of Cheil which re-positioned Samsung with the "imagine" campaign. Besides advertising, he is also a watch enthusiast.</p></p>', N'Film & Print', N'Our Recent Projects', N'Take a look at some of the most recent work our DESIGN THINKERS has created', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."', N'Digital', N'Advanced Digital impossibilities', N'Our services comes packed to the brim with tones of impossibilities', N'Partners speak', N'What our partners are saying', N'Don''t just take our words for it, take a look at what our clients have to say')
SET IDENTITY_INSERT [dbo].[PageMaster] OFF
/****** Object:  Table [dbo].[FileAndPrintImageMaster]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileAndPrintImageMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FileAndPrintImageMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[projectTitle] [nvarchar](500) NULL,
	[projectDate] [datetime] NULL,
	[ProjectDesc] [nvarchar](500) NULL,
	[thumbnailUrl] [nvarchar](1000) NULL,
	[OriginalImageUrl] [nvarchar](1000) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__FileAndP__3213E83F31EC6D26] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[FileAndPrintImageMaster] ON
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (1, N'Project Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created', N'a77ec9ac-17ca-407f-850e-f54303448b69filmprint (8).jpg', N'02574a4f-f3fe-4cdd-915e-7c13529fffa4filmprint (8).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (2, N'Project 2 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 2', N'261debbb-de9d-449c-bfde-d124665228ecfilmprint (9).jpg', N'f9453291-0bc5-4c08-8390-74151055a7e8filmprint (9).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (3, N'Project 3 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 3', N'4e817dbe-9ef1-43b8-9d46-e82df2d534fffilmprint (2).jpg', N'cc90dbcb-8dbc-4afe-a373-7f936de3d329filmprint (2).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (4, N'Project 4 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 4', N'c1f05a8d-3ee3-4d82-a5ef-1dc45c7b8cb2filmprint (3).jpg', N'997cbb30-b9d4-4fcf-a3ba-a5597a54d327filmprint (3).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (5, N'Project 5 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 5', N'81e593f6-5f2b-4062-a958-555405afd281filmprint (5).jpg', N'60f9c4c4-aa93-4929-b523-4d2163729fe6filmprint (5).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (6, N'Project 6 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 6', N'4d9c62fc-5695-4cf9-8de9-17dfac098050filmprint (2).jpg', N'45df2fab-21ae-41e3-9d81-4e0c47448137filmprint (2).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (7, N'Project 7 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 7', N'e0b5bdc8-42da-4053-8285-2be65db9457ffilmprint (9).jpg', N'13488769-d55e-4ccb-8642-7357440b2163filmprint (9).jpg', 1)
INSERT [dbo].[FileAndPrintImageMaster] ([id], [projectTitle], [projectDate], [ProjectDesc], [thumbnailUrl], [OriginalImageUrl], [isActive]) VALUES (8, N'Project 8 Title here', CAST(0x0000A1DA00000000 AS DateTime), N'Take a look at some of the most recent work our DESIGN THINKERS has created 8', N'644ad211-2dc3-4d9b-b572-1899b3bf277bfilmprint (4).jpg', N'06bd068d-358f-4f25-8712-fc2d0116e97efilmprint (4).jpg', 1)
SET IDENTITY_INSERT [dbo].[FileAndPrintImageMaster] OFF
/****** Object:  Table [dbo].[DropDownThinking]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DropDownThinking]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DropDownThinking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ddlValue] [varchar](100) NULL,
	[imgPath] [varchar](1000) NULL,
	[sectionTitle] [nvarchar](500) NULL,
	[sectionbody] [varchar](5000) NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DropDownThinking] ON
INSERT [dbo].[DropDownThinking] ([id], [ddlValue], [imgPath], [sectionTitle], [sectionbody], [IsActive]) VALUES (1, N'Project 1', N'1faa59d6-9c72-4d20-b4b9-7a45255c9d79daigram.jpg', N'Current project where DESIGN THINKING is being implemented: Re-positioning of brand Wonderfloor', N'<p style="text-align: left;"><p><b>FOUR QUARTERS</b>&nbsp; partners with organisations to deliver imposibilities through <b>DESIGN THINKING,&nbsp;</b>co-creating fresh and out-of-the-box ideas with end users interests in focus. DESIGN THINKING is a neo branding concept successfully used by leading brands such as Apple, Samsung, infosys, Brand Union etc Unlike analytical thinking, DESIGN THINKING is a process which includes the "building up" of ideas, with few, or no, limits on breadth during a "brainstorming" phase. This helps reduce fear of failure in the participant(s) and encourages input and participation from a wide variety of sources in the ideation phases. One version of the design thinking process has seven stages: define, research, ideate, prototype, choose, implement, and learn. Within these seven steps, problems can be framed, the right questions can be asked, more ideas can be created, and the best answers can be chosen. The steps aren''t linear; can occur simultaneously and', 1)
INSERT [dbo].[DropDownThinking] ([id], [ddlValue], [imgPath], [sectionTitle], [sectionbody], [IsActive]) VALUES (2, N'Project 2', N'bb6d7265-c3dc-44a1-a476-5ddd1041283ddaigram.png', N'Current project where DESIGN THINKING is being implemented: Re-positioning of brand Wonderfloor for project 2', N'<p style="text-align: left;"></p><p style="text-align: left;"><b style="text-align: left;">FOUR QUARTERS</b>&nbsp; partners with organisations to deliver imposibilities through <b>DESIGN THINKING,&nbsp;</b>co-creating fresh and out-of-the-box ideas with end users interests in focus. DESIGN THINKING is a neo branding concept successfully used by leading brands such as Apple, Samsung, infosys, Brand Union etc Unlike analytical thinking, DESIGN THINKING is a process which includes the "building up" of ideas, with few, or no, limits on breadth during a "brainstorming" phase. This helps reduce fear of failure in the participant(s) and encourages input and participation from a wide variety of sources in the ideation phases. One version of the design thinking process has seven stages: define, research, ideate, prototype, choose, implement, and learn. Within these seven steps, problems can be framed, the right questions can be asked, more ideas can be created, and the best answers can be chose', 1)
INSERT [dbo].[DropDownThinking] ([id], [ddlValue], [imgPath], [sectionTitle], [sectionbody], [IsActive]) VALUES (3, N'Project 3', N'793e6d37-ee31-4a51-9300-38f28011baeedaigram.jpg', N'Current project where DESIGN THINKING is being implemented: Re-positioning of brand Wonderfloor for project 3', N'<p style="text-align: left;"></p><p style="text-align: left;"><b style="text-align: left;">FOUR QUARTERS</b>&nbsp; partners with organisations to deliver imposibilities through <b>DESIGN THINKING,&nbsp;</b>co-creating fresh and out-of-the-box ideas with end users interests in focus. DESIGN THINKING is a neo branding concept successfully used by leading brands such as Apple, Samsung, infosys, Brand Union etc Unlike analytical thinking, DESIGN THINKING is a process which includes the "building up" of ideas, with few, or no, limits on breadth during a "brainstorming" phase. This helps reduce fear of failure in the participant(s) and encourages input and participation from a wide variety of sources in the ideation phases. One version of the design thinking process has seven stages: define, research, ideate, prototype, choose, implement, and learn. Within these seven steps, problems can be framed, the right questions can be asked, more ideas can be created, and the best answers can be chose', 1)
INSERT [dbo].[DropDownThinking] ([id], [ddlValue], [imgPath], [sectionTitle], [sectionbody], [IsActive]) VALUES (4, N'Project 4', N'73b019ae-b94a-416b-9c52-9c948d50c95bdaigram.png', N'Current project where DESIGN THINKING is being implemented: Re-positioning of brand Wonderfloor for project 4', N'<p style="text-align: left;"></p><p style="text-align: left;"><b style="text-align: left;">FOUR QUARTERS</b>&nbsp; partners with organisations to deliver imposibilities through <b>DESIGN THINKING,&nbsp;</b>co-creating fresh and out-of-the-box ideas with end users interests in focus. DESIGN THINKING is a neo branding concept successfully used by leading brands such as Apple, Samsung, infosys, Brand Union etc Unlike analytical thinking, DESIGN THINKING is a process which includes the "building up" of ideas, with few, or no, limits on breadth during a "brainstorming" phase. This helps reduce fear of failure in the participant(s) and encourages input and participation from a wide variety of sources in the ideation phases. One version of the design thinking process has seven stages: define, research, ideate, prototype, choose, implement, and learn. Within these seven steps, problems can be framed, the right questions can be asked, more ideas can be created, and the best answers can be chose', 1)
SET IDENTITY_INSERT [dbo].[DropDownThinking] OFF
/****** Object:  Table [dbo].[DropDownHome]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DropDownHome]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DropDownHome](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ddlValue] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DropDownHome] ON
INSERT [dbo].[DropDownHome] ([id], [ddlValue]) VALUES (1, N'DESIGN THINKING')
INSERT [dbo].[DropDownHome] ([id], [ddlValue]) VALUES (2, N'FILMS & PRINT')
INSERT [dbo].[DropDownHome] ([id], [ddlValue]) VALUES (3, N'DIGITAL')
INSERT [dbo].[DropDownHome] ([id], [ddlValue]) VALUES (4, N'PARTNER SPEAK')
SET IDENTITY_INSERT [dbo].[DropDownHome] OFF
/****** Object:  Table [dbo].[DropDownDigital]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DropDownDigital]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DropDownDigital](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ddlValue] [varchar](100) NULL,
	[imgUrl] [varchar](1000) NULL,
	[heading1] [varchar](100) NULL,
	[desc1] [varchar](1000) NULL,
	[heading2] [varchar](100) NULL,
	[desc2] [varchar](1000) NULL,
	[heading3] [varchar](100) NULL,
	[desc3] [varchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DropDownDigital] ON
INSERT [dbo].[DropDownDigital] ([id], [ddlValue], [imgUrl], [heading1], [desc1], [heading2], [desc2], [heading3], [desc3], [IsActive]) VALUES (1, N'DESIGN THINKING', N'bbd6017c-f3fe-4980-9985-76aabefea6e7computer.png', N'The Social Act', N'It''s a very noisy world out there and when you want to be heard, you need to stand out. We help brands build digital properties (sometimes we even extend this to on-ground properties), digital experiences and a unique social media presence across platforms. In short, we''re the guys to help you stand up, stand out, stand loud and stand proud. So if you''re looking for someone to give your brand the edge it deserves, call us maybe.', N'Technology innovations', N'Ideas and innovation go hand in hand. Our technology team understands this better than anybody. They complement every great concept that emerges with stellar innovation, giving it solid form and turning it into reality. What more can one ask for. Need to add something about App.', N'Website', N'Websites and first impressions. Same thing. Your website is your face and your representation on the internet and that makes it vital. It needs to be interactive, intuitive, utilitarian and gorgeous to boot. Thankfully, we can do all that and more. We combine the superpowers of creative copy, design and technology to give you an online destination for your brand, not a website. Because, you know, websites are just so 2013.', 1)
INSERT [dbo].[DropDownDigital] ([id], [ddlValue], [imgUrl], [heading1], [desc1], [heading2], [desc2], [heading3], [desc3], [IsActive]) VALUES (2, N'FILMS & PRINT', N'169a6bc6-b20a-4499-93e9-95bbcfebdf15mobile.png', N'The Social Act 2', N'It''s a very noisy world out there and when you want to be heard, you need to stand out. We help brands build digital properties (sometimes we even extend this to on-ground properties), digital experiences and a unique social media presence across platforms. In short, we''re the guys to help you stand up, stand out, stand loud and stand proud. So if you''re looking for someone to give your brand the edge it deserves, call us maybe.', N'Technology innovations 2', N'Ideas and innovation go hand in hand. Our technology team understands this better than anybody. They complement every great concept that emerges with stellar innovation, giving it solid form and turning it into reality. What more can one ask for. Need to add something about App.', N'Website 2', N'Websites and first impressions. Same thing. Your website is your face and your representation on the internet and that makes it vital. It needs to be interactive, intuitive, utilitarian and gorgeous to boot. Thankfully, we can do all that and more. We combine the superpowers of creative copy, design and technology to give you an online destination for your brand, not a website. Because, you know, websites are just so 2013.', 1)
INSERT [dbo].[DropDownDigital] ([id], [ddlValue], [imgUrl], [heading1], [desc1], [heading2], [desc2], [heading3], [desc3], [IsActive]) VALUES (3, N'DIGITAL', N'bd509ce6-c0fb-48e1-89bd-123d74ef4b842.jpg', N'The Social Act 3', N'It''s a very noisy world out there and when you want to be heard, you need to stand out. We help brands build digital properties (sometimes we even extend this to on-ground properties), digital experiences and a unique social media presence across platforms. In short, we''re the guys to help you stand up, stand out, stand loud and stand proud. So if you''re looking for someone to give your brand the edge it deserves, call us maybe.', N'Technology innovations 3', N'Ideas and innovation go hand in hand. Our technology team understands this better than anybody. They complement every great concept that emerges with stellar innovation, giving it solid form and turning it into reality. What more can one ask for. Need to add something about App.', N'Website 3', N'Websites and first impressions. Same thing. Your website is your face and your representation on the internet and that makes it vital. It needs to be interactive, intuitive, utilitarian and gorgeous to boot. Thankfully, we can do all that and more. We combine the superpowers of creative copy, design and technology to give you an online destination for your brand, not a website. Because, you know, websites are just so 2013.', 1)
INSERT [dbo].[DropDownDigital] ([id], [ddlValue], [imgUrl], [heading1], [desc1], [heading2], [desc2], [heading3], [desc3], [IsActive]) VALUES (4, N'PARTNER SPEAK', N'6cf4490b-3750-4e68-a728-61dd3716d7b5computer.png', N'The Social Act 4', N'It''s a very noisy world out there and when you want to be heard, you need to stand out. We help brands build digital properties (sometimes we even extend this to on-ground properties), digital experiences and a unique social media presence across platforms. In short, we''re the guys to help you stand up, stand out, stand loud and stand proud. So if you''re looking for someone to give your brand the edge it deserves, call us maybe.', N'Technology innovations 4', N'Ideas and innovation go hand in hand. Our technology team understands this better than anybody. They complement every great concept that emerges with stellar innovation, giving it solid form and turning it into reality. What more can one ask for. Need to add something about App.', N'Website 4', N'Websites and first impressions. Same thing. Your website is your face and your representation on the internet and that makes it vital. It needs to be interactive, intuitive, utilitarian and gorgeous to boot. Thankfully, we can do all that and more. We combine the superpowers of creative copy, design and technology to give you an online destination for your brand, not a website. Because, you know, websites are just so 2013.', 1)
INSERT [dbo].[DropDownDigital] ([id], [ddlValue], [imgUrl], [heading1], [desc1], [heading2], [desc2], [heading3], [desc3], [IsActive]) VALUES (5, N'', N'', N'', N'', N'', N'', N'', N'', 0)
SET IDENTITY_INSERT [dbo].[DropDownDigital] OFF
/****** Object:  Table [dbo].[clientMaster]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[clientMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[clientMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logoUrl] [varchar](1000) NULL,
	[logoDesc] [varchar](200) NULL,
	[isActive] [bit] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[clientMaster] ON
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (1, N'de4bc2d1-7189-4bb3-b3df-2e2b07062b18usha.png', N'Usha', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (2, N'15262013-2109-4149-b5ca-5721921c1407dainikbhaskar.png', N'Dainink Bhaskar', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (3, N'9f9e3223-254d-40fc-a873-42d4f661adb3dr.png', N'Dr.Morepen', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (4, N'b6653277-652e-4ca1-8fd8-bc4a774d1e5ahcl.png', N'HCL', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (5, N'53c998ee-72e1-475d-830d-9d95fa1b13a7ibuzz.png', N'iBuzz', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (6, N'1c65ea77-a4bc-4c79-994c-b58fb3d8caa5reva.png', N'Reva', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (7, N'f3e07330-1486-4960-ab3c-da6450b95176del.png', N'Del', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (8, N'e83d11c7-8f30-440f-bf0a-5868786106a1tas.png', N'Tasveer', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (9, N'a5b8bd98-6c77-4f20-b5ba-134a43aa6d01redio.png', N'Redio 94.3', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (10, N'85b786cb-d426-4209-b0de-ae686f1f1495microsoft.png', N'Microsoft', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (11, N'bd450df3-3ca0-46af-a147-5b87e170d2eewonderflor.png', N'WonderFlor', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (12, N'7bdc2c13-a6ec-4b92-b86b-0351f6ba4d88globle.png', N'Globle', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (13, N'6de9801e-434e-4f8f-9636-dfd3e29a1a53bru.png', N'Bru', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (14, N'688315ee-2da8-453d-853e-ea8302e63fbborange.png', N'Orange', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (15, N'd93b03f3-5ad8-4f72-a76c-2554ece111c9maxbhupa.png', N'Maxbhupa', 1)
INSERT [dbo].[clientMaster] ([id], [logoUrl], [logoDesc], [isActive]) VALUES (16, N'b3a06df3-2258-4021-9df2-9a23357d22d4ibuzz.png', N'ibuuz', 0)
SET IDENTITY_INSERT [dbo].[clientMaster] OFF
/****** Object:  Table [dbo].[speakMaster]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[speakMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[speakMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Desc1] [varchar](100) NULL,
	[Desc2] [varchar](100) NULL,
	[logoUrl] [varchar](1000) NULL,
	[logoDesc] [varchar](200) NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__speakMas__3213E83F35BCFE0A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[speakMaster] ON
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (1, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 1', N'd46835c3-92b4-4c23-a9a6-4381dd5c205a01 (1).png', N'', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (2, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 2', N'06ef98f8-722c-4cd8-9399-e4fc25414aed01 (2).png', N'House Sparrow (Passer domesticus)', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (3, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 3', N'337f24c2-9cbf-4a34-8fbc-1a45f77cfd7d01 (3).png', N'House Sparrow (Passer domesticus)', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (4, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 4', N'b75beb75-32f6-4205-b12e-6f4d1d43c58b01 (4).png', N'Fountain of the Pantheon', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (5, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 5', N'0033a97c-2a0f-46bc-b20e-f8bca3d529f701 (5).png', N'Great Egret Chicks', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (6, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 6', N'53aa4154-1520-4e67-9fa2-859790b8dd4101 (6).png', N'Bird Yoga', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (7, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 7', N'6b493573-096f-4fe1-9022-78a2890d9a4b01 (7).png', N'Sweet dreams', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (8, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 8', N'1ee4397f-2a25-4677-a963-4dc5baee648e01 (8).png', N'Elevate', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (9, N'the thing they do with Design Thinking workshop', N'is just amazing, its been great experience 9', N'bfaac4e9-0253-4aed-8b91-19a96b7fe3c501 (9).png', N'Elevate', 1)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (10, N'', N'', N'', N'', 0)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (11, N'jg', N'ghj', N'f66a0e76-114e-42bb-84db-e945689877adreva.png', N'jg', 0)
INSERT [dbo].[speakMaster] ([id], [Desc1], [Desc2], [logoUrl], [logoDesc], [isActive]) VALUES (12, N'hgfhf', N'fgh', N'7b06d2fe-2ec5-4482-bb95-8da53ea082677.jpg', N'fgh', 0)
SET IDENTITY_INSERT [dbo].[speakMaster] OFF
/****** Object:  Table [dbo].[ThinkerBody]    Script Date: 08/02/2015 05:06:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThinkerBody]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ThinkerBody](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ImageURL] [nvarchar](500) NULL,
	[ThinkerBody] [varchar](5000) NULL,
	[Align] [bit] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ThinkerBody] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ThinkerBody] ON
INSERT [dbo].[ThinkerBody] ([id], [ImageURL], [ThinkerBody], [Align], [IsActive]) VALUES (1, N'792490da-4fc7-459e-8484-cbf85d94ba41man.jpg', N'<p style="text-align: left;">A creative professional by training. Mrinal was introduced to design very early in life. At the age of 13, he was the youngest one to win the Soviet-land Nehru award for Art along with Om Puri, Kaifi Azmi and many more.<br style="text-align: left;"></p><p style="text-align: left;">He has worked for Ogilvy, FCB, Triton, Rediffusion and Cheil Worldwide (Korea). He was in the core global team of Cheil which re-positioned Samsung with the "imagine" campaign. Besides advertising, he is also a watch enthusiast.<br></p>', NULL, 1)
INSERT [dbo].[ThinkerBody] ([id], [ImageURL], [ThinkerBody], [Align], [IsActive]) VALUES (2, N'32a766ef-022d-4e1b-b68f-fcb4d87ce573man.jpg', N'<p style="text-align: left;">A creative professional by training. <b style="text-align: left;">Mrinal</b>&nbsp;was introduced to design very early in life. At the age of 13, he was the youngest one to win the Soviet-land Nehru award for Art along with Om Puri, Kaifi Azmi and many more.</p><p style="text-align: left;">He has worked for Ogilvy, FCB, Triton, Rediffusion and Cheil Worldwide (Korea). He was in the core global team of Cheil which re-positioned Samsung with the "imagine" campaign. Besides advertising, he is also a watch enthusiast.</p>', NULL, 1)
INSERT [dbo].[ThinkerBody] ([id], [ImageURL], [ThinkerBody], [Align], [IsActive]) VALUES (3, N'9406177a-1c70-425b-9509-2e7299d91bd86.jpg', N'jvhjghjghjghjgh', 0, 0)
SET IDENTITY_INSERT [dbo].[ThinkerBody] OFF
/****** Object:  StoredProcedure [dbo].[SpThinkModule]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpThinkModule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <18,july,2015>
-- Description:	<Management Title, SubTitle, Images Etc. For Admin>
-- =============================================
CREATE PROCEDURE [dbo].[SpThinkModule]
@ID int=0,
@DDLValue varchar(100)='''',
@ImageUrl nvarchar(1000)='''',
@SectionTitle varchar(500)='''',
@SectionBody varchar(1000)='''',

@ThinkTitle nvarchar(500)='''',
@ChiefThinkTitle1 nvarchar(500)='''',
@ChiefThinkBody1 varchar(5000)='''',
@ChiefThinkTitle2 varchar(500)='''',
@ChiefThinkBody2 varchar(5000)='''',
@Qtype varchar(50)=''''
AS
BEGIN
	if(@Qtype=''InsertInThink'')
	begin
		if Exists(Select 1 from DropDownThinking where DDLValue=@DDLValue And Imgpath=@ImageUrl And SectionTitle=@SectionTitle And sectionbody=@SectionBody And IsActive=0)
		begin
			update DropDownThinking set IsActive=1 where DDLValue=@DDLValue And Imgpath=@ImageUrl And SectionTitle=@SectionTitle And sectionbody=@SectionBody;
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End
		Else if Not Exists(Select 1 from DropDownThinking where DDLValue=@DDLValue And Imgpath=@ImageUrl And SectionTitle=@SectionTitle And sectionbody=@SectionBody And IsActive=1)
		begin
			insert into DropDownThinking(ddlValue,imgPath,sectionTitle,sectionbody)values(@DDLValue,@ImageUrl,@SectionTitle,@SectionBody);
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End
		Else
		Begin
			select ''Data Is Already Exist ....!'';
		End 
	End 
	if(@Qtype=''UpdateInThink'')
	begin
		if Exists(Select 1 from DropDownThinking where DDLValue=@DDLValue And Imgpath=@ImageUrl And SectionTitle=@SectionTitle And sectionbody=@SectionBody And IsActive=0)
		begin
			update DropDownThinking set IsActive=1 where DDLValue=@DDLValue And Imgpath=@ImageUrl And SectionTitle=@SectionTitle And sectionbody=@SectionBody;
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End
		Else 
		Begin
			update DropDownThinking set ddlValue=@DDLValue,imgPath=@ImageUrl,sectionTitle=@SectionTitle,sectionbody=@SectionBody where id=@ID;
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End 
	End 
	if(@Qtype=''UpdateInThink2'')
	begin
		if Exists(Select 1 from DropDownThinking where DDLValue=@DDLValue And SectionTitle=@SectionTitle And sectionbody=@SectionBody And IsActive=0)
		begin
			update DropDownThinking set IsActive=1 where DDLValue=@DDLValue And SectionTitle=@SectionTitle And sectionbody=@SectionBody;
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End
		Else 
		Begin
			update DropDownThinking set ddlValue=@DDLValue,sectionTitle=@SectionTitle,sectionbody=@SectionBody where id=@ID;
			update PageMaster set thinkingTitle=@ThinkTitle,chiefThinkTitle1=@ChiefThinkTitle1,
			chiefThinkBody1=@ChiefThinkBody1,chiefThinkTitle2=@ChiefThinkTitle2,chiefThinkBody2=@ChiefThinkBody2;
		End 
	End 
	if(@Qtype=''SelectFromThink'')
	begin
		Select * from DropDownThinking where IsActive=1;
	End
	if(@Qtype=''Select'')
	begin
		Select * from DropDownHome;
	End
	if(@Qtype=''DeleteFromThink'')
	begin
		update DropDownThinking set IsActive=0 where id=@ID;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spThinkerBody]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThinkerBody]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <1, Aug 2015>
-- Description:	<Managment for Thinker Body Section>
-- =============================================
CREATE PROCEDURE [dbo].[spThinkerBody]
@ID int=0,
@ImageUrl nvarchar(500)='''',
@ThinkerBody varchar(5000)='''',
@Align bit=0,
@Qtype varchar(50)=''''	
AS
BEGIN
	if(@Qtype=''InsertInThinkerBody'')
	begin
		if Exists(Select 1 from ThinkerBody where ImageURL=@ImageUrl AND ThinkerBody=@ThinkerBody AND IsActive=0)
		begin
			update ThinkerBody set IsActive=1 where ImageURL=@ImageUrl AND ThinkerBody=@ThinkerBody;
		End
		if Not Exists(Select 1 from ThinkerBody where ImageURL=@ImageUrl AND ThinkerBody=@ThinkerBody AND IsActive=1)
		begin
			insert into ThinkerBody(ImageURL,ThinkerBody,Align)values(@ImageUrl,@ThinkerBody,@Align);
		end
		Else
		Begin
			select ''Data Is Already Exist ....!'';
		End 
	End 
	if(@Qtype=''UpdateInThinkerBody'')
	begin
		if Exists(Select 1 from ThinkerBody where ImageURL=@ImageUrl AND ThinkerBody=@ThinkerBody AND IsActive=0)
		begin
			update ThinkerBody set isActive=1 where ImageURL=@ImageUrl AND ThinkerBody=@ThinkerBody;
		End
		Else
		begin
			update ThinkerBody set ImageURL=@ImageUrl,ThinkerBody=@ThinkerBody,Align=@Align where id=@ID;
		end
	End 
	
	if(@Qtype=''UpdateInThinkerBody2'')
	begin
		if Exists(Select 1 from ThinkerBody where ThinkerBody=@ThinkerBody AND IsActive=0)
		begin
			update ThinkerBody set IsActive=1 where ThinkerBody=@ThinkerBody;
		End
		Else
		begin
			update ThinkerBody set ThinkerBody=@ThinkerBody,Align=@Align where id=@ID;
		end
	End 
	
	if(@Qtype=''SelectFromThinkerBody'')
	Begin
		Select * From ThinkerBody where IsActive=1;
	End
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spSpeakMaster]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSpeakMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <23, June 2015>
-- Description:	<For Management of Speak Section>
-- =============================================
CREATE PROCEDURE [dbo].[spSpeakMaster]
@Id int=0,
@SpeakTitle varchar(500)='''',
@SpeakHeading varchar(500)='''',
@SpeakDesc varchar(500)='''',
@Desc1 varchar(500)='''',
@Desc2 varchar(500)='''',
@LogoURL varchar(1000)='''',
@LogoDesc varchar(500)='''',
@Qtype varchar(50)=''''
AS
BEGIN
	if(@Qtype=''InsertInSpeakMaster'')
	Begin
		if Exists(Select 1 from speakMaster Where Desc1=@Desc1 And Desc2=@Desc2 And logoUrl=@LogoURL And logoDesc=@LogoDesc And isActive=0)
		Begin
		update speakMaster set isActive=1 Where Desc1=@Desc1 And Desc2=@Desc2 And logoUrl=@LogoURL And logoDesc=@LogoDesc And isActive=0;
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
		else if Not Exists(Select 1 from speakMaster Where Desc1=@Desc1 And Desc2=@Desc2 And logoUrl=@LogoURL And logoDesc=@LogoDesc And isActive=1)
		Begin
		insert into speakMaster(Desc1,Desc2,logoUrl,logoDesc)values(@Desc1,@Desc2,@LogoURL,@LogoDesc);
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
	End
	
	if(@Qtype=''UpdateInSpeakMaster'')
	Begin
		if Exists(Select 1 from speakMaster Where Desc1=@Desc1 And Desc2=@Desc2 And logoUrl=@LogoURL And logoDesc=@LogoDesc And isActive=0)
		Begin
		update speakMaster set isActive=1 Where Desc1=@Desc1 And Desc2=@Desc2 And logoUrl=@LogoURL And logoDesc=@LogoDesc And isActive=0;
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
		else 
		Begin
		update speakMaster set Desc1=@Desc1,Desc2=@Desc2,logoUrl=@LogoURL,logoDesc=@LogoDesc where id=@Id
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
	End
	
	if(@Qtype=''UpdateInSpeakMaster2'')
	Begin
		if Exists(Select 1 from speakMaster Where Desc1=@Desc1 And Desc2=@Desc2 And logoDesc=@LogoDesc And isActive=0)
		Begin
		update speakMaster set isActive=1 Where Desc1=@Desc1 And Desc2=@Desc2 And logoDesc=@LogoDesc And isActive=0;
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
		else 
		Begin
		update speakMaster set Desc1=@Desc1,Desc2=@Desc2,logoDesc=@LogoDesc where id=@Id
		update PageMaster set speakTitle=@SpeakTitle,speakHeading=@SpeakHeading,speakDesc=@SpeakDesc;
		End
	End
	
	if (@Qtype=''SelectfromSpeak'')
	Begin
		Select * from speakMaster where isActive=1;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spMaster]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <23,july 2015>
-- Description:	<Only for Master Page Management>
-- =============================================
CREATE PROCEDURE [dbo].[spMaster]
@ID int=0,
@LogoUrl nvarchar(1000)='''',
@LogoTitle1 nvarchar(500)='''',
@LogoTitle2 nvarchar(500)='''',
@WelcomeTitle nvarchar(500)='''',
@WelcomeBody nvarchar(500)='''',
@VideoURL nvarchar(1000)='''',
@ThinkTitle nvarchar(500)='''',
@ChiefThinkTitle1 nvarchar(500)='''',
@ChiefThinkBody1 varchar(5000)='''',
@ChiefThinkTitle2 nvarchar(500)='''',
@ChiefThinkBody2 varchar(5000)='''',
@FilmPrintTitle nvarchar(500)='''',
@FilmPrintHeading nvarchar(500)='''',
@FilmPrintDesc nvarchar(500)='''',
@FilmPrintBottomDesc1 varchar(5000)='''',
@FilmPrintBottomDesc2 varchar(5000)='''',
@FilmPrintBottomDesc3 varchar(5000)='''',
@DigitalTitle nvarchar(500)='''',
@DigitalHeading nvarchar(500)='''',
@DigitalDesc nvarchar(500)='''',
@SpeakTitle nvarchar(500)='''',
@SpeakHeading nvarchar(500)='''',
@SpeakDesc nvarchar(500)='''',
@Qtype varchar(50)=''''
AS
BEGIN
	if(@Qtype=''Update'')
	Begin
	update PageMaster set logoPath=@LogoUrl,logoTitle1=@LogoTitle1,logoTitle2=@LogoTitle2,welcomeTitle=@WelcomeTitle,welcomeBody=@WelcomeBody,
	videoURL=@VideoURL where id=@ID;
	End
	if(@Qtype=''Update2'')
	Begin
	update PageMaster set logoTitle1=@LogoTitle1,logoTitle2=@LogoTitle2,welcomeTitle=@WelcomeTitle,welcomeBody=@WelcomeBody
	where id=@ID;
	End
	If(@Qtype=''Select'')
	Begin
	Select * From PageMaster;
	End
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spFile_PrintImage]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFile_PrintImage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <23, july 2015>
-- Description:	<For File and Print Images Management>
-- =============================================
CREATE PROCEDURE [dbo].[spFile_PrintImage]
@Id int=0,
@ProjectTitle nvarchar(500)='''',
@ProjectDate datetime='''',
@ProjectDesc nvarchar(500)='''',
@ThumbnailURL nvarchar(1000)='''',
@OrignalImageURL nvarchar(1000)='''',
@filmPrintTitle varchar(500)='''',
@filmPrintHeading varchar(500)='''',
@filmPrintDesc varchar(500)='''',
@filmPrintBottomDesc1 varchar(5000)='''',
@filmPrintBottomDesc2 varchar(5000)='''',
@filmPrintBottomDesc3 varchar(5000)='''',
@Qtype varchar(50)
AS
BEGIN
	if(@Qtype=''InsertinPrintImage'')
	Begin
		if Exists(Select 1 from FileAndPrintImageMaster where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc And isActive=0)
		Begin
			update FileAndPrintImageMaster set isActive=1,thumbnailUrl=@ThumbnailURL,OriginalImageUrl=@OrignalImageURL where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc;
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
		if Not Exists(Select 1 from FileAndPrintImageMaster where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc And isActive=1)
		Begin
			insert into FileAndPrintImageMaster(projectTitle,projectDate,ProjectDesc,thumbnailUrl,OriginalImageUrl)values(@ProjectTitle,@ProjectDate,@ProjectDesc,@ThumbnailURL,@OrignalImageURL);
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
	End
	if(@Qtype=''UpdateinPrintImage'')
	Begin
		if Exists(Select 1 from FileAndPrintImageMaster where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc And isActive=0)
		Begin
			update FileAndPrintImageMaster set isActive=1 where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc;
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
		Else
		Begin
			update FileAndPrintImageMaster set projectTitle=@ProjectTitle,projectDate=@ProjectDate,ProjectDesc=@ProjectDesc,thumbnailUrl=@ThumbnailURL,OriginalImageUrl=@OrignalImageURL where id=@Id; 
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
	End
	if(@Qtype=''UpdateinPrintImage2'')
	Begin
		if Exists(Select 1 from FileAndPrintImageMaster where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc And isActive=0)
		Begin
			update FileAndPrintImageMaster set isActive=1 where projectTitle=@ProjectTitle And projectDate=@ProjectDate And ProjectDesc=@ProjectDesc;
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
		Else
		Begin
			update FileAndPrintImageMaster set projectTitle=@ProjectTitle,projectDate=@ProjectDate,ProjectDesc=@ProjectDesc where id=@Id; 
			update PageMaster set filmPrintTitle=@filmPrintTitle,filmPrintHeading=@filmPrintHeading,filmPrintDesc=@filmPrintDesc,
			filmPrintBottomDesc1=@filmPrintBottomDesc1,filmPrintBottomDesc2=@filmPrintBottomDesc2,filmPrintBottomDesc3=@filmPrintBottomDesc3;
		End
	End
	if(@Qtype=''SelectFromPrintImage'')
	begin
		Select id,projectTitle,(Convert(Varchar,projectDate,103)) As projectDate,ProjectDesc,thumbnailUrl,OriginalImageUrl from FileAndPrintImageMaster where isActive=1;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spDigitalModule]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDigitalModule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <22 june, 2015>
-- Description:	<For Management of Digital Section>
-- =============================================
CREATE PROCEDURE [dbo].[spDigitalModule] 
@Id int=0,
@DDLValue varchar(100)='''',
@ImageUrl nvarchar(1000)='''',
@Heading1 varchar(100)='''',
@Desc1 varchar(1000)='''',
@Heading2 varchar(100)='''',
@Desc2 varchar(1000)='''',
@Heading3 varchar(100)='''',
@Desc3 varchar(1000)='''',
@DigitalTitle varchar(500)='''',
@DigitalHeading varchar(500)='''',
@DigitalDescription varchar(500)='''',
@Qtype varchar(50)=''''
AS
BEGIN
	if(@Qtype=''InsertInDigital'')
	begin
		if Exists(Select 1 from DropDownDigital where ddlValue=@DDLValue And imgUrl=@ImageUrl And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3 And IsActive=0)
		begin
			update DropDownDigital set IsActive=1, ddlValue=@DDLValue,imgUrl=@ImageUrl,heading1=@Heading1,heading2=@Heading2,heading3=@Heading3,desc1=@Desc1,desc2=@Desc2,desc3=@Desc3; 
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
		if Not Exists(Select 1 from DropDownDigital where ddlValue=@DDLValue And imgUrl=@ImageUrl And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3 And IsActive=1)
		begin
			insert into DropDownDigital(ddlValue,imgUrl,heading1,heading2,heading3,desc1,desc2,desc3)values(@DDLValue,@ImageUrl,@Heading1,@Heading2,@Heading3,@Desc1,@Desc2,@Desc3);
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
		Else
		Begin
			select ''Data Is Already Exist ....!'';
		End 
	End 
	if(@Qtype=''UpdateinDigital'')
	begin
		if Exists(Select 1 from DropDownDigital where ddlValue=@DDLValue And imgUrl=@ImageUrl And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3 And IsActive=0)
		begin
			update DropDownDigital set IsActive=1 where ddlValue=@DDLValue And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3; 
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
		else
		begin
			update DropDownDigital set ddlValue=@DDLValue,imgUrl=@ImageUrl,heading1=@Heading1,heading2=@Heading2,heading3=@Heading3,desc1=@Desc1,desc2=@Desc2,desc3=@Desc3 where id=@Id;
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
	End 
	if(@Qtype=''UpdateinDigital2'')
	begin
		if Exists(Select 1 from DropDownDigital where ddlValue=@DDLValue And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3 And IsActive=0)
		begin
			update DropDownDigital set IsActive=1 where ddlValue=@DDLValue And heading1=@Heading1 And heading2=@Heading2 And heading3=@Heading3 And desc1=@Desc1 and desc2=@Desc2 And desc3=@Desc3; 
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
		else
		begin
			update DropDownDigital set ddlValue=@DDLValue,heading1=@Heading1,heading2=@Heading2,heading3=@Heading3,desc1=@Desc1,desc2=@Desc2,desc3=@Desc3 where id=@Id;
			update PageMaster set digitalTitle=@DigitalTitle,digitalHeading=@DigitalHeading,digitalDesc=@DigitalDescription;
		End
	End 
	if(@Qtype=''SelectFromDigital'')
	begin
		Select * from DropDownDigital where IsActive=1;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spClient]    Script Date: 08/02/2015 05:06:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spClient]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <23, july 2015>
-- Description:	<Management Of Client Page>
-- =============================================
CREATE PROCEDURE [dbo].[spClient]
@ID int=0,
@LogoUrl nvarchar(1000)='''',
@LogoDesc varchar(500)='''',
@Qtype varchar(50)=''''
AS
BEGIN
	if(@Qtype=''InsertInClient'')
	begin
		if Exists(Select 1 from clientMaster where logoUrl=@LogoUrl AND logoDesc=@LogoDesc AND isActive=0)
		begin
			update clientMaster set isActive=1 where logoUrl=@LogoUrl AND logoDesc=@LogoDesc;
		End
		if Not Exists(Select 1 from clientMaster where logoUrl=@LogoUrl AND logoDesc=@LogoDesc AND isActive=1)
		begin
			insert into clientMaster(logoUrl,logoDesc)values(@LogoUrl,@LogoDesc);
		end
		Else
		Begin
			select ''Data Is Already Exist ....!'';
		End 
	End 
	if(@Qtype=''UpdateInClient'')
	begin
		if Exists(Select 1 from clientMaster where logoUrl=@LogoUrl AND logoDesc=@LogoDesc AND isActive=0)
		begin
			update clientMaster set isActive=1 where logoUrl=@LogoUrl AND logoDesc=@LogoDesc;
		End
		Else
		begin
			update clientMaster set logoUrl=@LogoUrl,logoDesc=@LogoDesc where id=@ID;
		end
	End 
	
	if(@Qtype=''UpdateInClient2'')
	begin
		if Exists(Select 1 from clientMaster where logoDesc=@LogoDesc AND isActive=0)
		begin
			update clientMaster set isActive=1 where logoDesc=@LogoDesc;
		End
		Else
		begin
			update clientMaster set logoDesc=@LogoDesc where id=@ID;
		end
	End 
	
	if(@Qtype=''SelectFromClient'')
	Begin
		Select * From clientMaster where isActive=1;
	End
END

' 
END
GO
/****** Object:  Default [DF_FileAndPrintImageMaster_isActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_FileAndPrintImageMaster_isActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[FileAndPrintImageMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FileAndPrintImageMaster_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[FileAndPrintImageMaster] ADD  CONSTRAINT [DF_FileAndPrintImageMaster_isActive]  DEFAULT ((1)) FOR [isActive]
END


End
GO
/****** Object:  Default [DF_DropDownThinking_IsActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DropDownThinking_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[DropDownThinking]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DropDownThinking_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DropDownThinking] ADD  CONSTRAINT [DF_DropDownThinking_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_DropDownDigital_IsActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DropDownDigital_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[DropDownDigital]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DropDownDigital_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DropDownDigital] ADD  CONSTRAINT [DF_DropDownDigital_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_clientMaster_isActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_clientMaster_isActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[clientMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_clientMaster_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[clientMaster] ADD  CONSTRAINT [DF_clientMaster_isActive]  DEFAULT ((1)) FOR [isActive]
END


End
GO
/****** Object:  Default [DF_speakMaster_isActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_speakMaster_isActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[speakMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_speakMaster_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[speakMaster] ADD  CONSTRAINT [DF_speakMaster_isActive]  DEFAULT ((1)) FOR [isActive]
END


End
GO
/****** Object:  Default [DF_ThinkerBody_IsActive]    Script Date: 08/02/2015 05:06:22 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ThinkerBody_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[ThinkerBody]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ThinkerBody_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ThinkerBody] ADD  CONSTRAINT [DF_ThinkerBody_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
