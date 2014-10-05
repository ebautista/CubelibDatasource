Imports ADODB
Imports System.Data.Common
Imports System.Data.OleDb
Imports CubeLibDataSource.CDatasource
Imports CubeLibDataSource.CDatabaseProperty
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.ServiceProcess
Imports System.Drawing
Imports Microsoft.VisualBasic.Compatibility

Module MGlobal

    Public DATABASES_DELIM As String = ";"

    Public Const FAILURE As Integer = -1
    Public Const SUCCESS As Integer = 0

    Public Enum CrudType
        CREATE
        READ
        UPDATE
        DELETE
    End Enum

    Public Const ACCESS_DB_EXTENSION_97_2003 As String = ".mdb"

    Public g_objDatabaseProperty As CDatabaseProperty

    Public g_objDBConnections As Collection
    Public g_objDBTransaction As System.Data.Common.DbTransaction

    ' Call this function to remove the key from memory after it is used for security.
    <DllImport("kernel32.dll")> _
    Public Sub ZeroMemory(ByVal addr As IntPtr, ByVal size As Integer)
    End Sub

    Public Function IsPersistencePropertyValueValid(ByVal PersistencePropertyPath As String, _
                                                    ByVal PersistencePropertyValue As String) _
                                                    As Boolean
        Dim blnValid As Boolean
        Dim strPropertyValue As String

        strPropertyValue = PersistencePropertyValue.ToUpper.Trim

        blnValid = True

        Select Case PersistencePropertyPath.ToUpper.Trim

            Case "database".ToUpper.Trim
                blnValid = blnValid And (strPropertyValue.Length > 0)
                blnValid = blnValid And (String.Equals(strPropertyValue, "ACCESS97") Or _
                                         String.Equals(strPropertyValue, "ACCESS2003") Or _
                                         String.Equals(strPropertyValue, "SQLSERVER"))

            Case "debug".ToUpper.Trim
                blnValid = blnValid And (strPropertyValue.Length > 0)
                blnValid = blnValid And (String.Equals(strPropertyValue, "TRUE") Or _
                                         String.Equals(strPropertyValue, "FALSE"))

            Case "mdbpath".ToUpper.Trim
                blnValid = blnValid And (strPropertyValue.Length > 0)

            Case "outputfilepath".ToUpper.Trim
                blnValid = blnValid And (strPropertyValue.Length > 0)

            Case "password".ToUpper.Trim

            Case "servername".ToUpper.Trim

            Case "username".ToUpper.Trim

            Case Else

        End Select

        Return blnValid
    End Function

    Public Function GetPersistencePropertyPath(ByVal PersistenceProperty As PersistencePropertyType) As String

        Select Case PersistenceProperty
            Case PersistencePropertyType.DATABASE
                GetPersistencePropertyPath = "database"

            Case PersistencePropertyType.DEBUG
                GetPersistencePropertyPath = "debug"

            Case PersistencePropertyType.MDB_PATH
                GetPersistencePropertyPath = "MdbPath"

            Case PersistencePropertyType.OUTPUT_FILE_PATH
                GetPersistencePropertyPath = "Outputfilepath"

            Case PersistencePropertyType.PASSWORD
                GetPersistencePropertyPath = "password"

            Case PersistencePropertyType.SERVER_NAME
                GetPersistencePropertyPath = "servername"

            Case PersistencePropertyType.SQL_SERVER_INTEGRATED_AUTHENTICATION

                GetPersistencePropertyPath = "IntegratedAuthentication"

            Case PersistencePropertyType.USER_NAME
                GetPersistencePropertyPath = "username"

            Case Else
                GetPersistencePropertyPath = ""

        End Select
    End Function

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

            Case "System.Byte[]"
                Return DataTypeEnum.adLongVarBinary

            Case Else
                Return DataTypeEnum.adVarChar
        End Select
    End Function

    Public Function CreateNewParameterADODB(ByRef AdoRow As ADODB.Recordset,
                                            ByVal FieldName As String,
                                            ByVal ADOType As ADODB.DataTypeEnum) As DbParameter

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                 CDatabaseProperty.DatabaseType.ACCESS2003
                Dim parameter As New OleDbParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.OleDbType = ConvertADODBToDBType(ADOType)
                Return parameter

            Case CDatabaseProperty.DatabaseType.SQLSERVER
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

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
                Dim parameter As New OleDbParameter
                parameter.Value = AdoRow.Fields(FieldName).Value
                parameter.ParameterName = "@PK_" + FieldName.Replace(" ", "_").Replace("-", "_")
                parameter.OleDbType = ConvertADONETToDBType(NETType)
                Return parameter

            Case CDatabaseProperty.DatabaseType.SQLSERVER
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

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
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
                    Case DataTypeEnum.adLongVarChar
                        Return OleDbType.LongVarChar
                    Case Else
                        Return OleDbType.VarWChar
                End Select

            Case CDatabaseProperty.DatabaseType.SQLSERVER
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
                        Return SqlDbType.Image
                    Case DataTypeEnum.adVarWChar
                        Return SqlDbType.NVarChar
                    Case DataTypeEnum.adLongVarChar
                        Return SqlDbType.NText
                    Case Else
                        Return SqlDbType.NVarChar
                End Select


            Case Else
                Throw New NotSupportedException("ConvertADODBToDBType: Unknown Database Type or Database Type not supported.")

        End Select
    End Function

    Public Function ConvertADONETToDBType(ByVal NETType As System.Type) As DbType

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
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
                    Case "System.Byte[]"
                        Return OleDbType.LongVarBinary
                    Case Else
                        Throw New NotSupportedException("ConvertADODBToDBType: Unknown or not supported ADODB DataType.")
                End Select

            Case CDatabaseProperty.DatabaseType.SQLSERVER
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
                    Case "System.Byte[]"
                        Return SqlDbType.VarBinary
                    Case Else
                        Throw New NotSupportedException("ConvertADODBToDBType: Unknown or not supported ADODB DataType.")
                End Select

            Case Else
                Throw New NotSupportedException("ConvertADODBToDBType: Unknown Database Type or Database Type not supported.")

        End Select
    End Function

    Public Function getConnectionObjectsNonQuery(ByVal SQL As String, _
                                                 ByVal Database As DBInstanceType, _
                                        Optional ByVal Year As String = "", _
                                        Optional ByVal OtherDatabaseName As String = "") As DbCommand

        Dim conTemp As DbConnection
        Dim command As DbCommand
        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in getConnectionObjectsNonQuery - Persistence Path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, False)

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
                AddToTrace("Connecting To Access Database...", True)

                command = New OleDbCommand(SQL, conTemp)

                If g_objDBConnections.Contains(strDBName) Then
                    command.Transaction = g_objDBTransaction
                End If

            Case CDatabaseProperty.DatabaseType.SQLSERVER
                AddToTrace("Connecting To SQL Server...", True)

                command = New SqlCommand(SQL, conTemp)

                If g_objDBConnections.Contains(strDBName) Then
                    command.Transaction = g_objDBTransaction
                End If

            Case Else
                Throw New NotSupportedException("getConnectionObjectsNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return command
    End Function

    Public Function getTableSchema(ByVal TableName As String, _
                                   ByVal Database As DBInstanceType, _
                          Optional ByVal Year As String = "", _
                          Optional ByVal OtherDatabaseName As String = "") As DataSet

        Dim conTemp As DbConnection
        Dim adapter As DataAdapter
        Dim dsTemp As New DataSet
        Dim objCommand As OleDb.OleDbCommand
        Dim objSQLCommand As SqlClient.SqlCommand
        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in getTableSchema - Persistence Path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, False)

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
                AddToTrace("Connecting To Access Database...", True)

                If g_objDBConnections.Contains(strDBName) Then
                    objCommand = New OleDb.OleDbCommand
                    objCommand.Connection = conTemp
                    objCommand.CommandText = "SELECT * FROM [" & TableName & "] WHERE 1=2"
                    objCommand.Transaction = g_objDBTransaction
                    adapter = New OleDbDataAdapter(objCommand)
                Else
                    adapter = New OleDbDataAdapter("SELECT * FROM [" & TableName & "] WHERE 1=2", conTemp)
                End If

                adapter.Fill(dsTemp)
                adapter.FillSchema(dsTemp, SchemaType.Source)

            Case CDatabaseProperty.DatabaseType.SQLSERVER
                AddToTrace("Connecting To SQL Server...", True)

                If g_objDBConnections.Contains(strDBName) Then
                    objSQLCommand = New SqlClient.SqlCommand
                    objSQLCommand.Connection = conTemp
                    objSQLCommand.CommandText = "SELECT * FROM [" & TableName & "] WHERE 1=2"
                    objSQLCommand.Transaction = g_objDBTransaction
                    adapter = New SqlClient.SqlDataAdapter(objSQLCommand)
                Else
                    adapter = New SqlClient.SqlDataAdapter("SELECT * FROM [" & TableName & "] WHERE 1=2", conTemp)
                End If

                adapter.Fill(dsTemp)
                adapter.FillSchema(dsTemp, SchemaType.Mapped)


            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return dsTemp
    End Function

    Public Function getDatabaseName(ByVal DBInstanceType As DBInstanceType, _
                                     ByVal Year As String, _
                                     ByVal DBType As DatabaseType, _
                                     ByVal OtherDatabaseName As String) As String

        Dim strDatabaseName As String = ""
        Dim strYear As String

        If Year Is Nothing Then
            strYear = ""
        Else
            strYear = Year
        End If

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
                If Not (strYear.Length = 2 Or strYear.Length = 4) Then
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YY or YYYY.")
                End If

                Select Case strYear.Length
                    Case 2
                        strDatabaseName = "mdb_history" + strYear
                    Case 4
                        strDatabaseName = "mdb_history" + strYear.Substring(2)
                End Select


            Case CDatasource.DBInstanceType.DATABASE_REPERTORY

                If Not (strYear.Length = 0 Or strYear.Length = 2 Or strYear.Length = 4) Then
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YY or YYYY or an empty string.")
                End If


                Select Case strYear.Length
                    Case 0
                        strDatabaseName = "mdb_repertory"

                    Case 2
                        If Convert.ToInt32(Year) > 97 Then
                            strDatabaseName = "19" + strYear
                        Else
                            strDatabaseName = "20" + strYear
                        End If

                        If Now.Year = Convert.ToInt32(strDatabaseName) Then
                            strDatabaseName = "mdb_repertory"
                        Else
                            strDatabaseName = "mdb_repertory_" + strDatabaseName
                        End If

                    Case 4
                        strDatabaseName = "mdb_repertory_" + strYear
                End Select

            Case CDatasource.DBInstanceType.DATABASE_EDI_HISTORY

                If Not (strYear.Length = 2 Or strYear.Length = 4) Then
                    Throw New InvalidDataException("Year supplied is of invalid format, correct format is YY or YYYY.")
                End If

                Select Case strYear.Length
                    Case 2
                        strDatabaseName = "mdb_EDIhistory" + strYear
                    Case 4
                        strDatabaseName = "mdb_EDIhistory" + strYear.Substring(2)
                End Select

            Case Else

                strDatabaseName = OtherDatabaseName

                If Right(strDatabaseName, 4).ToUpper = ".MDB" Then
                    strDatabaseName = strDatabaseName.Substring(0, strDatabaseName.Length - 4)
                End If

                'Throw New NotSupportedException("Database instance not supported.")

        End Select

        'ADD FILE EXTENSION FOR ACCESS DB
        If CDatabaseProperty.DatabaseType.ACCESS97.Equals(DBType) Or
            CDatabaseProperty.DatabaseType.ACCESS2003.Equals(DBType) Then

            strDatabaseName = strDatabaseName & ACCESS_DB_EXTENSION_97_2003

        End If

        Return strDatabaseName
    End Function

    Public Function IsServiceRunning_F(ByVal ServiceName As String) As Boolean
        Dim theServices() As ServiceController
        Dim theservice As ServiceController

        Dim running As Boolean

        theServices = ServiceController.GetServices

        For Each theservice In theServices
            Debug.WriteLine(theservice.ServiceName)
            If String.Equals(theservice.ServiceName, ServiceName, StringComparison.OrdinalIgnoreCase) Then
                running = (theservice.Status = ServiceProcess.ServiceControllerStatus.Running)

                Exit For
            End If
        Next

        Return running
    End Function

    Public Function GetDatabaseTypeDesc(ByVal DBType As DatabaseType) As String

        Select Case DBType
            Case CDatabaseProperty.DatabaseType.ACCESS97

                GetDatabaseTypeDesc = "ACCESS97"

            Case CDatabaseProperty.DatabaseType.ACCESS2003

                GetDatabaseTypeDesc = "ACCESS2003"

            Case CDatabaseProperty.DatabaseType.SQLSERVER

                GetDatabaseTypeDesc = "SQLSERVER"

            Case CDatabaseProperty.DatabaseType.ORACLE

                Throw New ClearingPointException("Error in MGlobbal.GetDatabaseTypeDesc - Oracle database not yet supported.")

            Case Else

                Throw New ClearingPointException("Error in MGlobbal.GetDatabaseTypeDesc - Database Type not suported.")

        End Select
    End Function

    Public Function GetArchiveDatabasesSQL_F(ByVal DBArchiveInstance As DBGeneralInstanceType) As String()
        Dim conTemp As DbConnection
        Dim cmdText As String
        Dim sqlCmd As SqlCommand
        Dim strDatabases As String = ""

        Dim lstDatabase As New List(Of String)()
        Dim blnAddToList As Boolean

        conTemp = getConnection("master", g_objDatabaseProperty, False)

        cmdText = ("SELECT * FROM master.dbo.sysdatabases")

        sqlCmd = New SqlCommand(cmdText, conTemp)

        Using reader As SqlDataReader = sqlCmd.ExecuteReader

            If reader.HasRows Then

                Do While reader.Read()

                    blnAddToList = False

                    Select Case DBArchiveInstance
                        Case DBGeneralInstanceType.DB_ARCHIVE_HISTORY

                            blnAddToList = IsHistoryDB_F(reader.Item("name"))

                        Case DBGeneralInstanceType.DB_ARCHIVE_EDI_HISTORY

                            blnAddToList = IsEDIHistoryDB_F(reader.Item("name"))

                        Case DBGeneralInstanceType.DB_ARCHIVE_REPERTORY

                            blnAddToList = IsRepertoryDB_F(reader.Item("name"))

                        Case DBGeneralInstanceType.DB_CP_DATABASES

                            blnAddToList = IsCPDatabase_F(reader.Item("name"))

                        Case Else
                            blnAddToList = True
                    End Select

                    If blnAddToList Then
                        strDatabases = strDatabases + reader.Item("name") + DATABASES_DELIM
                        lstDatabase.Add(reader.Item("name"))
                    End If
                Loop

            End If

            If strDatabases.Length > 0 Then
                strDatabases = strDatabases.TrimEnd(DATABASES_DELIM)
            End If

        End Using


        'Return strDatabases
        Return lstDatabase.ToArray

    End Function

    Public Function IsCPDatabase_F(ByVal DBName As String) As Boolean
        Dim blnCPDatabase As Boolean
        Dim strDBName As String

        blnCPDatabase = False
        strDBName = UCase$(Trim$(DBName))

        If Right$(strDBName, 4) = UCase$(".mdb") Then
            strDBName = Left$(strDBName, Len(strDBName) - 4)
        End If

        blnCPDatabase = blnCPDatabase Or (strDBName = "EDIFACT")
        blnCPDatabase = blnCPDatabase Or (strDBName = "MDB_DATA")
        blnCPDatabase = blnCPDatabase Or (strDBName = "MDB_EDIHISTORY")
        blnCPDatabase = blnCPDatabase Or (strDBName = "MDB_SADBEL")
        blnCPDatabase = blnCPDatabase Or (strDBName = "MDB_SCHEDULER")
        blnCPDatabase = blnCPDatabase Or (strDBName = "MDB_TARIC")
        blnCPDatabase = blnCPDatabase Or (strDBName = "TEMPLATECP")

        blnCPDatabase = blnCPDatabase Or IsHistoryDB_F(strDBName)

        blnCPDatabase = blnCPDatabase Or IsEDIHistoryDB_F(strDBName)

        blnCPDatabase = blnCPDatabase Or IsRepertoryDB_F(strDBName)

        Return blnCPDatabase
    End Function

    Public Function IsEDIHistoryDB_F(ByVal DBName As String) As Boolean

        Dim strDBName As String
        Dim blnEDIHistoryDB As Boolean

        blnEDIHistoryDB = False
        strDBName = Trim$(UCase$(DBName))

        ' REMOVE FILE EXTENSION
        If Right$(strDBName, 4) = UCase$(".mdb") Then
            strDBName = Left$(strDBName, Len(strDBName) - 4)
        End If

        If Left$(strDBName, 14) = "MDB_EDIHISTORY" And _
            (Len(strDBName) = 16) Then

            If IsNumeric(Mid$(strDBName, 15, 2)) Then
                blnEDIHistoryDB = True
            End If

        End If

        Return blnEDIHistoryDB
    End Function

    Public Function IsHistoryDB_F(ByVal DBName As String) As Boolean
        Dim strDBName As String
        Dim blnHistoryDB As Boolean

        blnHistoryDB = False
        strDBName = Trim$(UCase$(DBName))

        ' REMOVE FILE EXTENSION
        If Right$(strDBName, 4) = UCase$(".mdb") Then
            strDBName = Left$(strDBName, Len(strDBName) - 4)
        End If

        If Left$(strDBName, 11) = "MDB_HISTORY" And _
            (Len(strDBName) = 13) Then

            If IsNumeric(Mid$(strDBName, 12, 2)) Then
                blnHistoryDB = True
            End If
        End If

        Return blnHistoryDB
    End Function

    Public Function IsRepertoryDB_F(ByVal DBName As String) As Boolean

        Dim strDBName As String
        Dim blnRepertoryDB As Boolean

        blnRepertoryDB = False
        strDBName = Trim$(UCase$(DBName))

        ' REMOVE FILE EXTENSION
        If Right$(strDBName, 4) = UCase$(".mdb") Then
            strDBName = Left$(strDBName, Len(strDBName) - 4)
        End If

        If strDBName = UCase$("mdb_repertory") Then

            blnRepertoryDB = True

        ElseIf Left$(strDBName, 14) = "MDB_REPERTORY_" And _
                (Len(strDBName) = 18) Then

            If IsNumeric(Mid$(strDBName, 15, 4)) Then
                blnRepertoryDB = True
            End If
        End If

        Return blnRepertoryDB
    End Function

    Public Function GetRepertoryDBYear_F(ByVal RepertoryDBName As String) As String
        Dim strRepertoryDBName As String

        strRepertoryDBName = UCase$(Trim$(RepertoryDBName))

        ' Remove Preceding backslash like in strCurrentYear in CubeLibRepertorium
        If Left$(strRepertoryDBName, 1) = "\" Then
            strRepertoryDBName = Mid(strRepertoryDBName, 2)
        End If

        ' REMOVE .MDB FILE EXTENSION
        If Right$(strRepertoryDBName, 4) = UCase$(".mdb") Then
            strRepertoryDBName = Left$(strRepertoryDBName, Len(strRepertoryDBName) - 4)
        End If

        If IsRepertoryDB_F(strRepertoryDBName) Then
            If strRepertoryDBName = "MDB_REPERTORY" Then
                strRepertoryDBName = vbNullString
            Else
                strRepertoryDBName = Right$(strRepertoryDBName, 4)
            End If
        Else
            strRepertoryDBName = vbNullString
        End If

        GetRepertoryDBYear_F = strRepertoryDBName

    End Function

    Public Function GetHistoryDBYear_F(ByVal HistoryDBName As String) As String
        Dim strHistoryDBName As String

        strHistoryDBName = UCase$(Trim$(HistoryDBName))

        ' Remove Preceding backslash
        If Left$(strHistoryDBName, 1) = "\" Then
            strHistoryDBName = Mid(strHistoryDBName, 2)
        End If

        ' REMOVE .MDB FILE EXTENSION
        If Right$(strHistoryDBName, 4) = UCase$(".mdb") Then
            strHistoryDBName = Left$(strHistoryDBName, Len(strHistoryDBName) - 4)
        End If

        If IsHistoryDB_F(strHistoryDBName) Then
            strHistoryDBName = Right$(strHistoryDBName, 2)
        Else
            strHistoryDBName = vbNullString
        End If

        GetHistoryDBYear_F = strHistoryDBName
    End Function

    Public Function GetEDIHistoryDBYear_F(ByVal EDIHistoryDBName As String) As String
        Dim strEDIHistoryDBName As String

        strEDIHistoryDBName = UCase$(Trim$(EDIHistoryDBName))

        ' Remove Preceding backslash
        If Left$(strEDIHistoryDBName, 1) = "\" Then
            strEDIHistoryDBName = Mid(strEDIHistoryDBName, 2)
        End If

        ' REMOVE .MDB FILE EXTENSION
        If Right$(strEDIHistoryDBName, 4) = UCase$(".mdb") Then
            strEDIHistoryDBName = Left$(strEDIHistoryDBName, Len(strEDIHistoryDBName) - 4)
        End If

        If IsEDIHistoryDB_F(strEDIHistoryDBName) Then
            strEDIHistoryDBName = Right$(strEDIHistoryDBName, 2)
        Else
            strEDIHistoryDBName = vbNullString
        End If

        GetEDIHistoryDBYear_F = strEDIHistoryDBName
    End Function

    Public Function getConnection(ByVal DBName As String, _
                                  ByVal objProp As CDatabaseProperty, _
                         Optional ByVal UseDataShaping As Boolean = False) As DbConnection

        Dim conTemp As DbConnection
        Dim sbConn As New StringBuilder

        If g_objDBConnections.Contains(DBName) Then
            conTemp = g_objDBConnections.Item(DBName)
        Else

            Select Case objProp.getDatabaseType()
                Case CDatabaseProperty.DatabaseType.ACCESS97,
                    CDatabaseProperty.DatabaseType.ACCESS2003
                    If UseDataShaping Then
                        sbConn.Append("Provider=MSDataShape;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=")
                        sbConn.Append(objProp.getDatabasePathFromPersistence())
                        sbConn.Append("\")
                        sbConn.Append(DBName)
                        sbConn.Append(";Persist Security Info=False;Jet OLEDB:Database Password=")
                        sbConn.Append(objProp.getPassword())
                    Else
                        sbConn.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=")
                        sbConn.Append(objProp.getDatabasePathFromPersistence())
                        sbConn.Append("\")
                        sbConn.Append(DBName)
                        sbConn.Append(";Persist Security Info=False;Jet OLEDB:Database Password=")
                        sbConn.Append(objProp.getPassword())
                    End If

                    conTemp = New OleDbConnection(sbConn.ToString())

                Case CDatabaseProperty.DatabaseType.SQLSERVER
                    If UseDataShaping Then

                        sbConn.Append("Provider=MSDataShape;")
                        sbConn.Append("Data Provider=SQLOLEDB;")
                        sbConn.Append("Data Source=")
                        sbConn.Append(objProp.getServerName()).Append(";")

                        sbConn.Append("Initial Catalog =")
                        sbConn.Append(DBName).Append(";")

                        If objProp.getUserName().Trim(" ").Length > 0 And _
                           objProp.getPassword().Trim(" ").Length > 0 Then

                            If String.Equals(objProp.getServerIntegratedAuthentication().Trim(" "), "TRUE", System.StringComparison.OrdinalIgnoreCase) Then
                                sbConn.Append("Integrated Security=SSPI;")
                            Else
                                sbConn.Append("User ID=")
                                sbConn.Append(objProp.getUserName()).Append(";")

                                sbConn.Append("Password=")
                                sbConn.Append(objProp.getPassword()).Append(";")
                            End If

                        Else
                            sbConn.Append("Integrated Security=SSPI;")
                        End If

                        conTemp = New OleDbConnection(sbConn.ToString())

                    Else
                        sbConn.Append("Data Source=")
                        sbConn.Append(objProp.getServerName()).Append(";")

                        sbConn.Append("Initial Catalog =")
                        sbConn.Append(DBName).Append(";")

                        If objProp.getUserName().Trim(" ").Length > 0 And _
                           objProp.getPassword().Trim(" ").Length > 0 Then

                            If String.Equals(objProp.getServerIntegratedAuthentication().Trim(" "), "TRUE", System.StringComparison.OrdinalIgnoreCase) Then
                                sbConn.Append("Integrated Security=SSPI;")
                            Else
                                sbConn.Append("User ID=")
                                sbConn.Append(objProp.getUserName()).Append(";")

                                sbConn.Append("Password=")
                                sbConn.Append(objProp.getPassword()).Append(";")
                            End If

                        Else
                            sbConn.Append("Integrated Security=SSPI;")
                        End If

                        conTemp = New SqlConnection(sbConn.ToString())

                    End If


                Case Else
                    Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type.")

            End Select

            conTemp.Open()
        End If

        Return conTemp
    End Function

    Public Function IsPrimaryKeyColumn(ByRef Table As DataTable, ByRef Column As DataColumn) As Boolean
        Return Array.IndexOf(Table.PrimaryKey, Column) >= 0
    End Function

    Public Function GetTableName(ByRef adoRow As ADODB.Recordset,
                                  ByVal TableName As IConvertible) As String

        Dim type As Type = CType(TableName, Object).GetType
        Dim strTableName As String

        If type.Equals(GetType(SadbelTableType)) Then

            Select Case CType(TableName, SadbelTableType)

                Case SadbelTableType.DIGISIGN_PLDA_COMBINED, _
                      SadbelTableType.DIGISIGN_PLDA_IMPORT, _
                      SadbelTableType.MAIL_BOX, _
                      SadbelTableType.MAIL_GROUPS, _
                      SadbelTableType.MAIL_SETTINGS, _
                      SadbelTableType.SAD_PLDA_VALUE_LIST

                    Return CType(TableName, SadbelTableType).ToString

                    'Case SadbelTableType.AUTHORIZEDPARTIES
                    'Return CType(TableName, SadbelTableType).ToString

                Case Else

                    strTableName = CType(TableName, SadbelTableType).ToString

                    Return strTableName.Replace("_", " ")
            End Select

        ElseIf type.Equals(GetType(EdifactTableType)) Then

            Select Case CType(TableName, EdifactTableType)

                Case EdifactTableType.NCTS_DEPARTURE_FOLLOW_UP_REQUEST

                    strTableName = CType(TableName, EdifactTableType).ToString

                    Return strTableName.Replace("_", " ")

                Case Else
                    Return CType(TableName, EdifactTableType).ToString
            End Select

        ElseIf type.Equals(GetType(DataTableType)) Then

            Return CType(TableName, DataTableType).ToString

        ElseIf type.Equals(GetType(EdiHistoryTableType)) Then

            Return CType(TableName, EdiHistoryTableType).ToString

        ElseIf type.Equals(GetType(SadbelHistoryTableType)) Then

            strTableName = CType(TableName, SadbelHistoryTableType).ToString

            Return strTableName.Replace("_", " ")

        ElseIf type.Equals(GetType(SchedulerTableType)) Then

            strTableName = CType(TableName, SchedulerTableType).ToString

            Return strTableName.Replace("_", " ")

        ElseIf type.Equals(GetType(RepertoryTableType)) Then

            strTableName = CType(TableName, RepertoryTableType).ToString

            Return strTableName.Replace("_", " ")


        ElseIf type.Equals(GetType(TemplateCPTableType)) Then

            strTableName = CType(TableName, TemplateCPTableType).ToString

            Select Case CType(TableName, TemplateCPTableType)

                Case TemplateCPTableType.DELETEITEM_LOG

                    Return strTableName.Replace("_", " ")
                    'Return CType(TableName, TemplateCPTableType).ToString.Replace("_", " ")
                Case Else
                    Return strTableName
                    'Return CType(TableName, TemplateCPTableType).ToString
            End Select

        ElseIf type.Equals(GetType(TaricTableType)) Then
            strTableName = CType(TableName, TaricTableType).ToString

            Select Case CType(TableName, TaricTableType)

                Case TaricTableType.SUPP_UNITS

                    Return strTableName.Replace("_", " ")

                Case Else
                    Return CType(TableName, TaricTableType).ToString
            End Select
        End If

        Return ""
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
        ElseIf type.Equals(GetType(TaricTableType)) Then
            Return DBInstanceType.DATABASE_TARIC
        End If

        Throw New NotSupportedException("GetDBInstanceTypeFromTableEnumType: Unknown Database Instance Type.")
    End Function

    Public Function getConnectionObjects(ByVal SQL As String, _
                                         ByVal Database As DBInstanceType, _
                                Optional ByVal UseDataShaping As Boolean = False,
                                Optional ByVal IsQuery As Boolean = True, _
                                Optional ByVal Year As String = "", _
                                Optional ByVal OtherDatabaseName As String = "") As Object()

        Dim conObjects(IIf(IsQuery, 3, 2)) As Object

        Dim conTemp As DbConnection
        Dim adapter As DataAdapter
        Dim dsTemp As New DataSet
        Dim command As DbCommand
        Dim strDBName As String

        If g_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in getConnectionObjects - Persistence path was not initialized.")
        End If

        strDBName = getDatabaseName(Database, Year, g_objDatabaseProperty.getDatabaseType(), OtherDatabaseName)
        conTemp = getConnection(strDBName, g_objDatabaseProperty, UseDataShaping)

        Select Case g_objDatabaseProperty.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
                conObjects.SetValue(conTemp, 0)

                AddToTrace("Connecting To Access Database...", True)

                If IsQuery Then
                    command = New OleDbCommand(SQL, conTemp)
                    If g_objDBConnections.Contains(strDBName) Then
                        command.Transaction = g_objDBTransaction
                    End If

                    adapter = New OleDbDataAdapter(command)
                    adapter.Fill(dsTemp)
                    adapter.FillSchema(dsTemp, SchemaType.Source)

                    conObjects.SetValue(adapter, 1)
                    conObjects.SetValue(dsTemp, 2)
                Else

                    command = New OleDbCommand(SQL, conTemp)

                    If g_objDBConnections.Contains(strDBName) Then
                        command.Transaction = g_objDBTransaction
                    End If

                    conObjects.SetValue(command, 1)
                End If

            Case CDatabaseProperty.DatabaseType.SQLSERVER
                conObjects.SetValue(conTemp, 0)

                AddToTrace("Connecting To SQL Server...", True)

                If UseDataShaping Then
                    If IsQuery Then
                        command = New OleDbCommand(SQL, conTemp)
                        If g_objDBConnections.Contains(strDBName) Then
                            command.Transaction = g_objDBTransaction
                        End If

                        adapter = New OleDbDataAdapter(command)
                        adapter.Fill(dsTemp)
                        adapter.FillSchema(dsTemp, SchemaType.Mapped)
                        conObjects.SetValue(adapter, 1)
                        conObjects.SetValue(dsTemp, 2)
                    Else
                        command = New OleDbCommand(SQL, conTemp)

                        If g_objDBConnections.Contains(strDBName) Then
                            command.Transaction = g_objDBTransaction
                        End If

                        conObjects.SetValue(command, 1)
                    End If
                Else
                    If IsQuery Then
                        command = New SqlCommand(SQL, conTemp)
                        If g_objDBConnections.Contains(strDBName) Then
                            command.Transaction = g_objDBTransaction
                        End If

                        adapter = New SqlClient.SqlDataAdapter(command)
                        adapter.Fill(dsTemp)
                        adapter.FillSchema(dsTemp, SchemaType.Mapped)
                        conObjects.SetValue(adapter, 1)
                        conObjects.SetValue(dsTemp, 2)
                    Else
                        command = New SqlCommand(SQL, conTemp)

                        If g_objDBConnections.Contains(strDBName) Then
                            command.Transaction = g_objDBTransaction
                        End If

                        conObjects.SetValue(command, 1)
                    End If
                End If

            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type or Database Type not supported.")

        End Select

        Return conObjects
    End Function

    
End Module
