<ComClass(AppVB6.ClassId, AppVB6.InterfaceId, AppVB6.EventsId)> _
Public Class AppVB6

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "e4bd91e1-414d-4de6-8f8d-7ed477164066"
    Public Const InterfaceId As String = "e0bd03e9-58f2-44d3-8c5d-64411462bb02"
    Public Const EventsId As String = "8ee16994-83af-4d9a-9f57-43ce532a3fcb"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    Public Property Comments As String
    Public Property CompanyName As String
    Public Property EXEName As String
    Public Property FileDescription As String
    Public Property HelpFile As String
    Public Property hInstance As Long
    Public Property LegalCopyright As String
    Public Property LegalTrademarks As String
    Public Property LogMode As Long
    Public Property LogPath As String
    Public Property Major As Integer
    Public Property Minor As Integer
    Public Property NonModalAllowed As Boolean
    Public Property Path As String
    Public Property PrevInstance As Boolean
    Public Property ProductName As String
    Public Property RetainedProject As Boolean
    Public Property Revision As Integer
    Public Property StartMode As Integer
    Public Property TaskVisible As Boolean
    Public Property ThreadID As Long
    Public Property Title As String
    Public Property UnattendedApp As Boolean

    Public Sub SetAppProperties(ByVal Comments1 As String, _
                                ByVal CompanyName1 As String)
        Me.Comments = Comments1
        Me.CompanyName = CompanyName1
    End Sub
End Class


