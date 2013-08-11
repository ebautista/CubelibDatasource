Imports CubelibDatasource.CDatasource

Module MSadbel

    Public Sub FindAndUpdateRowSADBEL(ByRef adoRow As ADODB.Recordset, ByVal TableName As SadbelTableType)

        'Dim table As DataTable = Nothing

        Select Case TableName
            Case SadbelTableType.AUTHORIZED_PARTIES
                'ReDim pk(0)
                'pk(0) = adoRow.Fields("AUTH_ID").Value
                'adapter = New SadbelDataSetTableAdapters.AuthorizedPartiesTableAdapter

            Case SadbelTableType.BOX_DEFAULT_COMBINED_ADMIN
            Case SadbelTableType.BOX_DEFAULT_COMBINED_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_IE141_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_IE44_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS2_ADMIN
            Case SadbelTableType.BOX_DEFAULT_IMPORT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_COMBINED_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_COMBINED_CHILDREN_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_IMPORT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_IMPORT_CHILDREN_ADMIN
            Case SadbelTableType.BOX_DEFAULT_TRANSIT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_TRANSIT_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_VALUE_COMBINED_NCTS
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS_IE44
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS2
            Case SadbelTableType.BOX_DEFAULT_VALUE_EXPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_IMPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_PLDA_COMBINED
            Case SadbelTableType.BOX_DEFAULT_VALUE_PLDA_IMPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_TRANSIT
            Case SadbelTableType.BOX_DEFAULT_VALUE_TRANSIT_NCTS
            Case SadbelTableType.BRANCHES
            Case SadbelTableType.COLUMNS
            Case SadbelTableType.COMBINED_NCTS
            Case SadbelTableType.COMBINED_NCTS_DETAIL
            Case SadbelTableType.COMBINED_NCTS_DETAIL_BIJZONDERE
            Case SadbelTableType.COMBINED_NCTS_DETAIL_COLLI
            Case SadbelTableType.COMBINED_NCTS_DETAIL_CONTAINER
            Case SadbelTableType.COMBINED_NCTS_DETAIL_DOCUMENTEN
            Case SadbelTableType.COMBINED_NCTS_DETAIL_GEVOELIGE
            Case SadbelTableType.COMBINED_NCTS_DETAIL_GOEDEREN
            Case SadbelTableType.COMBINED_NCTS_HEADER
            Case SadbelTableType.COMBINED_NCTS_HEADER_ZEKERHEID
            Case SadbelTableType.CONSIGN_CTRY
            Case SadbelTableType.CONSIGNEE
            Case SadbelTableType.CONSIGNOR
            Case SadbelTableType.CONSIGNOR_CONSIGNEE
            Case SadbelTableType.COUNTRIES
            Case SadbelTableType.DBPROPERTIES
            Case SadbelTableType.DEFAULT_COLUMNS
            Case SadbelTableType.DEFAULT_USER_COMBINED_NCTS
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS2
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS_IE44
            Case SadbelTableType.DEFAULT_USER_EXPORT
            Case SadbelTableType.DEFAULT_USER_IMPORT
            Case SadbelTableType.DEFAULT_USER_PLDA_COMBINED
            Case SadbelTableType.DEFAULT_USER_PLDA_IMPORT
            Case SadbelTableType.DEFAULT_USER_TRANSIT
            Case SadbelTableType.DEFAULT_USER_TRANSIT_NCTS
            Case SadbelTableType.DIGISIGN_PLDA_COMBINED
            Case SadbelTableType.DIGISIGN_PLDA_IMPORT
            Case SadbelTableType.ENTREPOT_PROPERTIES
            Case SadbelTableType.ENTREPOTS
            Case SadbelTableType.ERROR_DUTCH
            Case SadbelTableType.ERROR_ENGLISH
            Case SadbelTableType.ERROR_FRENCH
            Case SadbelTableType.EUR1_PROPERTIES
            Case SadbelTableType.EXPORT
            Case SadbelTableType.EXPORT_DETAIL
            Case SadbelTableType.EXPORT_HEADER
            Case SadbelTableType.FIELD_GROUPING
            Case SadbelTableType.GROUPS
            Case SadbelTableType.GUARANTEE
            Case SadbelTableType.IMPORT
            Case SadbelTableType.IMPORT_DETAIL
            Case SadbelTableType.IMPORT_HEADER
            Case SadbelTableType.INBOUND_DOCS
            Case SadbelTableType.INBOUNDS
            Case SadbelTableType.LICENSEE
            Case SadbelTableType.LOGICAL_ID
            Case SadbelTableType.LRN
            Case SadbelTableType.MAIL_BOX
            Case SadbelTableType.MAIL_GROUPS
            Case SadbelTableType.MAIL_SETTINGS
            Case SadbelTableType.NCTS
            Case SadbelTableType.NCTS_DETAIL
            Case SadbelTableType.NCTS_DETAIL_BIJZONDERE
            Case SadbelTableType.NCTS_DETAIL_COLLI
            Case SadbelTableType.NCTS_DETAIL_CONTAINER
            Case SadbelTableType.NCTS_DETAIL_DOCUMENTEN
            Case SadbelTableType.NCTS_HEADER
            Case SadbelTableType.NCTS_HEADER_ZEKERHEID
            Case SadbelTableType.OPERATORS
            Case SadbelTableType.ORPHANED_MESSAGES
            Case SadbelTableType.OUTBOUND_DOCS
            Case SadbelTableType.OUTBOUNDS
            Case SadbelTableType.PDF_OUT_SETTINGS
            Case SadbelTableType.PIKCLIST_DEFINITION
            Case SadbelTableType.PIKCLIST_MAINTENANCE_DUTCH
            Case SadbelTableType.PIKCLIST_MAINTENANCE_ENGLISH
            Case SadbelTableType.PIKCLIST_MAINTENANCE_FRENCH
            Case SadbelTableType.PLDA_COMBINED
            Case SadbelTableType.PLDA_COMBINED_DETAIL_BIJZONDERE
            Case SadbelTableType.PLDA_COMBINED_DETAIL_CONTAINER
            Case SadbelTableType.PLDA_COMBINED_DETAIL
            Case SadbelTableType.PLDA_COMBINED_DETAIL_DOCUMENTEN
            Case SadbelTableType.PLDA_COMBINED_DETAIL_HANDELAARS
            Case SadbelTableType.PLDA_COMBINED_HEADER
            Case SadbelTableType.PLDA_COMBINED_HEADER_HANDELAARS
            Case SadbelTableType.PLDA_COMBINED_HEADER_TRANSIT_OFFICES
            Case SadbelTableType.PLDA_COMBINED_HEADER_ZEGELS
            Case SadbelTableType.PLDA_COMBINED_HEADER_ZEKERHEID
            Case SadbelTableType.PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
            Case SadbelTableType.PLDA_ERROR_CODE
            Case SadbelTableType.PLDA_IMPORT
            Case SadbelTableType.PLDA_IMPORT_DETAIL
            Case SadbelTableType.PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
            Case SadbelTableType.PLDA_IMPORT_DETAIL_BIJZONDERE
            Case SadbelTableType.PLDA_IMPORT_DETAIL_CONTAINER
            Case SadbelTableType.PLDA_IMPORT_DETAIL_DOCUMENTEN
            Case SadbelTableType.PLDA_IMPORT_DETAIL_HANDELAARS
            Case SadbelTableType.PLDA_IMPORT_DETAIL_ZELF
            Case SadbelTableType.PLDA_IMPORT_HEADER
                Dim adapter As New SadbelDataSetTableAdapters.PLDA_IMPORT_HEADERTableAdapter
                Dim table As DataTable = adapter.GetDataByPK(adoRow.Fields("CODE").Value, Convert.ToDouble(adoRow.Fields("HEADER").Value))

                If Not table Is Nothing AndAlso Not table.Rows Is Nothing AndAlso table.Rows.Count > 0 Then
                    Dim rowToUpdate As DataRow = table.Rows(0)

                    rowToUpdate.BeginEdit()
                    For Each Field As ADODB.Field In adoRow.Fields
                        rowToUpdate.SetField(Field.Name, Field.Value)
                    Next
                    rowToUpdate.EndEdit()

                    adapter.Update(rowToUpdate)
                End If

            Case SadbelTableType.PLDA_IMPORT_HEADER_HANDELAARS
            Case SadbelTableType.PLDA_IMPORT_HEADER_ZEGELS
            Case SadbelTableType.PLDA_LRN
            Case SadbelTableType.PLDA_MESSAGES
            Case SadbelTableType.PRINTDOCTYPES
            Case SadbelTableType.PRODUCTS
            Case SadbelTableType.QUEUE_PROPERTIES
            Case SadbelTableType.REMARKS
            Case SadbelTableType.REMOTE_DOCTYPE
            Case SadbelTableType.REMOTE_PRINTERS
            Case SadbelTableType.REPRESENTATIVE
            Case SadbelTableType.SETUP
            Case SadbelTableType.SHEET_PROPERTIES
            Case SadbelTableType.SKIP
            Case SadbelTableType.STOCK_CARDS
            Case SadbelTableType.SYSLINK_COMPATIBILITY
            Case SadbelTableType.SYSLINK_PROPERTIES
            Case SadbelTableType.TAB_ORDER
            Case SadbelTableType.TRANSIT
            Case SadbelTableType.TRANSIT_DETAIL
            Case SadbelTableType.TRANSIT_HEADER
            Case SadbelTableType.TREE
            Case SadbelTableType.USER_LOGICAL_ID
            Case SadbelTableType.USER_PRINTERS
            Case SadbelTableType.VALIDATION_RULES
            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateTableSADBEL: Unsupported enum encountered: " + TableName.GetType.Name)
        End Select

        
    End Sub

    Public Sub InsertRowSADBEL(ByRef adoRow As ADODB.Recordset, ByVal TableName As SadbelTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As SadbelDataSet.PLDA_IMPORT_HEADERDataTable = Nothing

        Select Case TableName
            Case SadbelTableType.AUTHORIZED_PARTIES
                'adapter = New SadbelDataSetTableAdapters.AuthorizedPartiesTableAdapter
                'table = CType(adapter, SadbelDataSetTableAdapters.AuthorizedPartiesTableAdapter).GetData
            Case SadbelTableType.BOX_DEFAULT_COMBINED_ADMIN
            Case SadbelTableType.BOX_DEFAULT_COMBINED_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_IE141_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS_IE44_ADMIN
            Case SadbelTableType.BOX_DEFAULT_EDI_NCTS2_ADMIN
            Case SadbelTableType.BOX_DEFAULT_IMPORT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_COMBINED_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_COMBINED_CHILDREN_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_IMPORT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_PLDA_IMPORT_CHILDREN_ADMIN
            Case SadbelTableType.BOX_DEFAULT_TRANSIT_ADMIN
            Case SadbelTableType.BOX_DEFAULT_TRANSIT_NCTS_ADMIN
            Case SadbelTableType.BOX_DEFAULT_VALUE_COMBINED_NCTS
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS_IE44
            Case SadbelTableType.BOX_DEFAULT_VALUE_EDI_NCTS2
            Case SadbelTableType.BOX_DEFAULT_VALUE_EXPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_IMPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_PLDA_COMBINED
            Case SadbelTableType.BOX_DEFAULT_VALUE_PLDA_IMPORT
            Case SadbelTableType.BOX_DEFAULT_VALUE_TRANSIT
            Case SadbelTableType.BOX_DEFAULT_VALUE_TRANSIT_NCTS
            Case SadbelTableType.BRANCHES
            Case SadbelTableType.COLUMNS
            Case SadbelTableType.COMBINED_NCTS
            Case SadbelTableType.COMBINED_NCTS_DETAIL
            Case SadbelTableType.COMBINED_NCTS_DETAIL_BIJZONDERE
            Case SadbelTableType.COMBINED_NCTS_DETAIL_COLLI
            Case SadbelTableType.COMBINED_NCTS_DETAIL_CONTAINER
            Case SadbelTableType.COMBINED_NCTS_DETAIL_DOCUMENTEN
            Case SadbelTableType.COMBINED_NCTS_DETAIL_GEVOELIGE
            Case SadbelTableType.COMBINED_NCTS_DETAIL_GOEDEREN
            Case SadbelTableType.COMBINED_NCTS_HEADER
            Case SadbelTableType.COMBINED_NCTS_HEADER_ZEKERHEID
            Case SadbelTableType.CONSIGN_CTRY
            Case SadbelTableType.CONSIGNEE
            Case SadbelTableType.CONSIGNOR
            Case SadbelTableType.CONSIGNOR_CONSIGNEE
            Case SadbelTableType.COUNTRIES
            Case SadbelTableType.DBPROPERTIES
            Case SadbelTableType.DEFAULT_COLUMNS
            Case SadbelTableType.DEFAULT_USER_COMBINED_NCTS
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS2
            Case SadbelTableType.DEFAULT_USER_EDI_NCTS_IE44
            Case SadbelTableType.DEFAULT_USER_EXPORT
            Case SadbelTableType.DEFAULT_USER_IMPORT
            Case SadbelTableType.DEFAULT_USER_PLDA_COMBINED
            Case SadbelTableType.DEFAULT_USER_PLDA_IMPORT
            Case SadbelTableType.DEFAULT_USER_TRANSIT
            Case SadbelTableType.DEFAULT_USER_TRANSIT_NCTS
            Case SadbelTableType.DIGISIGN_PLDA_COMBINED
            Case SadbelTableType.DIGISIGN_PLDA_IMPORT
            Case SadbelTableType.ENTREPOT_PROPERTIES
            Case SadbelTableType.ENTREPOTS
            Case SadbelTableType.ERROR_DUTCH
            Case SadbelTableType.ERROR_ENGLISH
            Case SadbelTableType.ERROR_FRENCH
            Case SadbelTableType.EUR1_PROPERTIES
            Case SadbelTableType.EXPORT
            Case SadbelTableType.EXPORT_DETAIL
            Case SadbelTableType.EXPORT_HEADER
            Case SadbelTableType.FIELD_GROUPING
            Case SadbelTableType.GROUPS
            Case SadbelTableType.GUARANTEE
            Case SadbelTableType.IMPORT
            Case SadbelTableType.IMPORT_DETAIL
            Case SadbelTableType.IMPORT_HEADER
            Case SadbelTableType.INBOUND_DOCS
            Case SadbelTableType.INBOUNDS
            Case SadbelTableType.LICENSEE
            Case SadbelTableType.LOGICAL_ID
            Case SadbelTableType.LRN
            Case SadbelTableType.MAIL_BOX
            Case SadbelTableType.MAIL_GROUPS
            Case SadbelTableType.MAIL_SETTINGS
            Case SadbelTableType.NCTS
            Case SadbelTableType.NCTS_DETAIL
            Case SadbelTableType.NCTS_DETAIL_BIJZONDERE
            Case SadbelTableType.NCTS_DETAIL_COLLI
            Case SadbelTableType.NCTS_DETAIL_CONTAINER
            Case SadbelTableType.NCTS_DETAIL_DOCUMENTEN
            Case SadbelTableType.NCTS_HEADER
            Case SadbelTableType.NCTS_HEADER_ZEKERHEID
            Case SadbelTableType.OPERATORS
            Case SadbelTableType.ORPHANED_MESSAGES
            Case SadbelTableType.OUTBOUND_DOCS
            Case SadbelTableType.OUTBOUNDS
            Case SadbelTableType.PDF_OUT_SETTINGS
            Case SadbelTableType.PIKCLIST_DEFINITION
            Case SadbelTableType.PIKCLIST_MAINTENANCE_DUTCH
            Case SadbelTableType.PIKCLIST_MAINTENANCE_ENGLISH
            Case SadbelTableType.PIKCLIST_MAINTENANCE_FRENCH
            Case SadbelTableType.PLDA_COMBINED
            Case SadbelTableType.PLDA_COMBINED_DETAIL_BIJZONDERE
            Case SadbelTableType.PLDA_COMBINED_DETAIL_CONTAINER
            Case SadbelTableType.PLDA_COMBINED_DETAIL
            Case SadbelTableType.PLDA_COMBINED_DETAIL_DOCUMENTEN
            Case SadbelTableType.PLDA_COMBINED_DETAIL_HANDELAARS
            Case SadbelTableType.PLDA_COMBINED_HEADER
            Case SadbelTableType.PLDA_COMBINED_HEADER_HANDELAARS
            Case SadbelTableType.PLDA_COMBINED_HEADER_TRANSIT_OFFICES
            Case SadbelTableType.PLDA_COMBINED_HEADER_ZEGELS
            Case SadbelTableType.PLDA_COMBINED_HEADER_ZEKERHEID
            Case SadbelTableType.PLDA_COMBINED_DETAIL_SENSITIVE_GOODS
            Case SadbelTableType.PLDA_ERROR_CODE
            Case SadbelTableType.PLDA_IMPORT
            Case SadbelTableType.PLDA_IMPORT_DETAIL
            Case SadbelTableType.PLDA_IMPORT_DETAIL_BEREKENINGS_EENHEDEN
            Case SadbelTableType.PLDA_IMPORT_DETAIL_BIJZONDERE
            Case SadbelTableType.PLDA_IMPORT_DETAIL_CONTAINER
            Case SadbelTableType.PLDA_IMPORT_DETAIL_DOCUMENTEN
            Case SadbelTableType.PLDA_IMPORT_DETAIL_HANDELAARS
            Case SadbelTableType.PLDA_IMPORT_DETAIL_ZELF
            Case SadbelTableType.PLDA_IMPORT_HEADER
            Case SadbelTableType.PLDA_IMPORT_HEADER_HANDELAARS
            Case SadbelTableType.PLDA_IMPORT_HEADER_ZEGELS
            Case SadbelTableType.PLDA_LRN
            Case SadbelTableType.PLDA_MESSAGES
            Case SadbelTableType.PRINTDOCTYPES
            Case SadbelTableType.PRODUCTS
            Case SadbelTableType.QUEUE_PROPERTIES
            Case SadbelTableType.REMARKS
            Case SadbelTableType.REMOTE_DOCTYPE
            Case SadbelTableType.REMOTE_PRINTERS
            Case SadbelTableType.REPRESENTATIVE
            Case SadbelTableType.SETUP
            Case SadbelTableType.SHEET_PROPERTIES
            Case SadbelTableType.SKIP
            Case SadbelTableType.STOCK_CARDS
            Case SadbelTableType.SYSLINK_COMPATIBILITY
            Case SadbelTableType.SYSLINK_PROPERTIES
            Case SadbelTableType.TAB_ORDER
            Case SadbelTableType.TRANSIT
            Case SadbelTableType.TRANSIT_DETAIL
            Case SadbelTableType.TRANSIT_HEADER
            Case SadbelTableType.TREE
            Case SadbelTableType.USER_LOGICAL_ID
            Case SadbelTableType.USER_PRINTERS
            Case SadbelTableType.VALIDATION_RULES
            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateTableSADBEL: Unsupported enum encountered: " + TableName.GetType.Name)
        End Select

        If Not table Is Nothing AndAlso Not table.Rows Is Nothing AndAlso table.Rows.Count > 0 Then
            Dim rowToInsert As DataRow = table.NewRow

            rowToInsert.BeginEdit()
            For Each Field As ADODB.Field In adoRow.Fields
                rowToInsert.SetField(Field.Name, Field.Value)
            Next
            rowToInsert.EndEdit()

            'adapter.InsertRow(rowToInsert)
        End If
    End Sub
End Module

