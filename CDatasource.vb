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
                           ByVal TableName As String) As Integer

        Dim conObjects() As Object
        Dim dbType As DBInstanceType

        If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Recordset.Source Is Nothing Then
            AddToTrace("Error in CDatasource.Update() - source recordset was not properly initialized.")
        End If

        RecordsetToUpdate.Recordset.Bookmark = Bookmark

        Try
            dbType = GetDatabaseInstanceType(RecordsetToUpdate.Connection)
            conObjects = getConnectionObjects(RecordsetToUpdate.Recordset.Source, dbType, False, True)

            Dim ds As DataSet = conObjects(2)
            Dim adapter As DataAdapter = conObjects(1)

            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso RecordsetToUpdate.Recordset.RecordCount > 0 Then
                Dim table As DataTable = ds.Tables(0)

                Dim columns() As DataColumn = table.PrimaryKey
                Dim pk() As Object

                If columns.Length > 0 Then
                    For index = 0 To columns.Length - 1
                        ReDim Preserve pk(index)
                        pk(index) = RecordsetToUpdate.Recordset.Fields(columns(index).ColumnName).Value
                        Debug.Print(columns(index).ColumnName)
                    Next

                    FindAndUpdateTable(RecordsetToUpdate.Recordset, pk, TableName)

                    conObjects(2).Dispose()
                    conObjects(1).Dispose()
                    conObjects(0).Close()
                    conObjects(0).Dispose()

                    Return SUCCESS
                Else
                    AddToTrace("Error in CubelibDatasource.Update: No Primary Key define for : " & RecordsetToUpdate.Recordset.Source)
                End If
            End If
        Catch ex As Exception
            AddToTrace("Error in CubelibDatasource.Update: " & ex.Message)
        End Try

        Return FAILURE
    End Function

    Public Function Insert(ByRef RecordsetToUpdate As CRecordset,
                           ByVal TableName As String) As Integer

        'Dim conObjects() As Object
        'Dim dbType As DBInstanceType

        'If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Recordset.Source Is Nothing Then
        '    AddToTrace("Error in CDatasource.Update() - source recordset was not properly initialized.")
        'End If

        'Try
        '    dbType = GetDatabaseInstanceType(RecordsetToUpdate.Connection)
        '    conObjects = getConnectionObjects(RecordsetToUpdate.Recordset.Source, dbType, False, True)

        '    Dim ds As DataSet = conObjects(2)
        '    Dim adapter As DataAdapter = conObjects(1)

        '    If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso RecordsetToUpdate.Recordset.RecordCount > 0 Then
        '        Dim table As DataTable = ds.Tables(0)

        '        Dim columns() As DataColumn = table.PrimaryKey
        '        Dim pk() As Object

        '        If columns.Length > 0 Then
        '            For index = 0 To columns.Length - 1
        '                ReDim Preserve pk(index)
        '                pk(index) = RecordsetToUpdate.Recordset.Fields(columns(index).ColumnName).Value
        '                Debug.Print(columns(index).ColumnName)
        '            Next

        '            Dim findRow As DataRow = table.Rows.Find(pk)

        '            If Not findRow Is Nothing Then
        '                findRow.BeginEdit()
        '                For Each Field As ADODB.Field In RecordsetToUpdate.Recordset.Fields
        '                    findRow.SetField(Field.Name, Field.Value)
        '                Next
        '                findRow.EndEdit()

        '                UpdateTable(findRow, TableName)

        '                conObjects(2).Dispose()
        '                conObjects(1).Dispose()
        '                conObjects(0).Close()
        '                conObjects(0).Dispose()

        '                Return SUCCESS
        '            Else
        '                AddToTrace("Error in CubelibDatasource.Update: No data found for : " & RecordsetToUpdate.Recordset.Source)
        '            End If
        '        Else
        '            AddToTrace("Error in CubelibDatasource.Update: No Primary Key define for : " & RecordsetToUpdate.Recordset.Source)
        '        End If
        '    End If
        'Catch ex As Exception
        '    AddToTrace("Error in CubelibDatasource.Update: " & ex.Message)
        'End Try

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

    'Private Sub SetUpdateCommand(ByRef adapter As DataAdapter,
    '                             ByRef Source As ADODB.Recordset,
    '                             ByVal TableName As String,
    '                             ByRef pk() As DataColumn,
    '                             ByRef ConTemp As DbConnection)

    '    Dim sb As New StringBuilder
    '    Dim index As Integer

    '    sb.Append("UPDATE [" & TableName & "] ")
    '    sb.Append("SET ")
    '    For Each Field As ADODB.Field In Source.Fields
    '        index = index + 1
    '        sb.Append("[" & Field.Name & "] = @Field" & index & ", ")
    '    Next
    '    sb.Remove(sb.ToString.LastIndexOf(","), 2)
    '    sb.Append(" WHERE ")
    '    For index = 0 To pk.Length - 1
    '        sb.Append("[" & pk(index).ColumnName & "] = @Clause" & index & " AND ")
    '    Next
    '    sb.Remove(sb.ToString.LastIndexOf(" AND "), 5)
    '    Debug.Print(sb.ToString)

    '    Select Case objProp.getDatabaseType
    '        Case DatabaseType.ACCESS
    '            Dim command As New OleDbCommand(sb.ToString, ConTemp)
    '            Dim index2 As Integer

    '            For Each Field As ADODB.Field In Source.Fields
    '                index2 = index2 + 1
    '                command.Parameters.Add("@Field" & index2, MapAdoToOle(Field.Type))
    '            Next

    '            For index2 = 0 To pk.Length - 1
    '                command.Parameters.Add("@Field" & index2, MapSystemToOle(pk(index2).DataType))
    '            Next

    '            CType(adapter, OleDbDataAdapter).UpdateCommand = command

    '        Case DatabaseType.SQLSERVER

    '        Case Else
    '            AddToTrace("Error in CDatasource.GetSQLUpdateCommand() - Unsupported Database Type.")
    '    End Select
    'End Sub

    Private Sub FindAndUpdateTable(ByRef adoRow As ADODB.Recordset, ByRef pk() As Object, ByVal TableName As String)
        Select Case TableName
            Case "PLDA IMPORT HEADER"
                Dim adapter As New Sadbel_DataSetTableAdapters.PLDA_IMPORT_HEADERTableAdapter
                Dim table As Sadbel_DataSet.PLDA_IMPORT_HEADERDataTable = adapter.GetDataByCH(pk(0), pk(1))

                If Not table.Rows Is Nothing AndAlso table.Rows.Count > 0 Then
                    Dim rowToUpdate As DataRow = table.Rows(0)

                    rowToUpdate.BeginEdit()
                    For Each Field As ADODB.Field In adoRow.Fields
                        rowToUpdate.SetField(Field.Name, Field.Value)
                    Next
                    rowToUpdate.EndEdit()

                    adapter.Update(rowToUpdate)
                Else
                    AddToTrace("Error in CubelibDatasource.FindAndUpdateTable: No data found for : " & adoRow.Source)
                End If

            Case Else

        End Select

    End Sub
End Class


