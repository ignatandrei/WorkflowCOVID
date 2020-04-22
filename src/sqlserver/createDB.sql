USE test
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[PatientStatus] DROP CONSTRAINT IF EXISTS [FK_PatientStatus_Patient]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientStatus]') AND type in (N'U'))
ALTER TABLE [dbo].[PatientStatus] DROP CONSTRAINT IF EXISTS [FK_PatientStatus_CovidStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientMedicalTest]') AND type in (N'U'))
ALTER TABLE [dbo].[PatientMedicalTest] DROP CONSTRAINT IF EXISTS [FK_PatientMedicalTest_Patient]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PatientMedicalTest]') AND type in (N'U'))
ALTER TABLE [dbo].[PatientMedicalTest] DROP CONSTRAINT IF EXISTS [FK_PatientMedicalTest_MedicalTests]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[LocationPatient] DROP CONSTRAINT IF EXISTS [FK_LocationPatient_Patient]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocationPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[LocationPatient] DROP CONSTRAINT IF EXISTS [FK_LocationPatient_Location]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BedPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[BedPatient] DROP CONSTRAINT IF EXISTS [FK_BedPatient_Patient]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BedPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[BedPatient] DROP CONSTRAINT IF EXISTS [FK_BedPatient_Bed]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bed]') AND type in (N'U'))
ALTER TABLE [dbo].[Bed] DROP CONSTRAINT IF EXISTS [FK_BedInRoom_PatientRoom]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AnamnesisPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[AnamnesisPatient] DROP CONSTRAINT IF EXISTS [FK_AnamnesisPatient_Patient]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AnamnesisPatient]') AND type in (N'U'))
ALTER TABLE [dbo].[AnamnesisPatient] DROP CONSTRAINT IF EXISTS [FK_AnamnesisPatient_Anamnesis]
GO
/****** Object:  Table [dbo].[StatusMedicalTest]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[StatusMedicalTest]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Room]
GO
/****** Object:  Table [dbo].[PatientStatus]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[PatientStatus]
GO
/****** Object:  Table [dbo].[PatientMedicalTest]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[PatientMedicalTest]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Patient]
GO
/****** Object:  Table [dbo].[MedicalTests]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[MedicalTests]
GO
/****** Object:  Table [dbo].[LocationPatient]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[LocationPatient]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Location]
GO
/****** Object:  Table [dbo].[CovidStatus]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[CovidStatus]
GO
/****** Object:  Table [dbo].[BedPatient]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[BedPatient]
GO
/****** Object:  Table [dbo].[Bed]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Bed]
GO
/****** Object:  Table [dbo].[Audit]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Audit]
GO
/****** Object:  Table [dbo].[AnamnesisPatient]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[AnamnesisPatient]
GO
/****** Object:  Table [dbo].[Anamnesis]    Script Date: 4/22/2020 6:44:11 PM ******/
DROP TABLE IF EXISTS [dbo].[Anamnesis]
GO

/****** Object:  Database [WorkflowCovid]    Script Date: 4/22/2020 6:44:11 PM ******/
USE [Test]
GO
/****** Object:  Table [dbo].[Anamnesis]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anamnesis](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayOrder] [int] NULL,
 CONSTRAINT [PK_Anamnesis] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnamnesisPatient]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnamnesisPatient](
	[IDPatient] [bigint] NOT NULL,
	[IDAnamnesis] [bigint] NOT NULL,
	[Details] [nvarchar](500) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_AnamnesisPatient] PRIMARY KEY CLUSTERED 
(
	[IDPatient] ASC,
	[IDAnamnesis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Audit]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit](
	[ID] [uniqueidentifier] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[DateTimeModified] [datetime] NOT NULL,
	[KeyValues] [nvarchar](50) NOT NULL,
	[OldValues] [nvarchar](1000) NULL,
	[NewValues] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bed]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bed](
	[IDBed] [bigint] IDENTITY(1,1) NOT NULL,
	[IDRoom] [int] NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_BedInRoom] PRIMARY KEY CLUSTERED 
(
	[IDBed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BedPatient]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BedPatient](
	[IDPatient] [bigint] NOT NULL,
	[IDBed] [bigint] NOT NULL,
	[DateModification] [datetime] NULL,
 CONSTRAINT [PK_BedPatient] PRIMARY KEY CLUSTERED 
(
	[IDPatient] ASC,
	[IDBed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CovidStatus]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CovidStatus](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CovidStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusInHospital] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocationPatient]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationPatient](
	[IDPatient] [bigint] NOT NULL,
	[IDLocation] [int] NOT NULL,
	[DateModif] [datetime] NOT NULL,
 CONSTRAINT [PK_LocationPatient] PRIMARY KEY CLUSTERED 
(
	[IDPatient] ASC,
	[IDLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalTests]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalTests](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MedicalTests] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Comments] [nvarchar](50) NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientMedicalTest]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientMedicalTest](
	[IDPacient] [bigint] NOT NULL,
	[IDMedicalTest] [bigint] NOT NULL,
	[IDMedicalTestStatus] [int] NOT NULL,
	[Result] [nvarchar](50) NULL,
	[DateModification] [datetime] NOT NULL,
 CONSTRAINT [PK_PatientMedicalTest] PRIMARY KEY CLUSTERED 
(
	[IDPacient] ASC,
	[IDMedicalTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientStatus]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientStatus](
	[IDPatient] [bigint] NOT NULL,
	[IDStatus] [int] NOT NULL,
	[DateModification] [datetime] NOT NULL,
 CONSTRAINT [PK_PatientStatus] PRIMARY KEY CLUSTERED 
(
	[IDPatient] ASC,
	[IDStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_PatientRoom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusMedicalTest]    Script Date: 4/22/2020 6:44:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMedicalTest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StatusMedicalTest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Anamnesis] ON 
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (1, N'Istoric fumat', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (2, N'Nr PA', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (3, N'Obezitate', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (4, N'IMC', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (5, N'HTA', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (6, N'Diabet zaharat', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (7, N'Link epidemiologic', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (8, N'Contact COVID', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (9, N'Cu cine a avut contact', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (10, N'Expunere la noxe', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (11, N'Ce expunere', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (12, N'Alte APP', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (13, N'Febra', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (14, N'Temperatura', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (15, N'Dispnee', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (16, N'mMRC', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (17, N'Tuse', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (18, N'Anosmie', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (19, N'Fatigabilitate', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (20, N'Scaderea apetitului', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (21, N'Cefalee', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (22, N'Angina faringiana', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (23, N'Frison', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (24, N'Rinoree', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (25, N'Greata', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (26, N'Varsaturi', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (27, N'Diaree', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (28, N'Scaune diareice', NULL)
GO
INSERT [dbo].[Anamnesis] ([ID], [Name], [DisplayOrder]) VALUES (29, N'Debutul simptomelor', NULL)
GO
SET IDENTITY_INSERT [dbo].[Anamnesis] OFF
GO
SET IDENTITY_INSERT [dbo].[Bed] ON 
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (1, 1, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (2, 1, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (3, 1, N'Pat3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (4, 2, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (5, 2, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (6, 3, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (7, 3, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (8, 4, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (9, 4, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (10, 4, N'Pat3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (11, 5, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (12, 5, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (13, 5, N'Pat3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (14, 5, N'Pat4')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (15, 5, N'Pat 5')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (16, 6, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (17, 6, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (18, 7, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (19, 7, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (20, 8, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (21, 8, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (22, 9, N'Pat 1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (23, 10, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (24, 10, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (25, 11, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (26, 11, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (27, 11, N'Pat 3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (28, 11, N'Pat 4')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (29, 12, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (30, 12, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (31, 13, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (32, 13, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (33, 14, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (34, 14, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (35, 15, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (36, 15, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (37, 16, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (38, 16, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (39, 17, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (40, 17, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (41, 17, N'Pat 3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (42, 18, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (43, 18, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (44, 18, N'Pat 3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (45, 19, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (46, 19, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (47, 19, N'Pat 3')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (48, 20, N'Pat1')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (49, 20, N'Pat2')
GO
INSERT [dbo].[Bed] ([IDBed], [IDRoom], [Name]) VALUES (50, 20, N'Pat 3')
GO
SET IDENTITY_INSERT [dbo].[Bed] OFF
GO
INSERT [dbo].[CovidStatus] ([ID], [Name]) VALUES (1, N'Suspect')
GO
INSERT [dbo].[CovidStatus] ([ID], [Name]) VALUES (2, N'Covid Confirmat')
GO
INSERT [dbo].[Location] ([ID], [Name]) VALUES (1, N'SpitalizareZi')
GO
INSERT [dbo].[Location] ([ID], [Name]) VALUES (2, N'Spitalizare')
GO
INSERT [dbo].[Location] ([ID], [Name]) VALUES (3, N'Acasa')
GO
INSERT [dbo].[Location] ([ID], [Name]) VALUES (4, N'Iesit Evidenta')
GO
SET IDENTITY_INSERT [dbo].[MedicalTests] ON 
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (1, N'PCR SARS COV 2')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (2, N'HLG')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (3, N'VSH')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (4, N'PROT C')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (5, N'Procalcitonina')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (6, N'APTT')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (7, N'INR')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (8, N'Feritina')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (9, N'CK')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (10, N'CK-MB')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (11, N'Troponina')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (12, N'Glicemie')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (13, N'Uree')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (14, N'Creatinina')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (15, N'TGO')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (16, N'TGP')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (17, N'BT')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (18, N'BD')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (19, N'LDH')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (20, N'Hemocult')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (21, N'EAB')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (22, N'Sputa BK')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (23, N'Sputa Flora')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (24, N'GeneXpert')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (25, N'Rx Torace')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (26, N'CT Torace N')
GO
INSERT [dbo].[MedicalTests] ([ID], [Name]) VALUES (27, N'CT Torace K')
GO
SET IDENTITY_INSERT [dbo].[MedicalTests] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (1, N'1A')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (2, N'2A')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (3, N'3A')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (4, N'4A')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (5, N'5A')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (6, N'1B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (7, N'2B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (8, N'3B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (9, N'4B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (10, N'5B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (11, N'6B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (12, N'7B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (13, N'8B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (14, N'9B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (15, N'10B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (16, N'11B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (17, N'12B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (18, N'13B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (19, N'14B')
GO
INSERT [dbo].[Room] ([ID], [Name]) VALUES (20, N'15B')
GO
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusMedicalTest] ON 
GO
INSERT [dbo].[StatusMedicalTest] ([ID], [Name]) VALUES (1, N'Analiza recomandata')
GO
INSERT [dbo].[StatusMedicalTest] ([ID], [Name]) VALUES (2, N'Recoltat Analize')
GO
INSERT [dbo].[StatusMedicalTest] ([ID], [Name]) VALUES (3, N'Analiza Efectuata')
GO
SET IDENTITY_INSERT [dbo].[StatusMedicalTest] OFF
GO
ALTER TABLE [dbo].[AnamnesisPatient]  WITH CHECK ADD  CONSTRAINT [FK_AnamnesisPatient_Anamnesis] FOREIGN KEY([IDAnamnesis])
REFERENCES [dbo].[Anamnesis] ([ID])
GO
ALTER TABLE [dbo].[AnamnesisPatient] CHECK CONSTRAINT [FK_AnamnesisPatient_Anamnesis]
GO
ALTER TABLE [dbo].[AnamnesisPatient]  WITH CHECK ADD  CONSTRAINT [FK_AnamnesisPatient_Patient] FOREIGN KEY([IDPatient])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[AnamnesisPatient] CHECK CONSTRAINT [FK_AnamnesisPatient_Patient]
GO
ALTER TABLE [dbo].[Bed]  WITH CHECK ADD  CONSTRAINT [FK_BedInRoom_PatientRoom] FOREIGN KEY([IDRoom])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[Bed] CHECK CONSTRAINT [FK_BedInRoom_PatientRoom]
GO
ALTER TABLE [dbo].[BedPatient]  WITH CHECK ADD  CONSTRAINT [FK_BedPatient_Bed] FOREIGN KEY([IDBed])
REFERENCES [dbo].[Bed] ([IDBed])
GO
ALTER TABLE [dbo].[BedPatient] CHECK CONSTRAINT [FK_BedPatient_Bed]
GO
ALTER TABLE [dbo].[BedPatient]  WITH CHECK ADD  CONSTRAINT [FK_BedPatient_Patient] FOREIGN KEY([IDPatient])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[BedPatient] CHECK CONSTRAINT [FK_BedPatient_Patient]
GO
ALTER TABLE [dbo].[LocationPatient]  WITH CHECK ADD  CONSTRAINT [FK_LocationPatient_Location] FOREIGN KEY([IDLocation])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[LocationPatient] CHECK CONSTRAINT [FK_LocationPatient_Location]
GO
ALTER TABLE [dbo].[LocationPatient]  WITH CHECK ADD  CONSTRAINT [FK_LocationPatient_Patient] FOREIGN KEY([IDPatient])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[LocationPatient] CHECK CONSTRAINT [FK_LocationPatient_Patient]
GO
ALTER TABLE [dbo].[PatientMedicalTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientMedicalTest_MedicalTests] FOREIGN KEY([IDMedicalTest])
REFERENCES [dbo].[MedicalTests] ([ID])
GO
ALTER TABLE [dbo].[PatientMedicalTest] CHECK CONSTRAINT [FK_PatientMedicalTest_MedicalTests]
GO
ALTER TABLE [dbo].[PatientMedicalTest]  WITH CHECK ADD  CONSTRAINT [FK_PatientMedicalTest_Patient] FOREIGN KEY([IDPacient])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[PatientMedicalTest] CHECK CONSTRAINT [FK_PatientMedicalTest_Patient]
GO
ALTER TABLE [dbo].[PatientStatus]  WITH CHECK ADD  CONSTRAINT [FK_PatientStatus_CovidStatus] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[CovidStatus] ([ID])
GO
ALTER TABLE [dbo].[PatientStatus] CHECK CONSTRAINT [FK_PatientStatus_CovidStatus]
GO
ALTER TABLE [dbo].[PatientStatus]  WITH CHECK ADD  CONSTRAINT [FK_PatientStatus_Patient] FOREIGN KEY([IDPatient])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[PatientStatus] CHECK CONSTRAINT [FK_PatientStatus_Patient]
GO
