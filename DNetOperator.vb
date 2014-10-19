<ComClass(DNetOperator.ClassId, DNetOperator.InterfaceId, DNetOperator.EventsId)> _
Public Class DNetOperator

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "01eadcea-44e9-49bb-9e4d-38b5ef4d82ab"
    Public Const InterfaceId As String = "2c042b97-4cc3-4de2-a43d-6012e0659af7"
    Public Const EventsId As String = "2187022c-ee59-4069-847f-f4922d27138d"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    Property Selected As Boolean
    Property Id As Long
    Property DType As Integer
    Property OperatorType As Integer
    Property OperatorTabType As Integer
    Property OperatorVentureNumber As String
    Property OperatorDeclarantStatus As String
    Property OperatorRegistrationNumber As String
    Property OperatorCapacity As String
    Property OperatorAuthorisedIdentity As String
    Property OperatorVentureName As String
    Property OperatorAddress1 As String
    Property OperatorAddress2 As String
    Property OperatorPostalCode As String
    Property OperatorStateProvince As String
    Property OperatorCity As String
    Property OperatorCountry As String
    Property OperatorContactPersonName As String
    Property OperatorContactPhoneNumber As String
    Property OperatorContactPersonFaxNumber As String
    Property OperatorContactEmail As String
    Property Status As DNetPickList.RecordStatus
End Class


