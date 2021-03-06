﻿Imports ADODB
Imports Microsoft.Win32
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CubeLibDataSource.CDatabaseProperty
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data.Sql
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System.Windows.Forms.AxHost

<ComClass(CDatasource.ClassId, CDatasource.InterfaceId, CDatasource.EventsId)> _
Public Class CDatasource
    Implements IDisposable

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "ce387449-a01d-434d-b31c-317e9b9accf9"
    Public Const InterfaceId As String = "08039bc1-af54-4883-8380-b52716522cb6"
    Public Const EventsId As String = "c9fb94be-f812-4f9e-bfdf-e3710ad9ecc6"
#End Region
    Private WithEvents m_objBackgroundWorker As New BackgroundWorker

    Private managedResource As New System.ComponentModel.Component
    Private unmanagedResource As IntPtr
    Protected disposed As Boolean = False

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
        g_objDBConnections = New Collection

        'm_objBackgroundWorker.WorkerReportsProgress = False
        'm_objBackgroundWorker.WorkerSupportsCancellation = True

        'AddHandler m_objBackgroundWorker.DoWork, AddressOf m_objBackgroundWorker_DoWork
        'AddHandler m_objBackgroundWorker.RunWorkerCompleted, AddressOf m_objBackgroundWorker_RunWorkerCompleted
    End Sub

    Protected Overridable Overloads Sub Dispose( _
            ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                managedResource.Dispose()
            End If
            ' Add code here to release the unmanaged resource.
            unmanagedResource = IntPtr.Zero
            ' Note that this is not thread safe. 
        End If
        Me.disposed = True
    End Sub

    Public Enum DBInstanceType
        DATABASE_SADBEL
        DATABASE_DATA
        DATABASE_EDIFACT
        DATABASE_SCHEDULER
        DATABASE_TEMPLATE
        DATABASE_TARIC
        DATABASE_HISTORY
        DATABASE_REPERTORY
        DATABASE_EDI_HISTORY
        DATABASE_OTHER
    End Enum

    Public Enum SadbelTableType
        AUTHORIZEDPARTIES
        BOX_DEFAULT_COMBINED_NCTS_ADMIN
        BOX_DEFAULT_EDI_NCTS_ADMIN
        BOX_DEFAULT_EDI_NCTS_IE141_ADMIN
        BOX_DEFAULT_EDI_NCTS_IE44_ADMIN
        BOX_DEFAULT_EDI_NCTS2_ADMIN
        BOX_DEFAULT_COMBINED_ADMIN
        BOX_DEFAULT_IMPORT_ADMIN
        BOX_DEFAULT_EXPORT_ADMIN
        BOX_DEFAULT_PLDA_COMBINED_ADMIN
        BOX_DEFAULT_PLDA_COMBINED_CHILDREN_ADMIN
        BOX_DEFAULT_PLDA_IMPORT_ADMIN
        BOX_DEFAULT_PLDA_IMPORT_CHILDREN_ADMIN
        BOX_DEFAULT_TRANSIT_ADMIN
        BOX_DEFAULT_TRANSIT_NCTS_ADMIN
        BOX_DEFAULT_VALUE_COMBINED_NCTS
        BOX_DEFAULT_VALUE_EDI_NCTS
        BOX_DEFAULT_VALUE_EDI_NCTS_IE44
        BOX_DEFAULT_VALUE_EDI_NCTS2
        BOX_DEFAULT_VALUE_EXPORT
        BOX_DEFAULT_VALUE_IMPORT
        BOX_DEFAULT_VALUE_PLDA_COMBINED
        BOX_DEFAULT_VALUE_PLDA_IMPORT
        BOX_DEFAULT_VALUE_TRANSIT
        BOX_DEFAULT_VALUE_TRANSIT_NCTS
        BRANCHES
        COLUMNS
        COMBINED_NCTS
        COMBINED_NCTS_DETAIL
        COMBINED_NCTS_DETAIL_BIJZONDERE
        COMBINED_NCTS_DETAIL_COLLI
        COMBINED_NCTS_DETAIL_CONTAINER
        COMBINED_NCTS_DETAIL_DOCUMENTEN
        COMBINED_NCTS_DETAIL_GEVOELIGE
        COMBINED_NCTS_DETAIL_GOEDEREN
        COMBINED_NCTS_HEADER
        COMBINED_NCTS_HEADER_ZEKERHEID
        CONSIGN_CTRY
        CONSIGNEE
        CONSIGNOR
        CONSIGNOR_CONSIGNEE
        COUNTRIES
        DBPROPERTIES
        DEFAULT_COLUMNS
        DEFAULT_USER_COMBINED_NCTS
        DEFAULT_USER_EDI_NCTS
        DEFAULT_USER_EDI_NCTS_IE44
        DEFAULT_USER_EDI_NCTS2
        DEFAULT_USER_EXPORT
        DEFAULT_USER_IMPORT
        DEFAULT_USER_PLDA_COMBINED
        DEFAULT_USER_PLDA_IMPORT
        DEFAULT_USER_TRANSIT
        DEFAULT_USER_TRANSIT_NCTS
        DIGISIGN_PLDA_COMBINED
        DIGISIGN_PLDA_IMPORT
        ENTREPOT_PROPERTIES
        ENTREPOTS
        ERROR_DUTCH
        ERROR_ENGLISH
        ERROR_FRENCH
        EUR1_PROPERTIES
        EXPORT
        EXPORT_DETAIL
        EXPORT_HEADER
        FIELD_GROUPING
        GROUPS
        GUARANTEE
        IMPORT
        IMPORT_DETAIL
        IMPORT_HEADER
        INBOUND_DOCS
        INBOUNDS
        LICENSEE
        LOGICAL_ID
        LRN
        MAIL_BOX
        MAIL_GROUPS
        MAIL_RECIPIENTS
        MAIL_SETTINGS
        NCTS
        NCTS_DETAIL
        NCTS_DETAIL_BIJZONDERE
        NCTS_DETAIL_COLLI
        NCTS_DETAIL_CONTAINER
        NCTS_DETAIL_DOCUMENTEN
        NCTS_HEADER
        NCTS_HEADER_ZEKERHEID
        OPERATORS
        ORPHANED_MESSAGES
        OUTBOUND_DOCS
        OUTBOUNDS
        PDF_OUT_SETTINGS
        PIKCLIST_DEFINITION
        PIKCLIST_MAINTENANCE_DUTCH
        PIKCLIST_MAINTENANCE_ENGLISH
        PIKCLIST_MAINTENANCE_FRENCH
        PLDA_COMBINED
        PLDA_COMBINED_DETAIL
        PLDA_COMBINED_DETAIL_BIJZONDERE
        PLDA_COMBINED_DETAIL_CONTAINER
        PLDA_COMBINED_DETAIL_DOCUMENTEN
        PLDA_COMBINED_DETAIL_HANDELAARS
        PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
        PLDA_COMBINED_HEADER
        PLDA_COMBINED_HEADER_HANDELAARS
        PLDA_COMBINED_HEADER_TRANSIT_OFFICES
        PLDA_COMBINED_HEADER_ZEGELS
        PLDA_COMBINED_HEADER_ZEKERHEID
        PLDA_ERROR_CODE
        PLDA_IMPORT
        PLDA_IMPORT_DETAIL
        PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
        PLDA_IMPORT_DETAIL_BIJZONDERE
        PLDA_IMPORT_DETAIL_CONTAINER
        PLDA_IMPORT_DETAIL_DOCUMENTEN
        PLDA_IMPORT_DETAIL_HANDELAARS
        PLDA_IMPORT_DETAIL_ZELF
        PLDA_IMPORT_HEADER
        PLDA_IMPORT_HEADER_HANDELAARS
        PLDA_IMPORT_HEADER_ZEGELS
        PLDA_LRN
        PLDA_MESSAGES
        PRINTDOCTYPES
        PRODUCTS
        QUEUE_PROPERTIES
        REMARKS
        REMOTE_PRINTERS
        REMOTE_DOCTYPE
        REPRESENTATIVE
        SAD_PLDA_VALUE_LIST
        SETUP
        SHEET_PROPERTIES
        SKIP
        STOCK_CARDS
        SYSLINK_COMPATIBILITY
        SYSLINK_PROPERTIES
        TAB_ORDER
        TRANSIT
        TRANSIT_DETAIL
        TRANSIT_HEADER
        TREE
        USER_LOGICAL_ID
        USER_PRINTERS
        VALIDATION_RULES
    End Enum

    Public Enum EdifactTableType
        BOX_SEARCH_MAP
        DATA_NCTS
        DATA_NCTS_BERICHT
        DATA_NCTS_BERICHT_DOUANEKANTOOR
        DATA_NCTS_BERICHT_HANDELAAR
        DATA_NCTS_BERICHT_HOOFDING
        DATA_NCTS_BERICHT_VERVOER
        DATA_NCTS_BERICHT_VERVOER_CONTROLE
        DATA_NCTS_BERICHT_VERVOER_INCIDENT
        DATA_NCTS_BERICHT_VERVOER_OVERLADING
        DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
        DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
        DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
        DATA_NCTS_BGM
        DATA_NCTS_CNT
        DATA_NCTS_CST
        DATA_NCTS_DETAIL
        DATA_NCTS_DETAIL_BIJZONDERE
        DATA_NCTS_DETAIL_COLLI
        DATA_NCTS_DETAIL_CONTAINER
        DATA_NCTS_DETAIL_DOCUMENTEN
        DATA_NCTS_DETAIL_RESULTATEN
        DATA_NCTS_DOC
        DATA_NCTS_DTM
        DATA_NCTS_FTX
        DATA_NCTS_GIR
        DATA_NCTS_GIS
        DATA_NCTS_HEADER
        DATA_NCTS_HEADER_RESULTATEN
        DATA_NCTS_HEADER_ZEKERHEID
        DATA_NCTS_LOC
        DATA_NCTS_MEA
        DATA_NCTS_MESSAGES
        DATA_NCTS_NAD
        DATA_NCTS_PAC
        DATA_NCTS_PCI
        DATA_NCTS_RFF
        DATA_NCTS_SEL
        DATA_NCTS_TDT
        DATA_NCTS_TOD
        DATA_NCTS_TPL
        DATA_NCTS_UNB
        DATA_NCTS_UNH
        DATA_NCTS_UNS
        DATA_NCTS_UNT
        DATA_NCTS_UNZ
        DBProperties
        EDI_TMS
        EDI_TMS_CORE
        EDI_TMS_GROUPS
        EDI_TMS_ITEMS
        EDI_TMS_SEGMENTS
        NCTS_DEPARTURE_FOLLOW_UP_REQUEST
        NCTS_IEM
        NCTS_IEM_MAP
        NCTS_IEM_MAP_CONDITIONS
        NCTS_IEM_TMS
        NCTS_ITM_BGM
        NCTS_ITM_CNT
        NCTS_ITM_CST
        NCTS_ITM_DOC
        NCTS_ITM_DTM
        NCTS_ITM_FTX
        NCTS_ITM_GIR
        NCTS_ITM_GIS
        NCTS_ITM_LOC
        NCTS_ITM_MEA
        NCTS_ITM_NAD
        NCTS_ITM_PAC
        NCTS_ITM_PCI
        NCTS_ITM_RFF
        NCTS_ITM_SEL
        NCTS_ITM_TDT
        NCTS_ITM_TOD
        NCTS_ITM_TPL
        NCTS_ITM_UNB
        NCTS_ITM_UNH
        NCTS_ITM_UNS
        NCTS_ITM_UNT
        NCTS_ITM_UNZ
        OUTPUT_FILE_FIELDS
        OUTPUT_FILE_GROUPS
    End Enum

    Public Enum DataTableType
        DBProperties
        MASTER
        MASTEREDINCTS
        MASTEREDINCTS2
        MASTEREDINCTSIE44
        MASTERNCTS
        MASTERPLDA
        OUTBOX
        REMARKS
        TEMPLATETREELINKS
        TEMPLATETREELINKS2003
        USERDEFINEDTEMPLATES
    End Enum

    Public Enum EdiHistoryTableType
        BOX_SEARCH_MAP
        DATA_NCTS
        DATA_NCTS_BERICHT
        DATA_NCTS_BERICHT_DOUANEKANTOOR
        DATA_NCTS_BERICHT_HANDELAAR
        DATA_NCTS_BERICHT_HOOFDING
        DATA_NCTS_BERICHT_VERVOER
        DATA_NCTS_BERICHT_VERVOER_CONTROLE
        DATA_NCTS_BERICHT_VERVOER_INCIDENT
        DATA_NCTS_BERICHT_VERVOER_OVERLADING
        DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
        DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
        DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
        DATA_NCTS_BGM
        DATA_NCTS_CNT
        DATA_NCTS_CST
        DATA_NCTS_DETAIL
        DATA_NCTS_DETAIL_BIJZONDERE
        DATA_NCTS_DETAIL_COLLI
        DATA_NCTS_DETAIL_CONTAINER
        DATA_NCTS_DETAIL_DOCUMENTEN
        DATA_NCTS_DETAIL_RESULTATEN
        DATA_NCTS_DOC
        DATA_NCTS_DTM
        DATA_NCTS_FTX
        DATA_NCTS_GIR
        DATA_NCTS_GIS
        DATA_NCTS_HEADER
        DATA_NCTS_HEADER_RESULTATEN
        DATA_NCTS_HEADER_ZEKERHEID
        DATA_NCTS_LOC
        DATA_NCTS_MEA
        DATA_NCTS_MESSAGES
        DATA_NCTS_NAD
        DATA_NCTS_PAC
        DATA_NCTS_PCI
        DATA_NCTS_RFF
        DATA_NCTS_SEL
        DATA_NCTS_TDT
        DATA_NCTS_TOD
        DATA_NCTS_TPL
        DATA_NCTS_UNB
        DATA_NCTS_UNH
        DATA_NCTS_UNS
        DATA_NCTS_UNT
        DATA_NCTS_UNZ
        DBProperties
        EDI_TMS
        EDI_TMS_CORE
        EDI_TMS_GROUPS
        EDI_TMS_ITEMS
        EDI_TMS_SEGMENTS
        MASTEREDINCTS
        MASTEREDINCTS2
        MASTEREDINCTSIE44
        NCTS_IEM
        NCTS_IEM_MAP
        NCTS_IEM_MAP_CONDITIONS
        NCTS_IEM_TMS
        NCTS_ITM_BGM
        NCTS_ITM_CNT
        NCTS_ITM_CST
        NCTS_ITM_DOC
        NCTS_ITM_DTM
        NCTS_ITM_FTX
        NCTS_ITM_GIR
        NCTS_ITM_GIS
        NCTS_ITM_LOC
        NCTS_ITM_MEA
        NCTS_ITM_NAD
        NCTS_ITM_PAC
        NCTS_ITM_PCI
        NCTS_ITM_RFF
        NCTS_ITM_SEL
        NCTS_ITM_TDT
        NCTS_ITM_TOD
        NCTS_ITM_TPL
        NCTS_ITM_UNB
        NCTS_ITM_UNH
        NCTS_ITM_UNS
        NCTS_ITM_UNT
        NCTS_ITM_UNZ
        OUTPUT_FILE_FIELDS
        OUTPUT_FILE_GROUPS
    End Enum

    Public Enum SadbelHistoryTableType
        COMBINED_NCTS
        COMBINED_NCTS_DETAIL
        COMBINED_NCTS_DETAIL_BIJZONDERE
        COMBINED_NCTS_DETAIL_COLLI
        COMBINED_NCTS_DETAIL_CONTAINER
        COMBINED_NCTS_DETAIL_DOCUMENTEN
        COMBINED_NCTS_DETAIL_GEVOELIGE
        COMBINED_NCTS_DETAIL_GOEDEREN
        COMBINED_NCTS_HEADER
        COMBINED_NCTS_HEADER_ZEKERHEID
        DBProperties
        EXPORT
        EXPORT_DETAIL
        EXPORT_HEADER
        IMPORT
        IMPORT_DETAIL
        IMPORT_HEADER
        InBoundDocs
        Inbounds
        MASTER
        MASTERNCTS
        MASTERPLDA
        NCTS
        NCTS_DETAIL
        NCTS_DETAIL_BIJZONDERE
        NCTS_DETAIL_COLLI
        NCTS_DETAIL_CONTAINER
        NCTS_DETAIL_DOCUMENTEN
        NCTS_HEADER
        NCTS_HEADER_ZEKERHEID
        OutboundDocs
        Outbounds
        PLDA_COMBINED
        PLDA_COMBINED_DETAIL
        PLDA_COMBINED_DETAIL_BIJZONDERE
        PLDA_COMBINED_DETAIL_CONTAINER
        PLDA_COMBINED_DETAIL_DOCUMENTEN
        PLDA_COMBINED_DETAIL_HANDELAARS
        PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
        PLDA_COMBINED_HEADER
        PLDA_COMBINED_HEADER_HANDELAARS
        PLDA_COMBINED_HEADER_TRANSIT_OFFICES
        PLDA_COMBINED_HEADER_ZEGELS
        PLDA_COMBINED_HEADER_ZEKERHEID
        PLDA_IMPORT
        PLDA_IMPORT_DETAIL
        PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
        PLDA_IMPORT_DETAIL_BIJZONDERE
        PLDA_IMPORT_DETAIL_CONTAINER
        PLDA_IMPORT_DETAIL_DOCUMENTEN
        PLDA_IMPORT_DETAIL_HANDELAARS
        PLDA_IMPORT_DETAIL_ZELF
        PLDA_IMPORT_HEADER
        PLDA_IMPORT_HEADER_HANDELAARS
        PLDA_IMPORT_HEADER_ZEGELS
        PLDA_MESSAGES
        REMARKS
        TRANSIT
        TRANSIT_DETAIL
        TRANSIT_HEADER
    End Enum

    Public Enum RepertoryTableType
        Code_Translation
        Columns
        DBProperties
        Export
        Fields
        Import
        PLDA_COMBINED
        PLDA_IMPORT
        Repertory_Properties
        Selection_Criteria
        Setup
        Transit
        Tree
    End Enum

    Public Enum SchedulerTableType
        Archiver_Properties
        DBProperties
        EDIProperties
        Error_Code_Maintenance
        Error_Reports_Pending
        LOGID_SCHEDULE
        MAINTENANCE_PROC_SETTINGS
        PLDA_Archiver_Properties
        PLDA_MESSAGES_QUEUE
        PLDAProperties
        PRINTBOXES
        PRINTDATA
        PRINTER_DEFINITION
        ReceivingCycles
        REMOTEFILE
        SEGMENT
        SENDITEMS
        SETUP
        TASK_SCHEDULE
    End Enum

    Public Enum TaricTableType
        CLIENTS
        CN
        COMMON
        DBProperties
        EXPORT
        IMPORT
        PROPERTIES
        SUPP_UNITS
    End Enum

    Public Enum TemplateCPTableType
        Allow_Move
        ButtonGroups
        ButtonGroups2003
        Buttons
        Buttons2003
        ButtonTreeSettings
        ButtonTreeSettings2003
        CPUpgradeTracker
        Databases
        DBProperties
        DBProps
        DBUpgradeTracker
        DefaultViewColumns
        DefaultViewColumns2003
        DELETEITEM_LOG
        Developer_Settings
        Features
        Filter
        FindViewColumns
        GroupNodes
        Licensee
        LinkedTables
        MainSettings
        Nodes
        Nodes2003
        PermDeletedArchivedDocs
        PrintBacklogTable
        PrintDocTypes
        TemplateTreeLinks
        Trees
        Trees2003
        TreeSettings
        TreeSettings2003
        TreeTypeGroups
        TreeTypes
        TreeViews
        TreeViews2003
        TVQueryDefs
        TVQueryDefs2003
        Users
        UserViewColumns
        UserViewColumns2003
        UVCFormatCondition
        UVCFormatCondition2003
        Views
        WindowSettings
    End Enum

    'Public Event GetSQLServerInstancesCompleted(ByRef SQLServerInstances() As String)

    Private m_arrSQLServerInstances() As String
    Private m_strPersitenceFilePath As String

    Public Function GetRepertoryDBYear(ByVal RepertoryDBName As String) As String

        GetRepertoryDBYear = GetRepertoryDBYear_F(RepertoryDBName)

    End Function

    Public Function GetEDIHistoryDBYear(ByVal EDIHistoryDBName As String) As String

        GetEDIHistoryDBYear = GetEDIHistoryDBYear_F(EDIHistoryDBName)

    End Function

    Public Function GetHistoryDBYear(ByVal HistoryDBName As String) As String

        GetHistoryDBYear = GetHistoryDBYear_F(HistoryDBName)

    End Function

    Public Sub UpdatePersistence(ByVal PersistenceProperty As PersistencePropertyType, _
                                 ByVal PersistencePropertyValue As String)

        If Not g_objDatabaseProperty Is Nothing Then

            g_objDatabaseProperty.SetPersistenceProperty(GetPersistencePropertyPath(PersistenceProperty), PersistencePropertyValue)

        End If

    End Sub

    Public Function OpenFile(ByVal PersistencePath As String, _
                             ByVal PersistenceFilename As String, _
                    Optional ByVal DBTypeDef As DatabaseType = CDatabaseProperty.DatabaseType.ACCESS2003, _
                    Optional ByVal DBServerNameDef As String = "", _
                    Optional ByVal DBServerIntegratedAuthenticationDef As String = "FALSE", _
                    Optional ByVal DBUserNameDef As String = "sa", _
                    Optional ByVal DBPasswordDef As String = "wack2", _
                    Optional ByVal DBPathDef As String = "", _
                    Optional ByVal DataPathDef As String = "") As String

        g_objDatabaseProperty = New CDatabaseProperty(PersistencePath, _
                                                      PersistenceFilename, _
                                                      DBTypeDef, _
                                                      DBServerNameDef, _
                                                      DBServerIntegratedAuthenticationDef, _
                                                      DBUserNameDef, _
                                                      DBPasswordDef, _
                                                      DBPathDef, _
                                                      DataPathDef)

        'RefreshSQLServerInstances()

        m_strPersitenceFilePath = PersistencePath

        Return PersistencePath

    End Function

    Public Function GetSQLServerInstances() As String()
        ' Retrieve the enumerator instance and then the data.
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim aiList As New List(Of String)

        Dim table As System.Data.DataTable = instance.GetDataSources()
        Dim strServerName As String
        Dim strInstanceName As String

        For Each row As DataRow In table.Rows
            strServerName = ""
            strInstanceName = ""

            For Each col As DataColumn In table.Columns

                If String.Equals("ServerName".ToUpper, col.ColumnName.ToUpper) Then
                    strServerName = row(col)
                End If

                If String.Equals("InstanceName".ToUpper, col.ColumnName.ToUpper) Then
                    strInstanceName = row(col)
                End If

                If strServerName.Length > 0 And _
                   strInstanceName.Length > 0 Then
                    Exit For
                End If
                'Console.WriteLine("{0} = {1}", col.ColumnName, row(col))
            Next

            aiList.Add(strServerName & "\" & strInstanceName)
        Next

        Return aiList.ToArray
    End Function


    'Public Function CanQuit() As Boolean
    '    Return Not (m_objBackgroundWorker.CancellationPending Or m_objBackgroundWorker.IsBusy)
    'End Function

    'Public Sub CancelWorker()

    '    If Not m_objBackgroundWorker.CancellationPending Then
    '        m_objBackgroundWorker.CancelAsync()
    '    End If

    'End Sub

    'Private Sub m_objBackgroundWorker_RunWorkerCompleted(ByVal sender As Object,
    '                                                     ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
    '                                                     Handles m_objBackgroundWorker.RunWorkerCompleted

    '    ' This event handler is called when the background thread finishes. 
    '    ' This method runs on the main thread. 

    '    RaiseEvent GetSQLServerInstancesCompleted(m_arrSQLServerInstances)

    '    m_objBackgroundWorker.Dispose()

    '    Debug.Assert(False)
    'End Sub

    'Public Sub CancelRefreshSQLServerInstances()
    '    m_objBackgroundWorker.CancelAsync()
    'End Sub

    'Public Sub RefreshSQLServerInstances()

    '    If Not m_objBackgroundWorker.IsBusy Then
    '        ' Start the asynchronous operation.
    '        m_objBackgroundWorker.RunWorkerAsync(Me)
    '    End If
    'End Sub

    'Private Sub AsynchRefreshSQLServerInstances(ByVal worker As System.ComponentModel.BackgroundWorker, _
    '                                      ByVal e As System.ComponentModel.DoWorkEventArgs)

    '    If IsServiceRunning_F("SQLBrowser") Then
    '        m_arrSQLServerInstances = GetSQLServerInstances()
    '    End If

    'End Sub

    Public Function Open(ByVal PersistencePath As String, _
                Optional ByVal DBTypeDef As DatabaseType = CDatabaseProperty.DatabaseType.ACCESS2003, _
                Optional ByVal DBServerNameDef As String = "", _
                Optional ByVal DBServerIntegratedAuthenticationDef As String = "FALSE", _
                Optional ByVal DBUserNameDef As String = "sa", _
                Optional ByVal DBPasswordDef As String = "wack2", _
                Optional ByVal DBPathDef As String = "", _
                Optional ByVal DataPathDef As String = "") As String

        g_objDatabaseProperty = New CDatabaseProperty(PersistencePath, _
                                                      , _
                                                      DBTypeDef, _
                                                      DBServerNameDef, _
                                                      DBServerIntegratedAuthenticationDef, _
                                                      DBUserNameDef, _
                                                      DBPasswordDef, _
                                                      DBPathDef, _
                                                      DataPathDef)

        'RefreshSQLServerInstances()

        m_strPersitenceFilePath = PersistencePath

        Return PersistencePath

    End Function

    'Private Sub m_objBackgroundWorker_DoWork(ByVal sender As Object,
    '                                         ByVal e As System.ComponentModel.DoWorkEventArgs) _
    '                                         Handles m_objBackgroundWorker.DoWork

    '    ' This event handler is where the actual work is done. 
    '    ' This method runs on the background thread. 

    '    ' Get the BackgroundWorker object that raised this event. 
    '    Dim worker As System.ComponentModel.BackgroundWorker
    '    worker = CType(sender, System.ComponentModel.BackgroundWorker)

    '    ' Get the Words object and call the main method. 
    '    Dim objDataSource As CDatasource = CType(e.Argument, CDatasource)
    '    objDataSource.AsynchRefreshSQLServerInstances(worker, e)

    'End Sub

    Public Sub RollbackTransaction(ByVal Database As DBInstanceType, _
                          Optional ByVal Year As String = "", _
                          Optional ByVal OtherDatabaseName As String = "", _
                          Optional ByVal UseDataShaping As Boolean = False)

        Dim conTemp As DbConnection

        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in RollbackTransaction - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, UseDataShaping)

        If g_objDBConnections.Contains(strDBName) Then

            'objTransaction = g_objDBConnections.Item(strDBName)

            g_objDBTransaction.Rollback()

            conTemp.Close()
            conTemp.Dispose()
            conTemp = Nothing

            g_objDBConnections.Remove(strDBName)

            g_objDBTransaction.Dispose()
            g_objDBTransaction = Nothing
        End If

    End Sub

    Public Sub CommitTransaction(ByVal Database As DBInstanceType, _
                        Optional ByVal Year As String = "", _
                        Optional ByVal OtherDatabaseName As String = "", _
                        Optional ByVal UseDataShaping As Boolean = False)

        Dim conTemp As DbConnection

        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in CommitTransaction - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, UseDataShaping)

        If g_objDBConnections.Contains(strDBName) Then
            'g_objDBTransaction = g_objDBConnections.Item(strDBName)

            g_objDBTransaction.Commit()
            conTemp.Close()
            conTemp.Dispose()
            conTemp = Nothing

            g_objDBConnections.Remove(strDBName)

            g_objDBTransaction.Dispose()
            g_objDBTransaction = Nothing
        End If

    End Sub

    Public Sub BeginTransaction(ByVal Database As DBInstanceType, _
                       Optional ByVal Year As String = "", _
                       Optional ByVal OtherDatabaseName As String = "", _
                       Optional ByVal UseDataShaping As Boolean = False)


        Dim conTemp As DbConnection

        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in BeginTransaction - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, UseDataShaping)

        If g_objDBConnections Is Nothing Then
            g_objDBConnections = New Collection
        End If

        If Not g_objDBConnections.Contains(strDBName) Then
            If g_objDBTransaction Is Nothing Then
                g_objDBTransaction = conTemp.BeginTransaction()

                'g_objDBConnections.Add(objTransaction, strDBName)
                g_objDBConnections.Add(conTemp, strDBName)
            End If
        End If
    End Sub

    ReadOnly Property DatabaseType() As CDatabaseProperty.DatabaseType
        Get
            Select Case g_objDatabaseProperty.getDatabaseType
                Case CDatabaseProperty.DatabaseType.ACCESS97,
                    CDatabaseProperty.DatabaseType.ACCESS2003,
                    CDatabaseProperty.DatabaseType.MYSQL,
                    CDatabaseProperty.DatabaseType.ORACLE,
                    CDatabaseProperty.DatabaseType.SQLSERVER

                    Return g_objDatabaseProperty.getDatabaseType

                Case Else
                    Return CDatabaseProperty.DatabaseType.ACCESS2003
            End Select
        End Get
    End Property

    ReadOnly Property SQLServerInstances() As String()
        Get
            Return m_arrSQLServerInstances
        End Get
    End Property

    ReadOnly Property IntegratedAuthentication() As Boolean
        Get
            If g_objDatabaseProperty.getServerIntegratedAuthentication.Trim().Length > 0 Then

                If String.Equals(g_objDatabaseProperty.getServerIntegratedAuthentication.Trim(), "TRUE", System.StringComparison.OrdinalIgnoreCase) Then

                    Return True

                ElseIf String.Equals(g_objDatabaseProperty.getServerIntegratedAuthentication.Trim(), "FALSE", System.StringComparison.OrdinalIgnoreCase) Then

                    Return False
                Else
                    Return False
                End If

            Else
                Return False
            End If

        End Get
    End Property

    ReadOnly Property ServerName() As String
        Get
            If g_objDatabaseProperty.getServerName.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getServerName.Trim()
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property PersistenceFilePath() As String
        Get
            Return m_strPersitenceFilePath
        End Get

    End Property

    ReadOnly Property Username() As String
        Get
            If g_objDatabaseProperty.getUserName.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getUserName.Trim()
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property DatabasePassword() As String
        Get
            If g_objDatabaseProperty.getPassword.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getPassword.Trim()
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property OutputFilePath() As String
        Get
            If g_objDatabaseProperty.getOutputFilePath.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getOutputFilePath.Trim()
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property DatabasePathFromPersistence() As String
        Get
            If g_objDatabaseProperty.getDatabasePathFromPersistence.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getDatabasePathFromPersistence.Trim()
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property DatabasePathFromRegistry() As String
        Get
            If g_objDatabaseProperty.getDatabasePathFromRegistry.Trim().Length > 0 Then
                Return g_objDatabaseProperty.getDatabasePathFromRegistry.Trim()
            Else
                Return ""
            End If
        End Get
    End Property


    ''' <summary>
    ''' DELETE, UPDATE and INSERT via SQL Script
    ''' </summary>
    Public Function ExecuteNonQueryOtherDB(ByVal SQL As String, _
                                           ByVal OtherDatabaseName As String) As Integer

        Dim conObjects() As Object
        Dim rowsAffected As Integer

        Try
            conObjects = getConnectionObjects(SQL, DBInstanceType.DATABASE_OTHER, False, False, "", OtherDatabaseName)

            rowsAffected = conObjects(1).ExecuteNonQuery()

            conObjects(1).Dispose()
            conObjects(1) = Nothing

            conObjects(0).Close()
            conObjects(0).Dispose()
            conObjects(0) = Nothing

        Catch ex As Exception
            Err.Raise(vbObjectError + 513, Me.GetType().Name, ex.Message)
            Return FAILURE
        End Try

        Return rowsAffected

    End Function

    Public Function GetDatabases(ByVal DBArchiveInstance As DBGeneralInstanceType) As String()

        Dim strFilter As String
        Dim strDatabase As String
        Dim strDatabases As String
        Dim obj As New List(Of String)

        'If g_objDatabaseProperty Is Nothing Then
        '    g_objDatabaseProperty = New CDatabaseProperty(
        'End If
        strDatabases = ""

        Select Case DBArchiveInstance
            Case DBGeneralInstanceType.DB_ARCHIVE_REPERTORY
                strFilter = "mdb_repertory_????.mdb"
                strFilter = "mdb_repertory_*.mdb"
            Case DBGeneralInstanceType.DB_ARCHIVE_HISTORY
                strFilter = "mdb_history??.mdb"
                'strFilter = "mdb_history*.mdb"
            Case DBGeneralInstanceType.DB_ARCHIVE_EDI_HISTORY
                strFilter = "mdb_edihistory??.mdb"
                strFilter = "mdb_edihistory*.mdb"
            Case Else
                strFilter = "*.mdb"
        End Select

        Select Case g_objDatabaseProperty.getDatabaseType

            Case CDatabaseProperty.DatabaseType.SQLSERVER


                Return GetArchiveDatabasesSQL_F(DBArchiveInstance)

            Case CDatabaseProperty.DatabaseType.ACCESS97, _
                 CDatabaseProperty.DatabaseType.ACCESS2003

                strDatabase = Dir(g_objDatabaseProperty.getDatabasePathFromPersistence.TrimEnd("\") + "\" + strFilter)

                Do
                    Select Case DBArchiveInstance
                        Case DBGeneralInstanceType.DB_ARCHIVE_REPERTORY

                            If IsRepertoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case DBGeneralInstanceType.DB_ARCHIVE_HISTORY

                            If IsHistoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case DBGeneralInstanceType.DB_ARCHIVE_EDI_HISTORY

                            If IsEDIHistoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case DBGeneralInstanceType.DB_CP_DATABASES

                            If IsCPDatabase_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case Else

                            If strDatabase.Trim(" ").Length > 0 Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                    End Select

                    strDatabase = Dir()

                    If strDatabase Is Nothing Then Exit Do

                Loop While strDatabase.Trim.Length > 0

                If strDatabases.Length > 0 Then
                    strDatabases = strDatabases.TrimEnd(DATABASES_DELIM)
                End If

                'Return strDatabases
                Return obj.ToArray

            Case Else

                'Return strDatabases
                Return obj.ToArray
        End Select



    End Function


    Public Function IsServiceRunning(ByVal ServiceName As String) As Boolean

        IsServiceRunning = IsServiceRunning_F(ServiceName)

    End Function

    Public Function GetDBInstanceTypeFromDBName(ByVal DatabaseName As String) As DBInstanceType

        Dim strDatabaseName As String = DatabaseName.Trim(" ").ToUpper

        If String.Equals(strDatabaseName.Substring(strDatabaseName.Length - 4), ".mdb".ToUpper) Then
            strDatabaseName = strDatabaseName.Substring(0, strDatabaseName.Length - 4)
        End If

        Select Case strDatabaseName

            Case "mdb_sadbel".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_SADBEL

            Case "mdb_data".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_DATA

            Case "edifact".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_EDIFACT

            Case "mdb_scheduler".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_SCHEDULER

            Case "TemplateCP".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_TEMPLATE

            Case "mdb_taric".ToUpper

                Return CDatasource.DBInstanceType.DATABASE_TARIC

            Case Else

                If IsRepertoryDB_F(strDatabaseName) Then

                    Return CDatasource.DBInstanceType.DATABASE_REPERTORY

                ElseIf IsHistoryDB_F(strDatabaseName) Then

                    Return CDatasource.DBInstanceType.DATABASE_HISTORY

                ElseIf IsEDIHistoryDB_F(strDatabaseName) Then

                    Return CDatasource.DBInstanceType.DATABASE_EDI_HISTORY

                Else
                    Return CDatasource.DBInstanceType.DATABASE_OTHER
                End If

        End Select

    End Function

    Public Function GetArchiveDatabases(ByVal DBArchiveInstance As DBGeneralInstanceType) As String()

        Dim strFilter As String
        Dim strDatabase As String
        Dim strDatabases As String
        Dim obj As New List(Of String)

        strDatabases = ""

        Select Case DBArchiveInstance
            Case DBGeneralInstanceType.DB_ARCHIVE_REPERTORY
                strFilter = "mdb_repertory_????.mdb"
                strFilter = "mdb_repertory_*.mdb"
            Case DBGeneralInstanceType.DB_ARCHIVE_HISTORY
                strFilter = "mdb_history??.mdb"
                'strFilter = "mdb_history*.mdb"
            Case DBGeneralInstanceType.DB_ARCHIVE_EDI_HISTORY
                strFilter = "mdb_edihistory??.mdb"
                strFilter = "mdb_edihistory*.mdb"
            Case Else

                Throw New ClearingPointException("Error in GetArchiveDatabases - Invalid DBGeneralInstanceType.")

                Return obj.ToArray
        End Select

        Select Case g_objDatabaseProperty.getDatabaseType

            Case CDatabaseProperty.DatabaseType.SQLSERVER


                Return GetArchiveDatabasesSQL_F(DBArchiveInstance)

            Case CDatabaseProperty.DatabaseType.ACCESS97, _
                 CDatabaseProperty.DatabaseType.ACCESS2003

                strDatabase = Dir(g_objDatabaseProperty.getDatabasePathFromPersistence.TrimEnd("\") + "\" + strFilter)

                Do
                    Select Case DBArchiveInstance
                        Case DBGeneralInstanceType.DB_ARCHIVE_REPERTORY

                            If IsRepertoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case DBGeneralInstanceType.DB_ARCHIVE_HISTORY

                            If IsHistoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case DBGeneralInstanceType.DB_ARCHIVE_EDI_HISTORY

                            If IsEDIHistoryDB_F(strDatabase) Then
                                strDatabases = strDatabases + strDatabase + DATABASES_DELIM
                                obj.Add(strDatabase)
                            End If

                        Case Else

                            Return obj.ToArray
                    End Select

                    strDatabase = Dir()

                    If strDatabase Is Nothing Then Exit Do

                Loop While strDatabase.Trim.Length > 0

                If strDatabases.Length > 0 Then
                    strDatabases = strDatabases.TrimEnd(DATABASES_DELIM)
                End If

                'Return strDatabases
                Return obj.ToArray

            Case Else

                'Return strDatabases
                Return obj.ToArray
        End Select



    End Function

    Public Function IsDatabaseExisting(ByVal DBInstanceType As CubeLibDataSource.CDatasource.DBInstanceType, _
                              Optional ByVal DatabaseYear As String = "", _
                              Optional ByVal OtherDatabaseName As String = "") As Boolean

        Dim strDatabaseName As String

        strDatabaseName = getDatabaseName(DBInstanceType, DatabaseYear, g_objDatabaseProperty.getDatabaseType, OtherDatabaseName)

        Select Case g_objDatabaseProperty.getDatabaseType

            Case CDatabaseProperty.DatabaseType.SQLSERVER

                Return CheckDatabaseExists_F(g_objDatabaseProperty.getServerName, strDatabaseName)

            Case CDatabaseProperty.DatabaseType.ACCESS97, _
                 CDatabaseProperty.DatabaseType.ACCESS2003

                Return File.Exists(g_objDatabaseProperty.getDatabasePathFromPersistence.TrimEnd("\") + "\" + strDatabaseName)

            Case Else
                Return False
        End Select

    End Function

    Public Function IsCPDatabase(ByVal DBName As String) As Boolean

        Return IsCPDatabase_F(DBName)

    End Function

    Public Function IsEDIHistoryDB(ByVal DBName As String) As Boolean

        Return IsEDIHistoryDB_F(DBName)

    End Function

    Public Function IsHistoryDB(ByVal DBName As String) As Boolean

        Return IsHistoryDB_F(DBName)

    End Function

    Public Function IsRepertoryDB(ByVal DBName As String) As Boolean

        Return IsRepertoryDB_F(DBName)

    End Function

    Public Function ExecuteAppendChunkFromFile(ByVal TableName As String, _
                                               ByVal FieldName As String, _
                                               ByVal PathFileName As String, _
                                               ByVal Database As DBInstanceType, _
                                      Optional ByVal Year As String = "", _
                                      Optional ByVal OtherDatabaseName As String = "") As Boolean

        Dim command As DbCommand
        Dim strDBName As String
        Dim conTemp As DbConnection
        Dim strCommand As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in ExecuteGetChunk - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, False)

        Try

            strCommand = "INSERT INTO " + TableName + " VALUES (@" + FieldName + ") "
            Select Case g_objDatabaseProperty.getDatabaseType()
                Case CDatabaseProperty.DatabaseType.ACCESS97,
                    CDatabaseProperty.DatabaseType.ACCESS2003

                    command = New OleDbCommand(strCommand, conTemp)

                Case CDatabaseProperty.DatabaseType.SQLSERVER
                    command = New SqlCommand(strCommand, conTemp)

                Case Else

                    Throw New ClearingPointException("Error in ExecuteGetChunk - Unknown Database Type.")
            End Select

            Dim ms As New MemoryStream()

            Image.FromFile(PathFileName).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)

            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@photo", SqlDbType.Image)
            p.Value = data
            command.Parameters.Add(p)
            command.ExecuteNonQuery()

        Catch ex As Exception
            Err.Raise(vbObjectError + 513, Me.GetType().Name, ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function ExecuteGetChunkToFile(ByVal SQLCommandGetChunk As String, _
                                          ByVal PathFileName As String, _
                                    ByVal Database As DBInstanceType, _
                            Optional ByVal Year As String = "", _
                            Optional ByVal OtherDatabaseName As String = "") As Boolean

        Dim command As DbCommand
        Dim strDBName As String
        Dim conTemp As DbConnection
        Dim imageData As Byte()

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in ExecuteGetChunk - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, False)

        Try

            Select Case g_objDatabaseProperty.getDatabaseType()
                Case CDatabaseProperty.DatabaseType.ACCESS97,
                    CDatabaseProperty.DatabaseType.ACCESS2003

                    command = New OleDbCommand(SQLCommandGetChunk, conTemp)

                Case CDatabaseProperty.DatabaseType.SQLSERVER
                    command = New SqlCommand(SQLCommandGetChunk, conTemp)

                Case Else

                    Throw New ClearingPointException("Error in ExecuteGetChunk - Unknown Database Type.")
            End Select

            imageData = DirectCast(command.ExecuteScalar(), Byte())

            If Not imageData Is Nothing Then
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)

                    Image.FromStream(ms, True).Save(PathFileName, System.Drawing.Imaging.ImageFormat.Bmp)
                End Using
            End If

        Catch ex As Exception
            Err.Raise(vbObjectError + 513, Me.GetType().Name, ex.Message)
            Return False
        End Try

        Return True

    End Function
    ''' <summary>
    ''' DELETE, UPDATE and INSERT via SQL Script
    ''' </summary>
    Public Function ExecuteNonQuery(ByVal SQL As String, _
                                    ByVal Database As DBInstanceType, _
                           Optional ByVal Year As String = "") As Integer

        Dim conObjects() As Object
        Dim rowsAffected As Integer

        Try
            conObjects = getConnectionObjects(SQL, Database, False, False, Year)

            rowsAffected = conObjects(1).ExecuteNonQuery()

            conObjects(1).Dispose()
            conObjects(1) = Nothing

            conObjects(0).Close()
            conObjects(0).Dispose()
            conObjects(0) = Nothing

        Catch ex As Exception
            Err.Raise(vbObjectError + 513, Me.GetType().Name, ex.Message)
            Return FAILURE
        End Try

        Return rowsAffected

    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_sadbel
    ''' </summary>
    Public Function UpdateSadbel(ByRef RecordsetToUpdate As ADODB.Recordset,
                                 ByVal TableName As SadbelTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for edifact
    ''' </summary>
    Public Function UpdateEdifact(ByRef RecordsetToUpdate As ADODB.Recordset,
                                  ByVal TableName As EdifactTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_data
    ''' </summary>
    Public Function UpdateData(ByRef RecordsetToUpdate As ADODB.Recordset,
                               ByVal TableName As DataTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_EDIHistoryXX
    ''' </summary>
    Public Function UpdateEdifactHistory(ByRef RecordsetToUpdate As ADODB.Recordset,
                                         ByVal TableName As EdifactTableType,
                                Optional ByVal Year As String = "") As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_historyXX
    ''' </summary>
    Public Function UpdateSadbelHistory(ByRef RecordsetToUpdate As ADODB.Recordset,
                                        ByVal TableName As SadbelHistoryTableType,
                               Optional ByVal Year As String = "") As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_RepertoryXXXX
    ''' </summary>
    Public Function UpdateRepertory(ByRef RecordsetToUpdate As ADODB.Recordset,
                                    ByVal TableName As RepertoryTableType,
                           Optional ByVal Year As String = "") As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function UpdateOtherDB(ByRef RecordsetToUpdate As ADODB.Recordset,
                                  ByVal TableName As String, _
                                  ByVal OtherDatabaseName As String) As Integer

        Return FindAndUpdateRowOther(RecordsetToUpdate, TableName, Me, OtherDatabaseName)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function UpdateTemplateCP(ByRef RecordsetToUpdate As ADODB.Recordset,
                                     ByVal TableName As TemplateCPTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for Scheduler
    ''' </summary>
    Public Function UpdateScheduler(ByRef RecordsetToUpdate As ADODB.Recordset,
                                    ByVal TableName As SchedulerTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for Taric
    ''' </summary>
    Public Function UpdateTaric(ByRef RecordsetToUpdate As ADODB.Recordset,
                                ByVal TableName As TaricTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_sadbel
    ''' </summary>
    Public Function InsertSadbel(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                 ByVal TableName As SadbelTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for edifact
    ''' </summary>
    Public Function InsertEdifact(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                  ByVal TableName As EdifactTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_data
    ''' </summary>
    Public Function InsertData(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                               ByVal TableName As DataTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for EdiHistoryXX
    ''' </summary>
    Public Function InsertEdifactHistory(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                         ByVal TableName As EdifactTableType,
                                Optional ByVal Year As String = "") As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_historyXX
    ''' </summary>
    Public Function InsertSadbelHistory(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                        ByVal TableName As SadbelHistoryTableType,
                               Optional ByVal Year As String = "") As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_repertoryXXXX
    ''' </summary>
    Public Function InsertRepertory(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                    ByVal TableName As RepertoryTableType,
                           Optional ByVal Year As String = "") As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function InsertOtherDB(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                  ByVal TableName As String, _
                                  ByVal OtherDatabaseName As String) As Integer

        Return InsertRowOther(ADORecordsetToInsert, TableName, Me, OtherDatabaseName)

    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function InsertTemplateCP(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                     ByVal TableName As TemplateCPTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for Scheduler
    ''' </summary>
    Public Function InsertScheduler(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                    ByVal TableName As SchedulerTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for Taric
    ''' </summary>
    Public Function InsertTaric(ByRef ADORecordsetToInsert As ADODB.Recordset, _
                                ByVal TableName As TaricTableType) As Integer

        Return InsertRow(ADORecordsetToInsert, TableName, Me)
    End Function

    ''' <summary>
    ''' SELECT query interface to VB.NET
    ''' </summary>
    ''' <returns>an ADODB.Recordset containing the queried record</returns>
    Public Function ExecuteQuery(ByVal SQL As String, _
                                 ByVal Database As DBInstanceType, _
                        Optional ByVal UseDataShaping As Boolean = False, _
                        Optional ByVal Year As String = "", _
                        Optional ByVal OtherDatabaseName As String = "") As Recordset

        Dim rstADO As New Recordset
        Dim conObjects() As Object

        'AddToTrace("Start of execute query: " + SQL, True)

        Try
            conObjects = getConnectionObjects(SQL, Database, UseDataShaping, True, Year, OtherDatabaseName)

            'If conObjects(2).Tables.Count > 0 AndAlso conObjects(2).Tables(0).Rows.Count > 0 Then
            If Not UseDataShaping Then
                If conObjects(2).Tables.Count > 0 Then
                    Dim fields As ADODB.Fields = rstADO.Fields
                    Dim columns As DataColumnCollection = conObjects(2).Tables(0).Columns

                    For Each column As DataColumn In columns
                        fields.Append(column.ColumnName, _
                                      TranslateType(column.DataType), _
                                      column.MaxLength, _
                                      IIf(column.AllowDBNull, FieldAttributeEnum.adFldIsNullable, FieldAttributeEnum.adFldUnspecified))
                    Next

                    rstADO.CursorLocation = CursorLocationEnum.adUseClient
                    rstADO.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0)

                    For Each row As DataRow In conObjects(2).Tables(0).Rows
                        rstADO.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)

                        For colIdx As Integer = 0 To columns.Count - 1
                            fields(colIdx).Value = row(colIdx)
                        Next

                        rstADO.Update()
                    Next

                End If
            Else
                If conObjects(2).Tables.Count > 0 Then
                    Dim parentFields As ADODB.Fields = rstADO.Fields
                    Dim rstADOChild As New ADODB.Recordset

                    For Each table As DataTable In conObjects(2).Tables
                        AddToTrace("Populating datashape recordset with table names as columns...")
                        If table.TableName <> "Table" Then
                            parentFields.Append(table.TableName.Replace("Table", vbNullString), DataTypeEnum.adVariant)
                        Else
                            parentFields.Append("MAIN", DataTypeEnum.adVariant)
                        End If
                    Next

                    rstADO.CursorLocation = CursorLocationEnum.adUseClient
                    rstADO.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0)
                    rstADO.AddNew()

                    For Each origTable As DataTable In conObjects(2).Tables
                        Dim strColumns() As String = EliminateLastColumn(origTable)
                        Dim table As DataTable = origTable.DefaultView.ToTable(True, strColumns)
                        Dim subTableName As String = table.TableName

                        Dim subT As DataColumn = table.Columns("DETAILTABLE")

                        If subTableName = "Table" Then subTableName = "MAIN"

                        subTableName = subTableName.Replace("Table", vbNullString)

                        AddToTrace("Populating datashape child tables with data, TABLENAME: " + subTableName)

                        rstADOChild = New Recordset

                        Dim childFields As ADODB.Fields = rstADOChild.Fields
                        Dim columns As DataColumnCollection = table.Columns

                        For Each column As DataColumn In columns
                            childFields.Append(column.ColumnName, _
                                          TranslateType(column.DataType), _
                                          column.MaxLength, _
                                          IIf(column.AllowDBNull, FieldAttributeEnum.adFldIsNullable, FieldAttributeEnum.adFldUnspecified))
                        Next

                        rstADOChild.CursorLocation = CursorLocationEnum.adUseClient
                        rstADOChild.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0)

                        For Each row As DataRow In table.Rows
                            'Debug.Print(table.TableName + " row count: " + table.Rows.Count)
                            rstADOChild.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)

                            Dim strRow As String = vbNullString
                            For colIdx As Integer = 0 To columns.Count - 1
                                childFields(colIdx).Value = row(colIdx)
                                strRow = strRow + columns(colIdx).ColumnName + ": " + Convert.ToString(row(colIdx)) + ", "
                            Next
                            strRow = strRow & vbCrLf
                            Debug.Print(strRow)
                        Next

                        If Not (rstADOChild.EOF And rstADOChild.BOF) Then rstADOChild.MoveFirst()
                        rstADO.Fields(subTableName).Value = rstADOChild
                        rstADO.Update()
                    Next
                End If
            End If

            conObjects(2).Dispose()
            conObjects(2) = Nothing

            conObjects(1).Dispose()
            conObjects(1) = Nothing

            conObjects(0).Close()
            conObjects(0).Dispose()
            conObjects(0) = Nothing

        Catch ex As Exception
            Err.Raise(vbObjectError + 514, Me.GetType().Name, ex.Message)
            Return rstADO
        End Try

        'AddToTrace("End of execute query: " & SQL, True)

        If Not (rstADO.EOF And rstADO.BOF) Then rstADO.MoveFirst()
        Return rstADO
    End Function

    Private Function EliminateLastColumn(ByVal dt As DataTable) As String()
        Dim strColumns(0) As String
        Dim idx As Integer = 0
        For Each scol As DataColumn In dt.Columns
            If scol.ColumnName <> dt.TableName Then
                ReDim Preserve strColumns(idx)
                strColumns(idx) = scol.ColumnName
                idx = idx + 1
            Else
                Debug.Assert(False)
            End If
        Next

        Return strColumns
    End Function

    Public Function GetEnumFromTableName(ByVal TableName As String, ByVal DBType As DBInstanceType) As Integer

        Select Case DBType
            Case DBInstanceType.DATABASE_DATA
                Dim tableEnum As DataTableType = [Enum].Parse(GetType(DataTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(DataTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_EDI_HISTORY
                Dim tableEnum As EdiHistoryTableType = [Enum].Parse(GetType(EdiHistoryTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(EdiHistoryTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_EDIFACT
                Dim tableEnum As EdifactTableType = [Enum].Parse(GetType(EdifactTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(EdifactTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_HISTORY
                Dim tableEnum As SadbelHistoryTableType = [Enum].Parse(GetType(SadbelHistoryTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(SadbelHistoryTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_REPERTORY
                Dim tableEnum As RepertoryTableType = [Enum].Parse(GetType(RepertoryTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(RepertoryTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_SADBEL
                Dim tableEnum As SadbelTableType = [Enum].Parse(GetType(SadbelTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(SadbelTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_SCHEDULER
                Dim tableEnum As SchedulerTableType = [Enum].Parse(GetType(SchedulerTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(SchedulerTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_TARIC
                Dim tableEnum As TaricTableType = [Enum].Parse(GetType(TaricTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(TaricTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case DBInstanceType.DATABASE_TEMPLATE
                Dim tableEnum As TemplateCPTableType = [Enum].Parse(GetType(TemplateCPTableType), TableName.Replace(" ", "_"), True)
                If [Enum].IsDefined(GetType(TemplateCPTableType), tableEnum) Then
                    Return Convert.ToInt32(tableEnum)
                End If
            Case Else
                AddToTrace("Error in GetEnumFromTableName(): Unsupported Database Type.")
        End Select

        Return 0
    End Function


#Region " IDisposable Support "
    ' Do not change or add Overridable to these methods. 
    ' Put cleanup code in Dispose(ByVal disposing As Boolean). 
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        m_objBackgroundWorker.Dispose()

        Dispose(False)
        MyBase.Finalize()


    End Sub
#End Region

End Class