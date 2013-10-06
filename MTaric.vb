Imports CubelibDatasource.CDatasource

Module MTaric

    Public Sub FindAndUpdateRowTaric(ByRef adoRow As ADODB.Recordset, ByVal TableName As TaricTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case TaricTableType.CLIENTS
                adapter = New TARICTableAdapters.CLIENTSTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TARIC CODE").Value)

            Case TaricTableType.CN
                adapter = New TARICTableAdapters.CNTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CN CODE").Value)

            Case TaricTableType.COMMON
                adapter = New TARICTableAdapters.COMMONTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TARIC CODE").Value)

            Case TaricTableType.DBProperties
                AddToTrace("TaricTableType.DBProperties does not have an update support.")

            Case TaricTableType.EXPORT
                adapter = New TARICTableAdapters.EXPORTTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TARIC CODE").Value)

            Case TaricTableType.IMPORT
                adapter = New TARICTableAdapters.IMPORTTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TARIC CODE").Value)

            Case TaricTableType.PROPERTIES
                AddToTrace("TaricTableType.PROPERTIES does not have an update support.")

            Case TaricTableType.SUPP_UNITS
                AddToTrace("TaricTableType.SUPP_UNITS does not have an update support.")

            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowTaric: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowTaric(ByRef adoRow As ADODB.Recordset, ByVal TableName As TaricTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case TaricTableType.CLIENTS
                adapter = New TARICTableAdapters.CLIENTSTableAdapter
                table = New TARIC.CLIENTSDataTable

            Case TaricTableType.CN
                adapter = New TARICTableAdapters.CNTableAdapter
                table = New TARIC.CNDataTable

            Case TaricTableType.COMMON
                adapter = New TARICTableAdapters.COMMONTableAdapter
                table = New TARIC.COMMONDataTable

            Case TaricTableType.DBProperties
                adapter = New TARICTableAdapters.DBPropertiesTableAdapter
                table = New TARIC.DBPropertiesDataTable

            Case TaricTableType.EXPORT
                adapter = New TARICTableAdapters.EXPORTTableAdapter
                table = New TARIC.EXPORTDataTable

            Case TaricTableType.IMPORT
                adapter = New TARICTableAdapters.IMPORTTableAdapter
                table = New TARIC.IMPORTDataTable

            Case TaricTableType.PROPERTIES
                adapter = New TARICTableAdapters.PROPERTIESTableAdapter
                table = New TARIC.PROPERTIESDataTable

            Case TaricTableType.SUPP_UNITS
                adapter = New TARICTableAdapters.SUPP_UNITSTableAdapter
                table = New TARIC.SUPP_UNITSDataTable

            Case Else
                Throw New NotSupportedException("Error in InsertRowTaric: Unsupported enum encountered: " + TableName.GetType.Name)
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
