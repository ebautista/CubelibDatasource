<ComClass(CRecordset.ClassId, CRecordset.InterfaceId, CRecordset.EventsId)> _
Public Class CRecordset

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "9e69cfd6-de85-4b63-90da-7f9b424f0c7f"
    Public Const InterfaceId As String = "ef0bdae6-439c-4d20-8f48-654b9b28cf71"
    Public Const EventsId As String = "5da34e22-80c7-466f-b1d8-7e9a30b73458"
#End Region

    Private m_rstADO As ADODB.Recordset

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    'Parameterized constructor
    Public Sub New(ByRef rstADO As ADODB.Recordset)
        MyBase.New()
        m_rstADO = rstADO
    End Sub

    'Wrapper for End Of File
    Public Function EOF() As Boolean
        Return IIf(m_rstADO Is Nothing, True, m_rstADO.EOF)
    End Function

    'Wrapper for Begin Of File
    Public Function BOF() As Boolean
        Return IIf(m_rstADO Is Nothing, True, m_rstADO.BOF)
    End Function

    'Wrapper for MoveFirst
    Public Sub MoveFirst()
        m_rstADO.MoveFirst()
    End Sub

    'Wrapper for MoveLast
    Public Sub MoveLast()
        m_rstADO.MoveLast()
    End Sub

    'Wrapper for MoveNext
    Public Sub MoveNext()
        m_rstADO.MoveNext()
    End Sub

    'Wrapper for RecordCount
    Public Function RecordCount() As Integer
        Return m_rstADO.RecordCount
    End Function

    Public Property Fields(ByVal Index As Integer)
        Get
            Return m_rstADO.Fields(Index).Value
        End Get
        Set(value)
            m_rstADO.Fields(Index).Value = value
        End Set
    End Property

End Class


