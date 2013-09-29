Imports CubelibDatasource.CDatasource

Module MEdifact

    Public Sub FindAndUpdateRowEdifact(ByRef adoRow As ADODB.Recordset, ByVal TableName As EdifactTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case EdifactTableType.BOX_SEARCH_MAP
            Case EdifactTableType.DATA_NCTS
            Case EdifactTableType.DATA_NCTS_BERICHT
            Case EdifactTableType.DATA_NCTS_BERICHT_DOUANEKANTOOR
            Case EdifactTableType.DATA_NCTS_BERICHT_HANDELAAR
            Case EdifactTableType.DATA_NCTS_BERICHT_HOOFDING
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_CONTROLE
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_INCIDENT
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
            Case EdifactTableType.DATA_NCTS_BGM
            Case EdifactTableType.DATA_NCTS_CNT
            Case EdifactTableType.DATA_NCTS_CST
            Case EdifactTableType.DATA_NCTS_DETAIL
            Case EdifactTableType.DATA_NCTS_DETAIL_BIJZONDERE
            Case EdifactTableType.DATA_NCTS_DETAIL_COLLI
            Case EdifactTableType.DATA_NCTS_DETAIL_CONTAINER
            Case EdifactTableType.DATA_NCTS_DETAIL_DOCUMENTEN
            Case EdifactTableType.DATA_NCTS_DETAIL_RESULTATEN
            Case EdifactTableType.DATA_NCTS_DOC
            Case EdifactTableType.DATA_NCTS_DTM
            Case EdifactTableType.DATA_NCTS_FTX
            Case EdifactTableType.DATA_NCTS_GIR
            Case EdifactTableType.DATA_NCTS_GIS
            Case EdifactTableType.DATA_NCTS_HEADER
            Case EdifactTableType.DATA_NCTS_HEADER_RESULTATEN
            Case EdifactTableType.DATA_NCTS_HEADER_ZEKERHEID
            Case EdifactTableType.DATA_NCTS_LOC
            Case EdifactTableType.DATA_NCTS_MEA
            Case EdifactTableType.DATA_NCTS_MESSAGES
            Case EdifactTableType.DATA_NCTS_NAD
            Case EdifactTableType.DATA_NCTS_PAC
            Case EdifactTableType.DATA_NCTS_PCI
            Case EdifactTableType.DATA_NCTS_RFF
            Case EdifactTableType.DATA_NCTS_SEL
            Case EdifactTableType.DATA_NCTS_TDT
            Case EdifactTableType.DATA_NCTS_TOD
            Case EdifactTableType.DATA_NCTS_TPL
            Case EdifactTableType.DATA_NCTS_UNB
            Case EdifactTableType.DATA_NCTS_UNH
            Case EdifactTableType.DATA_NCTS_UNS
            Case EdifactTableType.DATA_NCTS_UNT
            Case EdifactTableType.DATA_NCTS_UNZ
            Case EdifactTableType.DBProperties
            Case EdifactTableType.EDI_TMS
            Case EdifactTableType.EDI_TMS_CORE
            Case EdifactTableType.EDI_TMS_GROUPS
            Case EdifactTableType.EDI_TMS_ITEMS
            Case EdifactTableType.EDI_TMS_SEGMENTS
            Case EdifactTableType.NCTS_DEPARTURE_FOLLOW_UP_REQUEST
            Case EdifactTableType.NCTS_IEM
            Case EdifactTableType.NCTS_IEM_MAP
            Case EdifactTableType.NCTS_IEM_MAP_CONDITIONS
            Case EdifactTableType.NCTS_IEM_TMS
            Case EdifactTableType.NCTS_ITM_BGM
            Case EdifactTableType.NCTS_ITM_CNT
            Case EdifactTableType.NCTS_ITM_CST
            Case EdifactTableType.NCTS_ITM_DOC
            Case EdifactTableType.NCTS_ITM_DTM
            Case EdifactTableType.NCTS_ITM_FTX
            Case EdifactTableType.NCTS_ITM_GIR
            Case EdifactTableType.NCTS_ITM_GIS
            Case EdifactTableType.NCTS_ITM_LOC
            Case EdifactTableType.NCTS_ITM_MEA
            Case EdifactTableType.NCTS_ITM_NAD
            Case EdifactTableType.NCTS_ITM_PAC
            Case EdifactTableType.NCTS_ITM_PCI
            Case EdifactTableType.NCTS_ITM_RFF
            Case EdifactTableType.NCTS_ITM_SEL
            Case EdifactTableType.NCTS_ITM_TDT
            Case EdifactTableType.NCTS_ITM_TOD
            Case EdifactTableType.NCTS_ITM_TPL
            Case EdifactTableType.NCTS_ITM_UNB
            Case EdifactTableType.NCTS_ITM_UNH
            Case EdifactTableType.NCTS_ITM_UNS
            Case EdifactTableType.NCTS_ITM_UNT
            Case EdifactTableType.NCTS_ITM_UNZ
            Case EdifactTableType.OUTPUT_FILE_FIELDS
            Case EdifactTableType.OUTPUT_FILE_GROUPS
            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowEdifact: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowEdifact(ByRef adoRow As ADODB.Recordset, ByVal TableName As EdifactTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case EdifactTableType.BOX_SEARCH_MAP
            Case EdifactTableType.DATA_NCTS
            Case EdifactTableType.DATA_NCTS_BERICHT
            Case EdifactTableType.DATA_NCTS_BERICHT_DOUANEKANTOOR
            Case EdifactTableType.DATA_NCTS_BERICHT_HANDELAAR
            Case EdifactTableType.DATA_NCTS_BERICHT_HOOFDING
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_CONTROLE
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_INCIDENT
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_OVERLADING_CONTAINER
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO
            Case EdifactTableType.DATA_NCTS_BERICHT_VERVOER_VERZEGELING_INFO_ID
            Case EdifactTableType.DATA_NCTS_BGM
            Case EdifactTableType.DATA_NCTS_CNT
            Case EdifactTableType.DATA_NCTS_CST
            Case EdifactTableType.DATA_NCTS_DETAIL
            Case EdifactTableType.DATA_NCTS_DETAIL_BIJZONDERE
            Case EdifactTableType.DATA_NCTS_DETAIL_COLLI
            Case EdifactTableType.DATA_NCTS_DETAIL_CONTAINER
            Case EdifactTableType.DATA_NCTS_DETAIL_DOCUMENTEN
            Case EdifactTableType.DATA_NCTS_DETAIL_RESULTATEN
            Case EdifactTableType.DATA_NCTS_DOC
            Case EdifactTableType.DATA_NCTS_DTM
            Case EdifactTableType.DATA_NCTS_FTX
            Case EdifactTableType.DATA_NCTS_GIR
            Case EdifactTableType.DATA_NCTS_GIS
            Case EdifactTableType.DATA_NCTS_HEADER
            Case EdifactTableType.DATA_NCTS_HEADER_RESULTATEN
            Case EdifactTableType.DATA_NCTS_HEADER_ZEKERHEID
            Case EdifactTableType.DATA_NCTS_LOC
            Case EdifactTableType.DATA_NCTS_MEA
            Case EdifactTableType.DATA_NCTS_MESSAGES
            Case EdifactTableType.DATA_NCTS_NAD
            Case EdifactTableType.DATA_NCTS_PAC
            Case EdifactTableType.DATA_NCTS_PCI
            Case EdifactTableType.DATA_NCTS_RFF
            Case EdifactTableType.DATA_NCTS_SEL
            Case EdifactTableType.DATA_NCTS_TDT
            Case EdifactTableType.DATA_NCTS_TOD
            Case EdifactTableType.DATA_NCTS_TPL
            Case EdifactTableType.DATA_NCTS_UNB
            Case EdifactTableType.DATA_NCTS_UNH
            Case EdifactTableType.DATA_NCTS_UNS
            Case EdifactTableType.DATA_NCTS_UNT
            Case EdifactTableType.DATA_NCTS_UNZ
            Case EdifactTableType.DBProperties
            Case EdifactTableType.EDI_TMS
            Case EdifactTableType.EDI_TMS_CORE
            Case EdifactTableType.EDI_TMS_GROUPS
            Case EdifactTableType.EDI_TMS_ITEMS
            Case EdifactTableType.EDI_TMS_SEGMENTS
            Case EdifactTableType.NCTS_DEPARTURE_FOLLOW_UP_REQUEST
            Case EdifactTableType.NCTS_IEM
            Case EdifactTableType.NCTS_IEM_MAP
            Case EdifactTableType.NCTS_IEM_MAP_CONDITIONS
            Case EdifactTableType.NCTS_IEM_TMS
            Case EdifactTableType.NCTS_ITM_BGM
            Case EdifactTableType.NCTS_ITM_CNT
            Case EdifactTableType.NCTS_ITM_CST
            Case EdifactTableType.NCTS_ITM_DOC
            Case EdifactTableType.NCTS_ITM_DTM
            Case EdifactTableType.NCTS_ITM_FTX
            Case EdifactTableType.NCTS_ITM_GIR
            Case EdifactTableType.NCTS_ITM_GIS
            Case EdifactTableType.NCTS_ITM_LOC
            Case EdifactTableType.NCTS_ITM_MEA
            Case EdifactTableType.NCTS_ITM_NAD
            Case EdifactTableType.NCTS_ITM_PAC
            Case EdifactTableType.NCTS_ITM_PCI
            Case EdifactTableType.NCTS_ITM_RFF
            Case EdifactTableType.NCTS_ITM_SEL
            Case EdifactTableType.NCTS_ITM_TDT
            Case EdifactTableType.NCTS_ITM_TOD
            Case EdifactTableType.NCTS_ITM_TPL
            Case EdifactTableType.NCTS_ITM_UNB
            Case EdifactTableType.NCTS_ITM_UNH
            Case EdifactTableType.NCTS_ITM_UNS
            Case EdifactTableType.NCTS_ITM_UNT
            Case EdifactTableType.NCTS_ITM_UNZ
            Case EdifactTableType.OUTPUT_FILE_FIELDS
            Case EdifactTableType.OUTPUT_FILE_GROUPS
            Case Else
                Throw New NotSupportedException("Error in InsertRowEdifact: Unsupported enum encountered: " + TableName.GetType.Name)
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
