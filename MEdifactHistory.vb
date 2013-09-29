Imports CubelibDatasource.CDatasource

Module MEdifactHistory

    Public Sub FindAndUpdateRowEdifactHistory(ByRef adoRow As ADODB.Recordset, ByVal TableName As EdiHistoryTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case EdiHistoryTableType.BOX_SEARCH_MAP
            Case EdiHistoryTableType.DATA_NCTS
            Case EdiHistoryTableType.DATA_NCTS_BERICHT
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_DOUANEKANTOOR
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_HANDELAAR
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_HOOFDING
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_CONTROLE
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_INCIDENT
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
            Case EdiHistoryTableType.DATA_NCTS_BGM
            Case EdiHistoryTableType.DATA_NCTS_CNT
            Case EdiHistoryTableType.DATA_NCTS_CST
            Case EdiHistoryTableType.DATA_NCTS_DETAIL
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_BIJZONDERE
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_COLLI
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_CONTAINER
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_DOCUMENTEN
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_RESULTATEN
            Case EdiHistoryTableType.DATA_NCTS_DOC
            Case EdiHistoryTableType.DATA_NCTS_DTM
            Case EdiHistoryTableType.DATA_NCTS_FTX
            Case EdiHistoryTableType.DATA_NCTS_GIR
            Case EdiHistoryTableType.DATA_NCTS_GIS
            Case EdiHistoryTableType.DATA_NCTS_HEADER
            Case EdiHistoryTableType.DATA_NCTS_HEADER_RESULTATEN
            Case EdiHistoryTableType.DATA_NCTS_HEADER_ZEKERHEID
            Case EdiHistoryTableType.DATA_NCTS_LOC
            Case EdiHistoryTableType.DATA_NCTS_MEA
            Case EdiHistoryTableType.DATA_NCTS_MESSAGES
            Case EdiHistoryTableType.DATA_NCTS_NAD
            Case EdiHistoryTableType.DATA_NCTS_PAC
            Case EdiHistoryTableType.DATA_NCTS_PCI
            Case EdiHistoryTableType.DATA_NCTS_RFF
            Case EdiHistoryTableType.DATA_NCTS_SEL
            Case EdiHistoryTableType.DATA_NCTS_TDT
            Case EdiHistoryTableType.DATA_NCTS_TOD
            Case EdiHistoryTableType.DATA_NCTS_TPL
            Case EdiHistoryTableType.DATA_NCTS_UNB
            Case EdiHistoryTableType.DATA_NCTS_UNH
            Case EdiHistoryTableType.DATA_NCTS_UNS
            Case EdiHistoryTableType.DATA_NCTS_UNT
            Case EdiHistoryTableType.DATA_NCTS_UNZ
            Case EdiHistoryTableType.DBProperties
            Case EdiHistoryTableType.EDI_TMS
            Case EdiHistoryTableType.EDI_TMS_CORE
            Case EdiHistoryTableType.EDI_TMS_GROUPS
            Case EdiHistoryTableType.EDI_TMS_ITEMS
            Case EdiHistoryTableType.EDI_TMS_SEGMENTS
            Case EdiHistoryTableType.MASTEREDINCTS
            Case EdiHistoryTableType.MASTEREDINCTS2
            Case EdiHistoryTableType.MASTEREDINCTSIE44
            Case EdiHistoryTableType.NCTS_IEM
            Case EdiHistoryTableType.NCTS_IEM_MAP
            Case EdiHistoryTableType.NCTS_IEM_MAP_CONDITIONS
            Case EdiHistoryTableType.NCTS_IEM_TMS
            Case EdiHistoryTableType.NCTS_ITM_BGM
            Case EdiHistoryTableType.NCTS_ITM_CNT
            Case EdiHistoryTableType.NCTS_ITM_CST
            Case EdiHistoryTableType.NCTS_ITM_DOC
            Case EdiHistoryTableType.NCTS_ITM_DTM
            Case EdiHistoryTableType.NCTS_ITM_FTX
            Case EdiHistoryTableType.NCTS_ITM_GIR
            Case EdiHistoryTableType.NCTS_ITM_GIS
            Case EdiHistoryTableType.NCTS_ITM_LOC
            Case EdiHistoryTableType.NCTS_ITM_MEA
            Case EdiHistoryTableType.NCTS_ITM_NAD
            Case EdiHistoryTableType.NCTS_ITM_PAC
            Case EdiHistoryTableType.NCTS_ITM_PCI
            Case EdiHistoryTableType.NCTS_ITM_RFF
            Case EdiHistoryTableType.NCTS_ITM_SEL
            Case EdiHistoryTableType.NCTS_ITM_TDT
            Case EdiHistoryTableType.NCTS_ITM_TOD
            Case EdiHistoryTableType.NCTS_ITM_TPL
            Case EdiHistoryTableType.NCTS_ITM_UNB
            Case EdiHistoryTableType.NCTS_ITM_UNH
            Case EdiHistoryTableType.NCTS_ITM_UNS
            Case EdiHistoryTableType.NCTS_ITM_UNT
            Case EdiHistoryTableType.NCTS_ITM_UNZ
            Case EdiHistoryTableType.OUTPUT_FILE_FIELDS
            Case EdiHistoryTableType.OUTPUT_FILE_GROUPS

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
            Case EdiHistoryTableType.DATA_NCTS
            Case EdiHistoryTableType.DATA_NCTS_BERICHT
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_DOUANEKANTOOR
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_HANDELAAR
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_HOOFDING
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_CONTROLE
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_INCIDENT
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
            Case EdiHistoryTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
            Case EdiHistoryTableType.DATA_NCTS_BGM
            Case EdiHistoryTableType.DATA_NCTS_CNT
            Case EdiHistoryTableType.DATA_NCTS_CST
            Case EdiHistoryTableType.DATA_NCTS_DETAIL
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_BIJZONDERE
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_COLLI
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_CONTAINER
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_DOCUMENTEN
            Case EdiHistoryTableType.DATA_NCTS_DETAIL_RESULTATEN
            Case EdiHistoryTableType.DATA_NCTS_DOC
            Case EdiHistoryTableType.DATA_NCTS_DTM
            Case EdiHistoryTableType.DATA_NCTS_FTX
            Case EdiHistoryTableType.DATA_NCTS_GIR
            Case EdiHistoryTableType.DATA_NCTS_GIS
            Case EdiHistoryTableType.DATA_NCTS_HEADER
            Case EdiHistoryTableType.DATA_NCTS_HEADER_RESULTATEN
            Case EdiHistoryTableType.DATA_NCTS_HEADER_ZEKERHEID
            Case EdiHistoryTableType.DATA_NCTS_LOC
            Case EdiHistoryTableType.DATA_NCTS_MEA
            Case EdiHistoryTableType.DATA_NCTS_MESSAGES
            Case EdiHistoryTableType.DATA_NCTS_NAD
            Case EdiHistoryTableType.DATA_NCTS_PAC
            Case EdiHistoryTableType.DATA_NCTS_PCI
            Case EdiHistoryTableType.DATA_NCTS_RFF
            Case EdiHistoryTableType.DATA_NCTS_SEL
            Case EdiHistoryTableType.DATA_NCTS_TDT
            Case EdiHistoryTableType.DATA_NCTS_TOD
            Case EdiHistoryTableType.DATA_NCTS_TPL
            Case EdiHistoryTableType.DATA_NCTS_UNB
            Case EdiHistoryTableType.DATA_NCTS_UNH
            Case EdiHistoryTableType.DATA_NCTS_UNS
            Case EdiHistoryTableType.DATA_NCTS_UNT
            Case EdiHistoryTableType.DATA_NCTS_UNZ
            Case EdiHistoryTableType.DBProperties
            Case EdiHistoryTableType.EDI_TMS
            Case EdiHistoryTableType.EDI_TMS_CORE
            Case EdiHistoryTableType.EDI_TMS_GROUPS
            Case EdiHistoryTableType.EDI_TMS_ITEMS
            Case EdiHistoryTableType.EDI_TMS_SEGMENTS
            Case EdiHistoryTableType.MASTEREDINCTS
            Case EdiHistoryTableType.MASTEREDINCTS2
            Case EdiHistoryTableType.MASTEREDINCTSIE44
            Case EdiHistoryTableType.NCTS_IEM
            Case EdiHistoryTableType.NCTS_IEM_MAP
            Case EdiHistoryTableType.NCTS_IEM_MAP_CONDITIONS
            Case EdiHistoryTableType.NCTS_IEM_TMS
            Case EdiHistoryTableType.NCTS_ITM_BGM
            Case EdiHistoryTableType.NCTS_ITM_CNT
            Case EdiHistoryTableType.NCTS_ITM_CST
            Case EdiHistoryTableType.NCTS_ITM_DOC
            Case EdiHistoryTableType.NCTS_ITM_DTM
            Case EdiHistoryTableType.NCTS_ITM_FTX
            Case EdiHistoryTableType.NCTS_ITM_GIR
            Case EdiHistoryTableType.NCTS_ITM_GIS
            Case EdiHistoryTableType.NCTS_ITM_LOC
            Case EdiHistoryTableType.NCTS_ITM_MEA
            Case EdiHistoryTableType.NCTS_ITM_NAD
            Case EdiHistoryTableType.NCTS_ITM_PAC
            Case EdiHistoryTableType.NCTS_ITM_PCI
            Case EdiHistoryTableType.NCTS_ITM_RFF
            Case EdiHistoryTableType.NCTS_ITM_SEL
            Case EdiHistoryTableType.NCTS_ITM_TDT
            Case EdiHistoryTableType.NCTS_ITM_TOD
            Case EdiHistoryTableType.NCTS_ITM_TPL
            Case EdiHistoryTableType.NCTS_ITM_UNB
            Case EdiHistoryTableType.NCTS_ITM_UNH
            Case EdiHistoryTableType.NCTS_ITM_UNS
            Case EdiHistoryTableType.NCTS_ITM_UNT
            Case EdiHistoryTableType.NCTS_ITM_UNZ
            Case EdiHistoryTableType.OUTPUT_FILE_FIELDS
            Case EdiHistoryTableType.OUTPUT_FILE_GROUPS

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
