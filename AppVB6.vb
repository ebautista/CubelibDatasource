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

    Property Comments As String
    Property CompanyName As String
    Property EXEName As String
    Property FileDescription As String
    Property HelpFile As String
    Property hInstance As Long
    Property LegalCopyright As String
    Property LegalTrademarks As String
    Property LogMode As Long
    Property LogPath As String
    Property Major As Integer
    Property Minor As Integer
    Property NonModalAllowed As Boolean
    Property Path As String
    Property PrevInstance As Boolean
    Property ProductName As String
    Property RetainedProject As Boolean
    Property Revision As Integer
    Property StartMode As Integer
    Property TaskVisible As Boolean
    Property ThreadID As Long
    Property Title As String
    Property UnattendedApp As Boolean

    Public Sub SetAppProperties(Optional ByVal Comments As String = "", _
                                Optional ByVal CompanyName As String = "", _
                                Optional ByVal EXEName As String = "", _
                                Optional ByVal FileDescription As String = "", _
                                Optional ByVal HelpFile As String = "", _
                                Optional ByVal hInstance As Integer = 0, _
                                Optional ByVal LegalCopyright As String = "", _
                                Optional ByVal LegalTrademarks As String = "", _
                                Optional ByVal LogMode As Integer = 0, _
                                Optional ByVal LogPath As String = "", _
                                Optional ByVal Major As Integer = 0, _
                                Optional ByVal Minor As Integer = 0, _
                                Optional ByVal NonModalAllowed As Boolean = False, _
                                Optional ByVal Path As String = "", _
                                Optional ByVal PrevInstance As Boolean = False, _
                                Optional ByVal ProductName As String = "", _
                                Optional ByVal RetainedProject As Boolean = False, _
                                Optional ByVal Revision As Integer = 0, _
                                Optional ByVal StartMode As Integer = 0, _
                                Optional ByVal TaskVisible As Boolean = False, _
                                Optional ByVal ThreadID As Integer = 0, _
                                Optional ByVal Title As String = "", _
                                Optional ByVal UnattendedApp As Boolean = False)

        Me.Comments = Comments
        Me.CompanyName = CompanyName
        Me.EXEName = EXEName
        Me.FileDescription = FileDescription
        Me.HelpFile = HelpFile
        Me.hInstance = hInstance
        Me.LegalCopyright = LegalCopyright
        Me.LegalTrademarks = LegalTrademarks
        Me.LogMode = LogMode
        Me.LogPath = LogPath
        Me.Major = Major
        Me.Minor = Minor
        Me.NonModalAllowed = NonModalAllowed
        Me.Path = Path
        Me.PrevInstance = PrevInstance
        Me.ProductName = ProductName
        Me.RetainedProject = RetainedProject
        Me.Revision = Revision
        Me.StartMode = StartMode
        Me.TaskVisible = TaskVisible
        Me.ThreadID = ThreadID
        Me.Title = Title
        Me.UnattendedApp = UnattendedApp
    End Sub
End Class


