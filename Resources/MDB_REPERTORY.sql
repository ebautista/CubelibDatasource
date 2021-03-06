USE [mdb_repertory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Code Translation]') AND type in (N'U'))
DROP TABLE [dbo].[Code Translation]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_COLUMNS_SORTED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Columns] DROP CONSTRAINT [DF_COLUMNS_SORTED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_COLUMNS_FILTERED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Columns] DROP CONSTRAINT [DF_COLUMNS_FILTERED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Columns]') AND type in (N'U'))
DROP TABLE [dbo].[Columns]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EXPORT_FINAL_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Export] DROP CONSTRAINT [DF_EXPORT_FINAL_PRINT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Export]') AND type in (N'U'))
DROP TABLE [dbo].[Export]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FIELDS_SORTED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] DROP CONSTRAINT [DF_FIELDS_SORTED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FIELDS_FILTERED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Fields] DROP CONSTRAINT [DF_FIELDS_FILTERED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND type in (N'U'))
DROP TABLE [dbo].[Fields]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_FINAL_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Import] DROP CONSTRAINT [DF_IMPORT_FINAL_PRINT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Import]') AND type in (N'U'))
DROP TABLE [dbo].[Import]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_COMBINED_FINAL_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA COMBINED] DROP CONSTRAINT [DF_PLDA_COMBINED_FINAL_PRINT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_FINAL_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT] DROP CONSTRAINT [DF_PLDA_IMPORT_FINAL_PRINT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_REPERTORY_PROPERTIES_RESTART_NUMBERING_YEARLY]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Repertory Properties] DROP CONSTRAINT [DF_REPERTORY_PROPERTIES_RESTART_NUMBERING_YEARLY]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Repertory Properties]') AND type in (N'U'))
DROP TABLE [dbo].[Repertory Properties]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SELECTION_CRITERIA_PRINT_UNUSE_NUMBER]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Selection Criteria] DROP CONSTRAINT [DF_SELECTION_CRITERIA_PRINT_UNUSE_NUMBER]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Selection Criteria]') AND type in (N'U'))
DROP TABLE [dbo].[Selection Criteria]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setup]') AND type in (N'U'))
DROP TABLE [dbo].[Setup]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TRANSIT_FINAL_PRINT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Transit] DROP CONSTRAINT [DF_TRANSIT_FINAL_PRINT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transit]') AND type in (N'U'))
DROP TABLE [dbo].[Transit]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TREE_USED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tree] DROP CONSTRAINT [DF_TREE_USED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tree]') AND type in (N'U'))
DROP TABLE [dbo].[Tree]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tree]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tree](
	[LEVEL] [int] NULL,
	[PARENT ID] [nvarchar](50) NULL,
	[TREE ID] [nvarchar](50) NULL,
	[ROOT ID] [nvarchar](15) NULL,
	[DESCRIPTION] [nvarchar](50) NULL,
	[IMAGE] [tinyint] NULL,
	[PICTURE] [tinyint] NULL,
	[OWNER] [nvarchar](25) NULL,
	[DESCRIPTION1] [nvarchar](250) NULL,
	[USED] [bit] NOT NULL CONSTRAINT [DF_TREE_USED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transit](
	[CODE] [nvarchar](21) NULL,
	[REPERTORY NUMBER] [int] NULL,
	[SUPPLIER] [nvarchar](40) NULL,
	[RECEIVER] [nvarchar](40) NULL,
	[COUNTRY OF EXPEDITION] [nvarchar](3) NULL,
	[COUNTRY OF ORIGIN] [nvarchar](3) NULL,
	[NUMBER OF ITEMS] [int] NULL,
	[PACKAGING] [nvarchar](2) NULL,
	[MARKS AND NUMBERS] [nvarchar](39) NULL,
	[TARIFF NUMBER] [nvarchar](13) NULL,
	[NET WEIGHT] [float] NULL,
	[CUSTOMS VALUE] [float] NULL,
	[DOCUMENT TYPE] [nvarchar](3) NULL,
	[DOCUMENT DATE] [datetime] NULL,
	[PREVIOUS CUSTOMS] [nvarchar](max) NULL,
	[TREE ID] [nvarchar](15) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[FINAL PRINT] [bit] NOT NULL CONSTRAINT [DF_TRANSIT_FINAL_PRINT]  DEFAULT ((0)),
	[CURRENCY] [nvarchar](3) NULL,
	[PAGE NUMBER] [int] NULL,
	[Source] [smallint] NULL,
	[Customs Office] [nvarchar](36) NULL,
	[Document Number] [nvarchar](35) NULL,
	[Nature of Goods] [nvarchar](255) NULL,
	[Reference Number] [nvarchar](35) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Setup](
	[EDIT TIME] [datetime] NULL,
	[SENT TIME] [datetime] NULL,
	[TREE TIME] [datetime] NULL,
	[LAST COMPACT DATE] [datetime] NULL,
	[UPDATE TIME] [nvarchar](10) NULL,
	[EXPORT HEADER BOXES] [nvarchar](255) NULL,
	[EXPORT DETAIL BOXES] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Selection Criteria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Selection Criteria](
	[BOOK NAME] [nvarchar](70) NULL,
	[BOX] [nvarchar](2) NULL,
	[CONDITION] [nvarchar](1) NULL,
	[VALUE] [nvarchar](50) NULL,
	[PRINT UNUSE NUMBER] [bit] NOT NULL CONSTRAINT [DF_SELECTION_CRITERIA_PRINT_UNUSE_NUMBER]  DEFAULT ((0)),
	[HEADERDETAIL] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Repertory Properties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Repertory Properties](
	[TYPE] [int] NULL,
	[COMPANY LEVEL NUMBER] [nvarchar](4) NULL,
	[COMPANY NAME] [nvarchar](70) NULL,
	[LEVEL OF USE] [int] NULL,
	[STARTING NUMBER] [nvarchar](15) NULL,
	[LAST USED PAGE] [int] NULL,
	[RESTART NUMBERING YEARLY] [bit] NOT NULL CONSTRAINT [DF_REPERTORY_PROPERTIES_RESTART_NUMBERING_YEARLY]  DEFAULT ((0)),
	[BOOK NAME] [nvarchar](70) NULL,
	[BOOK NAME2] [nvarchar](250) NULL,
	[REPORTS] [nvarchar](1) NULL,
	[ACCOUNT NUMBER OR LOGID] [nvarchar](40) NULL,
	[LAST USED NUMBER] [int] NULL,
	[LAST FINAL NUMBER] [int] NULL,
	[NAME] [nvarchar](80) NULL,
	[ADDRESS] [nvarchar](80) NULL,
	[POST CODE] [nvarchar](10) NULL,
	[CITY] [nvarchar](30) NULL,
	[NUMBER] [nvarchar](10) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT](
	[CODE] [nvarchar](21) NULL,
	[REPERTORY NUMBER] [int] NULL,
	[SUPPLIER] [nvarchar](40) NULL,
	[RECEIVER] [nvarchar](40) NULL,
	[COUNTRY OF EXPEDITION] [nvarchar](3) NULL,
	[COUNTRY OF ORIGIN] [nvarchar](3) NULL,
	[NUMBER OF ITEMS] [int] NULL,
	[PACKAGING] [nvarchar](2) NULL,
	[MARKS AND NUMBERS] [nvarchar](39) NULL,
	[TARIFF NUMBER] [nvarchar](13) NULL,
	[NATURE OF GOODS] [nvarchar](78) NULL,
	[NET WEIGHT] [float] NULL,
	[CUSTOMS VALUE] [float] NULL,
	[CUSTOMS OFFICE] [int] NULL,
	[DOCUMENT TYPE] [nvarchar](3) NULL,
	[DOCUMENT NUMBER] [nvarchar](7) NULL,
	[DOCUMENT DATE] [datetime] NULL,
	[REFERENCE NUMBER] [nvarchar](21) NULL,
	[PREVIOUS CUSTOMS] [nvarchar](max) NULL,
	[TREE ID] [nvarchar](15) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[FINAL PRINT] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_FINAL_PRINT]  DEFAULT ((0)),
	[CURRENCY] [nvarchar](3) NULL,
	[PAGE NUMBER] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED](
	[CODE] [nvarchar](21) NULL,
	[REPERTORY NUMBER] [int] NULL,
	[SUPPLIER] [nvarchar](40) NULL,
	[RECEIVER] [nvarchar](40) NULL,
	[COUNTRY OF EXPEDITION] [nvarchar](3) NULL,
	[COUNTRY OF ORIGIN] [nvarchar](3) NULL,
	[NUMBER OF ITEMS] [int] NULL,
	[PACKAGING] [nvarchar](2) NULL,
	[MARKS AND NUMBERS] [nvarchar](39) NULL,
	[TARIFF NUMBER] [nvarchar](13) NULL,
	[NATURE OF GOODS] [nvarchar](78) NULL,
	[NET WEIGHT] [float] NULL,
	[CUSTOMS VALUE] [float] NULL,
	[CUSTOMS OFFICE] [int] NULL,
	[DOCUMENT TYPE] [nvarchar](3) NULL,
	[DOCUMENT NUMBER] [nvarchar](7) NULL,
	[DOCUMENT DATE] [datetime] NULL,
	[REFERENCE NUMBER] [nvarchar](21) NULL,
	[PREVIOUS CUSTOMS] [nvarchar](max) NULL,
	[TREE ID] [nvarchar](15) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[FINAL PRINT] [bit] NOT NULL CONSTRAINT [DF_PLDA_COMBINED_FINAL_PRINT]  DEFAULT ((0)),
	[CURRENCY] [nvarchar](3) NULL,
	[PAGE NUMBER] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Import]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Import](
	[CODE] [nvarchar](21) NULL,
	[REPERTORY NUMBER] [int] NULL,
	[SUPPLIER] [nvarchar](40) NULL,
	[RECEIVER] [nvarchar](40) NULL,
	[COUNTRY OF EXPEDITION] [nvarchar](3) NULL,
	[COUNTRY OF ORIGIN] [nvarchar](3) NULL,
	[NUMBER OF ITEMS] [int] NULL,
	[PACKAGING] [nvarchar](2) NULL,
	[TARIFF NUMBER] [nvarchar](13) NULL,
	[NET WEIGHT] [float] NULL,
	[CUSTOMS VALUE] [float] NULL,
	[DOCUMENT TYPE] [nvarchar](3) NULL,
	[DOCUMENT DATE] [datetime] NULL,
	[CURRENCY] [nvarchar](3) NULL,
	[DUTIES] [float] NULL,
	[ADDITIONAL DUTIES] [float] NULL,
	[VAT] [float] NULL,
	[ADDITIONAL VAT] [float] NULL,
	[FINES] [float] NULL,
	[BONDS] [float] NULL,
	[EXCISE DUTIES] [float] NULL,
	[ADDITIONAL EXCISE DUTIES] [float] NULL,
	[ACCOUNT 49] [nvarchar](5) NULL,
	[TREE ID] [nvarchar](15) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[FINAL PRINT] [bit] NOT NULL CONSTRAINT [DF_IMPORT_FINAL_PRINT]  DEFAULT ((0)),
	[PAGE NUMBER] [int] NULL,
	[Source] [smallint] NULL,
	[Customs Office] [nvarchar](36) NULL,
	[Document Number] [nvarchar](35) NULL,
	[MARKS AND NUMBERS] [nvarchar](105) NULL,
	[Nature of Goods] [nvarchar](255) NULL,
	[Reference Number] [nvarchar](35) NULL,
	[VAT Regulation] [nvarchar](25) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Fields](
	[TREE ID] [nvarchar](15) NULL,
	[COLUMN] [nvarchar](50) NULL,
	[SIZE] [int] NULL,
	[ALIGNMENT] [nvarchar](1) NULL,
	[SORTED] [bit] NOT NULL CONSTRAINT [DF_FIELDS_SORTED]  DEFAULT ((0)),
	[ORDER] [nvarchar](1) NULL,
	[FILTERED] [bit] NOT NULL CONSTRAINT [DF_FIELDS_FILTERED]  DEFAULT ((0)),
	[TYPE] [smallint] NULL,
	[STRING] [nvarchar](50) NULL,
	[POSITION] [smallint] NULL,
	[DATATYPE] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Export]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Export](
	[CODE] [nvarchar](21) NULL,
	[REPERTORY NUMBER] [int] NULL,
	[SUPPLIER] [nvarchar](40) NULL,
	[RECEIVER] [nvarchar](40) NULL,
	[COUNTRY OF EXPEDITION] [nvarchar](3) NULL,
	[COUNTRY OF ORIGIN] [nvarchar](3) NULL,
	[NUMBER OF ITEMS] [int] NULL,
	[PACKAGING] [nvarchar](2) NULL,
	[TARIFF NUMBER] [nvarchar](13) NULL,
	[NET WEIGHT] [float] NULL,
	[CUSTOMS VALUE] [float] NULL,
	[DOCUMENT TYPE] [nvarchar](3) NULL,
	[DOCUMENT DATE] [datetime] NULL,
	[PREVIOUS CUSTOMS] [nvarchar](max) NULL,
	[TREE ID] [nvarchar](15) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[FINAL PRINT] [bit] NOT NULL CONSTRAINT [DF_EXPORT_FINAL_PRINT]  DEFAULT ((0)),
	[CURRENCY] [nvarchar](3) NULL,
	[PAGE NUMBER] [int] NULL,
	[Source] [smallint] NULL,
	[Customs Office] [nvarchar](36) NULL,
	[Document Number] [nvarchar](35) NULL,
	[MARKS AND NUMBERS] [nvarchar](105) NULL,
	[Nature of Goods] [nvarchar](255) NULL,
	[Reference Number] [nvarchar](35) NULL
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
	[DBProps_PerformUpdates_Completed] [bit] NOT NULL CONSTRAINT [DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Columns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Columns](
	[TREE ID] [nvarchar](15) NULL,
	[COLUMN] [nvarchar](50) NULL,
	[SIZE] [int] NULL,
	[ALIGNMENT] [nvarchar](1) NULL,
	[SORTED] [bit] NOT NULL CONSTRAINT [DF_COLUMNS_SORTED]  DEFAULT ((0)),
	[ORDER] [nvarchar](1) NULL,
	[FILTERED] [bit] NOT NULL CONSTRAINT [DF_COLUMNS_FILTERED]  DEFAULT ((0)),
	[TYPE] [smallint] NULL,
	[STRING] [nvarchar](50) NULL,
	[POSITION] [smallint] NULL,
	[USER NO] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Code Translation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Code Translation](
	[BOOK NAME] [nvarchar](70) NULL,
	[ADDITIONAL DUTIES] [nvarchar](255) NULL,
	[VAT] [nvarchar](255) NULL,
	[ADDITIONAL VAT] [nvarchar](255) NULL,
	[FINES] [nvarchar](255) NULL,
	[BOND] [nvarchar](255) NULL,
	[EXCISE DUTIES] [nvarchar](255) NULL,
	[ADDITIONAL EXCISE DUTIES] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
