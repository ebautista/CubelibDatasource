﻿Imports Microsoft.Win32

Public Class CDatabaseProperty
    Private Const PROPERTY_FILE As String = "persistence.txt"
    Private Const REGKEY_CLEARINGPOINT_SETTINGS As String = "Software\Wow6432Node\Cubepoint\Clearingpoint\Settings"
    Private Const REGKEY_CLEARINGPOINT_SETTINGS_XP As String = "Software\Cubepoint\ClearingPoint\Settings"
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

        If Not regKey Is Nothing Then
            strDBPath = regKey.GetValue("MdbPath")
        Else
            strDBPath = m_objProp.getPropertyKey("MdbPath")
        End If

        Return strDBPath
    End Function

    Public Function printDebugTrace() As Boolean
        If m_objProp.getPropertyKey("debug").ToUpper = "TRUE" Then
            Return True
        Else
            Return False
        End If
    End Function

    'Need to add a registry source for SQL UserName and SQL Data Source
    Public Function GetRegistryKey(ByVal Key As String) As String
        Dim strDBPath As String
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS, False)
        strDBPath = regKey.GetValue(Key)

        If strDBPath Is Nothing AndAlso Len(strDBPath) < 0 Then
            regKey = Registry.LocalMachine.OpenSubKey(REGKEY_CLEARINGPOINT_SETTINGS_XP, False)
            strDBPath = regKey.GetValue(Key)
        End If

        Return strDBPath
    End Function
End Class
