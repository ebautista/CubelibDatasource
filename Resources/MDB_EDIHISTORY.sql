USE [mdb_EDIhistory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BOX_SEARCH_MAP]') AND type in (N'U'))
DROP TABLE [dbo].[BOX_SEARCH_MAP]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_DOUANEKANTOOR]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_DOUANEKANTOOR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_HANDELAAR]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_HANDELAAR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_HOOFDING]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_HOOFDING]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_CONTROLE]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_CONTROLE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_INCIDENT]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_INCIDENT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BGM]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_BGM]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_CNT]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_CNT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_CST]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_CST]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_BIJZONDERE]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL_BIJZONDERE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_COLLI]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL_COLLI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL_CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_DOCUMENTEN]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL_DOCUMENTEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_RESULTATEN]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DETAIL_RESULTATEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DOC]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DOC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DTM]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_DTM]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_FTX]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_FTX]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_GIR]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_GIR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_GIS]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_GIS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER_RESULTATEN]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_HEADER_RESULTATEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER_ZEKERHEID]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_HEADER_ZEKERHEID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_LOC]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_LOC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_MEA]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_MEA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_MESSAGES]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_MESSAGES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_NAD]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_NAD]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_PAC]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_PAC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_PCI]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_PCI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_RFF]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_RFF]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_SEL]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_SEL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TDT]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_TDT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TOD]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_TOD]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TPL]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_TPL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNB]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_UNB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNH]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_UNH]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNS]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_UNS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNT]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_UNT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNZ]') AND type in (N'U'))
DROP TABLE [dbo].[DATA_NCTS_UNZ]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS]') AND type in (N'U'))
DROP TABLE [dbo].[EDI_TMS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_CORE]') AND type in (N'U'))
DROP TABLE [dbo].[EDI_TMS_CORE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_GROUPS]') AND type in (N'U'))
DROP TABLE [dbo].[EDI_TMS_GROUPS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_ITEMS]') AND type in (N'U'))
DROP TABLE [dbo].[EDI_TMS_ITEMS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_SEGMENTS]') AND type in (N'U'))
DROP TABLE [dbo].[EDI_TMS_SEGMENTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTS]') AND type in (N'U'))
DROP TABLE [dbo].[MASTEREDINCTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTS2]') AND type in (N'U'))
DROP TABLE [dbo].[MASTEREDINCTS2]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTSIE44]') AND type in (N'U'))
DROP TABLE [dbo].[MASTEREDINCTSIE44]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NCTS_IEM_DONE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[NCTS_IEM] DROP CONSTRAINT [DF_NCTS_IEM_DONE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NCTS_IEM_OUTPUTACTIVE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[NCTS_IEM] DROP CONSTRAINT [DF_NCTS_IEM_OUTPUTACTIVE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_IEM]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_MAP]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_IEM_MAP]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_MAP_CONDITIONS]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_IEM_MAP_CONDITIONS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_TMS]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_IEM_TMS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_BGM]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_BGM]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_CNT]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_CNT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_CST]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_CST]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_DOC]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_DOC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_DTM]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_DTM]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_FTX]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_FTX]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_GIR]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_GIR]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_GIS]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_GIS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_LOC]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_LOC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_MEA]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_MEA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_NAD]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_NAD]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_PAC]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_PAC]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_PCI]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_PCI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_RFF]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_RFF]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_SEL]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_SEL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TDT]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_TDT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TOD]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_TOD]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TPL]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_TPL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNB]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_UNB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNH]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_UNH]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNS]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_UNS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNT]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_UNT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNZ]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS_ITM_UNZ]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OUTPUT_FILE_FIELDS]') AND type in (N'U'))
DROP TABLE [dbo].[OUTPUT_FILE_FIELDS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OUTPUT_FILE_GROUPS]') AND type in (N'U'))
DROP TABLE [dbo].[OUTPUT_FILE_GROUPS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OUTPUT_FILE_GROUPS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OUTPUT_FILE_GROUPS](
	[OUT_FILE_GRP_ID] [int] NOT NULL,
	[NCTS_IEM_ID] [int] NULL,
	[OUTPUT_FILE_GRP_RemarksIEMName] [nvarchar](10) NULL,
	[OUTPUT_FILE_GRP_Name] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OUTPUT_FILE_FIELDS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OUTPUT_FILE_FIELDS](
	[OUT_FILE_FLD_ID] [int] NOT NULL,
	[OUT_FILE_GRP_ID] [int] NULL,
	[OUT_FILE_FLD_Ordinal] [int] NULL,
	[OUT_FILE_FLD_Name] [nvarchar](50) NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_Ordinal] [int] NULL,
	[OUT_FILE_FLD_DataFormat] [nvarchar](50) NULL,
	[OUT_FILE_FLD_Length] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNZ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_UNZ](
	[NCTS_ITM_UNZ_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_UNZ_Description] [nvarchar](50) NULL,
	[NCTS_ITM_UNZ_Value] [nvarchar](50) NULL,
	[NCTS_ITM_UNZ_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_UNZ_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_UNZ_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_UNT](
	[NCTS_ITM_UNT_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_UNT_Description] [nvarchar](50) NULL,
	[NCTS_ITM_UNT_Value] [nvarchar](50) NULL,
	[NCTS_ITM_UNT_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_UNT_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_UNT_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_UNS](
	[NCTS_ITM_UNS_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_UNS_Description] [nvarchar](50) NULL,
	[NCTS_ITM_UNS_Value] [nvarchar](50) NULL,
	[NCTS_ITM_UNS_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_UNS_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_UNS_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNH]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_UNH](
	[NCTS_ITM_UNH_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_UNH_Description] [nvarchar](50) NULL,
	[NCTS_ITM_UNH_Value] [nvarchar](50) NULL,
	[NCTS_ITM_UNH_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_UNH_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_UNH_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_UNB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_UNB](
	[NCTS_ITM_UNB_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_UNB_Description] [nvarchar](50) NULL,
	[NCTS_ITM_UNB_Value] [nvarchar](50) NULL,
	[NCTS_ITM_UNB_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_UNB_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_UNB_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TPL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_TPL](
	[NCTS_ITM_TPL_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_TPL_Description] [nvarchar](50) NULL,
	[NCTS_ITM_TPL_Value] [nvarchar](50) NULL,
	[NCTS_ITM_TPL_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_TPL_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_TPL_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TOD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_TOD](
	[NCTS_ITM_TOD_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_TOD_Description] [nvarchar](50) NULL,
	[NCTS_ITM_TOD_Value] [nvarchar](50) NULL,
	[NCTS_ITM_TOD_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_TOD_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_TOD_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_TDT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_TDT](
	[NCTS_ITM_TDT_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_TDT_Description] [nvarchar](75) NULL,
	[NCTS_ITM_TDT_Value] [nvarchar](50) NULL,
	[NCTS_ITM_TDT_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_TDT_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_TDT_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_SEL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_SEL](
	[NCTS_ITM_SEL_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_SEL_Description] [nvarchar](50) NULL,
	[NCTS_ITM_SEL_Value] [nvarchar](50) NULL,
	[NCTS_ITM_SEL_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_SEL_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_SEL_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_RFF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_RFF](
	[NCTS_ITM_RFF_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_RFF_Description] [nvarchar](50) NULL,
	[NCTS_ITM_RFF_Value] [nvarchar](50) NULL,
	[NCTS_ITM_RFF_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_RFF_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_RFF_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_PCI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_PCI](
	[NCTS_ITM_PCI_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_PCI_Description] [nvarchar](50) NULL,
	[NCTS_ITM_PCI_Value] [nvarchar](50) NULL,
	[NCTS_ITM_PCI_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_PCI_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_PCI_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_PAC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_PAC](
	[NCTS_ITM_PAC_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_PAC_Description] [nvarchar](50) NULL,
	[NCTS_ITM_PAC_Value] [nvarchar](50) NULL,
	[NCTS_ITM_PAC_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_PAC_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_PAC_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_NAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_NAD](
	[NCTS_ITM_NAD_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_NAD_Description] [nvarchar](50) NULL,
	[NCTS_ITM_NAD_Value] [nvarchar](50) NULL,
	[NCTS_ITM_NAD_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_NAD_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_NAD_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_MEA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_MEA](
	[NCTS_ITM_MEA_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_MEA_Description] [nvarchar](50) NULL,
	[NCTS_ITM_MEA_Value] [nvarchar](50) NULL,
	[NCTS_ITM_MEA_Codelist] [nvarchar](10) NULL,
	[NCTS_ITM_MEA_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_MEA_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_LOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_LOC](
	[NCTS_ITM_LOC_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_LOC_Description] [nvarchar](50) NULL,
	[NCTS_ITM_LOC_Value] [nvarchar](50) NULL,
	[NCTS_ITM_LOC_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_LOC_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_LOC_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_GIS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_GIS](
	[NCTS_ITM_GIS_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_GIS_Description] [nvarchar](50) NULL,
	[NCTS_ITM_GIS_Value] [nvarchar](50) NULL,
	[NCTS_ITM_GIS_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_GIS_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_GIS_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_GIR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_GIR](
	[NCTS_ITM_GIR_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_GIR_Description] [nvarchar](50) NULL,
	[NCTS_ITM_GIR_Value] [nvarchar](50) NULL,
	[NCTS_ITM_GIR_Codelist] [nvarchar](10) NULL,
	[NCTS_ITM_GIR_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_GIR_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_FTX]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_FTX](
	[NCTS_ITM_FTX_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_FTX_Description] [nvarchar](50) NULL,
	[NCTS_ITM_FTX_Value] [nvarchar](50) NULL,
	[NCTS_ITM_FTX_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_FTX_DataType] [nvarchar](50) NULL,
	[NCTS_ITM_FTX_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_DTM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_DTM](
	[NCTS_ITM_DTM_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_DTM_Description] [nvarchar](50) NULL,
	[NCTS_ITM_DTM_Value] [nvarchar](50) NULL,
	[NCTS_ITM_DTM_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_DTM_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_DTM_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_DOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_DOC](
	[NCTS_ITM_DOC_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_DOC_Description] [nvarchar](50) NULL,
	[NCTS_ITM_DOC_Value] [nvarchar](50) NULL,
	[NCTS_ITM_DOC_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_DOC_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_DOC_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_CST]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_CST](
	[NCTS_ITM_CST_ID] [int] NOT NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[NCTS_ITM_CST_Description] [nvarchar](50) NULL,
	[NCTS_ITM_CST_Value] [nvarchar](50) NULL,
	[NCTS_ITM_CST_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_CST_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_CST_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_CNT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_CNT](
	[NCTS_ITM_CNT_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_CNT_Description] [nvarchar](50) NULL,
	[NCTS_ITM_CNT_Value] [nvarchar](50) NULL,
	[NCTS_ITM_CNT_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_CNT_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_CNT_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_ITM_BGM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_ITM_BGM](
	[NCTS_ITM_BGM_ID] [int] NOT NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[EDI_TMS_ITM_ID] [int] NULL,
	[NCTS_ITM_BGM_Description] [nvarchar](50) NULL,
	[NCTS_ITM_BGM_Value] [nvarchar](50) NULL,
	[NCTS_ITM_BGM_Codelist] [nvarchar](5) NULL,
	[NCTS_ITM_BGM_DataType] [nvarchar](10) NULL,
	[NCTS_ITM_BGM_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_TMS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_IEM_TMS](
	[NCTS_IEM_TMS_ID] [int] NOT NULL,
	[NCTS_IEM_ID] [int] NULL,
	[NCTS_IEM_TMS_RemarksIEMName] [nvarchar](10) NULL,
	[EDI_TMS_ID] [int] NULL,
	[NCTS_IEM_TMS_RemarksSegmentTag] [nvarchar](3) NULL,
	[NCTS_IEM_TMS_ParentID] [int] NULL,
	[NCTS_IEM_TMS_RemarksTMSSequence] [int] NULL,
	[NCTS_IEM_TMS_Ordinal] [int] NULL,
	[NCTS_IEM_TMS_Occurrence] [int] NULL,
	[NCTS_IEM_TMS_Usage] [nvarchar](1) NULL,
	[NCTS_IEM_TMS_RemarksQualifier] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_MAP_CONDITIONS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_IEM_MAP_CONDITIONS](
	[NCTS_IEM_MCN_ID] [int] NOT NULL,
	[NCTS_IEM_MCN_Source] [nvarchar](35) NULL,
	[NCTS_IEM_MCN_Condition] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM_MAP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_IEM_MAP](
	[NCTS_IEM_MAP_ID] [int] NOT NULL,
	[NCTS_IEM_MAP_Source] [nvarchar](50) NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[NCTS_IEM_ID] [int] NULL,
	[NCTS_IEM_MAP_StartPosition] [int] NULL,
	[NCTS_IEM_MAP_Length] [int] NULL,
	[EDI_TMS_SEG_ID] [int] NULL,
	[NCTS_IEM_MAP_ParentID] [int] NULL,
	[NCTS_IEM_MAP_EDI_ITM_ORDINAL] [int] NULL,
	[NCTS_IEM_MCN_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS_IEM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS_IEM](
	[NCTS_IEM_ID] [int] NOT NULL,
	[Done] [bit] NOT NULL CONSTRAINT [DF_NCTS_IEM_DONE]  DEFAULT ((0)),
	[EDI_TMS_COR_ID] [int] NULL,
	[NCTS_IEM_Name] [nvarchar](10) NULL,
	[NCTS_IEM_Code] [nvarchar](8) NULL,
	[NCTS_IEM_Description_E] [nvarchar](100) NULL,
	[NCTS_IEM_Description_D] [nvarchar](100) NULL,
	[NCTS_IEM_Description_F] [nvarchar](100) NULL,
	[NCTS_IEM_Reference] [nvarchar](20) NULL,
	[NCTS_IEM_OutputActive] [bit] NOT NULL CONSTRAINT [DF_NCTS_IEM_OUTPUTACTIVE]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTSIE44]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTEREDINCTSIE44](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[TREE ID] [nvarchar](10) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USER NO] [int] NULL,
	[DOC NUMBER] [nvarchar](7) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[ORIGIN] [nvarchar](10) NULL,
	[Type] [nvarchar](1) NULL,
	[COMM] [nvarchar](1) NULL,
	[LOGID] [nvarchar](4) NULL,
	[PRINT] [nvarchar](1) NULL,
	[VIEWED] [tinyint] NULL,
	[USERNAME] [nvarchar](25) NULL,
	[HEADER] [smallint] NULL,
	[Memo Field] [nvarchar](max) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[MR] [nvarchar](21) NULL,
	[BD] [nvarchar](8) NULL,
	[AJ] [nvarchar](2) NULL,
	[W8] [nvarchar](17) NULL,
	[W9] [nvarchar](35) NULL,
	[WA] [nvarchar](35) NULL,
	[WB] [nvarchar](35) NULL,
	[WD] [nvarchar](9) NULL,
	[T7] [nvarchar](1) NULL,
	[WE] [nvarchar](2) NULL,
	[SB] [nvarchar](1) NULL,
	[A9] [nvarchar](15) NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[B1] [nvarchar](26) NULL,
	[B7] [nvarchar](3) NULL,
	[L1] [nvarchar](10) NULL,
	[M1] [nvarchar](15) NULL,
	[M2] [nvarchar](12) NULL,
	[S1] [nvarchar](255) NULL,
	[S2] [nvarchar](42) NULL,
	[S3] [nvarchar](10) NULL,
	[S4] [nvarchar](2) NULL,
	[S5] [nvarchar](1) NULL,
	[S6] [nvarchar](11) NULL,
	[S7] [nvarchar](11) NULL,
	[S8] [nvarchar](11) NULL,
	[S9] [nvarchar](11) NULL,
	[SA] [nvarchar](11) NULL,
	[V1] [nvarchar](2) NULL,
	[V2] [nvarchar](15) NULL,
	[V3] [nvarchar](2) NULL,
	[V4] [nvarchar](15) NULL,
	[V5] [nvarchar](2) NULL,
	[V6] [nvarchar](15) NULL,
	[V7] [nvarchar](2) NULL,
	[V8] [nvarchar](15) NULL,
	[Y1] [nvarchar](1) NULL,
	[Y2] [nvarchar](5) NULL,
	[Y3] [nvarchar](20) NULL,
	[Y4] [nvarchar](26) NULL,
	[Y5] [nvarchar](1) NULL,
	[CC] [nvarchar](2) NULL,
	[CD] [nvarchar](140) NULL,
	[CE] [nvarchar](35) NULL,
	[CF] [nvarchar](15) NULL,
	[CG] [nvarchar](2) NULL,
	[CI] [nvarchar](140) NULL,
	[UA] [nvarchar](1) NULL,
	[UC] [nvarchar](8) NULL,
	[UD] [nvarchar](1) NULL,
	[UE] [nvarchar](max) NULL,
	[UF] [nvarchar](1) NULL,
	[CL] [nvarchar](1) NULL,
	[CH] [nvarchar](35) NULL,
	[DATE LAST RECEIVED] [datetime] NULL,
	[REMOTE_ID] [int] NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTS2]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTEREDINCTS2](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[TREE ID] [nvarchar](10) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USER NO] [int] NULL,
	[DOC NUMBER] [nvarchar](7) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[ORIGIN] [nvarchar](10) NULL,
	[Type] [nvarchar](1) NULL,
	[COMM] [nvarchar](1) NULL,
	[LOGID] [nvarchar](4) NULL,
	[PRINT] [nvarchar](1) NULL,
	[VIEWED] [tinyint] NULL,
	[USERNAME] [nvarchar](25) NULL,
	[HEADER] [smallint] NULL,
	[Memo Field] [nvarchar](max) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[MD] [nvarchar](6) NULL,
	[ME] [nvarchar](4) NULL,
	[MR] [nvarchar](21) NULL,
	[AH] [nvarchar](17) NULL,
	[AG] [nvarchar](35) NULL,
	[BD] [nvarchar](8) NULL,
	[BC] [nvarchar](35) NULL,
	[AI] [nvarchar](17) NULL,
	[MC] [nvarchar](8) NULL,
	[EP] [nvarchar](1) NULL,
	[AJ] [nvarchar](2) NULL,
	[BF] [nvarchar](35) NULL,
	[EQ] [nvarchar](27) NULL,
	[C7] [nvarchar](2) NULL,
	[ER] [nvarchar](1) NULL,
	[C8] [nvarchar](8) NULL,
	[C9] [nvarchar](35) NULL,
	[CA] [nvarchar](35) NULL,
	[CB] [nvarchar](2) NULL,
	[ES] [nvarchar](max) NULL,
	[AK] [nvarchar](4) NULL,
	[AL] [nvarchar](20) NULL,
	[AM] [nvarchar](20) NULL,
	[BG] [nvarchar](2) NULL,
	[BH] [nvarchar](8) NULL,
	[BI] [nvarchar](35) NULL,
	[BJ] [nvarchar](35) NULL,
	[BK] [nvarchar](2) NULL,
	[BL] [nvarchar](27) NULL,
	[SC] [nvarchar](17) NULL,
	[SD] [nvarchar](17) NULL,
	[SE] [nvarchar](17) NULL,
	[SF] [nvarchar](17) NULL,
	[SG] [nvarchar](17) NULL,
	[W8] [nvarchar](17) NULL,
	[W9] [nvarchar](35) NULL,
	[WA] [nvarchar](35) NULL,
	[WB] [nvarchar](35) NULL,
	[WC] [nvarchar](2) NULL,
	[WD] [nvarchar](9) NULL,
	[T7] [nvarchar](1) NULL,
	[WE] [nvarchar](2) NULL,
	[SB] [nvarchar](1) NULL,
	[DATE LAST RECEIVED] [datetime] NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL,
	[ZA] [nvarchar](2) NULL,
	[ZB] [nvarchar](2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTEREDINCTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTEREDINCTS](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[TREE ID] [nvarchar](13) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USER NO] [int] NULL,
	[A1] [nvarchar](4) NULL,
	[A2] [nvarchar](7) NULL,
	[A4] [nvarchar](8) NULL,
	[A5] [nvarchar](2) NULL,
	[A7] [nvarchar](3) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](15) NULL,
	[AA] [nvarchar](1) NULL,
	[AB] [nvarchar](17) NULL,
	[AC] [nvarchar](2) NULL,
	[AD] [nvarchar](8) NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[B2] [nvarchar](26) NULL,
	[B3] [nvarchar](4) NULL,
	[B4] [nvarchar](21) NULL,
	[B5] [nvarchar](4) NULL,
	[B6] [nvarchar](1) NULL,
	[B7] [nvarchar](3) NULL,
	[B8] [nvarchar](3) NULL,
	[B9] [nvarchar](2) NULL,
	[BA] [nvarchar](22) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](10) NULL,
	[C4] [nvarchar](6) NULL,
	[C5] [nvarchar](5) NULL,
	[D1] [nvarchar](7) NULL,
	[D2] [nvarchar](13) NULL,
	[D3] [nvarchar](2) NULL,
	[D4] [nvarchar](1) NULL,
	[D5] [nvarchar](2) NULL,
	[D6] [nvarchar](150) NULL,
	[D7] [nvarchar](150) NULL,
	[X1] [nvarchar](32) NULL,
	[X2] [nvarchar](24) NULL,
	[X3] [nvarchar](35) NULL,
	[X4] [nvarchar](17) NULL,
	[X5] [nvarchar](3) NULL,
	[X6] [nvarchar](9) NULL,
	[X7] [nvarchar](35) NULL,
	[X8] [nvarchar](35) NULL,
	[E1] [nvarchar](1) NULL,
	[E3] [nvarchar](35) NULL,
	[E4] [nvarchar](3) NULL,
	[E5] [nvarchar](3) NULL,
	[E6] [nvarchar](3) NULL,
	[E7] [nvarchar](3) NULL,
	[E8] [nvarchar](8) NULL,
	[EA] [nvarchar](8) NULL,
	[EC] [nvarchar](8) NULL,
	[EE] [nvarchar](8) NULL,
	[EG] [nvarchar](8) NULL,
	[EI] [nvarchar](8) NULL,
	[EJ] [nvarchar](1) NULL,
	[EK] [nvarchar](4) NULL,
	[EM] [nvarchar](3) NULL,
	[EN] [nvarchar](3) NULL,
	[EO] [nvarchar](1) NULL,
	[F1] [nvarchar](5) NULL,
	[F2] [nvarchar](5) NULL,
	[F3] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[G2] [nvarchar](7) NULL,
	[G3] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[H2] [nvarchar](6) NULL,
	[H3] [nvarchar](6) NULL,
	[J1] [nvarchar](12) NULL,
	[J2] [nvarchar](12) NULL,
	[J3] [nvarchar](12) NULL,
	[K1] [nvarchar](2) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](9) NULL,
	[U5] [nvarchar](6) NULL,
	[U6] [nvarchar](17) NULL,
	[U7] [nvarchar](3) NULL,
	[U8] [nvarchar](35) NULL,
	[W1] [nvarchar](32) NULL,
	[W2] [nvarchar](24) NULL,
	[W3] [nvarchar](35) NULL,
	[W4] [nvarchar](9) NULL,
	[W5] [nvarchar](3) NULL,
	[W6] [nvarchar](17) NULL,
	[W7] [nvarchar](1) NULL,
	[L1] [nvarchar](10) NULL,
	[L2] [nvarchar](13) NULL,
	[L3] [nvarchar](12) NULL,
	[L4] [nvarchar](3) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](17) NULL,
	[L7] [nvarchar](9) NULL,
	[L8] [nvarchar](3) NULL,
	[M1] [nvarchar](15) NULL,
	[M2] [nvarchar](12) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M5] [nvarchar](12) NULL,
	[M6] [nvarchar](13) NULL,
	[M7] [nvarchar](6) NULL,
	[M8] [nvarchar](12) NULL,
	[M9] [nvarchar](3) NULL,
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
	[RA] [nvarchar](6) NULL,
	[S1] [nvarchar](255) NULL,
	[S2] [nvarchar](42) NULL,
	[S3] [nvarchar](10) NULL,
	[S4] [nvarchar](2) NULL,
	[S5] [nvarchar](1) NULL,
	[S6] [nvarchar](11) NULL,
	[S7] [nvarchar](11) NULL,
	[S8] [nvarchar](11) NULL,
	[S9] [nvarchar](11) NULL,
	[SA] [nvarchar](11) NULL,
	[SB] [nvarchar](1) NULL,
	[V1] [nvarchar](2) NULL,
	[V2] [nvarchar](15) NULL,
	[V3] [nvarchar](2) NULL,
	[V4] [nvarchar](15) NULL,
	[V5] [nvarchar](2) NULL,
	[V6] [nvarchar](15) NULL,
	[V7] [nvarchar](2) NULL,
	[V8] [nvarchar](15) NULL,
	[Y1] [nvarchar](1) NULL,
	[Y2] [nvarchar](5) NULL,
	[Y3] [nvarchar](20) NULL,
	[Y4] [nvarchar](26) NULL,
	[Y5] [nvarchar](1) NULL,
	[Z1] [nvarchar](3) NULL,
	[Z2] [nvarchar](3) NULL,
	[Z3] [nvarchar](70) NULL,
	[Z4] [nvarchar](1) NULL,
	[T1] [nvarchar](5) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](7) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6] [nvarchar](22) NULL,
	[T7] [nvarchar](1) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[ADDITIONAL COST] [nvarchar](50) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[DOC NUMBER] [nvarchar](7) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[DUTIES TAXES P1] [nvarchar](17) NULL,
	[DUTIES TAXES P2] [nvarchar](17) NULL,
	[DUTIES TAXES P3] [nvarchar](17) NULL,
	[DUTIES TAXES P4] [nvarchar](17) NULL,
	[DUTIES TAXES P5] [nvarchar](17) NULL,
	[DUTIES TAXES P6] [nvarchar](17) NULL,
	[DUTIES TAXES P7] [nvarchar](17) NULL,
	[DUTIES TAXES P8] [nvarchar](14) NULL,
	[DUTIES TAXES B1] [nvarchar](50) NULL,
	[DUTIES TAXES B2] [nvarchar](50) NULL,
	[DUTIES TAXES B3] [nvarchar](50) NULL,
	[DUTIES TAXES B4] [nvarchar](50) NULL,
	[DUTIES TAXES B5] [nvarchar](50) NULL,
	[DUTIES TAXES B6] [nvarchar](50) NULL,
	[DUTIES TAXES B7] [nvarchar](50) NULL,
	[DUTIES TAXES B8] [nvarchar](50) NULL,
	[ORIGIN] [nvarchar](10) NULL,
	[Type] [nvarchar](1) NULL,
	[COMM] [nvarchar](1) NULL,
	[LOGID] [nvarchar](4) NULL,
	[PRINT] [nvarchar](1) NULL,
	[VIEWED] [tinyint] NULL,
	[USERNAME] [nvarchar](25) NULL,
	[HEADER] [smallint] NULL,
	[Code P1] [nvarchar](3) NULL,
	[Code P2] [nvarchar](3) NULL,
	[Code P3] [nvarchar](3) NULL,
	[Code P4] [nvarchar](3) NULL,
	[Code P5] [nvarchar](3) NULL,
	[Code P6] [nvarchar](3) NULL,
	[Code P7] [nvarchar](3) NULL,
	[Code P8] [nvarchar](3) NULL,
	[Code B1] [nvarchar](3) NULL,
	[Code B2] [nvarchar](3) NULL,
	[Code B3] [nvarchar](3) NULL,
	[Code B4] [nvarchar](3) NULL,
	[Code B5] [nvarchar](3) NULL,
	[Code B6] [nvarchar](3) NULL,
	[Code B7] [nvarchar](3) NULL,
	[Code B8] [nvarchar](3) NULL,
	[Memo Field] [nvarchar](max) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[MRN] [nvarchar](25) NULL,
	[DATE LAST RECEIVED] [datetime] NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[A6] [nvarchar](9) NULL,
	[B1] [nvarchar](27) NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_SEGMENTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDI_TMS_SEGMENTS](
	[EDI_TMS_SEG_ID] [int] NOT NULL,
	[EDI_TMS_SEG_Tag] [nvarchar](3) NULL,
	[EDI_TMS_SEG_Description] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_ITEMS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDI_TMS_ITEMS](
	[EDI_TMS_ITM_ID] [int] NOT NULL,
	[EDI_TMS_SEG_ID] [int] NULL,
	[EDI_TMS_ITM_RemarksSegmentTag] [nvarchar](3) NULL,
	[EDI_TMS_ITM_Ordinal] [int] NULL,
	[EDI_TMS_GRP_ID] [int] NULL,
	[EDI_TMS_ITM_RemarksGroupTag] [nvarchar](4) NULL,
	[EDI_TMS_ITM_Tag] [nvarchar](4) NULL,
	[EDI_TMS_ITM_Description] [nvarchar](50) NULL,
	[EDI_TMS_ITM_DataType] [nvarchar](10) NULL,
	[EDI_TMS_ITM_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_GROUPS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDI_TMS_GROUPS](
	[EDI_TMS_GRP_ID] [int] NOT NULL,
	[EDI_TMS_SEG_ID] [int] NULL,
	[EDI_TMS_GRP_Tag] [nvarchar](4) NULL,
	[EDI_TMS_GRP_Description] [nvarchar](50) NULL,
	[EDI_TMS_GRP_Usage] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS_CORE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDI_TMS_CORE](
	[EDI_TMS_COR_ID] [int] NOT NULL,
	[EDI_TMS_COR_Name] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDI_TMS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDI_TMS](
	[EDI_TMS_ID] [int] NOT NULL,
	[EDI_TMS_COR_ID] [int] NULL,
	[EDI_TMS_SEG_ID] [int] NULL,
	[EDI_TMS_RemarksSegmentTag] [nvarchar](3) NULL,
	[EDI_TMS_ParentID] [int] NULL,
	[EDI_TMS_Sequence] [int] NULL,
	[EDI_TMS_Level] [int] NULL,
	[EDI_TMS_Occurrence] [int] NULL,
	[EDI_TMS_Usage] [nvarchar](1) NULL
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNZ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_UNZ](
	[DATA_NCTS_UNZ_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_UNZ_ParentID] [int] NULL,
	[DATA_NCTS_UNZ_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_UNZ_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_UNZ_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_UNT](
	[DATA_NCTS_UNT_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_UNT_ParentID] [int] NULL,
	[DATA_NCTS_UNT_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_UNT_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_UNT_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_UNS](
	[DATA_NCTS_UNS_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_UNS_ParentID] [int] NULL,
	[DATA_NCTS_UNS_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_UNS_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNH]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_UNH](
	[DATA_NCTS_UNH_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_UNH_ParentID] [int] NULL,
	[DATA_NCTS_UNH_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_UNH_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_UNB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_UNB](
	[DATA_NCTS_UNB_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_UNB_ParentID] [int] NULL,
	[DATA_NCTS_UNB_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq16] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq17] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Seq18] [nvarchar](255) NULL,
	[DATA_NCTS_UNB_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TPL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_TPL](
	[DATA_NCTS_TPL_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_TPL_ParentID] [int] NULL,
	[DATA_NCTS_TPL_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_TPL_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_TPL_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_TPL_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_TPL_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_TPL_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TOD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_TOD](
	[DATA_NCTS_TOD_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_TOD_ParentID] [int] NULL,
	[DATA_NCTS_TOD_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_TOD_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_TDT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_TDT](
	[DATA_NCTS_TDT_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_TDT_ParentID] [int] NULL,
	[DATA_NCTS_TDT_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq16] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq17] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq18] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq19] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Seq20] [nvarchar](255) NULL,
	[DATA_NCTS_TDT_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_SEL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_SEL](
	[DATA_NCTS_SEL_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_SEL_ParentID] [int] NULL,
	[DATA_NCTS_SEL_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_SEL_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_RFF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_RFF](
	[DATA_NCTS_RFF_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_RFF_ParentID] [int] NULL,
	[DATA_NCTS_RFF_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_RFF_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_RFF_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_RFF_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_RFF_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_PCI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_PCI](
	[DATA_NCTS_PCI_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_PCI_ParentID] [int] NULL,
	[DATA_NCTS_PCI_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_PCI_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_PAC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_PAC](
	[DATA_NCTS_PAC_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_PAC_ParentID] [int] NULL,
	[DATA_NCTS_PAC_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_PAC_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_NAD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_NAD](
	[DATA_NCTS_NAD_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_NAD_ParentID] [int] NULL,
	[DATA_NCTS_NAD_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq16] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq17] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq18] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq19] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq20] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq21] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq22] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Seq23] [nvarchar](255) NULL,
	[DATA_NCTS_NAD_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_MESSAGES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_MESSAGES](
	[DATA_NCTS_MSG_ID] [int] NOT NULL,
	[NCTS_IEM_ID] [int] NULL,
	[DATA_NCTS_ID] [int] NULL,
	[DATA_NCTS_MSG_Date] [datetime] NULL,
	[DATA_NCTS_MSG_StatusType] [nvarchar](15) NULL,
	[User_ID] [int] NULL,
	[DATA_NCTS_MSG_Message] [nvarchar](max) NULL,
	[DATA_NCTS_MSG_Reference] [nvarchar](22) NULL,
	[DATA_NCTS_MSG_Date_Requested] [datetime] NULL,
	[DATA_NCTS_MSG_LOGID_Description] [nvarchar](40) NULL,
	[DATA_NCTS_MSG_TYPE] [nvarchar](1) NULL,
	[DATA_NCTS_MSG_Document_Name] [nvarchar](1) NULL,
	[DATA_NCTS_MSG_LOGID] [nvarchar](4) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_MEA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_MEA](
	[DATA_NCTS_MEA_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_MEA_ParentID] [int] NULL,
	[DATA_NCTS_MEA_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_MEA_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_LOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_LOC](
	[DATA_NCTS_LOC_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_LOC_ParentID] [int] NULL,
	[DATA_NCTS_LOC_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_LOC_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER_ZEKERHEID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_HEADER_ZEKERHEID](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[ORDINAL] [int] NULL,
	[EJ] [nvarchar](1) NULL,
	[EO] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER_RESULTATEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_HEADER_RESULTATEN](
	[Code] [nvarchar](21) NULL,
	[Header] [smallint] NULL,
	[Ordinal] [int] NULL,
	[CM] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[BA] [nvarchar](22) NULL,
	[DOC NUMBER] [nvarchar](25) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_GIS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_GIS](
	[DATA_NCTS_GIS_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_GIS_ParentID] [int] NULL,
	[DATA_NCTS_GIS_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_GIS_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_GIS_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_GIS_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_GIS_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_GIR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_GIR](
	[DATA_NCTS_GIR_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_GIR_ParentID] [int] NULL,
	[DATA_NCTS_GIR_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Seq16] [nvarchar](255) NULL,
	[DATA_NCTS_GIR_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_FTX]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_FTX](
	[DATA_NCTS_FTX_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_FTX_ParentID] [int] NULL,
	[DATA_NCTS_FTX_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_FTX_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DTM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DTM](
	[DATA_NCTS_DTM_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_DTM_ParentID] [int] NULL,
	[DATA_NCTS_DTM_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_DTM_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_DTM_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_DTM_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DOC](
	[DATA_NCTS_DOC_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_DOC_ParentID] [int] NULL,
	[DATA_NCTS_DOC_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_DOC_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_RESULTATEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL_RESULTATEN](
	[Code] [nvarchar](21) NULL,
	[Header] [smallint] NULL,
	[Detail] [int] NULL,
	[Ordinal] [int] NULL,
	[CL] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_DOCUMENTEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL_DOCUMENTEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Y1] [nvarchar](1) NULL,
	[Y5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL_CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[SB] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_COLLI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL_COLLI](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL_BIJZONDERE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL_BIJZONDERE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Z4] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[W7] [nvarchar](1) NULL,
	[T7] [nvarchar](1) NULL,
	[Memo Field] [nvarchar](max) NULL,
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_CST]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_CST](
	[DATA_NCTS_CST_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_CST_ParentID] [int] NULL,
	[DATA_NCTS_CST_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq10] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq11] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq12] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq13] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq14] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq15] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Seq16] [nvarchar](255) NULL,
	[DATA_NCTS_CST_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_CNT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_CNT](
	[DATA_NCTS_CNT_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_CNT_ParentID] [int] NULL,
	[DATA_NCTS_CNT_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_CNT_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_CNT_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_CNT_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BGM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BGM](
	[DATA_NCTS_BGM_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[DATA_NCTS_BGM_ParentID] [int] NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[DATA_NCTS_BGM_Seq1] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq2] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq3] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq4] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq5] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq6] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq7] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq8] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Seq9] [nvarchar](255) NULL,
	[DATA_NCTS_BGM_Instance] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID](
	[CODE] [nvarchar](21) NULL,
	[AL] [nvarchar](20) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO](
	[CODE] [nvarchar](21) NULL,
	[AK] [nvarchar](4) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL,
	[AL] [nvarchar](20) NULL,
	[AM] [nvarchar](20) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[SC] [nvarchar](17) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_OVERLADING](
	[CODE] [nvarchar](21) NULL,
	[BL] [nvarchar](27) NULL,
	[BG] [nvarchar](2) NULL,
	[BH] [nvarchar](8) NULL,
	[BI] [nvarchar](35) NULL,
	[BJ] [nvarchar](35) NULL,
	[BK] [nvarchar](2) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_INCIDENT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_INCIDENT](
	[CODE] [nvarchar](21) NULL,
	[ER] [nvarchar](50) NULL,
	[ES] [nvarchar](max) NULL,
	[C8] [nvarchar](50) NULL,
	[C9] [nvarchar](50) NULL,
	[CA] [nvarchar](50) NULL,
	[CB] [nvarchar](2) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER_CONTROLE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER_CONTROLE](
	[CODE] [nvarchar](21) NULL,
	[EQ] [nvarchar](1) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_VERVOER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_VERVOER](
	[CODE] [nvarchar](21) NULL,
	[BF] [nvarchar](35) NULL,
	[C7] [nvarchar](2) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_HOOFDING]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_HOOFDING](
	[CODE] [nvarchar](21) NULL,
	[MR] [nvarchar](21) NULL,
	[MC] [nvarchar](8) NULL,
	[BC] [nvarchar](35) NULL,
	[AH] [nvarchar](17) NULL,
	[AG] [nvarchar](35) NULL,
	[AI] [nvarchar](17) NULL,
	[AJ] [nvarchar](2) NULL,
	[EP] [nvarchar](1) NULL,
	[ORDINAL_PARENT] [int] NULL,
	[ORDINAL] [int] NULL,
	[ZA] [nvarchar](2) NULL,
	[ZB] [nvarchar](2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_HANDELAAR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_HANDELAAR](
	[CODE] [nvarchar](21) NULL,
	[W8] [nvarchar](17) NULL,
	[W9] [nvarchar](35) NULL,
	[WA] [nvarchar](35) NULL,
	[WE] [nvarchar](2) NULL,
	[WD] [nvarchar](9) NULL,
	[WB] [nvarchar](35) NULL,
	[ORDINAL] [int] NULL,
	[ORDINAL_PARENT] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT_DOUANEKANTOOR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT_DOUANEKANTOOR](
	[CODE] [nvarchar](21) NULL,
	[BD] [nvarchar](8) NULL,
	[ORDINAL_PARENT] [int] NULL,
	[ORDINAL] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS_BERICHT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS_BERICHT](
	[CODE] [nvarchar](21) NULL,
	[NCTS_IEM_ID] [int] NULL,
	[MD] [nvarchar](6) NULL,
	[ME] [nvarchar](4) NULL,
	[ORDINAL] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DATA_NCTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DATA_NCTS](
	[DATA_NCTS_ID] [int] NOT NULL,
	[DATA_NCTS_MSG_ID] [int] NULL,
	[CODE] [nvarchar](21) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[TYPE] [nvarchar](1) NULL,
	[COMM] [nvarchar](1) NULL,
	[USER NO] [int] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[PRINT] [nvarchar](1) NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[DOCUMENT COUNTER] [smallint] NULL,
	[REMARKS] [nvarchar](30) NULL,
	[TREE ID] [nvarchar](13) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[MRN] [nvarchar](25) NULL,
	[DATE LAST RECEIVED] [datetime] NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BOX_SEARCH_MAP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BOX_SEARCH_MAP](
	[BOX CODE] [nvarchar](2) NULL,
	[BOX_COR_TABLE] [nvarchar](50) NULL,
	[BOX_COR_FIELD] [nvarchar](50) NULL,
	[NCTS_IEM_TMS_ID] [int] NULL,
	[NCTS_IEM_ID] [int] NULL,
	[NCTS_DATA_INSTANCE] [int] NULL
) ON [PRIMARY]
END
GO
