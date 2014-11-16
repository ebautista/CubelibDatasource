Imports System.ComponentModel
Imports CubeLibDataSource.CDatabaseProperty
Imports System.Data.Common
Imports System.Text

<ComClass(CDatasourceTransactional.ClassId, CDatasourceTransactional.InterfaceId, CDatasourceTransactional.EventsId)> _
Public Class CDatasourceTransactional
    Implements IDisposable

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "c4cc3e7b-e0fc-48bf-8597-9fbc1606d93d"
    Public Const InterfaceId As String = "3be10fc8-e22f-4ede-8b00-9741ffcc85d3"
    Public Const EventsId As String = "b9bccc11-8658-4174-8b96-bbc78bcd98dd"
#End Region
    Private WithEvents m_objBackgroundWorker As New BackgroundWorker

    Private managedResource As New System.ComponentModel.Component
    Private unmanagedResource As IntPtr
    Protected disposed As Boolean = False

    Private m_objDatabaseProperty As CDatabaseProperty

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overridable Overloads Sub Dispose( _
            ByVal disposing As Boolean)
        If Not Me.disposed Then
            If disposing Then
                managedResource.Dispose()
            End If

            m_objDatabaseProperty = Nothing
            unmanagedResource = IntPtr.Zero
            ' Note that this is not thread safe. 
        End If
        Me.disposed = True
    End Sub

    Public Sub Open(ByVal PersistencePath As String, _
                Optional ByVal DBTypeDef As DatabaseType = CDatabaseProperty.DatabaseType.ACCESS2003, _
                Optional ByVal DBServerNameDef As String = "", _
                Optional ByVal DBServerIntegratedAuthenticationDef As String = "FALSE", _
                Optional ByVal DBUserNameDef As String = "sa", _
                Optional ByVal DBPasswordDef As String = "wack2", _
                Optional ByVal DBPathDef As String = "", _
                Optional ByVal DataPathDef As String = "")

        m_objDatabaseProperty = New CDatabaseProperty(PersistencePath, _
                                                      , _
                                                      DBTypeDef, _
                                                      DBServerNameDef, _
                                                      DBServerIntegratedAuthenticationDef, _
                                                      DBUserNameDef, _
                                                      DBPasswordDef, _
                                                      DBPathDef, _
                                                      DataPathDef)



    End Sub

    Public Function GetDBConnection(ByVal Database As CDatasource.DBInstanceType) As ADODB.Connection
        If m_objDatabaseProperty Is Nothing Then
            Throw New ClearingPointException("Error in GetDBConnection - Persistence path was not initialized.")
        End If

        Dim strDBName As String = getDatabaseName(Database, "", m_objDatabaseProperty.getDatabaseType())
        Return getConnection(strDBName, m_objDatabaseProperty)
    End Function

    Private Function getConnection(ByVal DBName As String, _
                                   ByVal objProp As CDatabaseProperty) As ADODB.Connection
        Dim conTemp As New ADODB.Connection
        Dim sbConn As New StringBuilder

        Select Case objProp.getDatabaseType()
            Case CDatabaseProperty.DatabaseType.ACCESS97,
                CDatabaseProperty.DatabaseType.ACCESS2003
                sbConn.Append("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=")
                sbConn.Append(objProp.getDatabasePathFromPersistence())
                sbConn.Append("\")
                sbConn.Append(DBName)
                sbConn.Append(";Persist Security Info=False;Jet OLEDB:Database Password=")
                sbConn.Append(objProp.getPassword())

            Case CDatabaseProperty.DatabaseType.SQLSERVER

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

            Case Else
                Throw New NotSupportedException("ExecuteNonQuery: Unknown Database Type.")

        End Select

        conTemp.Open(sbConn.ToString())

        Return conTemp
    End Function

#Region " IDisposable Support "
    ' Do not change or add Overridable to these methods. 
    ' Put cleanup code in Dispose(ByVal disposing As Boolean). 
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        m_objBackgroundWorker.Dispose()

        Dispose(False)
        MyBase.Finalize()
    End Sub
#End Region

End Class


