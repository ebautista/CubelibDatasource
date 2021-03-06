USE [mdb_history13]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL BIJZONDERE]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL BIJZONDERE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL COLLI]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL COLLI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL DOCUMENTEN]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL DOCUMENTEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL GEVOELIGE]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL GEVOELIGE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL GOEDEREN]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS DETAIL GOEDEREN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS HEADER ZEKERHEID]') AND type in (N'U'))
DROP TABLE [dbo].[COMBINED NCTS HEADER ZEKERHEID]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_PERFORMUPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT]') AND type in (N'U'))
DROP TABLE [dbo].[EXPORT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[EXPORT DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[EXPORT HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT]') AND type in (N'U'))
DROP TABLE [dbo].[IMPORT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[IMPORT DETAIL]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX7A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX7A]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX7B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX7B]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX7C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX7C]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX8A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX8A]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX8B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX8B]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX9A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX9A]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_IMPORT_HEADER_BOX9B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IMPORT HEADER] DROP CONSTRAINT [DF_IMPORT_HEADER_BOX9B]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[IMPORT HEADER]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_INBOUNDDOCS_GLOBAL]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[InBoundDocs] DROP CONSTRAINT [DF_INBOUNDDOCS_GLOBAL]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InBoundDocs]') AND type in (N'U'))
DROP TABLE [dbo].[InBoundDocs]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inbounds]') AND type in (N'U'))
DROP TABLE [dbo].[Inbounds]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTER]') AND type in (N'U'))
DROP TABLE [dbo].[MASTER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTERNCTS]') AND type in (N'U'))
DROP TABLE [dbo].[MASTERNCTS]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MASTERPLDA_EP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MASTERPLDA] DROP CONSTRAINT [DF_MASTERPLDA_EP]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTERPLDA]') AND type in (N'U'))
DROP TABLE [dbo].[MASTERPLDA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL BIJZONDERE]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS DETAIL BIJZONDERE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL COLLI]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS DETAIL COLLI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS DETAIL CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL DOCUMENTEN]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS DETAIL DOCUMENTEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS HEADER ZEKERHEID]') AND type in (N'U'))
DROP TABLE [dbo].[NCTS HEADER ZEKERHEID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OutboundDocs]') AND type in (N'U'))
DROP TABLE [dbo].[OutboundDocs]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Outbounds]') AND type in (N'U'))
DROP TABLE [dbo].[Outbounds]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL BIJZONDERE]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL BIJZONDERE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL DOCUMENTEN]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL DOCUMENTEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL HANDELAARS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL HANDELAARS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL SENSITIVE GOODS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED DETAIL SENSITIVE GOODS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER HANDELAARS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED HEADER HANDELAARS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER TRANSIT OFFICES]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED HEADER TRANSIT OFFICES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER ZEGELS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED HEADER ZEGELS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER ZEKERHEID]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA COMBINED HEADER ZEKERHEID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL BEREKENINGS EENHEDEN]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL BEREKENINGS EENHEDEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL BIJZONDERE]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL BIJZONDERE]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL CONTAINER]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL CONTAINER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL DOCUMENTEN]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL DOCUMENTEN]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL HANDELAARS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL HANDELAARS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL ZELF]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT DETAIL ZELF]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX7A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7A]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX7B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7B]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX7C]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7C]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX8B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX8B]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX8BIS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX8BIS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX9A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX9A]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_IMPORT_HEADER_BOX9B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA IMPORT HEADER] DROP CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX9B]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT HEADER]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER HANDELAARS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT HEADER HANDELAARS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER ZEGELS]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA IMPORT HEADER ZEGELS]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PLDA_MESSAGES_EP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PLDA MESSAGES] DROP CONSTRAINT [DF_PLDA_MESSAGES_EP]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA MESSAGES]') AND type in (N'U'))
DROP TABLE [dbo].[PLDA MESSAGES]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REMARKS]') AND type in (N'U'))
DROP TABLE [dbo].[REMARKS]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT]') AND type in (N'U'))
DROP TABLE [dbo].[TRANSIT]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT DETAIL]') AND type in (N'U'))
DROP TABLE [dbo].[TRANSIT DETAIL]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT HEADER]') AND type in (N'U'))
DROP TABLE [dbo].[TRANSIT HEADER]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRANSIT HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](4) NULL,
	[A2] [nvarchar](7) NULL,
	[A3] [nvarchar](9) NULL,
	[A4] [nvarchar](3) NULL,
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](3) NULL,
	[A7] [nvarchar](3) NULL,
	[B1] [nvarchar](26) NULL,
	[B2] [nvarchar](29) NULL,
	[B3] [nvarchar](2) NULL,
	[B4] [nvarchar](21) NULL,
	[B5] [nvarchar](4) NULL,
	[B6] [nvarchar](1) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](27) NULL,
	[C4] [nvarchar](6) NULL,
	[D1] [nvarchar](7) NULL,
	[D2] [nvarchar](13) NULL,
	[D3] [nvarchar](2) NULL,
	[D4] [nvarchar](1) NULL,
	[D5] [nvarchar](2) NULL,
	[D6] [nvarchar](11) NULL,
	[D7] [nvarchar](29) NULL,
	[E1] [nvarchar](1) NULL,
	[E2] [nvarchar](3) NULL,
	[E3] [nvarchar](17) NULL,
	[E4] [nvarchar](3) NULL,
	[E5] [nvarchar](3) NULL,
	[E6] [nvarchar](3) NULL,
	[E7] [nvarchar](3) NULL,
	[E8] [nvarchar](7) NULL,
	[E9] [nvarchar](3) NULL,
	[EA] [nvarchar](7) NULL,
	[EB] [nvarchar](3) NULL,
	[EC] [nvarchar](7) NULL,
	[ED] [nvarchar](3) NULL,
	[EE] [nvarchar](7) NULL,
	[EF] [nvarchar](3) NULL,
	[EG] [nvarchar](7) NULL,
	[EH] [nvarchar](3) NULL,
	[EI] [nvarchar](7) NULL,
	[EJ] [nvarchar](3) NULL,
	[F1] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[J1] [nvarchar](14) NULL,
	[F2] [nvarchar](5) NULL,
	[G2] [nvarchar](7) NULL,
	[H2] [nvarchar](6) NULL,
	[J2] [nvarchar](14) NULL,
	[F3] [nvarchar](5) NULL,
	[G3] [nvarchar](7) NULL,
	[H3] [nvarchar](6) NULL,
	[J3] [nvarchar](14) NULL,
	[K1] [nvarchar](2) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](4) NULL,
	[U5] [nvarchar](6) NULL,
	[W1] [nvarchar](32) NULL,
	[W2] [nvarchar](22) NULL,
	[W3] [nvarchar](22) NULL,
	[X1] [nvarchar](32) NULL,
	[X2] [nvarchar](22) NULL,
	[X3] [nvarchar](22) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[EXPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[EUR1] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRANSIT DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[L1] [nvarchar](13) NULL,
	[L2] [nvarchar](13) NULL,
	[L3] [nvarchar](12) NULL,
	[L4] [nvarchar](3) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](17) NULL,
	[M1] [nvarchar](12) NULL,
	[M2] [nvarchar](12) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M5] [nvarchar](12) NULL,
	[M6] [nvarchar](13) NULL,
	[M7] [nvarchar](6) NULL,
	[M8] [nvarchar](12) NULL,
	[N1] [nvarchar](5) NULL,
	[O1] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[N2] [nvarchar](5) NULL,
	[O2] [nvarchar](7) NULL,
	[P2] [nvarchar](6) NULL,
	[Q2] [nvarchar](12) NULL,
	[N3] [nvarchar](5) NULL,
	[O3] [nvarchar](7) NULL,
	[P3] [nvarchar](6) NULL,
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
	[S1] [nvarchar](78) NULL,
	[S2] [nvarchar](39) NULL,
	[S3] [nvarchar](6) NULL,
	[S4] [nvarchar](2) NULL,
	[S5] [nvarchar](1) NULL,
	[S6] [nvarchar](15) NULL,
	[T1] [nvarchar](5) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](7) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6] [nvarchar](22) NULL,
	[T7] [nvarchar](1) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[DUTIES TAXES P1] [nvarchar](14) NULL,
	[DUTIES TAXES P2] [nvarchar](14) NULL,
	[DUTIES TAXES P3] [nvarchar](14) NULL,
	[DUTIES TAXES P4] [nvarchar](14) NULL,
	[DUTIES TAXES P5] [nvarchar](14) NULL,
	[DUTIES TAXES P6] [nvarchar](14) NULL,
	[DUTIES TAXES P7] [nvarchar](14) NULL,
	[DUTIES TAXES P8] [nvarchar](14) NULL,
	[DUTIES TAXES B1] [nvarchar](14) NULL,
	[DUTIES TAXES B2] [nvarchar](14) NULL,
	[DUTIES TAXES B3] [nvarchar](14) NULL,
	[DUTIES TAXES B4] [nvarchar](14) NULL,
	[DUTIES TAXES B5] [nvarchar](14) NULL,
	[DUTIES TAXES B6] [nvarchar](14) NULL,
	[DUTIES TAXES B7] [nvarchar](14) NULL,
	[DUTIES TAXES B8] [nvarchar](14) NULL,
	[ADDITIONAL COST] [nvarchar](14) NULL,
	[U1] [nvarchar](65) NULL,
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
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRANSIT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRANSIT](
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[REMARKS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[REMARKS](
	[REMARKS] [nvarchar](30) NULL,
	[RESOURCE CODE] [smallint] NULL,
	[remarks code] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA MESSAGES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA MESSAGES](
	[Message_ID] [int] NULL,
	[Code] [nvarchar](21) NULL,
	[DType] [tinyint] NULL,
	[Message_Date] [datetime] NULL,
	[Message_StatusType] [nvarchar](15) NULL,
	[User_ID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[Message_Reference] [nvarchar](35) NULL,
	[Message_Date_Requested] [datetime] NULL,
	[Message_LOGID_Description] [nvarchar](40) NULL,
	[Message_TYPE] [nvarchar](25) NULL,
	[Message_Document_Name] [nvarchar](1) NULL,
	[Message_LOGID] [nvarchar](4) NULL,
	[Message_Request_Type] [tinyint] NULL,
	[Message_Reason] [nvarchar](255) NULL,
	[Message_EP] [bit] NOT NULL CONSTRAINT [DF_PLDA_MESSAGES_EP]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER ZEGELS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT HEADER ZEGELS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[E1] [nvarchar](35) NULL,
	[E2] [nvarchar](2) NULL,
	[E3] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER HANDELAARS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT HEADER HANDELAARS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [int] NULL,
	[ORDINAL] [int] NULL,
	[XE] [nvarchar](1) NULL,
	[X1] [nvarchar](35) NULL,
	[XD] [nvarchar](4) NULL,
	[XF] [nvarchar](1) NULL,
	[X8] [nvarchar](2) NULL,
	[X2] [nvarchar](70) NULL,
	[X3] [nvarchar](35) NULL,
	[X4] [nvarchar](35) NULL,
	[X6] [nvarchar](35) NULL,
	[X7] [nvarchar](9) NULL,
	[X5] [nvarchar](10) NULL,
	[X9] [nvarchar](35) NULL,
	[XA] [nvarchar](15) NULL,
	[XB] [nvarchar](15) NULL,
	[XC] [nvarchar](70) NULL,
	[XG] [nvarchar](35) NULL,
	[XH] [nvarchar](18) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](2) NULL,
	[A2] [nvarchar](1) NULL,
	[A3] [nvarchar](22) NULL,
	[A4] [nvarchar](8) NULL,
	[A5] [nvarchar](35) NULL,
	[A6] [nvarchar](36) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](2) NULL,
	[AA] [nvarchar](35) NULL,
	[AB] [nvarchar](35) NULL,
	[AC] [nvarchar](35) NULL,
	[B1] [nvarchar](1) NULL,
	[B2] [nvarchar](1) NULL,
	[B4] [nvarchar](35) NULL,
	[B5] [nvarchar](16) NULL,
	[B6] [nvarchar](16) NULL,
	[C1] [nvarchar](70) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](35) NULL,
	[C4] [nvarchar](19) NULL,
	[C5] [nvarchar](3) NULL,
	[C6] [nvarchar](12) NULL,
	[C7] [nvarchar](2) NULL,
	[C9] [nvarchar](19) NULL,
	[CA] [nvarchar](3) NULL,
	[CB] [nvarchar](12) NULL,
	[D1] [nvarchar](19) NULL,
	[D2] [nvarchar](19) NULL,
	[D3] [nvarchar](6) NULL,
	[D4] [nvarchar](35) NULL,
	[D5] [nvarchar](35) NULL,
	[D7] [nvarchar](2) NULL,
	[D8] [nvarchar](3) NULL,
	[D9] [nvarchar](3) NULL,
	[DA] [nvarchar](2) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[MRN] [nvarchar](18) NULL,
	[EXPORTER] [nvarchar](130) NULL,
	[IMPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[EUR1] [nvarchar](max) NULL,
	[RESULT PLDA IMPORT] [nvarchar](150) NULL,
	[RESULT PLDA EDI] [nvarchar](150) NULL,
	[B-Bis] [nvarchar](max) NULL,
	[OfcUsage] [nvarchar](50) NULL,
	[ExRate] [nvarchar](20) NULL,
	[DVfooter] [nvarchar](max) NULL,
	[Box1] [nvarchar](150) NULL,
	[Box2a] [nvarchar](150) NULL,
	[Box2b] [nvarchar](150) NULL,
	[Box3] [nvarchar](30) NULL,
	[Box4] [nvarchar](30) NULL,
	[Box5] [nvarchar](30) NULL,
	[Box6] [nvarchar](150) NULL,
	[Box7a] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7A]  DEFAULT ((0)),
	[Box7b] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7B]  DEFAULT ((0)),
	[Box7c] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX7C]  DEFAULT ((0)),
	[Box7cBis] [nvarchar](150) NULL,
	[Box8a] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX8B]  DEFAULT ((0)),
	[Box8b] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX8BIS]  DEFAULT ((0)),
	[Box8Bis] [nvarchar](150) NULL,
	[Box9a] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX9A]  DEFAULT ((0)),
	[Box9b] [bit] NOT NULL CONSTRAINT [DF_PLDA_IMPORT_HEADER_BOX9B]  DEFAULT ((0)),
	[Box9Bis] [nvarchar](150) NULL,
	[Box10] [int] NULL,
	[Box10b-1] [nvarchar](50) NULL,
	[Box10b-2] [nvarchar](20) NULL,
	[Box10b-3] [nvarchar](50) NULL,
	[AUTHORISATION] [nvarchar](35) NULL,
	[PRINTDATA3] [nvarchar](max) NULL,
	[DG] [nvarchar](17) NULL,
	[H1] [nvarchar](8) NULL,
	[H2] [nvarchar](8) NULL,
	[H3] [nvarchar](2) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL ZELF]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL ZELF](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[U1] [nvarchar](3) NULL,
	[U2] [nvarchar](19) NULL,
	[U3] [nvarchar](1) NULL,
	[U4] [nvarchar](10) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL HANDELAARS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL HANDELAARS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [int] NULL,
	[DETAIL] [int] NULL,
	[ORDINAL] [int] NULL,
	[VE] [nvarchar](1) NULL,
	[V1] [nvarchar](35) NULL,
	[V8] [nvarchar](2) NULL,
	[V2] [nvarchar](70) NULL,
	[V3] [nvarchar](35) NULL,
	[V4] [nvarchar](35) NULL,
	[V6] [nvarchar](35) NULL,
	[V7] [nvarchar](9) NULL,
	[V5] [nvarchar](10) NULL,
	[VG] [nvarchar](35) NULL,
	[VH] [nvarchar](18) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL DOCUMENTEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL DOCUMENTEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Q1] [nvarchar](4) NULL,
	[Q2] [nvarchar](35) NULL,
	[Q3] [nvarchar](8) NULL,
	[Q4] [nvarchar](35) NULL,
	[Q5] [nvarchar](2) NULL,
	[Q7] [nvarchar](35) NULL,
	[Q8] [nvarchar](35) NULL,
	[Q9] [nvarchar](70) NULL,
	[QA] [nvarchar](1) NULL,
	[QB] [nvarchar](4) NULL,
	[QC] [nvarchar](22) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S4] [nvarchar](17) NULL,
	[S5] [nvarchar](17) NULL,
	[S6] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL BIJZONDERE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL BIJZONDERE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[P1] [nvarchar](17) NULL,
	[P5] [nvarchar](1) NULL,
	[P2] [nvarchar](max) NULL,
	[P4] [nvarchar](20) NULL,
	[P3] [nvarchar](20) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL BEREKENINGS EENHEDEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL BEREKENINGS EENHEDEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [int] NULL,
	[DETAIL] [int] NULL,
	[ORDINAL] [int] NULL,
	[TZ] [nvarchar](4) NULL,
	[T8] [nvarchar](19) NULL,
	[T9] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA IMPORT DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA IMPORT DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[DETAIL] [float] NULL,
	[L1] [nvarchar](10) NULL,
	[L2] [nvarchar](4) NULL,
	[L3] [nvarchar](4) NULL,
	[L4] [nvarchar](4) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](4) NULL,
	[L7] [nvarchar](6) NULL,
	[L9] [nvarchar](19) NULL,
	[LA] [nvarchar](19) NULL,
	[T1] [nvarchar](255) NULL,
	[T2] [nvarchar](1) NULL,
	[T3] [nvarchar](5) NULL,
	[T4] [nvarchar](70) NULL,
	[T5] [nvarchar](8) NULL,
	[T6] [nvarchar](35) NULL,
	[T7] [nvarchar](1) NULL,
	[R1] [nvarchar](1) NULL,
	[R3] [nvarchar](8) NULL,
	[R5] [nvarchar](35) NULL,
	[R6] [nvarchar](45) NULL,
	[R9] [nvarchar](11) NULL,
	[M1] [nvarchar](8) NULL,
	[M2] [nvarchar](19) NULL,
	[M3] [nvarchar](1) NULL,
	[M4] [nvarchar](14) NULL,
	[M5] [nvarchar](2) NULL,
	[N1] [nvarchar](2) NULL,
	[N2] [nvarchar](2) NULL,
	[N3] [nvarchar](3) NULL,
	[N4] [nvarchar](1) NULL,
	[N5] [nvarchar](3) NULL,
	[N7] [nvarchar](2) NULL,
	[N8] [nvarchar](1) NULL,
	[N9] [nvarchar](2) NULL,
	[NB] [nvarchar](2) NULL,
	[ND] [nvarchar](3) NULL,
	[NE] [nvarchar](3) NULL,
	[NF] [nvarchar](3) NULL,
	[NG] [nvarchar](3) NULL,
	[NH] [nvarchar](3) NULL,
	[S1] [nvarchar](2) NULL,
	[S2] [nvarchar](8) NULL,
	[S3] [nvarchar](105) NULL,
	[O1] [nvarchar](1) NULL,
	[O2] [nvarchar](19) NULL,
	[O3] [nvarchar](3) NULL,
	[O4] [nvarchar](35) NULL,
	[O5] [nvarchar](19) NULL,
	[O6] [nvarchar](3) NULL,
	[O7] [nvarchar](19) NULL,
	[O8] [nvarchar](3) NULL,
	[O9] [nvarchar](19) NULL,
	[OA] [nvarchar](3) NULL,
	[OB] [nvarchar](12) NULL,
	[OC] [nvarchar](12) NULL,
	[OD] [nvarchar](12) NULL,
	[CUSTOMS OFFICE] [nvarchar](36) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Memo Field] [nvarchar](max) NULL,
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL,
	[DUTIES AND TAXES] [nvarchar](max) NULL,
	[ADDITIONAL COST] [nvarchar](14) NULL,
	[Box11a] [nvarchar](20) NULL,
	[Box11b] [nvarchar](20) NULL,
	[Box12] [nvarchar](20) NULL,
	[Box13a] [nvarchar](20) NULL,
	[Box13b] [nvarchar](20) NULL,
	[Box13c] [nvarchar](20) NULL,
	[Box14a] [nvarchar](20) NULL,
	[Box14b] [nvarchar](20) NULL,
	[Box14c] [nvarchar](20) NULL,
	[Box14d] [nvarchar](20) NULL,
	[Box15] [nvarchar](20) NULL,
	[Box16] [nvarchar](20) NULL,
	[Box17] [nvarchar](20) NULL,
	[Box17b] [nvarchar](20) NULL,
	[Box17c] [nvarchar](20) NULL,
	[Box18] [nvarchar](20) NULL,
	[Box19] [nvarchar](20) NULL,
	[Box20] [nvarchar](20) NULL,
	[Box21] [nvarchar](20) NULL,
	[Box21bis] [nvarchar](20) NULL,
	[Box22] [nvarchar](20) NULL,
	[Box23] [nvarchar](20) NULL,
	[Box24] [nvarchar](20) NULL,
	[Out_ID] [int] NULL,
	[LC] [nvarchar](35) NULL,
	[BoxExchangeRate] [nvarchar](20) NULL,
	[L8] [nvarchar](max) NULL,
	[R8] [nvarchar](70) NULL,
	[SF] [nvarchar](5) NULL,
	[R2] [nvarchar](6) NULL
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[AUTOPRINTSTATUS] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER ZEKERHEID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED HEADER ZEKERHEID](
	[HEADER] [int] NULL,
	[ORDINAL] [int] NULL,
	[CODE] [nvarchar](30) NULL,
	[E4] [nvarchar](1) NULL,
	[E5] [nvarchar](4) NULL,
	[E6] [nvarchar](35) NULL,
	[E7] [nvarchar](35) NULL,
	[E8] [nvarchar](7) NULL,
	[E9] [nvarchar](2) NULL,
	[EA] [nvarchar](2) NULL,
	[EB] [nvarchar](2) NULL,
	[EC] [nvarchar](2) NULL,
	[ED] [nvarchar](2) NULL,
	[EE] [nvarchar](2) NULL,
	[EF] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER ZEGELS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED HEADER ZEGELS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[E1] [nvarchar](35) NULL,
	[E2] [nvarchar](2) NULL,
	[E3] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER TRANSIT OFFICES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED HEADER TRANSIT OFFICES](
	[HEADER] [int] NULL,
	[ORDINAL] [int] NULL,
	[CODE] [nvarchar](30) NULL,
	[AE] [nvarchar](35) NULL,
	[AF] [nvarchar](35) NULL,
	[AG] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER HANDELAARS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED HEADER HANDELAARS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [int] NULL,
	[ORDINAL] [int] NULL,
	[XE] [nvarchar](1) NULL,
	[X1] [nvarchar](35) NULL,
	[XD] [nvarchar](4) NULL,
	[XF] [nvarchar](1) NULL,
	[X8] [nvarchar](2) NULL,
	[X2] [nvarchar](70) NULL,
	[X3] [nvarchar](35) NULL,
	[X4] [nvarchar](35) NULL,
	[X6] [nvarchar](35) NULL,
	[X7] [nvarchar](9) NULL,
	[X5] [nvarchar](10) NULL,
	[X9] [nvarchar](35) NULL,
	[XA] [nvarchar](15) NULL,
	[XB] [nvarchar](15) NULL,
	[XC] [nvarchar](70) NULL,
	[XG] [nvarchar](35) NULL,
	[XH] [nvarchar](18) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](2) NULL,
	[A2] [nvarchar](1) NULL,
	[A3] [nvarchar](22) NULL,
	[A4] [nvarchar](8) NULL,
	[A5] [nvarchar](35) NULL,
	[A6] [nvarchar](36) NULL,
	[A7] [nvarchar](35) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](2) NULL,
	[AA] [nvarchar](35) NULL,
	[AB] [nvarchar](35) NULL,
	[AC] [nvarchar](35) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](35) NULL,
	[C4] [nvarchar](19) NULL,
	[C5] [nvarchar](3) NULL,
	[C6] [nvarchar](12) NULL,
	[C7] [nvarchar](2) NULL,
	[D1] [nvarchar](19) NULL,
	[D2] [nvarchar](19) NULL,
	[D3] [nvarchar](6) NULL,
	[D4] [nvarchar](35) NULL,
	[D5] [nvarchar](35) NULL,
	[D6] [nvarchar](35) NULL,
	[D7] [nvarchar](2) NULL,
	[D8] [nvarchar](1) NULL,
	[D9] [nvarchar](1) NULL,
	[DB] [nvarchar](2) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[MRN] [nvarchar](18) NULL,
	[EXPORTER] [nvarchar](130) NULL,
	[IMPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[EUR1] [nvarchar](max) NULL,
	[RESULT PLDA EXPORT] [nvarchar](150) NULL,
	[RESULT PLDA EDI] [nvarchar](150) NULL,
	[AD] [nvarchar](5) NULL,
	[AH] [nvarchar](35) NULL,
	[AI] [nvarchar](35) NULL,
	[AJ] [nvarchar](2) NULL,
	[AK] [nvarchar](2) NULL,
	[AL] [nvarchar](8) NULL,
	[AM] [nvarchar](10) NULL,
	[AN] [nvarchar](2) NULL,
	[DC] [nvarchar](17) NULL,
	[DD] [nvarchar](17) NULL,
	[DE] [nvarchar](17) NULL,
	[DF] [nvarchar](2) NULL,
	[DG] [nvarchar](17) NULL,
	[AUTHORISATION] [nvarchar](35) NULL,
	[PRINTDATA3] [nvarchar](max) NULL,
	[AO] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL SENSITIVE GOODS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL SENSITIVE GOODS](
	[HEADER] [int] NULL,
	[DETAIL] [int] NULL,
	[ORDINAL] [int] NULL,
	[CODE] [nvarchar](30) NULL,
	[SB] [nvarchar](2) NULL,
	[SC] [nvarchar](5) NULL,
	[SD] [nvarchar](4) NULL,
	[SE] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL HANDELAARS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL HANDELAARS](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [int] NULL,
	[DETAIL] [int] NULL,
	[ORDINAL] [int] NULL,
	[VE] [nvarchar](1) NULL,
	[V1] [nvarchar](35) NULL,
	[V8] [nvarchar](2) NULL,
	[V2] [nvarchar](70) NULL,
	[V3] [nvarchar](35) NULL,
	[V4] [nvarchar](35) NULL,
	[V6] [nvarchar](35) NULL,
	[V7] [nvarchar](9) NULL,
	[V5] [nvarchar](10) NULL,
	[VG] [nvarchar](35) NULL,
	[VH] [nvarchar](18) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL DOCUMENTEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL DOCUMENTEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Q1] [nvarchar](4) NULL,
	[Q2] [nvarchar](35) NULL,
	[Q3] [nvarchar](8) NULL,
	[Q4] [nvarchar](35) NULL,
	[Q5] [nvarchar](2) NULL,
	[Q7] [nvarchar](35) NULL,
	[Q8] [nvarchar](35) NULL,
	[Q9] [nvarchar](70) NULL,
	[QA] [nvarchar](1) NULL,
	[QB] [nvarchar](4) NULL,
	[QC] [nvarchar](22) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S4] [nvarchar](17) NULL,
	[S5] [nvarchar](17) NULL,
	[S6] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL BIJZONDERE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL BIJZONDERE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[P1] [nvarchar](17) NULL,
	[P5] [nvarchar](1) NULL,
	[P3] [nvarchar](2) NULL,
	[P4] [nvarchar](2) NULL,
	[P2] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PLDA COMBINED DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PLDA COMBINED DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[DETAIL] [float] NULL,
	[L1] [nvarchar](10) NULL,
	[L2] [nvarchar](4) NULL,
	[L3] [nvarchar](4) NULL,
	[L4] [nvarchar](4) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](4) NULL,
	[L9] [nvarchar](19) NULL,
	[LA] [nvarchar](19) NULL,
	[M1] [nvarchar](4) NULL,
	[M2] [nvarchar](19) NULL,
	[M3] [nvarchar](1) NULL,
	[M4] [nvarchar](14) NULL,
	[M5] [nvarchar](2) NULL,
	[N1] [nvarchar](2) NULL,
	[N2] [nvarchar](2) NULL,
	[N3] [nvarchar](3) NULL,
	[N4] [nvarchar](1) NULL,
	[N7] [nvarchar](2) NULL,
	[N9] [nvarchar](2) NULL,
	[NB] [nvarchar](2) NULL,
	[NC] [nvarchar](1) NULL,
	[ND] [nvarchar](3) NULL,
	[NE] [nvarchar](3) NULL,
	[NF] [nvarchar](3) NULL,
	[NG] [nvarchar](3) NULL,
	[NH] [nvarchar](3) NULL,
	[R1] [nvarchar](1) NULL,
	[R2] [nvarchar](3) NULL,
	[R3] [nvarchar](8) NULL,
	[R5] [nvarchar](35) NULL,
	[R6] [nvarchar](45) NULL,
	[R9] [nvarchar](11) NULL,
	[S1] [nvarchar](2) NULL,
	[S2] [nvarchar](8) NULL,
	[S3] [nvarchar](105) NULL,
	[O2] [nvarchar](19) NULL,
	[O3] [nvarchar](3) NULL,
	[O4] [nvarchar](35) NULL,
	[O6] [nvarchar](3) NULL,
	[OB] [nvarchar](12) NULL,
	[T7] [nvarchar](1) NULL,
	[CUSTOMS OFFICE] [nvarchar](36) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Memo Field] [nvarchar](max) NULL,
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL,
	[LC] [nvarchar](35) NULL,
	[L8] [nvarchar](max) NULL,
	[R8] [nvarchar](70) NULL,
	[SF] [nvarchar](5) NULL
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[AUTOPRINTSTATUS] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Outbounds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Outbounds](
	[Out_ID] [int] NOT NULL,
	[Out_Code] [nvarchar](50) NULL,
	[Out_Header] [int] NULL,
	[Out_Detail] [int] NULL,
	[In_ID] [int] NULL,
	[Out_Batch_Num] [nvarchar](50) NULL,
	[Out_Job_Num] [nvarchar](50) NULL,
	[Out_Packages_Qty_Wgt] [float] NULL,
	[OutDoc_ID] [int] NULL,
	[Out_ValuePerUOM] [money] NULL,
	[Out_InvoiceDate] [datetime] NULL,
	[Out_InvoiceNumber] [nvarchar](25) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OutboundDocs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OutboundDocs](
	[OutDoc_ID] [int] NOT NULL,
	[OutDoc_Type] [nvarchar](50) NULL,
	[OutDoc_Num] [nvarchar](50) NULL,
	[OutDoc_Date] [datetime] NULL,
	[OutDoc_MRN] [nvarchar](50) NULL,
	[OutDoc_Comm_Settlement] [nvarchar](4) NULL,
	[OutDoc_Global] [tinyint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS HEADER ZEKERHEID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS HEADER ZEKERHEID](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[ORDINAL] [int] NULL,
	[E1] [nvarchar](1) NULL,
	[EJ] [nvarchar](1) NULL,
	[E3] [nvarchar](35) NULL,
	[EK] [nvarchar](4) NULL,
	[E4] [nvarchar](3) NULL,
	[E5] [nvarchar](3) NULL,
	[E6] [nvarchar](3) NULL,
	[E7] [nvarchar](3) NULL,
	[EM] [nvarchar](3) NULL,
	[EN] [nvarchar](3) NULL,
	[EO] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A4] [nvarchar](8) NULL,
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](3) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](15) NULL,
	[AA] [nvarchar](1) NULL,
	[AB] [nvarchar](17) NULL,
	[AC] [nvarchar](2) NULL,
	[AD] [nvarchar](8) NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[B7] [nvarchar](3) NULL,
	[B1] [nvarchar](26) NULL,
	[B8] [nvarchar](3) NULL,
	[B2] [nvarchar](26) NULL,
	[B3] [nvarchar](2) NULL,
	[B9] [nvarchar](2) NULL,
	[BA] [nvarchar](22) NULL,
	[B5] [nvarchar](4) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](11) NULL,
	[C4] [nvarchar](6) NULL,
	[C5] [nvarchar](5) NULL,
	[X4] [nvarchar](17) NULL,
	[X5] [nvarchar](3) NULL,
	[X1] [nvarchar](32) NULL,
	[X2] [nvarchar](24) NULL,
	[X6] [nvarchar](9) NULL,
	[X3] [nvarchar](35) NULL,
	[X7] [nvarchar](35) NULL,
	[X8] [nvarchar](35) NULL,
	[E8] [nvarchar](8) NULL,
	[EA] [nvarchar](8) NULL,
	[EC] [nvarchar](8) NULL,
	[EE] [nvarchar](8) NULL,
	[EG] [nvarchar](8) NULL,
	[EI] [nvarchar](8) NULL,
	[MRN] [nvarchar](18) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL DOCUMENTEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS DETAIL DOCUMENTEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Y1] [nvarchar](1) NULL,
	[Y2] [nvarchar](5) NULL,
	[Y3] [nvarchar](20) NULL,
	[Y4] [nvarchar](26) NULL,
	[Y5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS DETAIL CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S6] [nvarchar](11) NULL,
	[S7] [nvarchar](11) NULL,
	[S8] [nvarchar](11) NULL,
	[S9] [nvarchar](11) NULL,
	[SA] [nvarchar](11) NULL,
	[SB] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL COLLI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS DETAIL COLLI](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S2] [nvarchar](39) NULL,
	[S4] [nvarchar](2) NULL,
	[S3] [nvarchar](6) NULL,
	[S5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL BIJZONDERE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS DETAIL BIJZONDERE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Z1] [nvarchar](3) NULL,
	[Z2] [nvarchar](3) NULL,
	[Z3] [nvarchar](70) NULL,
	[Z4] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[U6] [nvarchar](17) NULL,
	[U7] [nvarchar](3) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](9) NULL,
	[U8] [nvarchar](35) NULL,
	[W1] [nvarchar](32) NULL,
	[W2] [nvarchar](24) NULL,
	[W4] [nvarchar](9) NULL,
	[W3] [nvarchar](35) NULL,
	[W5] [nvarchar](3) NULL,
	[W6] [nvarchar](17) NULL,
	[W7] [nvarchar](1) NULL,
	[L7] [nvarchar](3) NULL,
	[L1] [nvarchar](10) NULL,
	[L8] [nvarchar](3) NULL,
	[M1] [nvarchar](15) NULL,
	[M2] [nvarchar](12) NULL,
	[M9] [nvarchar](3) NULL,
	[S1] [nvarchar](78) NULL,
	[V1] [nvarchar](2) NULL,
	[V2] [nvarchar](15) NULL,
	[V3] [nvarchar](2) NULL,
	[V4] [nvarchar](15) NULL,
	[V5] [nvarchar](2) NULL,
	[V6] [nvarchar](15) NULL,
	[V7] [nvarchar](2) NULL,
	[V8] [nvarchar](15) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NCTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NCTS](
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTERPLDA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTERPLDA](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[Tree ID] [nvarchar](50) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USER NO] [int] NULL,
	[A1] [nvarchar](2) NULL,
	[A2] [nvarchar](1) NULL,
	[A3] [nvarchar](22) NULL,
	[A4] [nvarchar](10) NULL,
	[A5] [nvarchar](35) NULL,
	[A6] [nvarchar](36) NULL,
	[A7] [nvarchar](35) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](2) NULL,
	[AA] [nvarchar](35) NULL,
	[AB] [nvarchar](35) NULL,
	[AC] [nvarchar](35) NULL,
	[XE] [nvarchar](1) NULL,
	[X1] [nvarchar](35) NULL,
	[XD] [nvarchar](4) NULL,
	[XF] [nvarchar](1) NULL,
	[X8] [nvarchar](2) NULL,
	[X2] [nvarchar](70) NULL,
	[X3] [nvarchar](35) NULL,
	[X4] [nvarchar](35) NULL,
	[X5] [nvarchar](10) NULL,
	[X6] [nvarchar](35) NULL,
	[X7] [nvarchar](9) NULL,
	[X9] [nvarchar](35) NULL,
	[XA] [nvarchar](15) NULL,
	[XB] [nvarchar](15) NULL,
	[XC] [nvarchar](70) NULL,
	[B1] [nvarchar](1) NULL,
	[B2] [nvarchar](1) NULL,
	[B4] [nvarchar](35) NULL,
	[B5] [nvarchar](16) NULL,
	[B6] [nvarchar](16) NULL,
	[C1] [nvarchar](70) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](35) NULL,
	[C4] [nvarchar](19) NULL,
	[C5] [nvarchar](3) NULL,
	[C6] [nvarchar](12) NULL,
	[C7] [nvarchar](2) NULL,
	[C9] [nvarchar](19) NULL,
	[CA] [nvarchar](3) NULL,
	[CB] [nvarchar](12) NULL,
	[D1] [nvarchar](19) NULL,
	[D2] [nvarchar](19) NULL,
	[D3] [nvarchar](6) NULL,
	[D4] [nvarchar](35) NULL,
	[D5] [nvarchar](35) NULL,
	[D6] [nvarchar](35) NULL,
	[D7] [nvarchar](2) NULL,
	[D8] [nvarchar](3) NULL,
	[D9] [nvarchar](3) NULL,
	[DA] [nvarchar](2) NULL,
	[E1] [nvarchar](35) NULL,
	[E2] [nvarchar](2) NULL,
	[E3] [nvarchar](1) NULL,
	[L1] [nvarchar](10) NULL,
	[L2] [nvarchar](4) NULL,
	[L3] [nvarchar](4) NULL,
	[L4] [nvarchar](4) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](4) NULL,
	[L7] [nvarchar](6) NULL,
	[L9] [nvarchar](19) NULL,
	[LA] [nvarchar](19) NULL,
	[M1] [nvarchar](8) NULL,
	[M2] [nvarchar](19) NULL,
	[M3] [nvarchar](1) NULL,
	[M4] [nvarchar](14) NULL,
	[M5] [nvarchar](2) NULL,
	[O1] [nvarchar](1) NULL,
	[O2] [nvarchar](19) NULL,
	[O3] [nvarchar](3) NULL,
	[O4] [nvarchar](35) NULL,
	[O5] [nvarchar](19) NULL,
	[O6] [nvarchar](3) NULL,
	[O7] [nvarchar](19) NULL,
	[O8] [nvarchar](3) NULL,
	[O9] [nvarchar](19) NULL,
	[OA] [nvarchar](3) NULL,
	[OB] [nvarchar](12) NULL,
	[OC] [nvarchar](12) NULL,
	[OD] [nvarchar](12) NULL,
	[N1] [nvarchar](2) NULL,
	[N2] [nvarchar](2) NULL,
	[N3] [nvarchar](3) NULL,
	[N4] [nvarchar](1) NULL,
	[N5] [nvarchar](3) NULL,
	[N7] [nvarchar](2) NULL,
	[N8] [nvarchar](1) NULL,
	[N9] [nvarchar](2) NULL,
	[NB] [nvarchar](2) NULL,
	[NC] [nvarchar](1) NULL,
	[ND] [nvarchar](3) NULL,
	[NE] [nvarchar](3) NULL,
	[NF] [nvarchar](3) NULL,
	[NG] [nvarchar](3) NULL,
	[NH] [nvarchar](3) NULL,
	[VE] [nvarchar](1) NULL,
	[V1] [nvarchar](35) NULL,
	[V2] [nvarchar](70) NULL,
	[V3] [nvarchar](35) NULL,
	[V4] [nvarchar](35) NULL,
	[V5] [nvarchar](10) NULL,
	[V6] [nvarchar](35) NULL,
	[V7] [nvarchar](9) NULL,
	[V8] [nvarchar](2) NULL,
	[S1] [nvarchar](2) NULL,
	[S2] [nvarchar](8) NULL,
	[S3] [nvarchar](105) NULL,
	[S4] [nvarchar](17) NULL,
	[S5] [nvarchar](17) NULL,
	[S6] [nvarchar](1) NULL,
	[P1] [nvarchar](17) NULL,
	[P5] [nvarchar](1) NULL,
	[Q1] [nvarchar](4) NULL,
	[Q2] [nvarchar](35) NULL,
	[Q3] [nvarchar](8) NULL,
	[Q4] [nvarchar](35) NULL,
	[Q5] [nvarchar](2) NULL,
	[Q7] [nvarchar](35) NULL,
	[Q8] [nvarchar](35) NULL,
	[Q9] [nvarchar](70) NULL,
	[QA] [nvarchar](1) NULL,
	[QB] [nvarchar](4) NULL,
	[QC] [nvarchar](22) NULL,
	[R1] [nvarchar](1) NULL,
	[R3] [nvarchar](8) NULL,
	[R5] [nvarchar](35) NULL,
	[R6] [nvarchar](45) NULL,
	[R9] [nvarchar](11) NULL,
	[T1] [nvarchar](255) NULL,
	[T2] [nvarchar](1) NULL,
	[T3] [nvarchar](5) NULL,
	[T4] [nvarchar](70) NULL,
	[T5] [nvarchar](8) NULL,
	[T6] [nvarchar](35) NULL,
	[T7] [nvarchar](4) NULL,
	[T8] [nvarchar](19) NULL,
	[T9] [nvarchar](1) NULL,
	[TZ] [nvarchar](1) NULL,
	[U1] [nvarchar](3) NULL,
	[U2] [nvarchar](19) NULL,
	[U3] [nvarchar](1) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[ADDITIONAL COST] [nvarchar](50) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[CUSTOMS OFFICE] [nvarchar](36) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[Origin] [nvarchar](50) NULL,
	[TYPE] [nvarchar](1) NULL,
	[COMM] [nvarchar](1) NULL,
	[LOGID] [nvarchar](4) NULL,
	[PRINT] [nvarchar](1) NULL,
	[VIEWED] [tinyint] NULL,
	[USERNAME] [nvarchar](25) NULL,
	[HEADER] [smallint] NULL,
	[Memo Field] [nvarchar](max) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[MRN] [nvarchar](18) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[LC] [nvarchar](35) NULL,
	[XG] [nvarchar](35) NULL,
	[XH] [nvarchar](18) NULL,
	[VG] [nvarchar](35) NULL,
	[VH] [nvarchar](18) NULL,
	[AD] [nvarchar](5) NULL,
	[AE] [nvarchar](35) NULL,
	[AF] [nvarchar](35) NULL,
	[AH] [nvarchar](35) NULL,
	[AI] [nvarchar](35) NULL,
	[AL] [nvarchar](8) NULL,
	[AM] [nvarchar](10) NULL,
	[AN] [nvarchar](2) NULL,
	[DC] [nvarchar](17) NULL,
	[DD] [nvarchar](17) NULL,
	[DE] [nvarchar](17) NULL,
	[DF] [nvarchar](2) NULL,
	[DG] [nvarchar](17) NULL,
	[E4] [nvarchar](1) NULL,
	[E5] [nvarchar](4) NULL,
	[E6] [nvarchar](35) NULL,
	[E7] [nvarchar](35) NULL,
	[E8] [nvarchar](7) NULL,
	[E9] [nvarchar](2) NULL,
	[EA] [nvarchar](2) NULL,
	[EB] [nvarchar](2) NULL,
	[EC] [nvarchar](2) NULL,
	[ED] [nvarchar](2) NULL,
	[EE] [nvarchar](2) NULL,
	[EF] [nvarchar](1) NULL,
	[SB] [nvarchar](2) NULL,
	[SD] [nvarchar](4) NULL,
	[SE] [nvarchar](1) NULL,
	[P3] [nvarchar](2) NULL,
	[P4] [nvarchar](2) NULL,
	[AG] [nvarchar](1) NULL,
	[AJ] [nvarchar](2) NULL,
	[AK] [nvarchar](2) NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL,
	[EP] [bit] NOT NULL CONSTRAINT [DF_MASTERPLDA_EP]  DEFAULT ((0)),
	[Consignee Venture Number] [nvarchar](35) NULL,
	[L8] [nvarchar](max) NULL,
	[P2] [nvarchar](max) NULL,
	[R8] [nvarchar](70) NULL,
	[Declarant Venture Number] [nvarchar](35) NULL,
	[Intracom Venture Number] [nvarchar](35) NULL,
	[Representative Venture Number] [nvarchar](35) NULL,
	[Beneficiary Venture Number] [nvarchar](35) NULL,
	[Consignor Venture Number] [nvarchar](35) NULL,
	[Warehouse Depositor Venture Number] [nvarchar](35) NULL,
	[AO] [nvarchar](1) NULL,
	[SC] [nvarchar](15) NULL,
	[SF] [nvarchar](5) NULL,
	[Master_CorrID] [nvarchar](25) NULL,
	[Date Last Received] [datetime] NULL,
	[H1] [nvarchar](8) NULL,
	[H2] [nvarchar](8) NULL,
	[H3] [nvarchar](2) NULL,
	[U4] [nvarchar](10) NULL,
	[R2] [nvarchar](6) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTERNCTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTERNCTS](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[Tree ID] [nvarchar](50) NULL,
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
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](3) NULL,
	[A7] [nvarchar](3) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](15) NULL,
	[AA] [nvarchar](1) NULL,
	[AB] [nvarchar](17) NULL,
	[AC] [nvarchar](2) NULL,
	[AD] [nvarchar](8) NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[B1] [nvarchar](26) NULL,
	[B2] [nvarchar](26) NULL,
	[B3] [nvarchar](2) NULL,
	[B4] [nvarchar](21) NULL,
	[B5] [nvarchar](4) NULL,
	[B6] [nvarchar](1) NULL,
	[B7] [nvarchar](3) NULL,
	[B8] [nvarchar](3) NULL,
	[B9] [nvarchar](2) NULL,
	[BA] [nvarchar](22) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](11) NULL,
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
	[L7] [nvarchar](3) NULL,
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
	[S1] [nvarchar](78) NULL,
	[S2] [nvarchar](39) NULL,
	[S3] [nvarchar](6) NULL,
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
	[DOC NUMBER] [nvarchar](35) NULL,
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
	[Origin] [nvarchar](50) NULL,
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
	[MRN] [nvarchar](18) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MASTER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MASTER](
	[CODE] [nvarchar](30) NULL,
	[DTYPE] [tinyint] NULL,
	[DOCUMENT NAME] [nvarchar](40) NULL,
	[Tree ID] [nvarchar](50) NULL,
	[DATE CREATED] [datetime] NULL,
	[DATE LAST MODIFIED] [datetime] NULL,
	[DATE REQUESTED] [datetime] NULL,
	[DATE SEND] [datetime] NULL,
	[LAST MODIFIED BY] [nvarchar](25) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[REMARKS] [nvarchar](50) NULL,
	[USER NO] [int] NULL,
	[A1] [nvarchar](4) NULL,
	[A3/A2] [nvarchar](7) NULL,
	[A4] [nvarchar](3) NULL,
	[A5] [nvarchar](1) NULL,
	[A7/A6] [nvarchar](3) NULL,
	[A8/A7] [nvarchar](3) NULL,
	[B1] [nvarchar](26) NULL,
	[B2] [nvarchar](29) NULL,
	[B3] [nvarchar](2) NULL,
	[B6/B4] [nvarchar](21) NULL,
	[B7/B5] [nvarchar](4) NULL,
	[B8/B6] [nvarchar](1) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[D1] [nvarchar](7) NULL,
	[D3/D2] [nvarchar](13) NULL,
	[D5/D4] [nvarchar](1) NULL,
	[D6/D5] [nvarchar](2) NULL,
	[D8/D6] [nvarchar](11) NULL,
	[E2/C4] [nvarchar](6) NULL,
	[F1] [nvarchar](5) NULL,
	[F2] [nvarchar](5) NULL,
	[F3] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[G2] [nvarchar](7) NULL,
	[G3] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[H2] [nvarchar](6) NULL,
	[H3] [nvarchar](6) NULL,
	[K1] [nvarchar](22) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[U1] [nvarchar](65) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](4) NULL,
	[U5] [nvarchar](6) NULL,
	[L1] [nvarchar](13) NULL,
	[M1] [nvarchar](12) NULL,
	[M2] [nvarchar](12) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M8/M6] [nvarchar](13) NULL,
	[M9/M7] [nvarchar](6) NULL,
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
	[S1] [nvarchar](78) NULL,
	[T1] [nvarchar](55) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](22) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6/S3] [nvarchar](6) NULL,
	[T7] [nvarchar](1) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[ADDITIONAL COST] [nvarchar](50) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
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
	[Origin] [nvarchar](50) NULL,
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
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL,
	[Master_DeleteSourceTreeID] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inbounds]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Inbounds](
	[In_ID] [int] NOT NULL,
	[In_Code] [nvarchar](50) NULL,
	[In_Header] [int] NULL,
	[In_Detail] [int] NULL,
	[In_Batch_Num] [nvarchar](50) NULL,
	[In_Job_Num] [nvarchar](50) NULL,
	[In_Orig_Packages_Qty] [float] NULL,
	[In_Orig_Gross_Weight] [float] NULL,
	[In_Orig_Net_Weight] [float] NULL,
	[In_Orig_Packages_Type] [nvarchar](50) NULL,
	[In_TotalOut_Qty_Wgt] [float] NULL,
	[In_Reserved_Qty_Wgt] [float] NULL,
	[In_Avl_Qty_Wgt] [float] NULL,
	[Stock_ID] [int] NULL,
	[InDoc_ID] [int] NULL,
	[In_Source_In_ID] [int] NULL,
	[In_ValuePerUOM] [money] NULL,
	[In_InvoiceDate] [datetime] NULL,
	[In_InvoiceNumber] [nvarchar](25) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InBoundDocs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[InBoundDocs](
	[InDoc_ID] [int] NOT NULL,
	[InDoc_Type] [nvarchar](50) NULL,
	[InDoc_Num] [nvarchar](50) NULL,
	[InDoc_Date] [datetime] NULL,
	[InDoc_Office] [nvarchar](50) NULL,
	[InDoc_SeqNum] [int] NULL,
	[InDoc_Cert_Type] [nvarchar](5) NULL,
	[InDoc_Cert_Num] [nvarchar](7) NULL,
	[InDoc_Global] [bit] NOT NULL CONSTRAINT [DF_INBOUNDDOCS_GLOBAL]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IMPORT HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](4) NULL,
	[A2] [nvarchar](5) NULL,
	[A3] [nvarchar](7) NULL,
	[A4] [nvarchar](3) NULL,
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](1) NULL,
	[A7] [nvarchar](3) NULL,
	[A8] [nvarchar](3) NULL,
	[A9] [nvarchar](13) NULL,
	[B1] [nvarchar](26) NULL,
	[B2] [nvarchar](29) NULL,
	[B3] [nvarchar](2) NULL,
	[B4] [nvarchar](1) NULL,
	[B5] [nvarchar](15) NULL,
	[B6] [nvarchar](21) NULL,
	[B7] [nvarchar](4) NULL,
	[B8] [nvarchar](1) NULL,
	[B9] [nvarchar](4) NULL,
	[BA] [nvarchar](4) NULL,
	[BB] [nvarchar](17) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](2) NULL,
	[C4] [nvarchar](5) NULL,
	[C5] [nvarchar](6) NULL,
	[C6] [nvarchar](7) NULL,
	[D1] [nvarchar](7) NULL,
	[D2] [nvarchar](6) NULL,
	[D3] [nvarchar](13) NULL,
	[D4] [nvarchar](2) NULL,
	[D5] [nvarchar](1) NULL,
	[D6] [nvarchar](2) NULL,
	[D7] [nvarchar](29) NULL,
	[D8] [nvarchar](11) NULL,
	[D9] [nvarchar](1) NULL,
	[DA] [nvarchar](12) NULL,
	[DB] [nvarchar](12) NULL,
	[E1] [nvarchar](39) NULL,
	[E2] [nvarchar](6) NULL,
	[E3] [nvarchar](2) NULL,
	[E4] [nvarchar](12) NULL,
	[F1] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[J1] [nvarchar](14) NULL,
	[F2] [nvarchar](5) NULL,
	[G2] [nvarchar](7) NULL,
	[H2] [nvarchar](6) NULL,
	[J2] [nvarchar](14) NULL,
	[F3] [nvarchar](5) NULL,
	[G3] [nvarchar](7) NULL,
	[H3] [nvarchar](6) NULL,
	[J3] [nvarchar](14) NULL,
	[K1] [nvarchar](2) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[U1] [nvarchar](65) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](4) NULL,
	[U5] [nvarchar](6) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[IMPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[Box1] [nvarchar](150) NULL,
	[Box2a] [nvarchar](150) NULL,
	[Box2b] [nvarchar](150) NULL,
	[Box3] [nvarchar](30) NULL,
	[Box4] [nvarchar](30) NULL,
	[Box5] [nvarchar](30) NULL,
	[Box6] [nvarchar](150) NULL,
	[Box7a] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX7A]  DEFAULT ((0)),
	[Box7b] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX7B]  DEFAULT ((0)),
	[Box7c] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX7C]  DEFAULT ((0)),
	[Box7cBis] [nvarchar](150) NULL,
	[Box8a] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX8A]  DEFAULT ((0)),
	[Box8b] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX8B]  DEFAULT ((0)),
	[Box8Bis] [nvarchar](150) NULL,
	[Box9a] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX9A]  DEFAULT ((0)),
	[Box9b] [bit] NOT NULL CONSTRAINT [DF_IMPORT_HEADER_BOX9B]  DEFAULT ((0)),
	[Box9Bis] [nvarchar](150) NULL,
	[Box10] [int] NULL,
	[Box10b-1] [nvarchar](50) NULL,
	[Box10b-2] [nvarchar](20) NULL,
	[Box10b-3] [nvarchar](50) NULL,
	[B-Bis] [nvarchar](max) NULL,
	[OfcUsage] [nvarchar](50) NULL,
	[ExRate] [nvarchar](20) NULL,
	[DVfooter] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IMPORT DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IMPORT DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[L1] [nvarchar](13) NULL,
	[L2] [nvarchar](12) NULL,
	[L3] [nvarchar](12) NULL,
	[L4] [nvarchar](12) NULL,
	[M1] [nvarchar](12) NULL,
	[M2] [nvarchar](12) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M5] [nvarchar](2) NULL,
	[M6] [nvarchar](12) NULL,
	[M7] [nvarchar](12) NULL,
	[M8] [nvarchar](13) NULL,
	[M9] [nvarchar](6) NULL,
	[MA] [nvarchar](12) NULL,
	[N1] [nvarchar](5) NULL,
	[O1] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[N2] [nvarchar](5) NULL,
	[O2] [nvarchar](7) NULL,
	[P2] [nvarchar](6) NULL,
	[Q2] [nvarchar](12) NULL,
	[N3] [nvarchar](5) NULL,
	[O3] [nvarchar](7) NULL,
	[P3] [nvarchar](6) NULL,
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
	[S1] [nvarchar](78) NULL,
	[T1] [nvarchar](55) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](22) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6] [nvarchar](6) NULL,
	[T7] [nvarchar](1) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[DUTIES TAXES P1] [nvarchar](14) NULL,
	[DUTIES TAXES P2] [nvarchar](14) NULL,
	[DUTIES TAXES P3] [nvarchar](14) NULL,
	[DUTIES TAXES P4] [nvarchar](14) NULL,
	[DUTIES TAXES P5] [nvarchar](14) NULL,
	[DUTIES TAXES P6] [nvarchar](14) NULL,
	[DUTIES TAXES P7] [nvarchar](14) NULL,
	[DUTIES TAXES P8] [nvarchar](14) NULL,
	[DUTIES TAXES B1] [nvarchar](14) NULL,
	[DUTIES TAXES B2] [nvarchar](14) NULL,
	[DUTIES TAXES B3] [nvarchar](14) NULL,
	[DUTIES TAXES B4] [nvarchar](14) NULL,
	[DUTIES TAXES B5] [nvarchar](14) NULL,
	[DUTIES TAXES B6] [nvarchar](14) NULL,
	[DUTIES TAXES B7] [nvarchar](14) NULL,
	[DUTIES TAXES B8] [nvarchar](14) NULL,
	[ADDITIONAL COST] [nvarchar](14) NULL,
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
	[Box11a] [nvarchar](20) NULL,
	[Box11b] [nvarchar](20) NULL,
	[Box12] [nvarchar](20) NULL,
	[Box13a] [nvarchar](20) NULL,
	[Box13b] [nvarchar](20) NULL,
	[Box13c] [nvarchar](20) NULL,
	[Box14a] [nvarchar](20) NULL,
	[Box14b] [nvarchar](20) NULL,
	[Box14c] [nvarchar](20) NULL,
	[Box14d] [nvarchar](20) NULL,
	[Box15] [nvarchar](20) NULL,
	[Box16] [nvarchar](20) NULL,
	[Box17] [nvarchar](20) NULL,
	[Box17b] [nvarchar](20) NULL,
	[Box17c] [nvarchar](20) NULL,
	[Box18] [nvarchar](20) NULL,
	[Box19] [nvarchar](20) NULL,
	[Box20] [nvarchar](20) NULL,
	[Box21] [nvarchar](20) NULL,
	[Box21bis] [nvarchar](150) NULL,
	[Box22] [nvarchar](20) NULL,
	[Box23] [nvarchar](20) NULL,
	[Box24] [nvarchar](20) NULL,
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL,
	[Out_ID] [int] NULL
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EXPORT HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](4) NULL,
	[A2] [nvarchar](7) NULL,
	[A3] [nvarchar](9) NULL,
	[A4] [nvarchar](3) NULL,
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](3) NULL,
	[A7] [nvarchar](3) NULL,
	[B1] [nvarchar](26) NULL,
	[B2] [nvarchar](29) NULL,
	[B3] [nvarchar](2) NULL,
	[B4] [nvarchar](21) NULL,
	[B5] [nvarchar](4) NULL,
	[B6] [nvarchar](1) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](27) NULL,
	[C4] [nvarchar](6) NULL,
	[D1] [nvarchar](7) NULL,
	[D2] [nvarchar](13) NULL,
	[D3] [nvarchar](2) NULL,
	[D4] [nvarchar](1) NULL,
	[D5] [nvarchar](2) NULL,
	[D6] [nvarchar](11) NULL,
	[D7] [nvarchar](29) NULL,
	[E1] [nvarchar](1) NULL,
	[E2] [nvarchar](3) NULL,
	[E3] [nvarchar](17) NULL,
	[E4] [nvarchar](3) NULL,
	[E5] [nvarchar](3) NULL,
	[E6] [nvarchar](3) NULL,
	[E7] [nvarchar](3) NULL,
	[E8] [nvarchar](7) NULL,
	[E9] [nvarchar](3) NULL,
	[EA] [nvarchar](7) NULL,
	[EB] [nvarchar](3) NULL,
	[EC] [nvarchar](7) NULL,
	[ED] [nvarchar](3) NULL,
	[EE] [nvarchar](7) NULL,
	[EF] [nvarchar](3) NULL,
	[EG] [nvarchar](7) NULL,
	[EH] [nvarchar](3) NULL,
	[EI] [nvarchar](7) NULL,
	[EJ] [nvarchar](3) NULL,
	[F1] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[J1] [nvarchar](14) NULL,
	[F2] [nvarchar](5) NULL,
	[G2] [nvarchar](7) NULL,
	[H2] [nvarchar](6) NULL,
	[J2] [nvarchar](14) NULL,
	[F3] [nvarchar](5) NULL,
	[G3] [nvarchar](7) NULL,
	[H3] [nvarchar](6) NULL,
	[J3] [nvarchar](14) NULL,
	[K1] [nvarchar](2) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](4) NULL,
	[U5] [nvarchar](6) NULL,
	[W1] [nvarchar](32) NULL,
	[W2] [nvarchar](22) NULL,
	[W3] [nvarchar](22) NULL,
	[X1] [nvarchar](32) NULL,
	[X2] [nvarchar](22) NULL,
	[X3] [nvarchar](22) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[EXPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[EUR1] [nvarchar](max) NULL,
	[ExRate] [nvarchar](20) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EXPORT DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EXPORT DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[L1] [nvarchar](13) NULL,
	[L2] [nvarchar](13) NULL,
	[L3] [nvarchar](12) NULL,
	[L4] [nvarchar](3) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](17) NULL,
	[M1] [nvarchar](12) NULL,
	[M2] [nvarchar](12) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M5] [nvarchar](12) NULL,
	[M6] [nvarchar](13) NULL,
	[M7] [nvarchar](6) NULL,
	[M8] [nvarchar](12) NULL,
	[N1] [nvarchar](5) NULL,
	[O1] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[N2] [nvarchar](5) NULL,
	[O2] [nvarchar](7) NULL,
	[P2] [nvarchar](6) NULL,
	[Q2] [nvarchar](12) NULL,
	[N3] [nvarchar](5) NULL,
	[O3] [nvarchar](7) NULL,
	[P3] [nvarchar](6) NULL,
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
	[S1] [nvarchar](78) NULL,
	[S2] [nvarchar](39) NULL,
	[S3] [nvarchar](6) NULL,
	[S4] [nvarchar](2) NULL,
	[S5] [nvarchar](1) NULL,
	[S6] [nvarchar](15) NULL,
	[T1] [nvarchar](5) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](7) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6] [nvarchar](22) NULL,
	[T7] [nvarchar](1) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
	[ACCT WEEK] [nvarchar](4) NULL,
	[CUSTOMS VALUE] [nvarchar](14) NULL,
	[BASIS FOR VAT] [nvarchar](14) NULL,
	[DUTIES TAXES P1] [nvarchar](14) NULL,
	[DUTIES TAXES P2] [nvarchar](14) NULL,
	[DUTIES TAXES P3] [nvarchar](14) NULL,
	[DUTIES TAXES P4] [nvarchar](14) NULL,
	[DUTIES TAXES P5] [nvarchar](14) NULL,
	[DUTIES TAXES P6] [nvarchar](14) NULL,
	[DUTIES TAXES P7] [nvarchar](14) NULL,
	[DUTIES TAXES P8] [nvarchar](14) NULL,
	[DUTIES TAXES B1] [nvarchar](14) NULL,
	[DUTIES TAXES B2] [nvarchar](14) NULL,
	[DUTIES TAXES B3] [nvarchar](14) NULL,
	[DUTIES TAXES B4] [nvarchar](14) NULL,
	[DUTIES TAXES B5] [nvarchar](14) NULL,
	[DUTIES TAXES B6] [nvarchar](14) NULL,
	[DUTIES TAXES B7] [nvarchar](14) NULL,
	[DUTIES TAXES B8] [nvarchar](14) NULL,
	[ADDITIONAL COST] [nvarchar](14) NULL,
	[U1] [nvarchar](65) NULL,
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
	[Stock_ID] [int] NULL,
	[In_ID] [int] NULL
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS HEADER ZEKERHEID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS HEADER ZEKERHEID](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[ORDINAL] [int] NULL,
	[E1] [nvarchar](1) NULL,
	[EJ] [nvarchar](1) NULL,
	[E3] [nvarchar](35) NULL,
	[EK] [nvarchar](4) NULL,
	[E4] [nvarchar](3) NULL,
	[E5] [nvarchar](3) NULL,
	[E6] [nvarchar](3) NULL,
	[E7] [nvarchar](3) NULL,
	[EM] [nvarchar](3) NULL,
	[EN] [nvarchar](3) NULL,
	[EO] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS HEADER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS HEADER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [float] NULL,
	[A1] [nvarchar](4) NULL,
	[A2] [nvarchar](7) NULL,
	[A4] [nvarchar](8) NULL,
	[A5] [nvarchar](1) NULL,
	[A6] [nvarchar](3) NULL,
	[A7] [nvarchar](3) NULL,
	[A8] [nvarchar](5) NULL,
	[A9] [nvarchar](15) NULL,
	[AA] [nvarchar](1) NULL,
	[AB] [nvarchar](17) NULL,
	[AC] [nvarchar](2) NULL,
	[AD] [nvarchar](8) NULL,
	[AE] [nvarchar](20) NULL,
	[AF] [nvarchar](20) NULL,
	[B7] [nvarchar](3) NULL,
	[B1] [nvarchar](26) NULL,
	[B8] [nvarchar](3) NULL,
	[B2] [nvarchar](26) NULL,
	[B3] [nvarchar](2) NULL,
	[B9] [nvarchar](2) NULL,
	[B4] [nvarchar](21) NULL,
	[BA] [nvarchar](22) NULL,
	[B5] [nvarchar](4) NULL,
	[B6] [nvarchar](1) NULL,
	[C1] [nvarchar](3) NULL,
	[C2] [nvarchar](3) NULL,
	[C3] [nvarchar](11) NULL,
	[C4] [nvarchar](6) NULL,
	[C5] [nvarchar](5) NULL,
	[D1] [nvarchar](7) NULL,
	[D2] [nvarchar](13) NULL,
	[D3] [nvarchar](2) NULL,
	[D4] [nvarchar](1) NULL,
	[D5] [nvarchar](2) NULL,
	[D6] [nvarchar](150) NULL,
	[D7] [nvarchar](150) NULL,
	[F1] [nvarchar](5) NULL,
	[G1] [nvarchar](7) NULL,
	[H1] [nvarchar](6) NULL,
	[J1] [nvarchar](12) NULL,
	[F2] [nvarchar](5) NULL,
	[G2] [nvarchar](7) NULL,
	[H2] [nvarchar](6) NULL,
	[J2] [nvarchar](12) NULL,
	[F3] [nvarchar](5) NULL,
	[G3] [nvarchar](7) NULL,
	[H3] [nvarchar](6) NULL,
	[J3] [nvarchar](12) NULL,
	[K1] [nvarchar](2) NULL,
	[K2] [nvarchar](6) NULL,
	[K3] [nvarchar](2) NULL,
	[K4] [nvarchar](6) NULL,
	[K5] [nvarchar](2) NULL,
	[K6] [nvarchar](6) NULL,
	[X4] [nvarchar](17) NULL,
	[X5] [nvarchar](3) NULL,
	[X1] [nvarchar](32) NULL,
	[X2] [nvarchar](24) NULL,
	[X6] [nvarchar](9) NULL,
	[X3] [nvarchar](35) NULL,
	[X7] [nvarchar](35) NULL,
	[X8] [nvarchar](35) NULL,
	[E8] [nvarchar](8) NULL,
	[EA] [nvarchar](8) NULL,
	[EC] [nvarchar](8) NULL,
	[EE] [nvarchar](8) NULL,
	[EG] [nvarchar](8) NULL,
	[EI] [nvarchar](8) NULL,
	[DOC NUMBER] [nvarchar](35) NULL,
	[BOOK NAME] [nvarchar](70) NULL,
	[MRN] [nvarchar](18) NULL,
	[EXPORTER] [nvarchar](130) NULL,
	[IMPORTER] [nvarchar](130) NULL,
	[PRINTDATA] [nvarchar](max) NULL,
	[PRINTDATA2] [nvarchar](max) NULL,
	[EUR1] [nvarchar](max) NULL,
	[Result Combined NCTS] [nvarchar](150) NULL,
	[Result IE] [nvarchar](150) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL GOEDEREN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL GOEDEREN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[L1] [nvarchar](10) NULL,
	[L2] [nvarchar](13) NULL,
	[L3] [nvarchar](12) NULL,
	[L4] [nvarchar](3) NULL,
	[L5] [nvarchar](4) NULL,
	[L6] [nvarchar](17) NULL,
	[L8] [nvarchar](3) NULL,
	[M1] [nvarchar](15) NULL,
	[M2] [nvarchar](12) NULL,
	[M9] [nvarchar](3) NULL,
	[M3] [nvarchar](2) NULL,
	[M4] [nvarchar](12) NULL,
	[M5] [nvarchar](12) NULL,
	[S1] [nvarchar](78) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL GEVOELIGE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL GEVOELIGE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[V1] [nvarchar](2) NULL,
	[V2] [nvarchar](15) NULL,
	[V3] [nvarchar](2) NULL,
	[V4] [nvarchar](15) NULL,
	[V5] [nvarchar](2) NULL,
	[V6] [nvarchar](15) NULL,
	[V7] [nvarchar](2) NULL,
	[V8] [nvarchar](15) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL DOCUMENTEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL DOCUMENTEN](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Y1] [nvarchar](1) NULL,
	[Y2] [nvarchar](5) NULL,
	[Y3] [nvarchar](20) NULL,
	[Y4] [nvarchar](26) NULL,
	[Y5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL CONTAINER]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL CONTAINER](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S6] [nvarchar](11) NULL,
	[S7] [nvarchar](11) NULL,
	[S8] [nvarchar](11) NULL,
	[S9] [nvarchar](11) NULL,
	[SA] [nvarchar](11) NULL,
	[SB] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL COLLI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL COLLI](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[S2] [nvarchar](39) NULL,
	[S4] [nvarchar](2) NULL,
	[S3] [nvarchar](6) NULL,
	[S5] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL BIJZONDERE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL BIJZONDERE](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[ORDINAL] [int] NULL,
	[Z1] [nvarchar](3) NULL,
	[Z2] [nvarchar](3) NULL,
	[Z3] [nvarchar](70) NULL,
	[Z4] [nvarchar](1) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS DETAIL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS DETAIL](
	[CODE] [nvarchar](21) NULL,
	[HEADER] [smallint] NULL,
	[DETAIL] [smallint] NULL,
	[U6] [nvarchar](17) NULL,
	[U7] [nvarchar](3) NULL,
	[U2] [nvarchar](32) NULL,
	[U3] [nvarchar](24) NULL,
	[U4] [nvarchar](9) NULL,
	[U8] [nvarchar](35) NULL,
	[U5] [nvarchar](6) NULL,
	[W6] [nvarchar](17) NULL,
	[W7] [nvarchar](1) NULL,
	[W1] [nvarchar](32) NULL,
	[W2] [nvarchar](24) NULL,
	[W4] [nvarchar](9) NULL,
	[W3] [nvarchar](35) NULL,
	[W5] [nvarchar](3) NULL,
	[M6] [nvarchar](13) NULL,
	[M7] [nvarchar](6) NULL,
	[M8] [nvarchar](12) NULL,
	[N1] [nvarchar](135) NULL,
	[O1] [nvarchar](7) NULL,
	[P1] [nvarchar](6) NULL,
	[Q1] [nvarchar](12) NULL,
	[N2] [nvarchar](5) NULL,
	[O2] [nvarchar](27) NULL,
	[P2] [nvarchar](6) NULL,
	[Q2] [nvarchar](12) NULL,
	[N3] [nvarchar](5) NULL,
	[O3] [nvarchar](7) NULL,
	[P3] [nvarchar](6) NULL,
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
	[T1] [nvarchar](5) NULL,
	[T2] [nvarchar](6) NULL,
	[T3] [nvarchar](7) NULL,
	[T4] [nvarchar](19) NULL,
	[T5] [nvarchar](4) NULL,
	[T6] [nvarchar](22) NULL,
	[T7] [nvarchar](1) NULL,
	[CUSTOMS OFFICE] [nvarchar](2) NULL,
	[DOC TYPE] [nvarchar](3) NULL,
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COMBINED NCTS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COMBINED NCTS](
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
	[Tree ID] [nvarchar](50) NULL,
	[SUPPLIER NAME] [nvarchar](40) NULL,
	[DTYPE] [tinyint] NULL,
	[Error String] [nvarchar](max) NULL,
	[Error HD] [nvarchar](10) NULL,
	[LOGID] [nvarchar](4) NULL,
	[USERNAME] [nvarchar](25) NULL,
	[DATE PRINTED] [datetime] NULL,
	[PRINTED BY] [nvarchar](25) NULL,
	[REMOTE_ID] [int] NULL,
	[Mail_Recipients] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
