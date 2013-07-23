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

    Public Function Update(ByRef RecordsetToUpdate As ADODB.Recordset, _
                           ByVal Bookmark As Double) As Integer

        Dim conObjects() As Object
        Dim dbType As DBInstanceType

        If RecordsetToUpdate Is Nothing AndAlso RecordsetToUpdate.Source Is Nothing Then
            AddToTrace("Error in CDatasource.Update() - source recordset was not properly initialized.")
        End If

        RecordsetToUpdate.Bookmark = Bookmark

        Try
            dbType = GetDatabaseInstanceType(RecordsetToUpdate.ActiveConnection)
            conObjects = getConnectionObjects(RecordsetToUpdate.Source, dbType, False, True)

            Dim ds As DataSet = conObjects(2)

            Debug.Print(ds.Tables.Count)
            Debug.Print(ds.Tables(0).TableName)

            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 AndAlso RecordsetToUpdate.RecordCount > 0 Then
                Dim table As DataTable = ds.Tables(0)
                Dim tableToMerge As DataTable = table.Clone
                Dim row As DataRow = tableToMerge.NewRow()

                For Each Field As ADODB.Field In RecordsetToUpdate.Fields
                    'If Field.OriginalValue <> Field.Value Then
                    row(Field.Name) = Field.Value
                    'End If
                Next

                tableToMerge.Rows().Add(row)
                table.Merge(tableToMerge)
                table.AcceptChanges()
                table.Dispose()
            End If
        Catch ex As Exception
            AddToTrace("ExecuteNonQuery: " & ex.Message)
            Return FAILURE
        End Try

        Return SUCCESS

    End Function

    Public Function ExecuteQuery(ByVal SQL As String, _
                                 ByVal Database As DBInstanceType, _
                        Optional ByVal UseDataShaping As Boolean = False, _
                        Optional ByVal Year As String = vbNullString) As Recordset

        Dim rstADO As New Recordset
        Dim conObjects() As Object

        Try
            conObjects = getConnectionObjects(SQL, Database, UseDataShaping, True, Year)

            If conObjects(2).Tables.Count > 0 AndAlso conObjects(2).Tables(0).Rows.Count > 0 Then
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

            conObjects(2).Dispose()
            conObjects(1).Dispose()
            conObjects(0).Close()
            conObjects(0).Dispose()
        Catch ex As Exception
            AddToTrace("ExecuteQuery: " & ex.Message)
        End Try

        Return rstADO
    End Function

    Public Function getConnectionObjects(ByVal SQL As String, _
                                         ByVal Database As DBInstanceType, _
                                Optional ByVal UseDataShaping As Boolean = False,
                                Optional ByVal IsQuery As Boolean = True, _
                                Optional ByVal Year As String = vbNullString) As Object()

        Dim conObjects(IIf(IsQuery, 3, 2)) As Object

        Dim objProp As New CDatabaseProperty
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

                If IsQuery Then
                    adapter = New OleDbDataAdapter(SQL, conTemp)
                    adapter.Fill(dsTemp)
                    adapter.FillSchema(dsTemp, SchemaType.Mapped)
                    conObjects.SetValue(adapter, 1)
                    conObjects.SetValue(dsTemp, 2)
                Else
                    command = New OleDbCommand(SQL, conTemp)
                    conObjects.SetValue(command, 1)
                End If

            Case DatabaseType.SQLSERVER
                conObjects.SetValue(conTemp, 0)

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

        If Not Year Is Nothing AndAlso Year.Length <> 4 Then
            Throw New InvalidDataException("Year supplied is of invalid format, right format is YYYY.")
        End If

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
                strDatabaseName = "CPTemplate"

            Case CDatasource.DBInstanceType.DATABASE_TARIC
                strDatabaseName = "mdb_taric"

            Case CDatasource.DBInstanceType.DATABASE_HISTORY
                strDatabaseName = "mdb_history" + Year.Substring(2, 2)

            Case CDatasource.DBInstanceType.DATABASE_REPERTORY
                If Now.Year = Year Then
                    strDatabaseName = "mdb_repertory"
                Else
                    strDatabaseName = "mdb_repertory_" + Year
                End If

            Case CDatasource.DBInstanceType.DATABASE_EDI_HISTORY
                strDatabaseName = "mdb_history" + Year.Substring(2, 2)

            Case Else
                Throw New NotSupportedException("Database instance not supported.")

        End Select

        'ADD FILE EXTENSION FOR ACCESS DB
        If DatabaseType.ACCESS.Equals(DBType) Then
            strDatabaseName = strDatabaseName & ACCESS_DB_EXTENSION_97_2003
        End If

        Return strDatabaseName
    End Function

    Private Function GetDatabaseInstanceType(ByVal ConnectionString As ADODB.Connection) As DBInstanceType
        Dim strConnection As String = ConnectionString.ConnectionString
        Dim dbRegex As New Regex("Source=.*mdb")
        Dim match As Match = dbRegex.Match(strConnection)

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
                    AddToTrace("Error in CDatasource.GetDatabaseInstanceType() - could not determine db type from connectionString = " & strConnection)
                    Return Nothing

            End Select
        Else
            AddToTrace("Error in CDatasource.GetDatabaseInstanceType() - could not extract database name from connectionString = " & strConnection)
            Return Nothing
        End If
    End Function
End Class


