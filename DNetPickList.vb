Imports ADODB

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

    Private Operators As Dictionary(Of Integer, DNetOperator)

    Public ReadOnly Property OperatorList() As Dictionary(Of Integer, DNetOperator)
        Get
            Return Operators
        End Get
    End Property

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

        Operators = New Dictionary(Of Integer, DNetOperator)

        If record Is Nothing Or record.RecordCount = 0 Then Return
        record.MoveFirst()

        Do While Not record.EOF
            member = New DNetOperator
            member.Selected = False
            member.Status = RecordStatus.RecordUnchaged
            member.Id = FNullField(record, "Operator_ID")
            member.DType = FNullField(record, "DType")
            member.OperatorType = FNullField(record, "Operator_Type")
            member.OperatorTabType = FNullField(record, "Operator_TabType")
            member.OperatorVentureNumber = FNullField(record, "Operator_VentureNumber")
            member.OperatorDeclarantStatus = FNullField(record, "Operator_DeclarantStatus")
            member.OperatorRegistrationNumber = FNullField(record, "Operator_RegistrationNumber")
            member.OperatorCapacity = FNullField(record, "Operator_Capacity")
            member.OperatorAuthorisedIdentity = FNullField(record, "Operator_AuthorisedIdentity")
            member.OperatorVentureName = FNullField(record, "Operator_VentureName")
            member.OperatorAddress1 = FNullField(record, "Operator_Address1")
            member.OperatorAddress2 = FNullField(record, "Operator_Address2")
            member.OperatorPostalCode = FNullField(record, "Operator_PostalCode")
            member.OperatorStateProvince = FNullField(record, "Operator_StateProvince")
            member.OperatorCity = FNullField(record, "Operator_City")
            member.OperatorCountry = FNullField(record, "Operator_Country")
            member.OperatorContactPersonName = FNullField(record, "Operator_ContactPersonName")
            member.OperatorContactPhoneNumber = FNullField(record, "Operator_ContactTelNumber")
            member.OperatorContactPersonFaxNumber = FNullField(record, "Operator_ContactFaxNumber")
            member.OperatorContactEmail = FNullField(record, "Operator_ContactEmail")

            Operators.Add(member.Id, member)

            record.MoveNext()
        Loop
    End Sub

    Public Function GetRecord(ByVal pk As Integer) As DNetOperator
        Return Operators.Item(pk)
    End Function

    Public Sub UpdateRecord(ByVal member As DNetOperator)
        If member Is Nothing Then Return

        If member.Status = RecordStatus.RecordNew Then
            member.Status = RecordStatus.RecordNew
        Else
            member.Status = RecordStatus.RecordUpdated
        End If

        ' Overwrites the original member
        Operators.Item(member.Id) = member
    End Sub

    Public Function AddRecord(ByVal member As DNetOperator) As Integer
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

    Public Sub DeleteRecord(ByVal pk As Integer)
        Dim item As DNetOperator

        If Operators.ContainsKey(pk) Then
            item = Operators.Item(pk)

            If item.Status = RecordStatus.RecordNew Then
                Operators.Remove(pk)
            Else
                item.Status = RecordStatus.RecordDeleted
            End If
        End If
    End Sub

    Public Sub CommitChanges(ByVal PersistencePath As String)
        Dim objSource As New CDatasource
        Dim strCommand As String

        objSource.UpdatePersistence(PersistencePropertyType.MDB_PATH, PersistencePath)

        For Each item As DNetOperator In Operators.Values
            Select Case item.Status
                Case RecordStatus.RecordUnchaged
                    ' Do Nothing

                Case RecordStatus.RecordDeleted
                    strCommand = vbNullString
                    strCommand = strCommand & "DELETE "
                    strCommand = strCommand & "FROM "
                    strCommand = strCommand & "OPERATORS "
                    strCommand = strCommand & "WHERE [Operator_ID] = " & item.Id
                    objSource.ExecuteNonQuery(strCommand, CDatasource.DBInstanceType.DATABASE_SADBEL)

                Case RecordStatus.RecordNew
                    strCommand = vbNullString
                    strCommand = strCommand & "INSERT INTO "
                    strCommand = strCommand & "OPERATORS "
                    strCommand = strCommand & "("
                    strCommand = strCommand & "[DTYPE],"
                    strCommand = strCommand & "[OPERATOR_TYPE],"
                    strCommand = strCommand & "[OPERATOR_TABTYPE],"
                    strCommand = strCommand & "[OPERATOR_VENTURENUMBER],"
                    strCommand = strCommand & "[OPERATOR_DECLARANTSTATUS],"
                    strCommand = strCommand & "[OPERATOR_REGISTRATIONNUMBER],"
                    strCommand = strCommand & "[OPERATOR_CAPACITY],"
                    strCommand = strCommand & "[OPERATOR_AUTHORISEDIDENTITY],"
                    strCommand = strCommand & "[OPERATOR_VENTURENAME],"
                    strCommand = strCommand & "[OPERATOR_ADDRESS1],"
                    strCommand = strCommand & "[OPERATOR_ADDRESS2],"
                    strCommand = strCommand & "[OPERATOR_POSTALCODE],"
                    strCommand = strCommand & "[OPERATOR_STATEPROVINCE],"
                    strCommand = strCommand & "[OPERATOR_CITY],"
                    strCommand = strCommand & "[OPERATOR_COUNTRY],"
                    strCommand = strCommand & "[OPERATOR_CONTACTPERSONNAME],"
                    strCommand = strCommand & "[OPERATOR_CONTACTTELNUMBER],"
                    strCommand = strCommand & "[OPERATOR_CONTACTFAXNUMBER],"
                    strCommand = strCommand & "[OPERATOR_CONTACTEMAIL]"
                    strCommand = strCommand & ") "
                    strCommand = strCommand & "VALUES "
                    strCommand = strCommand & "("
                    strCommand = strCommand & "" & item.DType & ", "
                    strCommand = strCommand & "" & item.OperatorType & ", "
                    strCommand = strCommand & "" & item.OperatorTabType & ", "
                    strCommand = strCommand & "'" & item.OperatorVentureNumber & "', "
                    strCommand = strCommand & "'" & item.OperatorDeclarantStatus & "', "
                    strCommand = strCommand & "'" & item.OperatorRegistrationNumber & "', "
                    strCommand = strCommand & "'" & item.OperatorCapacity & "', "
                    strCommand = strCommand & "'" & item.OperatorAuthorisedIdentity & "', "
                    strCommand = strCommand & "'" & item.OperatorVentureName & "', "
                    strCommand = strCommand & "'" & item.OperatorAddress1 & "', "
                    strCommand = strCommand & "'" & item.OperatorAddress2 & "', "
                    strCommand = strCommand & "'" & item.OperatorPostalCode & "', "
                    strCommand = strCommand & "'" & item.OperatorStateProvince & "', "
                    strCommand = strCommand & "'" & item.OperatorCity & "', "
                    strCommand = strCommand & "'" & item.OperatorCountry & "', "
                    strCommand = strCommand & "'" & item.OperatorContactPersonName & "', "
                    strCommand = strCommand & "'" & item.OperatorContactPhoneNumber & "', "
                    strCommand = strCommand & "'" & item.OperatorContactPersonFaxNumber & "', "
                    strCommand = strCommand & "'" & item.OperatorContactEmail & "' "
                    strCommand = strCommand & ")"
                    objSource.ExecuteNonQuery(strCommand, CDatasource.DBInstanceType.DATABASE_SADBEL)

                Case RecordStatus.RecordUpdated
                    strCommand = vbNullString
                    strCommand = strCommand & "UPDATE OP "
                    strCommand = strCommand & "SET "
                    strCommand = strCommand & "[DTYPE] = " & item.DType & ", "
                    strCommand = strCommand & "[OPERATOR_TYPE] = " & item.OperatorType & ", "
                    strCommand = strCommand & "[OPERATOR_TABTYPE] = " & item.OperatorTabType & ", "
                    strCommand = strCommand & "[OPERATOR_VENTURENUMBER] = '" & item.OperatorVentureNumber & "', "
                    strCommand = strCommand & "[OPERATOR_DECLARANTSTATUS] = '" & item.OperatorDeclarantStatus & "', "
                    strCommand = strCommand & "[OPERATOR_REGISTRATIONNUMBER] = '" & item.OperatorRegistrationNumber & "', "
                    strCommand = strCommand & "[OPERATOR_CAPACITY] = '" & item.OperatorCapacity & "', "
                    strCommand = strCommand & "[OPERATOR_AUTHORISEDIDENTITY] = '" & item.OperatorAuthorisedIdentity & "', "
                    strCommand = strCommand & "[OPERATOR_VENTURENAME] = '" & item.OperatorVentureName & "', "
                    strCommand = strCommand & "[OPERATOR_ADDRESS1] = '" & item.OperatorAddress1 & "', "
                    strCommand = strCommand & "[OPERATOR_ADDRESS2] = '" & item.OperatorAddress2 & "', "
                    strCommand = strCommand & "[OPERATOR_POSTALCODE] = '" & item.OperatorPostalCode & "', "
                    strCommand = strCommand & "[OPERATOR_STATEPROVINCE] = '" & item.OperatorStateProvince & "', "
                    strCommand = strCommand & "[OPERATOR_CITY] = '" & item.OperatorCity & "', "
                    strCommand = strCommand & "[OPERATOR_COUNTRY] = '" & item.OperatorCountry & "', "
                    strCommand = strCommand & "[OPERATOR_CONTACTPERSONNAME] = '" & item.OperatorContactPersonName & "', "
                    strCommand = strCommand & "[OPERATOR_CONTACTTELNUMBER] = '" & item.OperatorContactPhoneNumber & "', "
                    strCommand = strCommand & "[OPERATOR_CONTACTFAXNUMBER] = '" & item.OperatorContactPersonFaxNumber & "', "
                    strCommand = strCommand & "[OPERATOR_CONTACTEMAIL] = '" & item.OperatorContactEmail & "', "
                    strCommand = strCommand & "FROM "
                    strCommand = strCommand & "OPERATORS OP "
                    strCommand = strCommand & "WHERE [Operator_ID] = " & item.Id
                    objSource.ExecuteNonQuery(strCommand, CDatasource.DBInstanceType.DATABASE_SADBEL)

            End Select
        Next
    End Sub

    Public Function FNullField(ByRef record As ADODB.Recordset, ByVal columnName As String) As Object
        Dim Data As Object = record.Fields(columnName).Value

        If (Data Is Nothing) Or IsDBNull(Data) Then
            Select Case record.Fields(columnName).Type
                Case DataTypeEnum.adInteger
                    Return 0
                Case DataTypeEnum.adBoolean
                    Return False
                Case DataTypeEnum.adDate
                    Return vbNull
                Case DataTypeEnum.adDouble
                    Return 0
                Case DataTypeEnum.adNumeric
                    Return 0
                Case DataTypeEnum.adLongVarWChar
                    Return ""
                Case DataTypeEnum.adSingle
                    Return 0
                Case DataTypeEnum.adUnsignedTinyInt
                    Return 0
                Case DataTypeEnum.adSmallInt
                    Return 0
                Case DataTypeEnum.adLongVarBinary
                    Return vbNull
                Case DataTypeEnum.adVarWChar
                    Return ""
                Case DataTypeEnum.adLongVarChar
                    Return ""
                Case DataTypeEnum.adVarChar
                    Return ""
                Case Else
                    Return ""
            End Select
        End If

        Return Data
    End Function

End Class


