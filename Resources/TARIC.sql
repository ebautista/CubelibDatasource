USE [mdb_taric]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTS]') AND type in (N'U'))
DROP TABLE [dbo].[CLIENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CN]') AND type in (N'U'))
DROP TABLE [dbo].[CN]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_COMMON_SUPP_STAT_LOCK_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[COMMON] DROP CONSTRAINT [DF_COMMON_SUPP_STAT_LOCK_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_COMMON_SUPP_CALC_LOCK_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[COMMON] DROP CONSTRAINT [DF_COMMON_SUPP_CALC_LOCK_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_COMMON_GROSS_WT_LOCK_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[COMMON] DROP CONSTRAINT [DF_COMMON_GROSS_WT_LOCK_CODE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMMON]') AND type in (N'U'))
DROP TABLE [dbo].[COMMON]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_PERFORM_UPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_PERFORM_UPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EXPORT_DEF_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EXPORT] DROP CONSTRAINT [DF_EXPORT_DEF_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EXPORT_COMM_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EXPORT] DROP CONSTRAINT [DF_EXPORT_COMM_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EXPORT_LIC_REQD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EXPORT] DROP CONSTRAINT [DF_EXPORT_LIC_REQD]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT]') AND type in (N'U'))
DROP TABLE [dbo].[EXPORT]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_DEF_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT] DROP CONSTRAINT [DF_IMPORT_DEF_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_COMM_CODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT] DROP CONSTRAINT [DF_IMPORT_COMM_CODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_LIC_REQUIRED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT] DROP CONSTRAINT [DF_IMPORT_LIC_REQUIRED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT]') AND type in (N'U'))
DROP TABLE [dbo].[IMPORT]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PROPERTIES_AUTOSAVE_TEST_DOCS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PROPERTIES] DROP CONSTRAINT [DF_PROPERTIES_AUTOSAVE_TEST_DOCS]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPERTIES]') AND type in (N'U'))
DROP TABLE [dbo].[PROPERTIES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SUPP UNITS]') AND type in (N'U'))
DROP TABLE [dbo].[SUPP UNITS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SUPP UNITS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SUPP UNITS](
	[SUPP UNIT] [nvarchar](2) NULL,
	[SUPP QTY CODE] [nvarchar](2) NULL,
	[GROSS WT CALC CODE] [nvarchar](2) NULL,
	[ASCII UNIT] [nvarchar](50) NULL,
	[DESC ENGLISH] [nvarchar](50) NULL,
	[DESC DUTCH] [nvarchar](50) NULL,
	[DESC FRENCH] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROPERTIES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PROPERTIES](
	[USE] [smallint] NULL,
	[MIN LIC VALUE] [nvarchar](14) NULL,
	[MIN VALUE CURR] [nvarchar](3) NULL,
	[AUTOSAVE TEST DOCS] [bit] NOT NULL CONSTRAINT [DF_PROPERTIES_AUTOSAVE_TEST_DOCS]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IMPORT](
	[TARIC CODE] [nvarchar](10) NOT NULL,
	[CTRY CODE] [nvarchar](3) NOT NULL,
	[DEF CODE] [bit] NOT NULL CONSTRAINT [DF_IMPORT_DEF_CODE]  DEFAULT ((0)),
	[COMM CODE] [bit] NOT NULL CONSTRAINT [DF_IMPORT_COMM_CODE]  DEFAULT ((0)),
	[LIC REQD] [bit] NOT NULL CONSTRAINT [DF_IMPORT_LIC_REQUIRED]  DEFAULT ((0)),
	[MIN VALUE] [nvarchar](14) NULL,
	[MIN VALUE CURR] [nvarchar](3) NULL,
	[N1] [nvarchar](5) NULL,
	[N2] [nvarchar](5) NULL,
	[N3] [nvarchar](5) NULL,
	[O1] [nvarchar](7) NULL,
	[O2] [nvarchar](7) NULL,
	[O3] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[P2] [nvarchar](6) NULL,
	[P3] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[Q2] [nvarchar](12) NULL,
	[Q3] [nvarchar](12) NULL,
	[R1] [nvarchar](2) NULL,
	[R2] [nvarchar](6) NULL,
	[R3] [nvarchar](2) NULL,
	[R4] [nvarchar](6) NULL,
	[R5] [nvarchar](2) NULL,
	[R6] [nvarchar](6) NULL,
	[R7] [nvarchar](2) NULL,
	[R8] [nvarchar](6) NULL,
	[R9] [nvarchar](2) NULL,
	[RA] [nvarchar](6) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EXPORT](
	[TARIC CODE] [nvarchar](10) NOT NULL,
	[CTRY CODE] [nvarchar](3) NOT NULL,
	[DEF CODE] [bit] NOT NULL CONSTRAINT [DF_EXPORT_DEF_CODE]  DEFAULT ((0)),
	[COMM CODE] [bit] NOT NULL CONSTRAINT [DF_EXPORT_COMM_CODE]  DEFAULT ((0)),
	[LIC REQD] [bit] NOT NULL CONSTRAINT [DF_EXPORT_LIC_REQD]  DEFAULT ((0)),
	[N1] [nvarchar](5) NULL,
	[N2] [nvarchar](5) NULL,
	[N3] [nvarchar](5) NULL,
	[O1] [nvarchar](7) NULL,
	[O2] [nvarchar](7) NULL,
	[O3] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[P2] [nvarchar](6) NULL,
	[P3] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[Q2] [nvarchar](12) NULL,
	[Q3] [nvarchar](12) NULL,
	[R1] [nvarchar](2) NULL,
	[R2] [nvarchar](6) NULL,
	[R3] [nvarchar](2) NULL,
	[R4] [nvarchar](6) NULL,
	[R5] [nvarchar](2) NULL,
	[R6] [nvarchar](6) NULL,
	[R7] [nvarchar](2) NULL,
	[R8] [nvarchar](6) NULL,
	[R9] [nvarchar](2) NULL,
	[RA] [nvarchar](6) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBProperties](
	[DBProps_Version] [nvarchar](20) NULL,
	[DBProps_Date] [datetime] NULL,
	[DBProps_Exe_Date] [datetime] NULL,
	[DBProps_PerformUpdates_Completed] [bit] NOT NULL CONSTRAINT [DF_DBPROPERTIES_PERFORM_UPDATES_COMPLETED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMMON]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMMON](
	[TARIC CODE] [nvarchar](10) NOT NULL,
	[KEY DUTCH] [nvarchar](20) NULL,
	[KEY FRENCH] [nvarchar](20) NULL,
	[SUPP STAT UNIT] [nvarchar](2) NULL,
	[SUPP STAT QTY CODE] [nvarchar](2) NULL,
	[SUPP STAT LOCK CODE] [bit] NOT NULL CONSTRAINT [DF_COMMON_SUPP_STAT_LOCK_CODE]  DEFAULT ((0)),
	[SUPP CALC UNIT] [nvarchar](2) NULL,
	[SUPP CALC QTY CODE] [nvarchar](2) NULL,
	[SUPP CALC LOCK CODE] [bit] NOT NULL CONSTRAINT [DF_COMMON_SUPP_CALC_LOCK_CODE]  DEFAULT ((0)),
	[GROSS WT CALC CODE] [nvarchar](2) NULL,
	[GROSS WT LOCK CODE] [bit] NOT NULL CONSTRAINT [DF_COMMON_GROSS_WT_LOCK_CODE]  DEFAULT ((0)),
	[DESC DUTCH] [nvarchar](max) NULL,
	[DESC FRENCH] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CN](
	[CN CODE] [nvarchar](8) NOT NULL,
	[DESC DUTCH] [nvarchar](250) NULL,
	[DESC FRENCH] [nvarchar](250) NULL,
	[SUPP STAT UNIT] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CLIENTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CLIENTS](
	[TARIC CODE] [nvarchar](10) NOT NULL,
	[VAT NUM OR NAME] [nvarchar](32) NOT NULL
) ON [PRIMARY]
END
GO
