USE [TemplateCP]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Allow_Move]') AND type in (N'U'))
DROP TABLE [dbo].[Allow_Move]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BUTTONGROUPS_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ButtonGroups] DROP CONSTRAINT [DF_BUTTONGROUPS_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonGroups]') AND type in (N'U'))
DROP TABLE [dbo].[ButtonGroups]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonGroups2003]') AND type in (N'U'))
DROP TABLE [dbo].[ButtonGroups2003]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BUTTONS_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Buttons] DROP CONSTRAINT [DF_BUTTONS_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BUTTONS_DELETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Buttons] DROP CONSTRAINT [DF_BUTTONS_DELETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buttons]') AND type in (N'U'))
DROP TABLE [dbo].[Buttons]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BUTTONS2003_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Buttons2003] DROP CONSTRAINT [DF_BUTTONS2003_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buttons2003]') AND type in (N'U'))
DROP TABLE [dbo].[Buttons2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonTreeSettings]') AND type in (N'U'))
DROP TABLE [dbo].[ButtonTreeSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonTreeSettings2003]') AND type in (N'U'))
DROP TABLE [dbo].[ButtonTreeSettings2003]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_CPUPGRADETRACKER_PERFORMUPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CPUpgradeTracker] DROP CONSTRAINT [DF_CPUPGRADETRACKER_PERFORMUPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CPUpgradeTracker]') AND type in (N'U'))
DROP TABLE [dbo].[CPUpgradeTracker]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Databases]') AND type in (N'U'))
DROP TABLE [dbo].[Databases]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBPROPERTIES_EMPTY]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBProperties] DROP CONSTRAINT [DF_DBPROPERTIES_EMPTY]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProperties]') AND type in (N'U'))
DROP TABLE [dbo].[DBProperties]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProps]') AND type in (N'U'))
DROP TABLE [dbo].[DBProps]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DBUPGRADETRACKER_PERFORMUPDATES_COMPLETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DBUpgradeTracker] DROP CONSTRAINT [DF_DBUPGRADETRACKER_PERFORMUPDATES_COMPLETED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUpgradeTracker]') AND type in (N'U'))
DROP TABLE [dbo].[DBUpgradeTracker]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DEFAULTVIEWCOLUMNS_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DefaultViewColumns] DROP CONSTRAINT [DF_DEFAULTVIEWCOLUMNS_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultViewColumns]') AND type in (N'U'))
DROP TABLE [dbo].[DefaultViewColumns]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DEFAULTVIEWCOLUMNS2003_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[DefaultViewColumns2003] DROP CONSTRAINT [DF_DEFAULTVIEWCOLUMNS2003_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultViewColumns2003]') AND type in (N'U'))
DROP TABLE [dbo].[DefaultViewColumns2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DELETEITEM LOG]') AND type in (N'U'))
DROP TABLE [dbo].[DELETEITEM LOG]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_DEVELOPER_SETTINGS_FORDEV]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Developer Settings] DROP CONSTRAINT [DF_DEVELOPER_SETTINGS_FORDEV]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Developer Settings]') AND type in (N'U'))
DROP TABLE [dbo].[Developer Settings]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FEATURES_ACTIVATED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Features] DROP CONSTRAINT [DF_FEATURES_ACTIVATED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Features]') AND type in (N'U'))
DROP TABLE [dbo].[Features]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filter]') AND type in (N'U'))
DROP TABLE [dbo].[Filter]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_FIND_VIEWCOLUMNS_CARDSVIEW]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[FindViewColumns] DROP CONSTRAINT [DF_FIND_VIEWCOLUMNS_CARDSVIEW]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FindViewColumns]') AND type in (N'U'))
DROP TABLE [dbo].[FindViewColumns]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_GROUPNODES_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[GroupNodes] DROP CONSTRAINT [DF_GROUPNODES_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupNodes]') AND type in (N'U'))
DROP TABLE [dbo].[GroupNodes]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_LICENSEE_USE_EXACTID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Licensee] DROP CONSTRAINT [DF_LICENSEE_USE_EXACTID]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Licensee]') AND type in (N'U'))
DROP TABLE [dbo].[Licensee]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkedTables]') AND type in (N'U'))
DROP TABLE [dbo].[LinkedTables]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAIN_SETTINGS_NAVIGATION]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainSettings] DROP CONSTRAINT [DF_MAIN_SETTINGS_NAVIGATION]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAIN_SETTINGS_FINDBOX]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainSettings] DROP CONSTRAINT [DF_MAIN_SETTINGS_FINDBOX]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAIN_SETTINGS_STATUSBAR]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainSettings] DROP CONSTRAINT [DF_MAIN_SETTINGS_STATUSBAR]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAIN_SETTINGS_VIEWOPTIONS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainSettings] DROP CONSTRAINT [DF_MAIN_SETTINGS_VIEWOPTIONS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_MAIN_SETTINGS_CUSTOMFIND]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainSettings] DROP CONSTRAINT [DF_MAIN_SETTINGS_CUSTOMFIND]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MainSettings]') AND type in (N'U'))
DROP TABLE [dbo].[MainSettings]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NODES_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Nodes] DROP CONSTRAINT [DF_NODES_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nodes]') AND type in (N'U'))
DROP TABLE [dbo].[Nodes]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NODES2003_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Nodes2003] DROP CONSTRAINT [DF_NODES2003_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nodes2003]') AND type in (N'U'))
DROP TABLE [dbo].[Nodes2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermDeletedArchivedDocs]') AND type in (N'U'))
DROP TABLE [dbo].[PermDeletedArchivedDocs]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBacklogTable]') AND type in (N'U'))
DROP TABLE [dbo].[PrintBacklogTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintDocTypes]') AND type in (N'U'))
DROP TABLE [dbo].[PrintDocTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TemplateTreeLinks]') AND type in (N'U'))
DROP TABLE [dbo].[TemplateTreeLinks]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trees]') AND type in (N'U'))
DROP TABLE [dbo].[Trees]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trees2003]') AND type in (N'U'))
DROP TABLE [dbo].[Trees2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeSettings]') AND type in (N'U'))
DROP TABLE [dbo].[TreeSettings]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeSettings2003]') AND type in (N'U'))
DROP TABLE [dbo].[TreeSettings2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeTypeGroups]') AND type in (N'U'))
DROP TABLE [dbo].[TreeTypeGroups]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeTypes]') AND type in (N'U'))
DROP TABLE [dbo].[TreeTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeViews]') AND type in (N'U'))
DROP TABLE [dbo].[TreeViews]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeViews2003]') AND type in (N'U'))
DROP TABLE [dbo].[TreeViews2003]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TVQueryDefs]') AND type in (N'U'))
DROP TABLE [dbo].[TVQueryDefs]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TVQueryDefs2003]') AND type in (N'U'))
DROP TABLE [dbo].[TVQueryDefs2003]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_HAS_ADMIN_RIGHTS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_HAS_ADMIN_RIGHTS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_MAINTAIN_TABLES]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_MAINTAIN_TABLES]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_ALL_LOGICAL_IDS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_ALL_LOGICAL_IDS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ALL_SENT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ALL_SENT]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ALL_WAITING]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ALL_WAITING]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ALL_DELETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ALL_DELETED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_CLEANUP_DELETED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_CLEANUP_DELETED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_DELETE_OTHER_USER_ITEMS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_DELETE_OTHER_USER_ITEMS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_WITH_SECURITY]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_WITH_SECURITY]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_RELATE_L1_TO_S1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_RELATE_L1_TO_S1]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_FIXED_USER]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_FIXED_USER]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_LOGGED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_LOGGED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ONLY_DOCTYPE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ONLY_DOCTYPE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ONLY_VATNUM]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ONLY_VATNUM]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ONLY_CTRYCODE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ONLY_CTRYCODE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ALL_TO_BE_PRINTED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ALL_TO_BE_PRINTED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_SHOW_ALL_DRAFTS]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_SHOW_ALL_DRAFTS]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERS_TASKPANE_VISIBLE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_USERS_TASKPANE_VISIBLE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_GROUPHEADER_VISIBLE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_GROUPHEADER_VISIBLE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_CARDSVIEW]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_CARDSVIEW]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_ODDEVENCOLOR]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_ODDEVENCOLOR]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_GRIDLINES]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_GRIDLINES]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_ISGROUP_EXPANDED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_ISGROUP_EXPANDED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_SELECTEDVIEW]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_SELECTEDVIEW]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_AUTOGROUP]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_AUTOGROUP]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN_READINGPANE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns] DROP CONSTRAINT [DF_USERVIEWCOLUMN_READINGPANE]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserViewColumns]') AND type in (N'U'))
DROP TABLE [dbo].[UserViewColumns]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN2003_GROUPHEADER_VISIBLE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns2003] DROP CONSTRAINT [DF_USERVIEWCOLUMN2003_GROUPHEADER_VISIBLE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN2003_CARDSVIEW]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns2003] DROP CONSTRAINT [DF_USERVIEWCOLUMN2003_CARDSVIEW]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN2003_ODDEVENCOLOR]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns2003] DROP CONSTRAINT [DF_USERVIEWCOLUMN2003_ODDEVENCOLOR]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN2003_GRIDLINES]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns2003] DROP CONSTRAINT [DF_USERVIEWCOLUMN2003_GRIDLINES]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_USERVIEWCOLUMN2003_ISGROUP_EXPANDED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UserViewColumns2003] DROP CONSTRAINT [DF_USERVIEWCOLUMN2003_ISGROUP_EXPANDED]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserViewColumns2003]') AND type in (N'U'))
DROP TABLE [dbo].[UserViewColumns2003]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_FONTBOLD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_FONTBOLD]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_FONTITALIC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_FONTITALIC]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_FONTSTRIKETHRU]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_FONTSTRIKETHRU]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_FONTUNDERLINE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_FONTUNDERLINE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_HASVALUELIST]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_HASVALUELIST]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_SELECTED]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_SELECTED]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition] DROP CONSTRAINT [DF_UVCFORMATCONDITION_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UVCFormatCondition]') AND type in (N'U'))
DROP TABLE [dbo].[UVCFormatCondition]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION2003_FONTBOLD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition2003] DROP CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTBOLD]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION2003_FONTITALIC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition2003] DROP CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTITALIC]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION2003_FONTSTRIKETHRU]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition2003] DROP CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTSTRIKETHRU]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION2003_FONTUNDERLINE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition2003] DROP CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTUNDERLINE]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_UVCFORMATCONDITION2003_HASVALUELIST]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[UVCFormatCondition2003] DROP CONSTRAINT [DF_UVCFORMATCONDITION2003_HASVALUELIST]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UVCFormatCondition2003]') AND type in (N'U'))
DROP TABLE [dbo].[UVCFormatCondition2003]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_VIEWS_DEFAULT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Views] DROP CONSTRAINT [DF_VIEWS_DEFAULT]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Views]') AND type in (N'U'))
DROP TABLE [dbo].[Views]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WindowSettings]') AND type in (N'U'))
DROP TABLE [dbo].[WindowSettings]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WindowSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WindowSettings](
	[Window_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Window_Key] [nvarchar](50) NULL,
	[Window_Height] [float] NULL,
	[Window_Width] [float] NULL,
	[Window_Top] [float] NULL,
	[Window_Left] [float] NULL,
	[Window_State] [int] NULL,
	[Window_ShowCmd] [int] NULL,
	[Window_Flags] [int] NULL,
	[Window_MinX] [int] NULL,
	[Window_MinY] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Views]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Views](
	[View_ID] [int] NOT NULL,
	[Node_ID] [int] NULL,
	[View_Caption] [nvarchar](50) NULL,
	[View_Position] [int] NULL,
	[View_Default] [bit] NOT NULL CONSTRAINT [DF_VIEWS_DEFAULT]  DEFAULT ((0)),
	[View_Filter] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UVCFormatCondition2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UVCFormatCondition2003](
	[FC_ID] [int] NOT NULL,
	[FC_Operator] [nvarchar](20) NULL,
	[FC_Value1] [nvarchar](150) NULL,
	[FC_Value2] [nvarchar](150) NULL,
	[FC_FontBold] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTBOLD]  DEFAULT ((0)),
	[FC_FontItalic] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTITALIC]  DEFAULT ((0)),
	[FC_FontStrikeThru] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTSTRIKETHRU]  DEFAULT ((0)),
	[FC_FontUnderline] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION2003_FONTUNDERLINE]  DEFAULT ((0)),
	[FC_ForeColor] [float] NULL,
	[FC_Icon] [int] NULL,
	[FC_Text] [nvarchar](150) NULL,
	[FC_HasValueList] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION2003_HASVALUELIST]  DEFAULT ((0)),
	[FC_Remarks] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UVCFormatCondition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UVCFormatCondition](
	[FC_ID] [int] NOT NULL,
	[FC_Name] [nvarchar](50) NULL,
	[FC_Operator] [int] NULL,
	[FC_Value1] [nvarchar](150) NULL,
	[FC_Value2] [nvarchar](150) NULL,
	[FC_FontBold] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_FONTBOLD]  DEFAULT ((0)),
	[FC_FontItalic] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_FONTITALIC]  DEFAULT ((0)),
	[FC_FontStrikeThru] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_FONTSTRIKETHRU]  DEFAULT ((0)),
	[FC_FontUnderline] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_FONTUNDERLINE]  DEFAULT ((0)),
	[FC_ForeColor] [float] NULL,
	[FC_Icon] [image] NULL,
	[FC_Text] [nvarchar](50) NULL,
	[FC_HasValueList] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_HASVALUELIST]  DEFAULT ((0)),
	[UVC_ID] [int] NULL,
	[FC_Field] [nvarchar](50) NULL,
	[FC_ColumnType] [int] NULL,
	[FC_ColumnText] [nvarchar](50) NULL,
	[FC_Selected] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_SELECTED]  DEFAULT ((0)),
	[FC_Remarks] [nvarchar](100) NULL,
	[FC_Priority] [int] NULL,
	[FC_Default] [bit] NOT NULL CONSTRAINT [DF_UVCFORMATCONDITION_DEFAULT]  DEFAULT ((0)),
	[Node_ID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserViewColumns2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserViewColumns2003](
	[UVC_ID] [int] NOT NULL,
	[TView_ID] [int] NULL,
	[User_ID] [int] NULL,
	[UVC_DVCIDs] [nvarchar](max) NULL,
	[UVC_ColumnAlignments] [nvarchar](max) NULL,
	[UVC_ColumnWidths] [nvarchar](max) NULL,
	[UVC_GroupHeaders] [nvarchar](max) NULL,
	[UVC_Sort] [nvarchar](50) NULL,
	[UVC_Filter] [nvarchar](50) NULL,
	[Node_ID] [int] NULL,
	[UVC_GroupHeaderVisible] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN2003_GROUPHEADER_VISIBLE]  DEFAULT ((0)),
	[UVC_CardsView] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN2003_CARDSVIEW]  DEFAULT ((0)),
	[UVC_OddEvenColor] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN2003_ODDEVENCOLOR]  DEFAULT ((0)),
	[UVC_GridLines] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN2003_GRIDLINES]  DEFAULT ((0)),
	[UVC_RequirementIs1] [nvarchar](max) NULL,
	[UVC_GroupRowFormat] [nvarchar](max) NULL,
	[UVC_IsGroupRowExpanded] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN2003_ISGROUP_EXPANDED]  DEFAULT ((0)),
	[UVC_SelectedItem] [nvarchar](max) NULL,
	[UVC_FCIDs] [nvarchar](max) NULL,
	[UVC_ColumnFormat] [nvarchar](max) NULL,
	[UVC_LastX] [int] NULL,
	[UVC_LastY] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserViewColumns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserViewColumns](
	[UVC_ID] [int] NOT NULL,
	[TView_ID] [int] NULL,
	[View_ID] [int] NULL,
	[User_ID] [int] NULL,
	[UVC_DVCIDs] [nvarchar](max) NULL,
	[UVC_ColumnAlignments] [nvarchar](max) NULL,
	[UVC_ColumnWidths] [nvarchar](max) NULL,
	[UVC_GroupHeaders] [nvarchar](max) NULL,
	[UVC_Sort] [nvarchar](max) NULL,
	[UVC_Filter] [nvarchar](50) NULL,
	[Node_ID] [int] NULL,
	[UVC_GroupHeaderVisible] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_GROUPHEADER_VISIBLE]  DEFAULT ((0)),
	[UVC_CardsView] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_CARDSVIEW]  DEFAULT ((0)),
	[UVC_OddEvenColor] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_ODDEVENCOLOR]  DEFAULT ((0)),
	[UVC_GridLines] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_GRIDLINES]  DEFAULT ((0)),
	[UVC_RequirementIs1] [nvarchar](max) NULL,
	[UVC_GroupRowFormat] [nvarchar](max) NULL,
	[UVC_IsGroupRowExpanded] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_ISGROUP_EXPANDED]  DEFAULT ((0)),
	[UVC_SelectedItem] [nvarchar](max) NULL,
	[UVC_FCIDs] [nvarchar](max) NULL,
	[UVC_ColumnFormat] [nvarchar](max) NULL,
	[UVC_SelectedView] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_SELECTEDVIEW]  DEFAULT ((0)),
	[UVC_AutoGroup] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_AUTOGROUP]  DEFAULT ((0)),
	[UVC_ExpandCollapseDefault] [int] NULL,
	[UVC_ReadingPane] [bit] NOT NULL CONSTRAINT [DF_USERVIEWCOLUMN_READINGPANE]  DEFAULT ((0)),
	[UVC_LastX] [int] NULL,
	[UVC_LastY] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[User_ID] [int] NOT NULL,
	[User_Name] [nvarchar](25) NOT NULL,
	[User_Password] [nvarchar](25) NOT NULL,
	[User_Rights] [smallint] NOT NULL,
	[User_StateSettings] [int] NOT NULL,
	[User_MainDimensionPosition] [nvarchar](75) NOT NULL,
	[User_TreeWidth] [float] NOT NULL,
	[User_Level] [int] NULL,
	[User_ButtonGroup] [int] NULL,
	[User_ButtonBarWidth] [float] NULL,
	[ADMINISTRATOR RIGHTS] [bit] NOT NULL CONSTRAINT [DF_USERS_HAS_ADMIN_RIGHTS]  DEFAULT ((0)),
	[MAINTAIN TABLES] [bit] NOT NULL CONSTRAINT [DF_USERS_MAINTAIN_TABLES]  DEFAULT ((0)),
	[ALL LOGICAL IDS] [bit] NOT NULL CONSTRAINT [DF_USERS_ALL_LOGICAL_IDS]  DEFAULT ((0)),
	[SHOW ALL SENT] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ALL_SENT]  DEFAULT ((0)),
	[SHOW ALL WITH ERRORS] [bit] NOT NULL CONSTRAINT [DF_]  DEFAULT ((0)),
	[SHOW ALL WAITING] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ALL_WAITING]  DEFAULT ((0)),
	[SHOW ALL DELETED] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ALL_DELETED]  DEFAULT ((0)),
	[CLEAN UP DELETED] [bit] NOT NULL CONSTRAINT [DF_USERS_CLEANUP_DELETED]  DEFAULT ((0)),
	[EVERY] [smallint] NULL,
	[DAYS OR ITEMS] [nvarchar](1) NULL,
	[DELETE OTHER USERS ITEMS] [bit] NOT NULL CONSTRAINT [DF_USERS_DELETE_OTHER_USER_ITEMS]  DEFAULT ((0)),
	[DELETE SENT IN N DAYS] [smallint] NULL,
	[WITH SECURITY] [bit] NOT NULL CONSTRAINT [DF_USERS_WITH_SECURITY]  DEFAULT ((0)),
	[REFRESH IN SECONDS] [int] NULL,
	[RELATE L1 TO S1] [bit] NOT NULL CONSTRAINT [DF_USERS_RELATE_L1_TO_S1]  DEFAULT ((0)),
	[SUPPLIER BOX] [nvarchar](2) NULL,
	[LAST USED PRINTER] [nvarchar](150) NULL,
	[LAST DV PRINTER] [nvarchar](50) NULL,
	[LOGID DESCRIPTION] [nvarchar](40) NULL,
	[FIXED USER] [bit] NOT NULL CONSTRAINT [DF_USERS_FIXED_USER]  DEFAULT ((0)),
	[LOGGED] [bit] NOT NULL CONSTRAINT [DF_USERS_LOGGED]  DEFAULT ((0)),
	[SDICOUNT] [int] NULL,
	[SDECOUNT] [int] NULL,
	[SDTCOUNT] [int] NULL,
	[DECOUNT] [int] NULL,
	[SHOW ONLY DOCTYPE] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ONLY_DOCTYPE]  DEFAULT ((0)),
	[SHOW ONLY VATNUM] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ONLY_VATNUM]  DEFAULT ((0)),
	[SHOW ONLY CTRYCODE] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ONLY_CTRYCODE]  DEFAULT ((0)),
	[SAVE NEW TARICCTRY] [int] NULL,
	[SHOW ALL TOBEPRINTED] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ALL_TO_BE_PRINTED]  DEFAULT ((0)),
	[SHOW ALL DRAFTS] [bit] NOT NULL CONSTRAINT [DF_USERS_SHOW_ALL_DRAFTS]  DEFAULT ((0)),
	[SDI2COUNT] [int] NULL,
	[SDE2COUNT] [int] NULL,
	[SDT2COUNT] [int] NULL,
	[LANGUAGE] [tinyint] NULL,
	[PLDAIMPORTPRINTSETTING] [int] NULL,
	[PLDAEXPORTPRINTSETTING] [int] NULL,
	[DIGITAL SIGNATURE OPTION] [smallint] NULL,
	[DIGITAL SIGNATURE SELECTED] [nvarchar](255) NULL,
	[User_TaskPaneVisible] [bit] NOT NULL CONSTRAINT [DF_USERS_TASKPANE_VISIBLE]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TVQueryDefs2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TVQueryDefs2003](
	[TVQ_ID] [int] NOT NULL,
	[TV_QueryName] [nvarchar](250) NULL,
	[TV_QuerySql] [nvarchar](250) NULL,
	[TV_QueryConnectionKey] [nvarchar](250) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TVQueryDefs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TVQueryDefs](
	[TVQ_ID] [int] NOT NULL,
	[TV_QueryName] [nvarchar](50) NULL,
	[TV_QuerySql] [nvarchar](max) NULL,
	[TV_QueryConnectionKey] [nvarchar](50) NULL,
	[TVQ_IDOld] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeViews2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeViews2003](
	[TView_ID] [int] NOT NULL,
	[TView_SQLFrom] [nvarchar](max) NOT NULL,
	[TView_SQLWhere] [nvarchar](max) NULL,
	[TView_SQLOrderBy] [nvarchar](max) NULL,
	[TView_SQLGroupBy] [nvarchar](max) NULL,
	[TVIew_SQLHaving] [nvarchar](max) NULL,
	[TView_Description] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeViews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeViews](
	[TView_ID] [int] NOT NULL,
	[TView_SQLFrom] [nvarchar](max) NOT NULL,
	[TView_SQLWhere] [nvarchar](max) NULL,
	[TView_SQLOrderBy] [nvarchar](max) NULL,
	[TView_SQLGroupBy] [nvarchar](max) NULL,
	[TVIew_SQLHaving] [nvarchar](max) NULL,
	[TView_Description] [nvarchar](50) NULL,
	[TView_IDOld] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeTypes](
	[TreeType_ID] [int] NOT NULL,
	[TreeType_Description] [nvarchar](150) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeTypeGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeTypeGroups](
	[TTGroup_ID] [int] NOT NULL,
	[TreeType_ID] [int] NOT NULL,
	[TTGroup_Description] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeSettings2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeSettings2003](
	[TreeSet_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Tree_ID] [int] NOT NULL,
	[TreeSet_NodeCount] [int] NOT NULL,
	[TreeSet_ExpandedNodes] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreeSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreeSettings](
	[TreeSet_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Tree_ID] [int] NULL,
	[TreeSet_NodeCount] [int] NOT NULL,
	[TreeSet_ExpandedNodes] [nvarchar](max) NULL,
	[TreeSet_IDOld] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trees2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Trees2003](
	[Tree_ID] [int] NOT NULL,
	[TreeType_ID] [int] NOT NULL,
	[Tree_Remarks] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Trees](
	[Tree_ID] [int] NOT NULL,
	[TreeType_ID] [int] NOT NULL,
	[Tree_Description] [nvarchar](15) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TemplateTreeLinks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TemplateTreeLinks](
	[TREE ID] [nvarchar](50) NULL,
	[Node_ID1] [int] NULL,
	[Node_ID2] [int] NULL,
	[TreeLink_ID] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintDocTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PrintDocTypes](
	[PrintDoc_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[PrintDoc_Declaration] [nvarchar](100) NULL,
	[PrintDoc_DV1] [nvarchar](100) NULL,
	[PrintDoc_NCTS] [nvarchar](100) NULL,
	[PrintDoc_PrePrintedForm] [nvarchar](100) NULL,
	[PrintDoc_Repertory] [nvarchar](100) NULL,
	[PrintDoc_SummaryReports] [nvarchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBacklogTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PrintBacklogTable](
	[PrintBacklogTable_ID] [int] NOT NULL,
	[PrintBacklogTable_CommandLine] [nvarchar](max) NULL,
	[PrintBacklogTable_LastPrintCommandDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermDeletedArchivedDocs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PermDeletedArchivedDocs](
	[User_ID] [int] NULL,
	[PermDeletedArchivedDocs_DType] [int] NULL,
	[PermDeletedArchivedDocs_ItemCount] [int] NULL,
	[PermDeletedArchivedDocs_ArchivedStartDate] [datetime] NULL,
	[PermDeletedArchivedDocs_ArchivedEndDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nodes2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Nodes2003](
	[Node_ID] [int] NOT NULL,
	[Node_RecordsKey] [int] NOT NULL,
	[Node_Level] [int] NOT NULL,
	[Node_Text] [nvarchar](100) NOT NULL,
	[Node_ParentID] [int] NOT NULL,
	[Node_Image] [nvarchar](50) NOT NULL,
	[Node_SelectedImage] [nvarchar](50) NOT NULL,
	[Node_Default] [bit] NOT NULL CONSTRAINT [DF_NODES2003_DEFAULT]  DEFAULT ((0)),
	[Tree_ID] [int] NOT NULL,
	[TView_ID] [int] NOT NULL,
	[Node_Remarks] [nvarchar](50) NULL,
	[TVQ_ID] [nvarchar](10) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Nodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Nodes](
	[Node_ID] [int] NOT NULL,
	[Node_RecordsKey] [int] NULL,
	[Node_Level] [int] NULL,
	[Node_Text] [nvarchar](100) NULL,
	[Node_ParentID] [int] NULL,
	[Node_Image] [nvarchar](50) NULL,
	[Node_SelectedImage] [nvarchar](50) NULL,
	[Node_Default] [bit] NOT NULL CONSTRAINT [DF_NODES_DEFAULT]  DEFAULT ((0)),
	[Tree_ID] [int] NULL,
	[TView_ID] [int] NULL,
	[Node_SelectedView] [int] NULL,
	[Node_Remarks] [nvarchar](50) NULL,
	[TVQ_ID] [nvarchar](10) NULL,
	[Feature_ID] [int] NULL,
	[Node_IDOld] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MainSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MainSettings](
	[Setting_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Setting_Navigation] [bit] NOT NULL CONSTRAINT [DF_MAIN_SETTINGS_NAVIGATION]  DEFAULT ((0)),
	[Setting_FindBox] [bit] NOT NULL CONSTRAINT [DF_MAIN_SETTINGS_FINDBOX]  DEFAULT ((0)),
	[Setting_StatusBar] [bit] NOT NULL CONSTRAINT [DF_MAIN_SETTINGS_STATUSBAR]  DEFAULT ((0)),
	[Setting_ReadingPanePos] [int] NULL,
	[Setting_NavigationWidth] [float] NULL,
	[Setting_GridWidth] [float] NULL,
	[Setting_GridHeight] [float] NULL,
	[Setting_ExpandedButtons] [int] NULL,
	[Tree_ID] [int] NULL,
	[Setting_FindBoxType] [int] NULL,
	[Setting_ViewOptions] [bit] NOT NULL CONSTRAINT [DF_MAIN_SETTINGS_VIEWOPTIONS]  DEFAULT ((0)),
	[Setting_CommandBar] [nvarchar](max) NULL,
	[Setting_CommandBarVersion] [float] NULL,
	[Setting_CustomFind] [bit] NOT NULL CONSTRAINT [DF_MAIN_SETTINGS_CUSTOMFIND]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkedTables]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkedTables](
	[Table_ID] [int] NOT NULL,
	[Table_NewName] [nvarchar](50) NULL,
	[Table_SourceName] [nvarchar](50) NULL,
	[DB_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Licensee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Licensee](
	[Lic_ID] [int] NOT NULL,
	[Lic_Name] [nvarchar](50) NULL,
	[Lic_Address] [nvarchar](150) NULL,
	[Lic_City] [nvarchar](50) NULL,
	[Lic_PostalCode] [nvarchar](25) NULL,
	[Lic_Country] [nvarchar](25) NULL,
	[Lic_Phone] [nvarchar](25) NULL,
	[Lic_Fax] [nvarchar](25) NULL,
	[Lic_Email] [nvarchar](75) NULL,
	[Lic_LegalInfo] [nvarchar](max) NULL,
	[Lic_Currency] [nvarchar](50) NULL,
	[Lic_Database] [nvarchar](50) NULL,
	[Lic_UseEXACTID] [bit] NOT NULL CONSTRAINT [DF_LICENSEE_USE_EXACTID]  DEFAULT ((0)),
	[Lic_Language] [nvarchar](15) NULL,
	[Lic_Logo] [image] NULL,
	[Lic_Logosize] [nvarchar](100) NULL,
	[Lic_LogoProperties] [nvarchar](255) NULL,
	[Lic_Website] [nvarchar](255) NULL,
	[Lic_Key] [nvarchar](50) NULL,
	[Lic_User] [nvarchar](50) NULL,
	[Lic_SerialNumber] [nvarchar](50) NULL,
	[Lic_DutchURL] [nvarchar](255) NULL,
	[Lic_FrenchURL] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupNodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GroupNodes](
	[GNode_ID] [int] NOT NULL,
	[GNode_RecordsKey] [int] NOT NULL,
	[GNode_Level] [int] NOT NULL,
	[GNode_Text] [nvarchar](100) NOT NULL,
	[GNode_ParentID] [int] NOT NULL,
	[GNode_Image] [nvarchar](50) NOT NULL,
	[GNode_SelectedImage] [nvarchar](50) NOT NULL,
	[GNode_Default] [bit] NOT NULL CONSTRAINT [DF_GROUPNODES_DEFAULT]  DEFAULT ((0)),
	[TTGroup_ID] [int] NOT NULL,
	[TView_ID] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FindViewColumns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FindViewColumns](
	[FVC_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[FVC_ColumnAlignments] [nvarchar](max) NULL,
	[FVC_ColumnWidths] [nvarchar](max) NULL,
	[FVC_GroupHeaders] [nvarchar](max) NULL,
	[FVC_Sort] [nvarchar](50) NULL,
	[FVC_CardsView] [bit] NOT NULL CONSTRAINT [DF_FIND_VIEWCOLUMNS_CARDSVIEW]  DEFAULT ((0)),
	[FVC_ColumnFormat] [nvarchar](max) NULL,
	[FVC_DocumentType] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Filter](
	[Filter_ID] [int] NOT NULL,
	[UVC_ID] [int] NULL,
	[Filter_Field] [nvarchar](50) NULL,
	[Filter_Operator] [int] NULL,
	[Filter_Value] [nvarchar](50) NULL,
	[Filter_Type] [int] NULL,
	[Filter_DataType] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Features]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Features](
	[Feature_ID] [int] NOT NULL,
	[Feature_Code] [int] NULL,
	[Feature_Name] [nvarchar](50) NULL,
	[Feature_Activated] [bit] NOT NULL CONSTRAINT [DF_FEATURES_ACTIVATED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Developer Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Developer Settings](
	[ForDevelopment] [bit] NOT NULL CONSTRAINT [DF_DEVELOPER_SETTINGS_FORDEV]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DELETEITEM LOG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DELETEITEM LOG](
	[CODE] [nvarchar](50) NULL,
	[LRN] [nvarchar](50) NULL,
	[MRN] [nvarchar](50) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[DATE DELETED] [datetime] NULL,
	[ORIGINAL TREE ID] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultViewColumns2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DefaultViewColumns2003](
	[DVC_ID] [int] NOT NULL,
	[TView_ID] [int] NOT NULL,
	[DVC_FieldSource] [nvarchar](50) NOT NULL,
	[DVC_FieldAlias] [nvarchar](50) NOT NULL,
	[DVC_Position] [int] NOT NULL,
	[DVC_Default] [bit] NOT NULL CONSTRAINT [DF_DEFAULTVIEWCOLUMNS2003_DEFAULT]  DEFAULT ((0)),
	[DVC_Alignment] [nvarchar](50) NULL,
	[DVC_Width] [float] NULL,
	[DVC_Requirement] [int] NULL,
	[DVC_GroupHeaderLevel] [int] NULL,
	[DVC_DataType] [nvarchar](50) NULL,
	[DVC_FCIDs] [nvarchar](max) NULL,
	[DVC_Format] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DefaultViewColumns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DefaultViewColumns](
	[DVC_ID] [int] NOT NULL,
	[TView_ID] [int] NULL,
	[DVC_FieldSource] [nvarchar](255) NULL,
	[DVC_FieldAlias] [nvarchar](50) NULL,
	[DVC_Position] [int] NULL,
	[DVC_Default] [bit] NOT NULL CONSTRAINT [DF_DEFAULTVIEWCOLUMNS_DEFAULT]  DEFAULT ((0)),
	[DVC_Alignment] [nvarchar](50) NULL,
	[DVC_Width] [float] NULL,
	[DVC_Requirement] [int] NULL,
	[DVC_GroupHeaderLevel] [int] NULL,
	[DVC_DataType] [nvarchar](50) NULL,
	[DVC_FCIDs] [nvarchar](max) NULL,
	[DVC_Format] [nvarchar](max) NULL,
	[DVC_IDOld] [int] NULL,
	[DVC_HeaderIcon] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBUpgradeTracker]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBUpgradeTracker](
	[DBUpgradeTrack_ID] [int] NOT NULL,
	[DBUpgradeTrack_Name] [nvarchar](50) NULL,
	[DBUpgradeTrack_Version] [nvarchar](20) NULL,
	[DBUpgradeTrack_Date] [datetime] NULL,
	[DBUpgradeTrack_PerformUpdates_Completed] [bit] NOT NULL CONSTRAINT [DF_DBUPGRADETRACKER_PERFORMUPDATES_COMPLETED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DBProps]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DBProps](
	[DBProps_Version] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
	[DBProps_DBEmpty] [bit] NOT NULL CONSTRAINT [DF_DBPROPERTIES_EMPTY]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Databases]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Databases](
	[DB_ID] [int] NOT NULL,
	[DB_Name] [nvarchar](50) NULL,
	[DB_Location] [nvarchar](max) NULL,
	[DB_Password] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CPUpgradeTracker]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CPUpgradeTracker](
	[CPUpgradeTrack_ID] [int] NOT NULL,
	[CPUpgradeTrack_Version] [nvarchar](20) NULL,
	[CPUpgradeTrack_Date] [datetime] NULL,
	[CPUpgradeTrack_Exe_Date] [datetime] NULL,
	[CPUpgradeTrack_PerformUpdates_Completed] [bit] NOT NULL CONSTRAINT [DF_CPUPGRADETRACKER_PERFORMUPDATES_COMPLETED]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonTreeSettings2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ButtonTreeSettings2003](
	[BTS_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Button_ID] [int] NOT NULL,
	[BTS_TopNode] [int] NOT NULL,
	[BTS_SelectedNode] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonTreeSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ButtonTreeSettings](
	[BTS_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Button_ID] [int] NOT NULL,
	[BTS_TopNode] [int] NOT NULL,
	[BTS_SelectedNode] [int] NOT NULL,
	[Button_IDOld] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buttons2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buttons2003](
	[Button_ID] [int] NOT NULL,
	[BGroup_ID] [int] NOT NULL,
	[Button_Caption] [nvarchar](50) NOT NULL,
	[Tree_ID] [int] NOT NULL,
	[Button_IconName] [nvarchar](25) NOT NULL,
	[Button_Default] [bit] NOT NULL CONSTRAINT [DF_BUTTONS2003_DEFAULT]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buttons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buttons](
	[Button_ID] [int] NOT NULL,
	[BGroup_ID] [int] NULL,
	[Button_Caption] [nvarchar](255) NULL,
	[Tree_ID] [int] NULL,
	[Button_IconName] [nvarchar](25) NULL,
	[Button_Default] [bit] NOT NULL CONSTRAINT [DF_BUTTONS_DEFAULT]  DEFAULT ((0)),
	[Node_ID] [int] NULL,
	[Button_IDOld] [int] NULL,
	[Button_Deleted] [bit] NOT NULL CONSTRAINT [DF_BUTTONS_DELETED]  DEFAULT ((0)),
	[Button_Order] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonGroups2003]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ButtonGroups2003](
	[BGroup_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[BGroup_Caption] [nvarchar](50) NOT NULL,
	[Button_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ButtonGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ButtonGroups](
	[BGroup_ID] [int] NOT NULL,
	[User_ID] [int] NULL,
	[Tree_ID] [int] NULL,
	[BGroup_SelectedNodeID] [int] NULL,
	[BGroup_Caption] [nvarchar](50) NULL,
	[BGroup_TopNode] [int] NULL,
	[BGroup_Default] [bit] NOT NULL CONSTRAINT [DF_BUTTONGROUPS_DEFAULT]  DEFAULT ((0)),
	[Feature_ID] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Allow_Move]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Allow_Move](
	[Allow_ID] [int] NOT NULL,
	[Allow_From] [nvarchar](50) NULL,
	[Allow_From_Tag] [nvarchar](50) NULL,
	[Allow_To] [nvarchar](50) NULL,
	[Allow_To_Tag] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
