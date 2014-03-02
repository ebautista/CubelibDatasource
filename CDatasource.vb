﻿Imports ADODB
Imports Microsoft.Win32
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CubelibDatasource.CDatabaseProperty
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

<ComClass(CDatasource.ClassId, CDatasource.InterfaceId, CDatasource.EventsId)> _
Public Class CDatasource

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "ce387449-a01d-434d-b31c-317e9b9accf9"
    Public Const InterfaceId As String = "08039bc1-af54-4883-8380-b52716522cb6"
    Public Const EventsId As String = "c9fb94be-f812-4f9e-bfdf-e3710ad9ecc6"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
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
    End Enum

    Public Enum SadbelTableType
        AUTHORIZED_PARTIES
        BOX_DEFAULT_COMBINED_NCTS_ADMIN
        BOX_DEFAULT_EDI_NCTS_ADMIN
        BOX_DEFAULT_EDI_NCTS_IE141_ADMIN
        BOX_DEFAULT_EDI_NCTS_IE44_ADMIN
        BOX_DEFAULT_EDI_NCTS2_ADMIN
        BOX_DEFAULT_COMBINED_ADMIN
        BOX_DEFAULT_IMPORT_ADMIN
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

    ''' <summary>
    ''' DELETE, UPDATE and INSERT via SQL Script
    ''' </summary>
    Public Function ExecuteNonQuery(ByVal SQL As String, _
                                    ByVal Database As DBInstanceType, _
                           Optional ByVal Year As String = vbNullString) As Integer

        Dim conObjects() As Object

        Try
            conObjects = getConnectionObjects(SQL, Database, False, False, Year)
            conObjects(1).ExecuteNonQuery()

            conObjects(1).Dispose()
            conObjects(0).Close()
            conObjects(0).Dispose()
        Catch ex As Exception
            AddToTrace("ExecuteNonQuery: " & ex.Message)
            Return FAILURE
        End Try

        Return SUCCESS

    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_sadbel
    ''' </summary>
    Public Function UpdateSadbel(ByRef RecordsetToUpdate As CRecordset, _
                                 ByVal TableName As SadbelTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for edifact
    ''' </summary>
    Public Function UpdateEdifact(ByRef RecordsetToUpdate As CRecordset, _
                                  ByVal TableName As EdifactTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_data
    ''' </summary>
    Public Function UpdateData(ByRef RecordsetToUpdate As CRecordset, _
                               ByVal TableName As DataTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_EDIHistoryXX
    ''' </summary>
    Public Function UpdateEdifactHistory(ByRef RecordsetToUpdate As CRecordset, _
                                         ByVal TableName As EdifactTableType,
                                         ByVal Year As Integer) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_historyXX
    ''' </summary>
    Public Function UpdateSadbelHistory(ByRef RecordsetToUpdate As CRecordset, _
                                        ByVal TableName As SadbelHistoryTableType,
                                        ByVal Year As Integer) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for mdb_RepertoryXXXX
    ''' </summary>
    Public Function UpdateRepertory(ByRef RecordsetToUpdate As CRecordset, _
                                    ByVal TableName As RepertoryTableType,
                                    ByVal Year As Integer) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName, Year)
    End Function

    ''' <summary>
    ''' Update a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function UpdateTemplateCP(ByRef RecordsetToUpdate As CRecordset, _
                                     ByVal TableName As TemplateCPTableType) As Integer

        Return FindAndUpdateRow(RecordsetToUpdate, TableName)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_sadbel
    ''' </summary>
    Public Function InsertSadbel(ByRef RecordsetToInsert As CRecordset, _
                                 ByVal TableName As SadbelTableType) As Integer

        Return InsertRow(RecordsetToInsert, TableName)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for edifact
    ''' </summary>
    Public Function InsertEdifact(ByRef RecordsetToInsert As CRecordset, _
                                  ByVal TableName As EdifactTableType) As Integer

        Return InsertRow(RecordsetToInsert, TableName)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_data
    ''' </summary>
    Public Function InsertData(ByRef RecordsetToInsert As CRecordset, _
                               ByVal TableName As DataTableType) As Integer

        Return InsertRow(RecordsetToInsert, TableName)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for EdiHistoryXX
    ''' </summary>
    Public Function InsertEdifactHistory(ByRef RecordsetToInsert As CRecordset, _
                                         ByVal TableName As EdifactTableType,
                                         ByVal Year As Integer) As Integer

        Return InsertRow(RecordsetToInsert, TableName, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_historyXX
    ''' </summary>
    Public Function InsertSadbelHistory(ByRef RecordsetToInsert As CRecordset, _
                                        ByVal TableName As SadbelHistoryTableType,
                                        ByVal Year As Integer) As Integer

        Return InsertRow(RecordsetToInsert, TableName, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for mdb_repertoryXXXX
    ''' </summary>
    Public Function InsertRepertory(ByRef RecordsetToInsert As CRecordset, _
                                    ByVal TableName As RepertoryTableType,
                                    ByVal Year As Integer) As Integer

        Return InsertRow(RecordsetToInsert, TableName, Year)
    End Function

    ''' <summary>
    ''' Insert a selected ADODB.Recordset.Row for TemplateCP
    ''' </summary>
    Public Function InsertTemplateCP(ByRef RecordsetToInsert As CRecordset, _
                                     ByVal TableName As TemplateCPTableType) As Integer

        Return InsertRow(RecordsetToInsert, TableName)
    End Function

    ''' <summary>
    ''' SELECT query interface to VB.NET
    ''' </summary>
    ''' <returns>an ADODB.Recordset containing the queried record</returns>
    Public Function ExecuteQuery(ByVal SQL As String, _
                                 ByVal Database As DBInstanceType, _
                        Optional ByVal UseDataShaping As Boolean = False, _
                        Optional ByVal Year As String = vbNullString) As Recordset

        Dim rstADO As New Recordset
        Dim conObjects() As Object

        AddToTrace("Start of execute query: " & SQL, True)

        Try
            conObjects = getConnectionObjects(SQL, Database, UseDataShaping, True, Year)

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

                        AddToTrace("Populating datashape child tables with data, TABLENAME: " & subTableName)

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
                            'Debug.Print(table.TableName & " row count: " & table.Rows.Count)
                            rstADOChild.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)

                            Dim strRow As String = vbNullString
                            For colIdx As Integer = 0 To columns.Count - 1
                                childFields(colIdx).Value = row(colIdx)
                                strRow = strRow & columns(colIdx).ColumnName & ": " & row(colIdx) & ", "
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
            conObjects(1).Dispose()
            conObjects(0).Close()
            conObjects(0).Dispose()
        Catch ex As Exception
            AddToTrace("ExecuteQuery: " & ex.Message)
        End Try

        AddToTrace("End of execute query: " & SQL, True)

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
            End If
        Next

        Return strColumns
    End Function
End Class


