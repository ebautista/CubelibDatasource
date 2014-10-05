Imports Microsoft.Win32
Imports System.IO

Public Class CDatabaseProperty

    Private Const PROPERTY_FILE As String = "CPConfig.dat"
    Private Const REGKEY_CLEARINGPOINT_SETTINGS As String = "Software\Wow6432Node\Cubepoint\Clearingpoint\Settings"
    Private Const REGKEY_CLEARINGPOINT_SETTINGS_XP As String = "Software\Cubepoint\ClearingPoint\Settings"
    Private m_objProp As CProperty

    Public Enum DatabaseType
        SQLSERVER
        ACCESS97
        ACCESS2003
        ORACLE
        MYSQL
    End Enum

    Friend Sub New(ByVal PersistencePath As String, _
          Optional ByVal PersitenceFilename As String = PROPERTY_FILE, _
          Optional ByVal DBTypeDef As DatabaseType = CDatabaseProperty.DatabaseType.ACCESS2003, _
          Optional ByVal DBServerNameDef As String = "", _
          Optional ByVal DBServerIntegratedAuthenticationDef As String = "FALSE", _
          Optional ByVal DBUserNameDef As String = "sa", _
          Optional ByVal DBPasswordDef As String = "wack2", _
          Optional ByVal DBPathDef As String = "", _
          Optional ByVal DataPathDef As String = "")

        MyBase.New()

        Dim strPersistenceFileName As String

        strPersistenceFileName = PersitenceFilename.Trim(" ")
        If strPersistenceFileName.Contains(".") Then
            If Not String.Equals(".dat".ToUpper, strPersistenceFileName.Substring(strPersistenceFileName.Length - 4).ToUpper) Then
                strPersistenceFileName = strPersistenceFileName + ".dat"
            End If
        Else
            strPersistenceFileName = strPersistenceFileName + ".dat"
        End If

        If PersistencePath = "" Then
            Throw New ClearingPointException("Error in CDatabaseProperty - Destination path is empty or null string.")
        End If

        If File.Exists(PersistencePath.TrimEnd("\") + "\" + strPersistenceFileName) Then

            Try
                m_objProp = New CProperty(PersistencePath, strPersistenceFileName)

            Catch ex As Exception
                Throw New ClearingPointException("Error in CDatabaseProperty - " & ex.Message)
            End Try

        Else
            Try
                m_objProp = New CProperty(PersistencePath, strPersistenceFileName, "# ClearingPoint Configuration File versio 1.0")


                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.DATABASE), GetDatabaseTypeDesc(DBTypeDef))

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.DEBUG), "FALSE")

                Dim strMachineName As String

                If IsNothing(DBServerNameDef) Then
                    strMachineName = Environment.MachineName()

                ElseIf DBServerNameDef.Trim(" ").Length <= 0 Then

                    strMachineName = Environment.MachineName()
                Else

                    strMachineName = DBServerNameDef
                End If

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.SERVER_NAME), strMachineName + "\SQLEXPRESS")

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.SQL_SERVER_INTEGRATED_AUTHENTICATION), DBServerIntegratedAuthenticationDef)

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.USER_NAME), DBUserNameDef)

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.PASSWORD), DBPasswordDef)

                Dim strDBPath As String

                If IsNothing(DBPathDef) Then

                    strDBPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    If String.Equals(strDBPath.Substring(0, 6), "file:\", System.StringComparison.OrdinalIgnoreCase) Then
                        strDBPath = strDBPath.Substring(6)
                    End If
                ElseIf DBPathDef.Trim(" ").Length <= 0 Then

                    strDBPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    If String.Equals(strDBPath.Substring(0, 6), "file:\", System.StringComparison.OrdinalIgnoreCase) Then
                        strDBPath = strDBPath.Substring(6)
                    End If
                Else

                    strDBPath = DBPathDef
                End If

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.MDB_PATH), strDBPath)

                Dim strOutputFilePath As String

                If IsNothing(DataPathDef) Then
                    strOutputFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    If String.Equals(strOutputFilePath.Substring(0, 6), "file:\", System.StringComparison.OrdinalIgnoreCase) Then
                        strOutputFilePath = strOutputFilePath.Substring(6)
                    End If
                ElseIf DataPathDef.Trim(" ").Length <= 0 Then

                    strOutputFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    If String.Equals(strOutputFilePath.Substring(0, 6), "file:\", System.StringComparison.OrdinalIgnoreCase) Then
                        strOutputFilePath = strOutputFilePath.Substring(6)
                    End If
                Else
                    strOutputFilePath = DataPathDef
                End If

                If String.Equals(strOutputFilePath.Substring(strOutputFilePath.Length - 4), "\OUT", System.StringComparison.OrdinalIgnoreCase) Then
                    strOutputFilePath = strOutputFilePath.Substring(1, strOutputFilePath.Length - 4)
                End If
                strOutputFilePath = strOutputFilePath.TrimEnd("\") + "\Out"

                SetPersistenceProperty(GetPersistencePropertyPath(PersistencePropertyType.OUTPUT_FILE_PATH), strOutputFilePath)

            Catch ex As Exception
                Throw New ClearingPointException("Error in CDatabaseProperty - " & ex.Message)
            End Try
        End If

    End Sub

    'Public Sub New(ByVal filePath As String)
    '    MyBase.New()

    '    If filePath = "" Then
    '        Throw New ClearingPointException("Error in CDatabaseProperty - Persistence path is empty or null string.")
    '    End If

    '    If Not File.Exists(filePath.TrimEnd("\") + "\" + PROPERTY_FILE) Then
    '        Throw New ClearingPointException("Error in CDatabaseProperty - persistence file does not exist in the specified path.")
    '    End If

    '    Try
    '        m_objProp = New CProperty(filePath, PROPERTY_FILE)

    '    Catch ex As Exception
    '        Throw New ClearingPointException("Error in CDatabaseProperty - " & ex.Message)
    '    End Try
    'End Sub

    Public Function getOutputFilePath() As String
        Return m_objProp.getPropertyKey("OutputFilePath")
    End Function

    Public Function getDatabaseType() As DatabaseType
        Dim dbType As String = m_objProp.getPropertyKey("database")
        Return DirectCast([Enum].Parse(GetType(DatabaseType), dbType), DatabaseType)
    End Function

    Public Function getServerName() As String
        Return m_objProp.getPropertyKey("servername")
    End Function

    Public Function getServerIntegratedAuthentication() As String
        Return m_objProp.getPropertyKey("IntegratedAuthentication")
    End Function

    Public Function getUserName() As String
        Return m_objProp.getPropertyKey("username")
    End Function

    Public Function getPassword() As String
        Return m_objProp.getPropertyKey("password")
    End Function

    Public Function getDatabasePathFromRegistry() As String
        Dim strDBPath As String
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS, False)

        If Not regKey Is Nothing Then
            strDBPath = regKey.GetValue("MdbPath")
        Else
            strDBPath = ""
        End If

        Return strDBPath
    End Function

    Public Function getDatabasePathFromPersistence() As String
        Return m_objProp.getPropertyKey("MdbPath")
    End Function

    Public Function printDebugTrace() As Boolean
        If m_objProp.getPropertyKey("debug").ToUpper = "TRUE" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub SetPersistenceProperty(ByVal PersistencePropertyPath As String, _
                                      ByVal PersistencePropertyValue As String)

        If Not m_objProp Is Nothing Then

            m_objProp.setPropertyKey(PersistencePropertyPath, PersistencePropertyValue)

        End If

    End Sub

    'TODO: Need to add a registry source for SQL UserName and SQL Data Source
    Public Function GetRegistryKey(ByVal Key As String) As String
        Dim strDBPath As String
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS, False)
        strDBPath = regKey.GetValue(Key)
        AddToTrace("RegKey: " & REGKEY_CLEARINGPOINT_SETTINGS & " DBPath: " & strDBPath)
        If strDBPath Is Nothing AndAlso Len(strDBPath) < 0 Then
            regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS_XP, False)
            strDBPath = regKey.GetValue(Key)
            AddToTrace("RegKey: " & REGKEY_CLEARINGPOINT_SETTINGS_XP & " DBPath: " & strDBPath)
        End If

        Return strDBPath
    End Function

End Class
