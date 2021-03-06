USE [master]
GO
/****** Object:  Database [DEMO_DB]    Script Date: 01/03/2021 11:59:33 ******/
CREATE DATABASE [DEMO_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DEMO_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEMO_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DEMO_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DEMO_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DEMO_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DEMO_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DEMO_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DEMO_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DEMO_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DEMO_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DEMO_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DEMO_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DEMO_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DEMO_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DEMO_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DEMO_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DEMO_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DEMO_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DEMO_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DEMO_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DEMO_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DEMO_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DEMO_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DEMO_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DEMO_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DEMO_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DEMO_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DEMO_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DEMO_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DEMO_DB] SET  MULTI_USER 
GO
ALTER DATABASE [DEMO_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DEMO_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DEMO_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DEMO_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DEMO_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DEMO_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DEMO_DB] SET QUERY_STORE = OFF
GO
USE [DEMO_DB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 01/03/2021 11:59:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [varchar](100) NULL,
	[AddressLine2] [varchar](100) NULL,
	[AddressLine3] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[ZipCode] [int] NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[PartyId] [int] NOT NULL,
	[BrandName] [varchar](100) NOT NULL,
	[Date] [date] NOT NULL,
	[BagQuantity] [int] NULL,
	[BagSizeLength] [decimal](18, 0) NULL,
	[BagSizeWidth] [decimal](18, 0) NULL,
	[BagWeight] [decimal](18, 0) NULL,
	[BagType] [bit] NULL,
	[BoppType] [bit] NULL,
	[BoppMetallize] [bit] NULL,
	[Micron] [decimal](18, 0) NULL,
	[RateType] [bit] NULL,
	[Rate] [decimal](18, 0) NULL,
	[BagMaking] [varchar](max) NULL,
	[CuttingSize] [varchar](50) NULL,
	[CuttingType] [bit] NULL,
	[Bottom] [bit] NULL,
	[Gadget] [bit] NULL,
	[Yan] [bit] NULL,
	[ExpectedDeliveryDate] [date] NULL,
	[PreparedBy] [int] NOT NULL,
	[SpecialInstruction] [varchar](max) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[HasAction] [bit] NOT NULL,
	[Action] [varchar](200) NULL,
	[Controller] [varchar](200) NULL,
	[Class] [varchar](max) NULL,
	[ParentModuleId] [int] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[PartyId] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [varchar](50) NULL,
	[AddressId] [int] NULL,
	[GSTNumber] [char](15) NULL,
	[ContactNumber] [char](10) NOT NULL,
	[AlternateContactNumber] [char](10) NULL,
	[EmailId] [varchar](100) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleModulePermission]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModulePermission](
	[RoleModulePermissionId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_RoleModulePermission] PRIMARY KEY CLUSTERED 
(
	[RoleModulePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateName] [varchar](50) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[TokenId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AuthToken] [varchar](500) NOT NULL,
	[IssuedOn] [datetime] NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](500) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetail](
	[UserDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[EmailId] [varchar](100) NOT NULL,
	[ProfilePicture] [varchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[ContactNumber] [char](10) NOT NULL,
	[AlternateContactNumber] [char](10) NULL,
	[Gender] [bit] NULL,
	[MaritalStatus] [bit] NULL,
	[PermanentAddressId] [int] NULL,
	[CurrentAddressId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_UserDetail] PRIMARY KEY CLUSTERED 
(
	[UserDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleName] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedBy] [int] NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUserRole]    Script Date: 01/03/2021 11:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUserRole](
	[UserUserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UserRoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserUserRole] PRIMARY KEY CLUSTERED 
(
	[UserUserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (1, N'Administration', 0, NULL, NULL, N'fa fa-circle-o', NULL)
INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (2, N'User', 1, N'Get', N'User', N'fa fa-circle-o', 1)
INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (3, N'Role', 1, N'Role', N'Get', N'fa fa-circle-o', 1)
INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (4, N'Role Access & Rights', 1, N'RoleModulePermission', N'Get', N'fa fa-circle-o', 1)
INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (5, N'Inventory', 0, NULL, NULL, N'fa fa-circle-o', NULL)
INSERT [dbo].[Module] ([ModuleId], [Title], [HasAction], [Action], [Controller], [Class], [ParentModuleId]) VALUES (6, N'Stock', 1, N'Stock', N'Get', N'fa fa-circle-o', 5)
SET IDENTITY_INSERT [dbo].[Module] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleModulePermission] ON 

INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (1, 1, 1, 1, CAST(N'2021-01-03T01:37:09.780' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.780' AS DateTime))
INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (2, 1, 2, 1, CAST(N'2021-01-03T01:37:09.797' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.797' AS DateTime))
INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (3, 1, 3, 1, CAST(N'2021-01-03T01:37:09.810' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.810' AS DateTime))
INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (4, 1, 4, 1, CAST(N'2021-01-03T01:37:09.820' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.820' AS DateTime))
INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (5, 1, 5, 1, CAST(N'2021-01-03T01:37:09.823' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.823' AS DateTime))
INSERT [dbo].[RoleModulePermission] ([RoleModulePermissionId], [RoleId], [ModuleId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (6, 1, 6, 1, CAST(N'2021-01-03T01:37:09.827' AS DateTime), 1, CAST(N'2021-01-03T01:37:09.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleModulePermission] OFF
GO
SET IDENTITY_INSERT [dbo].[Token] ON 

INSERT [dbo].[Token] ([TokenId], [UserId], [AuthToken], [IssuedOn], [ExpiresOn]) VALUES (1, 1, N'fbde4281-bdab-40c8-a098-5e3405867751', CAST(N'2021-01-02T12:55:41.417' AS DateTime), CAST(N'2021-01-10T01:48:49.887' AS DateTime))
SET IDENTITY_INSERT [dbo].[Token] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Password], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (1, N'test', N'test', 1, 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime), 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime))
INSERT [dbo].[User] ([UserId], [Username], [Password], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (2, N'admin', N'Admin@123', 1, 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime), 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime))
INSERT [dbo].[User] ([UserId], [Username], [Password], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (3, N'accountant', N'Accountant@123', 1, 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime), 1, CAST(N'2020-12-31T04:59:39.543' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetail] ON 

INSERT [dbo].[UserDetail] ([UserDetailId], [UserId], [FirstName], [MiddleName], [LastName], [EmailId], [ProfilePicture], [DateOfBirth], [ContactNumber], [AlternateContactNumber], [Gender], [MaritalStatus], [PermanentAddressId], [CurrentAddressId], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (3, 1, N'Jasmina', NULL, N'Dafade', N'jasminadafade@gmail.com', NULL, NULL, N'1234567890', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-02-27T16:49:44.827' AS DateTime), NULL, CAST(N'2021-02-27T16:49:44.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([UserRoleId], [UserRoleName], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (1, N'Super Admin', 1, 1, CAST(N'2020-12-31T04:59:44.053' AS DateTime), 1, CAST(N'2020-12-31T04:59:44.053' AS DateTime))
INSERT [dbo].[UserRole] ([UserRoleId], [UserRoleName], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (2, N'Admin', 1, 1, CAST(N'2020-12-31T04:59:44.060' AS DateTime), 1, CAST(N'2020-12-31T04:59:44.060' AS DateTime))
INSERT [dbo].[UserRole] ([UserRoleId], [UserRoleName], [Active], [CreatedBy], [CreatedOn], [ChangedBy], [ChangedOn]) VALUES (3, N'Accountant', 1, 1, CAST(N'2020-12-31T04:59:44.060' AS DateTime), 1, CAST(N'2020-12-31T04:59:44.060' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUserRole] ON 

INSERT [dbo].[UserUserRole] ([UserUserRoleId], [UserId], [UserRoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserUserRole] ([UserUserRoleId], [UserId], [UserRoleId]) VALUES (2, 2, 2)
INSERT [dbo].[UserUserRole] ([UserUserRoleId], [UserId], [UserRoleId]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[UserUserRole] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Module_Title]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [UC_Module_Title] UNIQUE NONCLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Party_PartyName]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[Party] ADD  CONSTRAINT [UC_Party_PartyName] UNIQUE NONCLUSTERED 
(
	[PartyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UC_RoleModulePermission_RoleId_ModuleId]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[RoleModulePermission] ADD  CONSTRAINT [UC_RoleModulePermission_RoleId_ModuleId] UNIQUE NONCLUSTERED 
(
	[RoleId] ASC,
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Token_AuthToken]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[Token] ADD  CONSTRAINT [UC_Token_AuthToken] UNIQUE NONCLUSTERED 
(
	[AuthToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UC_Token_UserId]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[Token] ADD  CONSTRAINT [UC_Token_UserId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_User_Username]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UC_User_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_UserRole_UserRoleName]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [UC_UserRole_UserRoleName] UNIQUE NONCLUSTERED 
(
	[UserRoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UC_UserUserRole_UserId]    Script Date: 01/03/2021 11:59:34 ******/
ALTER TABLE [dbo].[UserUserRole] ADD  CONSTRAINT [UC_UserUserRole_UserId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Job] ADD  CONSTRAINT [DF_job_createdon]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Job] ADD  CONSTRAINT [DF_job_changedon]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[Party] ADD  CONSTRAINT [DF_Party_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Party] ADD  CONSTRAINT [DF_Party_ChangedOn]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[RoleModulePermission] ADD  CONSTRAINT [DF_RoleModulePermission_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[RoleModulePermission] ADD  CONSTRAINT [DF_RoleModulePermission_ChangedOn]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_user_ChangedOn]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[UserDetail] ADD  CONSTRAINT [DF_UserDetail_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserDetail] ADD  CONSTRAINT [DF_UserDetail_ChangedOn]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_ChangedOn]  DEFAULT (getdate()) FOR [ChangedOn]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_State]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_user_changedby] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_user_changedby]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK_Job_user_createdby] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK_Job_user_createdby]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_Module_Module] FOREIGN KEY([ParentModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_Module_Module]
GO
ALTER TABLE [dbo].[Party]  WITH CHECK ADD  CONSTRAINT [FK_Party_User_ChangedBy] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Party] CHECK CONSTRAINT [FK_Party_User_ChangedBy]
GO
ALTER TABLE [dbo].[Party]  WITH CHECK ADD  CONSTRAINT [FK_Party_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Party] CHECK CONSTRAINT [FK_Party_User_CreatedBy]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_RoleModulePermission_ChangedBy] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_RoleModulePermission_ChangedBy]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_RoleModulePermission_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_RoleModulePermission_CreatedBy]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
GO
ALTER TABLE [dbo].[Token]  WITH CHECK ADD  CONSTRAINT [FK_Token_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Token] CHECK CONSTRAINT [FK_Token_User_UserId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_ChangedBy] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_ChangedBy]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_CreatedBy]
GO
ALTER TABLE [dbo].[UserDetail]  WITH CHECK ADD  CONSTRAINT [FK_UserDetail_User_ChangedBy] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserDetail] CHECK CONSTRAINT [FK_UserDetail_User_ChangedBy]
GO
ALTER TABLE [dbo].[UserDetail]  WITH CHECK ADD  CONSTRAINT [FK_UserDetail_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserDetail] CHECK CONSTRAINT [FK_UserDetail_User_CreatedBy]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_ChangedBy] FOREIGN KEY([ChangedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_ChangedBy]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_CreatedBy]
GO
ALTER TABLE [dbo].[UserUserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserUserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserUserRole] CHECK CONSTRAINT [FK_UserUserRole_User]
GO
ALTER TABLE [dbo].[UserUserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserUserRole_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRole] ([UserRoleId])
GO
ALTER TABLE [dbo].[UserUserRole] CHECK CONSTRAINT [FK_UserUserRole_UserRole]
GO
USE [master]
GO
ALTER DATABASE [DEMO_DB] SET  READ_WRITE 
GO
