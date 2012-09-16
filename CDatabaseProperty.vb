Imports Microsoft.Win32

Public Class CDatabaseProperty
    Private Const PROPERTY_FILE As String = "persistence.txt"
    Private Const REGKEY_CLEARINGPOINT_SETTINGS As String = "Software\Wow6432Node\Cubepoint\Clearingpoint\Settings"

    Private m_objProp As New CProperty(AppDomain.CurrentDomain.BaseDirectory, PROPERTY_FILE)

    Public Enum DatabaseType
        SQLSERVER
        ACCESS
        ORACLE
        MYSQL
    End Enum

    Public Function getDatabaseType() As DatabaseType
        Dim dbType As String = m_objProp.getPropertyKey("database")
        Return DirectCast([Enum].Parse(GetType(DatabaseType), dbType), DatabaseType)
    End Function

    Public Function getServerName() As String
        Return m_objProp.getPropertyKey("servername")
    End Function

    Public Function getUserName() As String
        Return m_objProp.getPropertyKey("username")
    End Function

    Public Function getPassword() As String
        Return m_objProp.getPropertyKey("password")
    End Function

    Public Function getDatabasePath() As String
        Dim strDBPath As String
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS, False)
        strDBPath = regKey.GetValue("MdbPath")

        Return strDBPath
    End Function

    'Need to add a registry source for SQL UserName and SQL Data Source
    Public Function GetRegistryKey(ByVal Key As String) As String
        Dim strDBPath As String
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS, False)
        strDBPath = regKey.GetValue(Key)

        Return strDBPath
    End Function
End Class
