Imports CubelibDatasource.CDatasource

Module MData

    Public Sub FindAndUpdateRowData(ByRef adoRow As ADODB.Recordset, ByVal TableName As DataTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case DataTableType.DBProperties
                AddToTrace("DataTableType.DBProperties does not have an update support.")

            Case DataTableType.MASTER
                adapter = New DATATableAdapters.MASTERTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.MASTEREDINCTS
                adapter = New DATATableAdapters.MASTEREDINCTSTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.MASTEREDINCTS2
                adapter = New DATATableAdapters.MASTEREDINCTS2TableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.MASTEREDINCTSIE44
                adapter = New DATATableAdapters.MASTEREDINCTSIE44TableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.MASTERNCTS
                adapter = New DATATableAdapters.MASTERNCTSTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.MASTERPLDA
                adapter = New DATATableAdapters.MASTERPLDATableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case DataTableType.OUTBOX
                AddToTrace("DataTableType.OUTBOX does not have an update support.")

            Case DataTableType.REMARKS
                AddToTrace("DataTableType.REMARKS does not have an update support.")

            Case DataTableType.TEMPLATETREELINKS
                adapter = New DATATableAdapters.TEMPLATETREELINKSTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeLink_ID").Value)

            Case DataTableType.TEMPLATETREELINKS2003
                adapter = New DATATableAdapters.TEMPLATETREELINKS2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeLink_ID").Value)

            Case DataTableType.USERDEFINEDTEMPLATES
                adapter = New DATATableAdapters.USERDEFINEDTEMPLATESTableAdapter
                table = adapter.GetByPK(adoRow.Fields("USERDEF_ID").Value)

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
                adapter = New DATATableAdapters.DBPropertiesTableAdapter
                table = New DATA.DBPropertiesDataTable

            Case DataTableType.MASTER
                adapter = New DATATableAdapters.MASTERTableAdapter
                table = New DATA.MASTERDataTable

            Case DataTableType.MASTEREDINCTS
                adapter = New DATATableAdapters.MASTEREDINCTSTableAdapter
                table = New DATA.MASTEREDINCTSDataTable

            Case DataTableType.MASTEREDINCTS2
                adapter = New DATATableAdapters.MASTEREDINCTS2TableAdapter
                table = New DATA.MASTEREDINCTS2DataTable

            Case DataTableType.MASTEREDINCTSIE44
                adapter = New DATATableAdapters.MASTEREDINCTSIE44TableAdapter
                table = New DATA.MASTEREDINCTSIE44DataTable

            Case DataTableType.MASTERNCTS
                adapter = New DATATableAdapters.MASTERNCTSTableAdapter
                table = New DATA.MASTERNCTSDataTable

            Case DataTableType.MASTERPLDA
                adapter = New DATATableAdapters.MASTERPLDATableAdapter
                table = New DATA.MASTERPLDADataTable

            Case DataTableType.OUTBOX
                adapter = New DATATableAdapters.OUTBOXTableAdapter
                table = New DATA.OUTBOXDataTable

            Case DataTableType.REMARKS
                adapter = New DATATableAdapters.REMARKSTableAdapter
                table = New DATA.REMARKSDataTable

            Case DataTableType.TEMPLATETREELINKS
                adapter = New DATATableAdapters.TEMPLATETREELINKSTableAdapter
                table = New DATA.TEMPLATETREELINKSDataTable

            Case DataTableType.TEMPLATETREELINKS2003
                adapter = New DATATableAdapters.TEMPLATETREELINKS2003TableAdapter
                table = New DATA.TEMPLATETREELINKS2003DataTable

            Case DataTableType.USERDEFINEDTEMPLATES
                adapter = New DATATableAdapters.USERDEFINEDTEMPLATESTableAdapter
                table = New DATA.USERDEFINEDTEMPLATESDataTable

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
