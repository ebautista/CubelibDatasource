Imports CubelibDatasource.CDatasource

Module MCRUD

    Public Sub DelegateUpdate(ByRef adoRow As ADODB.Recordset, ByRef pk() As Object, ByRef TableName As IConvertible)

        Dim type As Type = GetType(TableName)

        'If TableName.GetTypeCode.is Then

        'End If

    End Sub

    Public Sub FindAndUpdateTableSADBEL(ByRef adoRow As ADODB.Recordset, ByRef pk() As Object, ByVal TableName As SadbelTableType)
        Select Case TableName
            Case SadbelTableType.PLDA_IMPORT_HEADER
                Dim adapter As New SadbelTableAdapters.PLDA_IMPORT_HEADERTableAdapter
                Dim table As Sadbel.PLDA_IMPORT_HEADERDataTable = adapter.GetDataByCH(pk(0), pk(1))

                If Not table.Rows Is Nothing AndAlso table.Rows.Count > 0 Then
                    Dim rowToUpdate As DataRow = table.Rows(0)

                    rowToUpdate.BeginEdit()
                    For Each Field As ADODB.Field In adoRow.Fields
                        rowToUpdate.SetField(Field.Name, Field.Value)
                    Next
                    rowToUpdate.EndEdit()

                    adapter.Update(rowToUpdate)
                Else
                    AddToTrace("Error in CubelibDatasource.FindAndUpdateTable: No data found for : " & adoRow.Source)
                End If

            Case Else

        End Select

    End Sub

End Module
