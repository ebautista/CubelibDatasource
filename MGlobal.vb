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

    Public Function CreateNewParameterADODB(ByRef AdoRow As ADODB.Recordset,
                                            ByVal FieldName As String,
                                            ByVal ADOType As ADODB.DataTypeEnum) As DbParameter

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                Dim parameter As New OleDbParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.OleDbType = ConvertADODBToDBType(ADOType)
                Return parameter

            Case DatabaseType.SQLSERVER
                Dim parameter As New SqlParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.SqlDbType = ConvertADODBToDBType(ADOType)
                Return parameter

            Case Else
                Throw New NotSupportedException("CreateNewParameter: Unknown Database Type or Database Type not supported.")

        End Select
    End Function

    Public Function CreateNewParameterADONET(ByRef AdoRow As ADODB.Recordset,
                                             ByVal FieldName As String,
                                             ByVal NETType As System.Type) As DbParameter

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                Dim parameter As New OleDbParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@PK_" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.OleDbType = ConvertADONETToDBType(NETType)
                Return parameter

            Case DatabaseType.SQLSERVER
                Dim parameter As New SqlParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@PK_" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.SqlDbType = ConvertADONETToDBType(NETType)
                Return parameter

            Case Else
                Throw New NotSupportedException("CreateNewParameter: Unknown Database Type or Database Type not supported.")

        End Select
    End Function

    Public Function ConvertADODBToDBType(ByVal ADOType As ADODB.DataTypeEnum) As DbType

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                Select Case ADOType
                    Case DataTypeEnum.adInteger
                        Return OleDbType.Integer
                    Case DataTypeEnum.adBoolean
                        Return OleDbType.Boolean
                    Case DataTypeEnum.adDate
                        Return OleDbType.Date
                    Case DataTypeEnum.adDouble
                        Return OleDbType.Double
                    Case DataTypeEnum.adNumeric
                        Return OleDbType.Decimal
                    Case DataTypeEnum.adLongVarWChar
                        Return OleDbType.VarWChar
                    Case DataTypeEnum.adSingle
                        Return OleDbType.Single
                    Case DataTypeEnum.adUnsignedTinyInt
                        Return OleDbType.UnsignedTinyInt
                    Case DataTypeEnum.adSmallInt
                        Return OleDbType.SmallInt
                    Case DataTypeEnum.adLongVarBinary
                        Return OleDbType.LongVarBinary
                    Case DataTypeEnum.adVarWChar
                        Return OleDbType.VarWChar
                    Case Else
                        Return OleDbType.VarWChar
                End Select

            Case DatabaseType.SQLSERVER
                Select Case ADOType
                    Case DataTypeEnum.adInteger
                        Return SqlDbType.Int
                    Case DataTypeEnum.adBoolean
                        Return SqlDbType.Bit
                    Case DataTypeEnum.adDate
                        Return SqlDbType.DateTime
                    Case DataTypeEnum.adDouble
                        Return SqlDbType.Float
                    Case DataTypeEnum.adNumeric
                        Return SqlDbType.Decimal
                    Case DataTypeEnum.adLongVarWChar
                        Return SqlDbType.NText
                    Case DataTypeEnum.adSingle
                        Return SqlDbType.Real
                    Case DataTypeEnum.adUnsignedTinyInt
                        Return SqlDbType.TinyInt
                    Case DataTypeEnum.adSmallInt
                        Return SqlDbType.SmallInt
                    Case DataTypeEnum.adLongVarBinary
                        Return SqlDbType.VarBinary
                    Case DataTypeEnum.adVarWChar
                        Return SqlDbType.NVarChar
                    Case Else
                        Return SqlDbType.NVarChar
                End Select


            Case Else
                Throw New NotSupportedException("ConvertADODBToDBType: Unknown Database Type or Database Type not supported.")

        End Select
    End Function

    Public Function ConvertADONETToDBType(ByVal NETType As System.Type) As DbType

        Select Case objProp.getDatabaseType()
            Case DatabaseType.ACCESS
                Select Case NETType.UnderlyingSystemType.ToString()
                    Case "System.Int32"
                        Return OleDbType.Integer
                    Case "System.Boolean"
                        Return OleDbType.Boolean
                    Case "System.DateTime"
                        Return OleDbType.Date
                    Case "System.Double"
                        Return OleDbType.Double
                    Case "System.Decimal"
                        Return OleDbType.Decimal
                    Case "System.Single"
                        Return OleDbType.Single
                    Case "System.Byte"
                        Return OleDbType.UnsignedTinyInt
                    Case "System.Int16"
                        Return OleDbType.SmallInt
                    Case "System.String"
                        Return OleDbType.VarWChar
                    Case Else
                        Throw New NotSupportedException("ConvertADODBToDBType: Unknown or not supported ADODB DataType.")
                End Select

            Case DatabaseType.SQLSERVER
                Select Case NETType.UnderlyingSystemType.ToString()
                    Case "System.Int32"
                        Return SqlDbType.Int
                    Case "System.Boolean"
                        Return SqlDbType.Bit
                    Case "System.DateTime"
                        Return SqlDbType.DateTime
                    Case "System.Double"
                        Return SqlDbType.Float
                    Case "System.Decimal"
                        Return SqlDbType.Decimal
                    Case "System.Single"
                        Return SqlDbType.Real
                    Case "System.Byte"
                        Return SqlDbType.TinyInt
                    Case "System.Int16"
                        Return SqlDbType.SmallInt
                    Case "System.String"
                        Return SqlDbType.NVarChar
                    Case Else
                        Throw New NotSupportedException("ConvertADODBToDBType: Unknown or not supported ADODB DataType.")
                End Select


            Case Else
                Throw New NotSupportedException("ConvertADODBToDBType: Unknown Database Type or Database Type not supported.")

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
                Throw New NotSupportedException("getConnectionObjectsNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return command
    End Function

    Public Function getTableSchema(ByVal TableName As String, _
                                   ByVal Database As DBInstanceType, _
                          Optional ByVal Year As String = vbNullString) As DataSet

        Dim conTemp As DbConnection
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
                strDatabaseName = "edifact"

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

    Public Function GetTableName(ByRef adoRow As ADODB.Recordset,
                                  ByVal TableName As IConvertible) As String

        Dim type As Type = CType(TableName, Object).GetType

        If type.Equals(GetType(SadbelTableType)) Then
            Select Case CType(TableName, SadbelTableType)
                Case SadbelTableType.DIGISIGN_PLDA_COMBINED
                Case SadbelTableType.DIGISIGN_PLDA_IMPORT
                Case SadbelTableType.MAIL_BOX
                Case SadbelTableType.MAIL_GROUPS
                Case SadbelTableType.MAIL_SETTINGS
                    Return CType(TableName, SadbelTableType).ToString
                Case Else
                    Return CType(TableName, SadbelTableType).ToString.Replace("_", " ")
            End Select
        ElseIf type.Equals(GetType(EdifactTableType)) Then
            Select Case CType(TableName, EdifactTableType)
                Case EdifactTableType.NCTS_DEPARTURE_FOLLOW_UP_REQUEST
                    Return CType(TableName, EdifactTableType).ToString.Replace("_", " ")
                Case Else
                    Return CType(TableName, EdifactTableType).ToString
            End Select
        ElseIf type.Equals(GetType(DataTableType)) Then
            Return CType(TableName, DataTableType).ToString
        ElseIf type.Equals(GetType(EdiHistoryTableType)) Then
            Return CType(TableName, EdiHistoryTableType).ToString
        ElseIf type.Equals(GetType(SadbelHistoryTableType)) Then
            Return CType(TableName, SadbelHistoryTableType).ToString.Replace("_", " ")
        ElseIf type.Equals(GetType(SchedulerTableType)) Then
            Return CType(TableName, SchedulerTableType).ToString.Replace("_", " ")
        ElseIf type.Equals(GetType(RepertoryTableType)) Then
            Return CType(TableName, RepertoryTableType).ToString.Replace("_", " ")
        ElseIf type.Equals(GetType(TemplateCPTableType)) Then
            Select Case CType(TableName, TemplateCPTableType)
                Case TemplateCPTableType.DELETEITEM_LOG
                    Return CType(TableName, TemplateCPTableType).ToString.Replace("_", " ")
                Case Else
                    Return CType(TableName, TemplateCPTableType).ToString
            End Select
        End If

        Return vbNullString
    End Function

    Public Function GetDBInstanceTypeFromTableEnumType(ByVal TableName As IConvertible) As DBInstanceType
        Dim type As Type = CType(TableName, Object).GetType

        If type.Equals(GetType(SadbelTableType)) Then
            Return DBInstanceType.DATABASE_SADBEL
        ElseIf type.Equals(GetType(EdifactTableType)) Then
            Return DBInstanceType.DATABASE_EDIFACT
        ElseIf type.Equals(GetType(DataTableType)) Then
            Return DBInstanceType.DATABASE_DATA
        ElseIf type.Equals(GetType(EdiHistoryTableType)) Then
            Return DBInstanceType.DATABASE_EDI_HISTORY
        ElseIf type.Equals(GetType(SadbelHistoryTableType)) Then
            Return DBInstanceType.DATABASE_HISTORY
        ElseIf type.Equals(GetType(SchedulerTableType)) Then
            Return DBInstanceType.DATABASE_SCHEDULER
        ElseIf type.Equals(GetType(RepertoryTableType)) Then
            Return DBInstanceType.DATABASE_REPERTORY
        ElseIf type.Equals(GetType(TemplateCPTableType)) Then
            Return DBInstanceType.DATABASE_TEMPLATE
        End If

        Throw New NotSupportedException("GetDBInstanceTypeFromTableEnumType: Unknown Database Instance Type.")
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
End Module
