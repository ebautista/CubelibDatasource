Imports ADODB
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

    Private Const FAILURE As Integer = -1
    Private Const SUCCESS As Integer = 0

    Public Function ExecuteNonQuery(ByVal SQL As String, _
                                    ByVal Database As DBInstanceType, _
                           Optional ByVal Year As String = vbNullString) As Integer

        Dim conObjects() As Object

        Try
            conObjects = getConnectionObjects(SQL, Database, False, False)
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

    Public Function Update(ByRef RecordsetToUpdate As CRecordset, _
                           ByVal Bookmark As Double,
                           ByVal TableName As IConvertible) As Integer

        If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Recordset.Source Is Nothing Then
            AddToTrace("Error in CDatasource.Update() - source recordset was not properly initialized.")
        End If

        RecordsetToUpdate.Recordset.Bookmark = Bookmark

        Try
            DelegateUpdate(RecordsetToUpdate.Recordset, TableName)
            Return SUCCESS
        Catch ex As Exception
            AddToTrace("Error in CubelibDatasource.Update: " & ex.Message)
        End Try

        Return FAILURE
    End Function

    'Public Function Update(ByRef RecordsetToUpdate As CRecordset, _
    '                       ByVal Bookmark As Double,
    '                       ByVal TableName As IConvertible) As Integer

    '    Dim conObjects() As Object
    '    Dim dbType As DBInstanceType

    '    If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Recordset.Source Is Nothing Then
    '        AddToTrace("Error in CDatasource.Update() - source recordset was not properly initialized.")
    '    End If

    '    RecordsetToUpdate.Recordset.Bookmark = Bookmark

    '    Try
    '        dbType = GetDatabaseInstanceType(RecordsetToUpdate.Connection)
    '        conObjects = getConnectionObjects(RecordsetToUpdate.Recordset.Source, dbType, False, True)

    '        Dim ds As DataSet = conObjects(2)
    '        Dim adapter As DataAdapter = conObjects(1)

    '        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso RecordsetToUpdate.Recordset.RecordCount > 0 Then
    '            Dim table As DataTable = ds.Tables(0)

    '            Dim columns() As DataColumn = table.PrimaryKey
    '            Dim pk() As Object

    '            If columns.Length > 0 Then
    '                For index = 0 To columns.Length - 1
    '                    ReDim Preserve pk(index)
    '                    pk(index) = RecordsetToUpdate.Recordset.Fields(columns(index).ColumnName).Value
    '                    Debug.Print(columns(index).ColumnName)
    '                Next

    '                DelegateUpdate(RecordsetToUpdate.Recordset, pk, TableName)

    '                conObjects(2).Dispose()
    '                conObjects(1).Dispose()
    '                conObjects(0).Close()
    '                conObjects(0).Dispose()

    '                Return SUCCESS
    '            Else
    '                AddToTrace("Error in CubelibDatasource.Update: No Primary Key define for : " & RecordsetToUpdate.Recordset.Source)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        AddToTrace("Error in CubelibDatasource.Update: " & ex.Message)
    '    End Try

    '    Return FAILURE
    'End Function

    Public Function Insert(ByRef RecordsetToUpdate As CRecordset,
                           ByVal Bookmark As Double,
                           ByVal TableName As IConvertible) As Integer

        If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Recordset.Source Is Nothing Then
            AddToTrace("Error in CDatasource.Insert() - source recordset was not properly initialized.")
        End If

        RecordsetToUpdate.Recordset.Bookmark = Bookmark

        Try
            DelegateInsert(RecordsetToUpdate.Recordset, TableName)
            Return SUCCESS
        Catch ex As Exception
            AddToTrace("Error in CubelibDatasource.Insert: " & ex.Message)
        End Try

        Return FAILURE
    End Function

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

    Public Function getConnectionObjects(ByVal SQL As String, _
                                         ByVal Database As DBInstanceType, _
                                Optional ByVal UseDataShaping As Boolean = False,
                                Optional ByVal IsQuery As Boolean = True, _
                                Optional ByVal Year As String = vbNullString) As Object()

        Dim conObjects(IIf(IsQuery, 3, 2)) As Object

        Dim conTemp As DbConnection
        Dim adapter As DataAdapter
        Dim dsTemp As New DataSet
        Dim command As DbCommand
        Dim strDBName As String

        strDBName = getDatabaseName(Database, Year, objProp.getDatabaseType())
        conTemp = getConnection(strDBName, objProp, UseDataShaping)

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                conObjects.SetValue(conTemp, 0)

                AddToTrace("Connecting To Access Database...", True)

                If IsQuery Then
                    adapter = New OleDbDataAdapter(SQL, conTemp)
                    adapter.Fill(dsTemp)
                    adapter.FillSchema(dsTemp, SchemaType.Source)

                    conObjects.SetValue(adapter, 1)
                    conObjects.SetValue(dsTemp, 2)
                Else
                    command = New OleDbCommand(SQL, conTemp)
                    conObjects.SetValue(command, 1)
                End If

            Case DatabaseType.SQLSERVER
                conObjects.SetValue(conTemp, 0)

                AddToTrace("Connecting To SQL Server...", True)

                If IsQuery Then
                    adapter = New SqlClient.SqlDataAdapter(SQL, conTemp)
                    adapter.Fill(dsTemp)
                    adapter.FillSchema(dsTemp, SchemaType.Mapped)
                    conObjects.SetValue(adapter, 1)
                    conObjects.SetValue(dsTemp, 2)
                Else
                    command = New SqlCommand(SQL, conTemp)
                    conObjects.SetValue(command, 1)
                End If

            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return conObjects
    End Function

    Public Function getConnection(ByVal DBName As String, _
                                  ByVal objProp As CDatabaseProperty, _
                         Optional ByVal UseDataShaping As Boolean = False) As DbConnection

        Dim conTemp As DbConnection
        Dim sbConn As New StringBuilder

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                If UseDataShaping Then
                    sbConn.Append("Provider=MSDataShape;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=")
                    sbConn.Append(objProp.getDatabasePath())
                    sbConn.Append("\")
                    sbConn.Append(DBName)
                    sbConn.Append(";Persist Security Info=False;Jet OLEDB:Database Password=")
                    sbConn.Append(objProp.getPassword())
                Else
                    sbConn.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=")
                    sbConn.Append(objProp.getDatabasePath())
                    sbConn.Append("\")
                    sbConn.Append(DBName)
                    sbConn.Append(";Persist Security Info=False;Jet OLEDB:Database Password=")
                    sbConn.Append(objProp.getPassword())
                End If

                conTemp = New OleDbConnection(sbConn.ToString())

            Case DatabaseType.SQLSERVER
                If UseDataShaping Then
                    sbConn.Append("Provider=MSDataShape;Data Source=")
                    sbConn.Append(objProp.getServerName())
                    sbConn.Append(";Integrated Security=SSPI;Initial Catalog=")
                    sbConn.Append(DBName)
                    sbConn.Append(";User ID=")
                    sbConn.Append(objProp.getUserName())
                    sbConn.Append(";Password=")
                    sbConn.Append(objProp.getPassword())
                    sbConn.Append(";")
                Else
                    sbConn.Append("Data Source=")
                    sbConn.Append(objProp.getServerName())
                    sbConn.Append(";Integrated Security=SSPI;Initial Catalog=")
                    sbConn.Append(DBName)
                    sbConn.Append(";User ID=")
                    sbConn.Append(objProp.getUserName())
                    sbConn.Append(";Password=")
                    sbConn.Append(objProp.getPassword())
                    sbConn.Append(";")
                End If

                conTemp = New SqlConnection(sbConn.ToString())
            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type.")

        End Select

        conTemp.Open()
        Return conTemp
    End Function

    Private Function getDatabaseName(ByVal DBInstanceType As DBInstanceType, _
                                     ByVal Year As String, _
                                     ByVal DBType As DatabaseType) As String

        Dim strDatabaseName As String = vbNullString

        'GET DB INSTANCE NAME
        Select Case DBInstanceType
            Case CDatasource.DBInstanceType.DATABASE_SADBEL
                strDatabaseName = "mdb_sadbel"

            Case CDatasource.DBInstanceType.DATABASE_DATA
                strDatabaseName = "mdb_data"

            Case CDatasource.DBInstanceType.DATABASE_EDIFACT
                strDatabaseName = "mdb_edifact"

            Case CDatasource.DBInstanceType.DATABASE_SCHEDULER
                strDatabaseName = "mdb_scheduler"

            Case CDatasource.DBInstanceType.DATABASE_TEMPLATE
                strDatabaseName = "TemplateCP"

            Case CDatasource.DBInstanceType.DATABASE_TARIC
                strDatabaseName = "mdb_taric"

            Case CDatasource.DBInstanceType.DATABASE_HISTORY
                If Year.Length <> 2 Then
                    Throw New InvalidDataException("Year supplied is of invalid format, right format is YY.")
                End If

                strDatabaseName = "mdb_history" + Year

            Case CDatasource.DBInstanceType.DATABASE_REPERTORY
                If Year.Length <> 4 Then
                    Throw New InvalidDataException("Year supplied is of invalid format, right format is YYYY.")
                End If

                If Now.Year = Year Then
                    strDatabaseName = "mdb_repertory"
                Else
                    strDatabaseName = "mdb_repertory_" + Year
                End If

            Case CDatasource.DBInstanceType.DATABASE_EDI_HISTORY
                If Year.Length <> 2 Then
                    Throw New InvalidDataException("Year supplied is of invalid format, right format is YY.")
                End If

                If Now.Year = Year Then
                    strDatabaseName = "mdb_EDIhistory"
                Else
                    strDatabaseName = "mdb_EDIhistory" + Year
                End If

            Case Else
                Throw New NotSupportedException("Database instance not supported.")

        End Select

        'ADD FILE EXTENSION FOR ACCESS DB
        If DatabaseType.ACCESS.Equals(DBType) Then
            strDatabaseName = strDatabaseName & ACCESS_DB_EXTENSION_97_2003
        End If

        Return strDatabaseName
    End Function

    Private Function GetDatabaseInstanceType(ByVal ConnectionString As String) As DBInstanceType
        Dim dbRegex As New Regex("Source=.*mdb")
        Dim match As Match = dbRegex.Match(ConnectionString)

        If match.Success Then
            Dim dbName As String = match.Value
            dbName = dbName.Substring(dbName.LastIndexOf("\") + 1)
            dbName = dbName.Replace(".mdb", vbNullString)

            Select Case dbName
                Case "mdb_sadbel"
                    Return DBInstanceType.DATABASE_SADBEL

                Case "mdb_data"
                    Return DBInstanceType.DATABASE_DATA

                Case "mdb_edifact"
                    Return DBInstanceType.DATABASE_EDIFACT

                Case "mdb_scheduler"
                    Return DBInstanceType.DATABASE_SCHEDULER

                Case "CPTemplate"
                    Return DBInstanceType.DATABASE_TEMPLATE

                Case "mdb_taric"
                    Return DBInstanceType.DATABASE_TARIC

                Case "mdb_history"
                    Return DBInstanceType.DATABASE_HISTORY

                Case "mdb_repertory"
                    Return DBInstanceType.DATABASE_REPERTORY

                Case Else
                    AddToTrace("Error in CDatasource.GetDatabaseInstanceType() - could not determine db type from connectionString = " & ConnectionString)
                    Return Nothing

            End Select
        Else
            AddToTrace("Error in CDatasource.GetDatabaseInstanceType() - could not extract database name from connectionString = " & ConnectionString)
            Return Nothing
        End If
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

    Private Sub DelegateUpdate(ByRef adoRow As ADODB.Recordset, ByRef TableName As IConvertible)
        Dim type As Type = CType(TableName, Object).GetType

        If type.Equals(GetType(SadbelTableType)) Then
            FindAndUpdateRowSADBEL(adoRow, TableName)
        End If
        'TODO: put all CP Database cases in here
    End Sub

    Private Sub DelegateInsert(ByRef adoRow As ADODB.Recordset, ByRef TableName As IConvertible)
        Dim type As Type = CType(TableName, Object).GetType

        If type.Equals(GetType(SadbelTableType)) Then
            InsertRowSADBEL(adoRow, TableName)
        End If
        'TODO: put all CP Database cases in here
    End Sub
End Class


