<ComClass(DNetPickList.ClassId, DNetPickList.InterfaceId, DNetPickList.EventsId)> _
Public Class DNetPickList

#Region "COM GUIDs"
    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.
    Public Const ClassId As String = "2cf4b7b4-16a5-4b83-ba5a-e17d3889cceb"
    Public Const InterfaceId As String = "73f16f9f-2421-4c9b-928b-8828561da6ce"
    Public Const EventsId As String = "c2990473-c295-4656-8c1f-eb93a56a5dad"
#End Region

    ' A creatable COM class must have a Public Sub New() 
    ' with no parameters, otherwise, the class will not be 
    ' registered in the COM registry and cannot be created 
    ' via CreateObject.
    Public Sub New()
        MyBase.New()
    End Sub

    Public Enum RecordStatus
        RecordNew
        RecordUpdated
        RecordDeleted
        RecordUnchaged
    End Enum

    Property Operators As Dictionary(Of Integer, DNetOperator)

    Public Function GetSelected() As DNetOperator
        For Each item As KeyValuePair(Of Integer, DNetOperator) In Operators
            If item.Value.Selected Then
                Return item.Value
            End If
        Next

        Return Nothing
    End Function

    Public Sub PopulateList(ByRef record As ADODB.Recordset)
        Dim index As Integer = 0
        Dim member As DNetOperator

        If record Is Nothing Or record.RecordCount = 0 Then Return
        record.MoveFirst()

        Do While record.EOF
            member = New DNetOperator
            member.Selected = False
            member.Status = RecordStatus.RecordUnchaged
            member.Id = record.Fields("Operator_ID").Value
            member.DType = record.Fields("DType").Value
            member.OperatorType = record.Fields("Operator_Type").Value
            member.OperatorTabType = record.Fields("Operator_TabType").Value
            member.OperatorVentureNumber = record.Fields("Operator_VentureNumber").Value
            member.OperatorDeclarantStatus = record.Fields("Operator_DeclarantStatus").Value
            member.OperatorRegistrationNumber = record.Fields("Operator_RegistrationNumber").Value
            member.OperatorCapacity = record.Fields("Operator_Capacity").Value
            member.OperatorAuthorisedIdentity = record.Fields("Operator_AuthorisedIdentity").Value
            member.OperatorVentureName = record.Fields("Operator_VentureName").Value
            member.OperatorAddress1 = record.Fields("Operator_Address1").Value
            member.OperatorAddress2 = record.Fields("Operator_Address2").Value
            member.OperatorPostalCode = record.Fields("Operator_PostalCode").Value
            member.OperatorStateProvince = record.Fields("Operator_StateProvince").Value
            member.OperatorCity = record.Fields("Operator_City").Value
            member.OperatorCountry = record.Fields("Operator_Country").Value
            member.OperatorContactPersonName = record.Fields("Operator_ContactPersonName").Value
            member.OperatorContactPhoneNumber = record.Fields("Operator_ContactTelNumber").Value
            member.OperatorContactPersonFaxNumber = record.Fields("Operator_ContactFaxNumber").Value
            member.OperatorContactEmail = record.Fields("Operator_ContactEmail").Value

            Operators.Add(member.Id, member)

            record.MoveNext()
        Loop
    End Sub

    Public Sub UpdateRecord(ByRef member As DNetOperator)
        If member Is Nothing Then Return

        If member.Status = RecordStatus.RecordNew Then
            member.Status = RecordStatus.RecordNew
        Else
            member.Status = RecordStatus.RecordUpdated
        End If

        ' Overwrites the original member
        Operators.Item(member.Id) = member
    End Sub

    Public Function AddRecord(ByRef member As DNetOperator) As Integer
        Dim minTempPk As Integer = 0

        For Each index As Integer In Operators.Keys
            If minTempPk > index Then
                minTempPk = index
            End If
        Next

        member.Id = minTempPk - 1
        member.Status = RecordStatus.RecordNew
        Operators.Add(member.Id, member)

        Return member.Id
    End Function

    Public Sub DeleteRecord(ByRef member As DNetOperator)
        Dim item As DNetOperator

        If Operators.ContainsKey(member.Id) Then
            item = Operators.Item(member.Id)

            If item.Status = RecordStatus.RecordNew Then
                Operators.Remove(member.Id)
            Else
                item.Status = RecordStatus.RecordDeleted
            End If
        End If
    End Sub
End Class


