USE [mdb_scheduler]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Archiver Properties] DROP CONSTRAINT [DF_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Archiver Properties]') AND type in (N'U'))
DROP TABLE [dbo].[Archiver Properties]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_PERFORM_UPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_PERFORM_UPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EDIPROPERTIES_DISABLE_ERROR_CHECKING]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EDIProperties] DROP CONSTRAINT [DF_EDIPROPERTIES_DISABLE_ERROR_CHECKING]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDIProperties]') AND type in (N'U'))
DROP TABLE [dbo].[EDIProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Error Code Maintenance]') AND type in (N'U'))
DROP TABLE [dbo].[Error Code Maintenance]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Error Reports Pending]') AND type in (N'U'))
DROP TABLE [dbo].[Error Reports Pending]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOGID SCHEDULE]') AND type in (N'U'))
DROP TABLE [dbo].[LOGID SCHEDULE]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAINTENANCE_PROC_SETTINGS_ENABLE_BACKUP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MAINTENANCE PROC SETTINGS] DROP CONSTRAINT [DF_MAINTENANCE_PROC_SETTINGS_ENABLE_BACKUP]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MAINTENANCE PROC SETTINGS]') AND type in (N'U'))
DROP TABLE [dbo].[MAINTENANCE PROC SETTINGS]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA Archiver Properties] DROP CONSTRAINT [DF_PLDA_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA Archiver Properties]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA Archiver Properties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA MESSAGES QUEUE]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA MESSAGES QUEUE]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDAPROPERTIES_DISABLE_ERROR_CHECKING]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDAProperties] DROP CONSTRAINT [DF_PLDAPROPERTIES_DISABLE_ERROR_CHECKING]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDAProperties]') AND type in (N'U'))
DROP TABLE [dbo].[PLDAProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTBOXES]') AND type in (N'U'))
DROP TABLE [dbo].[PRINTBOXES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTDATA]') AND type in (N'U'))
DROP TABLE [dbo].[PRINTDATA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTER DEFINITION]') AND type in (N'U'))
DROP TABLE [dbo].[PRINTER DEFINITION]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceivingCycles]') AND type in (N'U'))
DROP TABLE [dbo].[ReceivingCycles]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_REMOTEFILE_SENT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[REMOTEFILE] DROP CONSTRAINT [DF_REMOTEFILE_SENT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REMOTEFILE]') AND type in (N'U'))
DROP TABLE [dbo].[REMOTEFILE]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SEGMENT_EXCLUDE_LANGUAGE_WHEN_EMPTY]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SEGMENT] DROP CONSTRAINT [DF_SEGMENT_EXCLUDE_LANGUAGE_WHEN_EMPTY]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SEGMENT]') AND type in (N'U'))
DROP TABLE [dbo].[SEGMENT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SENDITEMS]') AND type in (N'U'))
DROP TABLE [dbo].[SENDITEMS]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SETUP_CONTROLPANEL]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SETUP] DROP CONSTRAINT [DF_SETUP_CONTROLPANEL]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SETUP_CUT3CHARS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SETUP] DROP CONSTRAINT [DF_SETUP_CUT3CHARS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SETUP_OPENCLOSE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SETUP] DROP CONSTRAINT [DF_SETUP_OPENCLOSE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SETUP_ENCRYPT_PRINTDATA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SETUP] DROP CONSTRAINT [DF_SETUP_ENCRYPT_PRINTDATA]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SETUP]') AND type in (N'U'))
DROP TABLE [dbo].[SETUP]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TASK_SCHEDULE_ACTIVE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TASK SCHEDULE] DROP CONSTRAINT [DF_TASK_SCHEDULE_ACTIVE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TASK SCHEDULE]') AND type in (N'U'))
DROP TABLE [dbo].[TASK SCHEDULE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TASK SCHEDULE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TASK SCHEDULE](
	[TASK CODE] [nvarchar](2) NULL,
	[ORDER] [smallint] NULL,
	[SCHEDULE] [bit] NOT NULL CONSTRAINT [DF_TASK_SCHEDULE_ACTIVE]  DEFAULT ((0)),
	[LAST RUN] [datetime] NULL,
	[DEFAULT] [nvarchar](12) NULL,
	[WAIT] [int] NULL,
	[PROPERTY] [nvarchar](4) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SETUP]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SETUP](
	[EMPTY PRINTBOX] [nvarchar](5) NULL,
	[USERNAME] [nvarchar](20) NULL,
	[GATEWAY] [nvarchar](20) NULL,
	[IP ADDRESS] [nvarchar](20) NULL,
	[WAIT TIME] [nvarchar](5) NULL,
	[CONTROLPANEL] [bit] NOT NULL CONSTRAINT [DF_SETUP_CONTROLPANEL]  DEFAULT ((0)),
	[CUT3CHARS] [bit] NOT NULL CONSTRAINT [DF_SETUP_CUT3CHARS]  DEFAULT ((0)),
	[OPENCLOSE] [bit] NOT NULL CONSTRAINT [DF_SETUP_OPENCLOSE]  DEFAULT ((0)),
	[LOCKRETRY] [smallint] NULL,
	[LOCKDELAY] [smallint] NULL,
	[ENCRYPT PRINTDATA] [bit] NOT NULL CONSTRAINT [DF_SETUP_ENCRYPT_PRINTDATA]  DEFAULT ((0)),
	[STARTAFTER] [smallint] NULL,
	[TERMINATIONFILENAME] [nvarchar](12) NULL,
	[PLDA CUSTOMS LOCALE] [int] NULL,
	[CLEAN_LOCKUPFILE] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SENDITEMS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SENDITEMS](
	[LOGID] [nvarchar](4) NULL,
	[TEST] [int] NULL,
	[OPERATIONAL] [int] NULL,
	[DUPLICATA] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SEGMENT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SEGMENT](
	[Segment_ID] [int] NOT NULL,
	[Segment_TagName] [nvarchar](100) NULL,
	[Segment_ExcludeLANGWhenEmpty] [bit] NOT NULL CONSTRAINT [DF_SEGMENT_EXCLUDE_LANGUAGE_WHEN_EMPTY]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REMOTEFILE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REMOTEFILE](
	[REMOTEFILE_ID] [int] NOT NULL,
	[REMOTEFILE_PATH] [nvarchar](50) NULL,
	[REMOTEFILE_NAME] [nvarchar](50) NULL,
	[REMOTEFILE_PRINTMODE] [nvarchar](1) NULL,
	[REMOTEFILE_SENT] [bit] NOT NULL CONSTRAINT [DF_REMOTEFILE_SENT]  DEFAULT ((0)),
	[REMOTEFILE_TYPE] [nvarchar](3) NULL,
	[REMOTE_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceivingCycles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReceivingCycles](
	[RecCyc_ID] [int] NOT NULL,
	[RecCyc_CustomsSystem] [nvarchar](15) NULL,
	[RecCyc_SlowPollCycles] [nvarchar](35) NULL,
	[RecCyc_FastPollCycles] [nvarchar](35) NULL,
	[RecCyc_FastPollIncrement] [smallint] NULL,
	[RecCyc_FastPollCycleType] [tinyint] NULL,
	[RecCyc_FastPollInitialValue] [smallint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTER DEFINITION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRINTER DEFINITION](
	[LOGID] [nvarchar](4) NULL,
	[MODE] [nvarchar](1) NULL,
	[PRINTER] [nvarchar](255) NULL,
	[SEPARATOR] [nvarchar](100) NULL,
	[PRINTING] [nvarchar](1) NULL,
	[DOWNLOAD] [nvarchar](1) NULL,
	[VOLGBRIEFJE PRINTER] [nvarchar](255) NULL,
	[NCTS DOC PRINTER] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTDATA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRINTDATA](
	[FILENAME] [nvarchar](50) NULL,
	[STATUS] [nvarchar](1) NULL,
	[DATE PRINTED] [datetime] NULL,
	[LOGID] [nvarchar](4) NULL,
	[MODE] [nvarchar](1) NULL,
	[DATE DOWNLOAD] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PRINTBOXES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PRINTBOXES](
	[LOGID] [nvarchar](4) NULL,
	[TEST] [int] NULL,
	[OPERATIONAL] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDAProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDAProperties](
	[PLDAPROP_ID] [int] NOT NULL,
	[PLDAPROP_Type] [int] NULL,
	[PLDAPROP_QueueName] [nvarchar](25) NULL,
	[PLDAPROP_Host] [nvarchar](15) NULL,
	[PLDAPROP_Port] [nvarchar](15) NULL,
	[PLDAPROP_UserName] [nvarchar](25) NULL,
	[PLDAPROP_UserPassword] [nvarchar](25) NULL,
	[PLDAPROP_SlowPollCycles] [nvarchar](35) NULL,
	[PLDAPROP_FastPollCycles] [nvarchar](35) NULL,
	[PLDAPROP_TimeOut] [int] NULL,
	[PLDAPROP_DisableErrChecking] [bit] NOT NULL CONSTRAINT [DF_PLDAPROPERTIES_DISABLE_ERROR_CHECKING]  DEFAULT ((0)),
	[PLDAPROP_FastPollIncrement] [smallint] NULL,
	[PLDAPROP_FastPollCycleType] [tinyint] NULL,
	[PLDAPROP_FastPollInitialValue] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA MESSAGES QUEUE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA MESSAGES QUEUE](
	[MESSAGE] [nvarchar](max) NULL,
	[MESSAGE DATE] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA Archiver Properties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA Archiver Properties](
	[PLDAArchiver_EnableOffPeak] [bit] NOT NULL CONSTRAINT [DF_PLDA_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]  DEFAULT ((0)),
	[PLDAArchiver_Documents] [tinyint] NULL,
	[PLDAArchiver_OffPeakStart] [datetime] NULL,
	[PLDAArchiver_OffPeakEnd] [datetime] NULL,
	[PLDAArchiver_OffPeakDocs] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MAINTENANCE PROC SETTINGS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MAINTENANCE PROC SETTINGS](
	[ENABLE_BACKUP] [bit] NOT NULL CONSTRAINT [DF_MAINTENANCE_PROC_SETTINGS_ENABLE_BACKUP]  DEFAULT ((0)),
	[BACKUP_PATH] [nvarchar](max) NULL,
	[BACKUP_DATABASES] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LOGID SCHEDULE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LOGID SCHEDULE](
	[MODE] [nvarchar](1) NULL,
	[LOGID] [nvarchar](4) NULL,
	[SCHEDULE] [tinyint] NULL,
	[DEFAULT] [nvarchar](12) NULL,
	[LAST RUN] [datetime] NULL,
	[TEMP DEFAULT] [nvarchar](5) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Error Reports Pending]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Error Reports Pending](
	[CODE] [nvarchar](255) NULL,
	[Pending_CusRes] [nvarchar](max) NULL,
	[Pending_CusDec] [nvarchar](max) NULL,
	[DTYPE] [smallint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Error Code Maintenance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Error Code Maintenance](
	[ErrCdeMntnce_LastSentXML] [datetime] NULL,
	[ErrCdeMntnce_LastCodeUpdate] [datetime] NULL,
	[ErrCdeMntnce_LatestXMLDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EDIProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EDIProperties](
	[EDIPROP_ID] [int] NOT NULL,
	[EDIPROP_Type] [int] NULL,
	[EDIPROP_QueueName] [nvarchar](25) NULL,
	[EDIPROP_Host] [nvarchar](15) NULL,
	[EDIPROP_Port] [nvarchar](15) NULL,
	[EDIPROP_UserName] [nvarchar](25) NULL,
	[EDIPROP_UserPassword] [nvarchar](25) NULL,
	[EDIPROP_SlowPollCycles] [nvarchar](35) NULL,
	[EDIPROP_FastPollCycles] [nvarchar](35) NULL,
	[EDIPROP_TimeOut] [int] NULL,
	[EDIPROP_DisableErrChecking] [bit] NOT NULL CONSTRAINT [DF_EDIPROPERTIES_DISABLE_ERROR_CHECKING]  DEFAULT ((0)),
	[EDIPROP_FastPollCycleType] [int] NULL,
	[EDIPROP_FastPollInitialValue] [int] NULL,
	[EDIPROP_FastPollIncrement] [int] NULL
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Archiver Properties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Archiver Properties](
	[Archiver_EnableOffPeak] [bit] NOT NULL CONSTRAINT [DF_ARCHIVER_PROPERTIES_ENABLE_OFFPEAK]  DEFAULT ((0)),
	[Archiver_Documents] [tinyint] NULL,
	[Archiver_OffPeakStart] [datetime] NULL,
	[Archiver_OffPeakEnd] [datetime] NULL,
	[Archiver_OffPeakDocs] [int] NULL
) ON [PRIMARY]
END
GO
