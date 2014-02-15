Imports ADODB
Imports System.Data.Common
Imports System.Data.OleDb
Imports CubelibDatasource.CDatasource
Imports CubelibDatasource.CDatabaseProperty
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient

Module MGlobal

    Public Const FAILURE As Integer = -1
    Public Const SUCCESS As Integer = 0

    Public Enum CrudType
        CREATE
        READ
        UPDATE
        DELETE
    End Enum

    Public Const ACCESS_DB_EXTENSION_97_2003 As String = ".mdb"

    Public objProp As New CDatabaseProperty

    Public Function TranslateType(ByVal columnType As Type) As DataTypeEnum

        Select Case columnType.UnderlyingSystemType.ToString()
            Case "System.Boolean"
                Return DataTypeEnum.adBoolean

            Case "System.Byte"
                Return DataTypeEnum.adUnsignedTinyInt

            Case "System.Char"
                Return DataTypeEnum.adChar

            Case "System.DateTime"
                Return DataTypeEnum.adDate

            Case "System.Decimal"
                Return DataTypeEnum.adCurrency

            Case "System.Double"
                Return DataTypeEnum.adDouble

            Case "System.Int16"
                Return DataTypeEnum.adSmallInt

            Case "System.Int32"
                Return DataTypeEnum.adInteger

            Case "System.Int64"
                Return DataTypeEnum.adBigInt

            Case "System.SByte"
                Return DataTypeEnum.adTinyInt

            Case "System.Single"
                Return DataTypeEnum.adSingle

            Case "System.UInt16"
                Return DataTypeEnum.adUnsignedSmallInt

            Case "System.UInt32"
                Return DataTypeEnum.adUnsignedInt

            Case "System.UInt64"
                Return DataTypeEnum.adUnsignedBigInt

            Case "System.String"
                Return DataTypeEnum.adVarChar

            Case Else
                Return DataTypeEnum.adVarChar
        End Select
    End Function

    Public Function getConnectionObjectsNonQuery(ByVal SQL As String, _
                                                 ByVal Database As DBInstanceType, _
                                        Optional ByVal Year As String = vbNullString) As DbCommand

        Dim conTemp As DbConnection
        Dim command As DbCommand
        Dim strDBName As String

        strDBName = getDatabaseName(Database, Year, objProp.getDatabaseType())
        conTemp = getConnection(strDBName, objProp, False)

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                AddToTrace("Connecting To Access Database...", True)

                command = New OleDbCommand(SQL, conTemp)
            Case DatabaseType.SQLSERVER
                AddToTrace("Connecting To SQL Server...", True)

                command = New SqlCommand(SQL, conTemp)
            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return command
    End Function

    Public Function getTableSchema(ByVal TableName As String, _
                                   ByVal Database As DBInstanceType, _
                          Optional ByVal Year As String = vbNullString) As DataSet

        Dim conTemp As DbConnection
        Dim command As DbCommand
        Dim adapter As DataAdapter
        Dim dsTemp As New DataSet
        Dim strDBName As String

        strDBName = getDatabaseName(Database, Year, objProp.getDatabaseType())
        conTemp = getConnection(strDBName, objProp, False)

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                AddToTrace("Connecting To Access Database...", True)

                adapter = New OleDbDataAdapter("SELECT * FROM [" & TableName & "] WHERE 1=2", conTemp)
                adapter.Fill(dsTemp)
                adapter.FillSchema(dsTemp, SchemaType.Source)

            Case DatabaseType.SQLSERVER
                AddToTrace("Connecting To SQL Server...", True)

                adapter = New SqlClient.SqlDataAdapter("SELECT * FROM [" & TableName & "] WHERE 1=2", conTemp)
                adapter.Fill(dsTemp)
                adapter.FillSchema(dsTemp, SchemaType.Mapped)


            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return dsTemp
    End Function

    Public Function getDatabaseName(ByVal DBInstanceType As DBInstanceType, _
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
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YY.")
                End If

                strDatabaseName = "mdb_history" + Year

            Case CDatasource.DBInstanceType.DATABASE_REPERTORY
                If Year.Length <> 4 Then
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YYYY.")
                End If

                If Now.Year = Year Then
                    strDatabaseName = "mdb_repertory"
                Else
                    strDatabaseName = "mdb_repertory_" + Year
                End If

            Case CDatasource.DBInstanceType.DATABASE_EDI_HISTORY
                If Year.Length <> 2 Then
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YY.")
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

    Public Function IsPrimaryKeyColumn(ByRef Table As DataTable, ByRef Column As DataColumn) As Boolean
        Return Array.IndexOf(Table.PrimaryKey, Column) >= 0
    End Function
End Module
