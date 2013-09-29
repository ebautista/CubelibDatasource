Imports CubelibDatasource.CDatasource

Module MSadbelHistory

    Public Sub FindAndUpdateRowSadbelHistory(ByRef adoRow As ADODB.Recordset, ByVal TableName As SadbelHistoryTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case SadbelHistoryTableType.COMBINED_NCTS
                adapter = New SADBEL_HISTORYTableAdapters.COMBINED_NCTSTableAdapter
                'table = adapter.GetByPK(adoRow.Fields("CODE").Value, Convert.ToDouble(adoRow.Fields("HEADER").Value))

            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_COLLI
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_CONTAINER
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_GEVOELIGE
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_GOEDEREN
            Case SadbelHistoryTableType.COMBINED_NCTS_HEADER
            Case SadbelHistoryTableType.COMBINED_NCTS_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.DBProperties
            Case SadbelHistoryTableType.EXPORT
            Case SadbelHistoryTableType.EXPORT_DETAIL
            Case SadbelHistoryTableType.EXPORT_HEADER
            Case SadbelHistoryTableType.IMPORT
            Case SadbelHistoryTableType.IMPORT_DETAIL
            Case SadbelHistoryTableType.IMPORT_HEADER
            Case SadbelHistoryTableType.InBoundDocs
            Case SadbelHistoryTableType.Inbounds
            Case SadbelHistoryTableType.MASTER
            Case SadbelHistoryTableType.MASTERNCTS
            Case SadbelHistoryTableType.MASTERPLDA
            Case SadbelHistoryTableType.NCTS
            Case SadbelHistoryTableType.NCTS_DETAIL
            Case SadbelHistoryTableType.NCTS_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.NCTS_DETAIL_COLLI
            Case SadbelHistoryTableType.NCTS_DETAIL_CONTAINER
            Case SadbelHistoryTableType.NCTS_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.NCTS_HEADER
            Case SadbelHistoryTableType.NCTS_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.OutboundDocs
            Case SadbelHistoryTableType.Outbounds
            Case SadbelHistoryTableType.PLDA_COMBINED
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_CONTAINER
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_HANDELAARS
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_HANDELAARS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_TRANSIT_OFFICES
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_ZEGELS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.PLDA_IMPORT
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_CONTAINER
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_HANDELAARS
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_ZELF
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER_HANDELAARS
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER_ZEGELS
            Case SadbelHistoryTableType.PLDA_MESSAGES
            Case SadbelHistoryTableType.REMARKS
            Case SadbelHistoryTableType.TRANSIT
            Case SadbelHistoryTableType.TRANSIT_DETAIL
            Case SadbelHistoryTableType.TRANSIT_HEADER
            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowSadbelHistory: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowSadbelHistory(ByRef adoRow As ADODB.Recordset, ByVal TableName As SadbelHistoryTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case SadbelHistoryTableType.COMBINED_NCTS
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_COLLI
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_CONTAINER
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_GEVOELIGE
            Case SadbelHistoryTableType.COMBINED_NCTS_DETAIL_GOEDEREN
            Case SadbelHistoryTableType.COMBINED_NCTS_HEADER
            Case SadbelHistoryTableType.COMBINED_NCTS_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.DBProperties
            Case SadbelHistoryTableType.EXPORT
            Case SadbelHistoryTableType.EXPORT_DETAIL
            Case SadbelHistoryTableType.EXPORT_HEADER
            Case SadbelHistoryTableType.IMPORT
            Case SadbelHistoryTableType.IMPORT_DETAIL
            Case SadbelHistoryTableType.IMPORT_HEADER
            Case SadbelHistoryTableType.InBoundDocs
            Case SadbelHistoryTableType.Inbounds
            Case SadbelHistoryTableType.MASTER
            Case SadbelHistoryTableType.MASTERNCTS
            Case SadbelHistoryTableType.MASTERPLDA
            Case SadbelHistoryTableType.NCTS
            Case SadbelHistoryTableType.NCTS_DETAIL
            Case SadbelHistoryTableType.NCTS_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.NCTS_DETAIL_COLLI
            Case SadbelHistoryTableType.NCTS_DETAIL_CONTAINER
            Case SadbelHistoryTableType.NCTS_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.NCTS_HEADER
            Case SadbelHistoryTableType.NCTS_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.OutboundDocs
            Case SadbelHistoryTableType.Outbounds
            Case SadbelHistoryTableType.PLDA_COMBINED
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_CONTAINER
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_HANDELAARS
            Case SadbelHistoryTableType.PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_HANDELAARS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_TRANSIT_OFFICES
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_ZEGELS
            Case SadbelHistoryTableType.PLDA_COMBINED_HEADER_ZEKERHEID
            Case SadbelHistoryTableType.PLDA_IMPORT
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_BIJZONDERE
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_CONTAINER
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_DOCUMENTEN
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_HANDELAARS
            Case SadbelHistoryTableType.PLDA_IMPORT_DETAIL_ZELF
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER_HANDELAARS
            Case SadbelHistoryTableType.PLDA_IMPORT_HEADER_ZEGELS
            Case SadbelHistoryTableType.PLDA_MESSAGES
            Case SadbelHistoryTableType.REMARKS
            Case SadbelHistoryTableType.TRANSIT
            Case SadbelHistoryTableType.TRANSIT_DETAIL
            Case SadbelHistoryTableType.TRANSIT_HEADER

            Case Else
                Throw New NotSupportedException("Error in InsertRowSadbelHistory: Unsupported enum encountered: " + TableName.GetType.Name)
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
