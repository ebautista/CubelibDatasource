Imports CubelibDatasource.CDatasource

Module MData

    Public Sub FindAndUpdateRowData(ByRef adoRow As ADODB.Recordset, ByVal TableName As DataTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case DataTableType.DBProperties
            Case DataTableType.MASTER
            Case DataTableType.MASTEREDINCTS
            Case DataTableType.MASTEREDINCTS2
            Case DataTableType.MASTEREDINCTSIE44
            Case DataTableType.MASTERNCTS
            Case DataTableType.MASTERPLDA
            Case DataTableType.OUTBOX
            Case DataTableType.REMARKS
            Case DataTableType.TEMPLATETREELINKS
            Case DataTableType.TEMPLATETREELINKS2003
            Case DataTableType.USERDEFINEDTEMPLATES

            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowData: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowData(ByRef adoRow As ADODB.Recordset, ByVal TableName As DataTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case DataTableType.DBProperties
            Case DataTableType.MASTER
            Case DataTableType.MASTEREDINCTS
            Case DataTableType.MASTEREDINCTS2
            Case DataTableType.MASTEREDINCTSIE44
            Case DataTableType.MASTERNCTS
            Case DataTableType.MASTERPLDA
            Case DataTableType.OUTBOX
            Case DataTableType.REMARKS
            Case DataTableType.TEMPLATETREELINKS
            Case DataTableType.TEMPLATETREELINKS2003
            Case DataTableType.USERDEFINEDTEMPLATES

            Case Else
                Throw New NotSupportedException("Error in InsertRowData: Unsupported enum encountered: " + TableName.GetType.Name)
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
