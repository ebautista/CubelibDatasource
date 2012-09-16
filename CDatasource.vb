Imports ADODB
Imports Microsoft.Win32
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CubelibDatasource.CDatabaseProperty

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


    Public Function ExecuteNonQuery(ByVal SQL As String, _
                                    ByVal DBName As String) As Integer

        Dim conObjects() As Object

        Try
            conObjects = getConnectionObjects(SQL, DBName)
            conObjects(1).ExecuteNonQuery()

            conObjects(1).Dispose()
            conObjects(0).Close()
            conObjects(0).Dispose()
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return 0
        End Try

        Return 1

    End Function


    Public Function ExecuteQuery(ByVal SQL As String, _
                                 ByVal DBName As String, _
                        Optional ByVal UseDataShaping As Boolean = False) As Recordset

        Dim rstADO As New Recordset

        Dim conObjects() As Object

        conObjects = getConnectionObjects(SQL, DBName, UseDataShaping)

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

        Return rstADO
    End Function

    Public Function getConnectionObjects(ByVal SQL As String, _
                                         ByVal DBName As String, _
                                Optional ByVal UseDataShaping As Boolean = False,
                                Optional ByVal IsQuery As Boolean = True) As Object()
        Dim conObjects(IIf(IsQuery, 3, 2)) As Object

        Dim objProp As New CDatabaseProperty
        Dim conTemp As DbConnection
        Dim adapter As DataAdapter
        Dim dsTemp As New DataSet
        Dim command As DbCommand

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                DBName = IIf(DBName.Contains(".mdb"), DBName, DBName & ACCESS_DB_EXTENSION_97_2003)

                If UseDataShaping Then
                    conTemp = New OleDbConnection("Provider=MSDataShape;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & objProp.getDatabasePath() & "\" & DBName & ";Persist Security Info=False;Jet OLEDB:Database Password=" & objProp.getPassword())
                Else
                    conTemp = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & objProp.getDatabasePath() & "\" & DBName & ";Persist Security Info=False;Jet OLEDB:Database Password=" & objProp.getPassword())
                End If

                conTemp.Open()
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
                DBName = Replace(DBName, ".mdb", vbNullString)

                If UseDataShaping Then
                    conTemp = New SqlConnection("Provider=MSDataShape;Data Source=" & objProp.getServerName() & ";Integrated Security=SSPI;Initial Catalog=" & DBName & ";User ID=" & objProp.getUserName() & ";Password=" & objProp.getPassword() & ";")
                Else
                    conTemp = New SqlConnection("Data Source=" & objProp.getServerName() & ";Integrated Security=SSPI;Initial Catalog=" & DBName & ";User ID=" & objProp.getUserName() & ";Password=" & objProp.getPassword() & ";")
                End If

                conTemp.Open()
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
            Case DatabaseType.ORACLE
                Throw (New Exception("ExecuteNonQuery: Oracle Database is not yet supported."))

            Case DatabaseType.MYSQL
                Throw (New Exception("ExecuteNonQuery: MYSQL Database is not yet supported."))

            Case Else
                Throw (New Exception("ExecuteNonQuery: Unknown Database Type."))

        End Select

        Return conObjects
    End Function
End Class


