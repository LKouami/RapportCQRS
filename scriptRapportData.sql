USE [RapportData]
GO
/****** Object:  Table [dbo].[A_Claim]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Claim](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[ClaimType] [tinyint] NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
 CONSTRAINT [Pk_A_Claim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Uk_A_Claim] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_Connections]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Connections](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [int] NOT NULL,
	[DateConnection] [datetime2](7) NOT NULL,
	[IPAddress] [nvarchar](15) NOT NULL,
	[Successful] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_Role]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_Role](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
 CONSTRAINT [Pk_A_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_RoleClaim]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_RoleClaim](
	[RoleId] [tinyint] NOT NULL,
	[ClaimId] [tinyint] NOT NULL,
	[ClaimValue] [nvarchar](2000) NOT NULL,
 CONSTRAINT [Pk_A_RoleClaim] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_User]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Token] [nvarchar](200) NULL,
	[Status] [tinyint] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Modified_By] [int] NOT NULL,
	[Modified_At] [datetime2](7) NOT NULL,
	[Deleted_By] [int] NULL,
	[Deleted_At] [datetime2](7) NULL,
 CONSTRAINT [Pk_A_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_UserClaim]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_UserClaim](
	[UserId] [int] NOT NULL,
	[ClaimId] [tinyint] NOT NULL,
	[ClaimValue] [nvarchar](2000) NOT NULL,
 CONSTRAINT [Pk_A_UserClaim] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[A_UserRole]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[A_UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [tinyint] NOT NULL,
 CONSTRAINT [Pk_A_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S_Activity]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_Activity](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[ContenuAct] [nvarchar](255) NOT NULL,
	[Status] [bit] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Modified_By] [int] NOT NULL,
	[Modified_At] [datetime2](7) NOT NULL,
	[Deleted_By] [int] NULL,
	[Deleted_At] [datetime2](7) NULL,
 CONSTRAINT [Pk_SActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S_TimeTable]    Script Date: 7/23/2020 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S_TimeTable](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[DateDuJour] [datetime2](7) NOT NULL,
	[HeureArrive] [datetime2](7) NOT NULL,
	[HeureDepart] [datetime2](7) NOT NULL,
	[Status] [bit] NOT NULL,
	[Created_By] [int] NOT NULL,
	[Created_At] [datetime2](7) NOT NULL,
	[Modified_By] [int] NOT NULL,
	[Modified_At] [datetime2](7) NOT NULL,
	[Deleted_By] [int] NULL,
	[Deleted_At] [datetime2](7) NULL,
 CONSTRAINT [Pk_S_TimeTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
