Imports CubelibDatasource.CDatasource

Module MEdifactHistory

    Public Sub FindAndUpdateRowEdifactHistory(ByRef adoRow As ADODB.Recordset, ByVal TableName As EdiHistoryTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case EdiHistoryTableType.BOX_SEARCH_MAP

            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowEdifactHistory: Unsupported enum encountered: " + TableName.GetType.Name)
        End Select

        If Not table Is Nothing AndAlso Not table.Rows Is Nothing AndAlso table.Rows.Count > 0 Then
            Dim rowToUpdate As DataRow = table.Rows(0)

            rowToUpdate.BeginEdit()
            For Each Field As ADODB.Field In adoRow.Fields
                rowToUpdate.SetField(Field.Name, Field.Value)
            Next
            rowToUpdate.EndEdit()

            adapter.RowUpdate(rowToUpdate)
        End If
    End Sub

    Public Sub InsertRowEdifactHistory(ByRef adoRow As ADODB.Recordset, ByVal TableName As EdiHistoryTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case EdiHistoryTableType.BOX_SEARCH_MAP

            Case Else
                Throw New NotSupportedException("Error in InsertRowEdifactHistory: Unsupported enum encountered: " + TableName.GetType.Name)
        End Select

        rowToInsert = table.NewRow
        rowToInsert.BeginEdit()
        For Each Field As ADODB.Field In adoRow.Fields
            rowToInsert.SetField(Field.Name, Field.Value)
        Next
        rowToInsert.EndEdit()

        table.Rows.Add(rowToInsert)
        adapter.TableUpdate(table)
        table.AcceptChanges()
    End Sub

End Module
