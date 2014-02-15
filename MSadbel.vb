Imports CubelibDatasource.CDatasource
Imports ADODB
Imports System.Data.Common
Imports System.Text

Module MSadbel

    Public Function FindAndUpdateRowSADBEL(ByRef RecordsetToUpdate As CRecordset, ByVal TableName As SadbelTableType) As Integer

        Dim adoRow As Recordset = RecordsetToUpdate.Recordset
        Dim source As New CDatasource
        Dim command As DbCommand
        Dim dataset As DataSet
        Dim fullUpdateClause As String
        Dim strTableName As String
        Dim columns As DataColumnCollection

        'Mark the row where to get the update value from
        adoRow.Bookmark = RecordsetToUpdate.BookMark

        'Get the TableName
        strTableName = GetSadbelTableName(adoRow, TableName)

        'Get the Table Schema
        dataset = getTableSchema(strTableName, DBInstanceType.DATABASE_SADBEL)

        'Generate the fullUpdateClause
        fullUpdateClause = CreateUpdateClause(strTableName, dataset, adoRow)

        If fullUpdateClause = vbNullString Then
            AddToTrace("Error in FindAndUpdateRowSADBEL() - Primary Keys on table " & strTableName & " has not been defined or ADO record does not contain a row to update.", False)
            Return MGlobal.FAILURE
        End If

        'Set the update command with the connection object 
        command = getConnectionObjectsNonQuery(fullUpdateClause, DBInstanceType.DATABASE_SADBEL)

        For Each Field As ADODB.Field In adoRow.Fields
            Debug.Print(Field.Name & " " & Field.Type)
            'command.Parameters.Add(Field.Value)
        Next

        columns = dataset.Tables(0).Columns
        For Each column As DataColumn In columns
            If IsPrimaryKeyColumn(dataset.Tables(0), column) Then
                'command.Parameters.Add(keyValue.Value)
            End If
        Next

        'command.ExecuteNonQuery()

        Return MGlobal.SUCCESS
    End Function

    Public Sub InsertRowSADBEL(ByRef adoRow As ADODB.Recordset, ByVal TableName As SadbelTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

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
                adapter = New SADBELTableAdapters.PLDA_IMPORT_HEADERTableAdapter
                table = New SADBEL.PLDA_IMPORT_HEADERDataTable

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

    Private Function GetSadbelTableNameAndPrimaryKeyValuePairs(ByRef adoRow As ADODB.Recordset,
                                                               ByVal TableName As SadbelTableType) As List(Of KeyValuePair(Of String, Object))
        Dim primaryKeys As New List(Of KeyValuePair(Of String, Object))

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
                primaryKeys.Add(New KeyValuePair(Of String, Object)("TableName", "PLDA IMPORT HEADER"))
                primaryKeys.Add(New KeyValuePair(Of String, Object)("Code", adoRow.Fields("Code").Value))
                primaryKeys.Add(New KeyValuePair(Of String, Object)("Header", adoRow.Fields("Header").Value))

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

        Return primaryKeys
    End Function

    Private Function GetSadbelTableName(ByRef adoRow As ADODB.Recordset,
                                                               ByVal TableName As SadbelTableType) As String

        Select Case TableName
            Case SadbelTableType.AUTHORIZED_PARTIES
                Return "AUTHORIZED PARTIES"

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
                Return "PLDA IMPORT HEADER"

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

        Return vbNullString
    End Function

    Private Function CreateUpdateClause(ByVal strTableName As String,
                                        ByRef Data As DataSet,
                                        ByRef adoRow As Recordset) As String

        Dim strSQL As String = vbNullString
        Dim command As New StringBuilder
        Dim columns As DataColumnCollection = Data.Tables(0).Columns
        Dim hasPK As Boolean = False

        '----------------------------------------------------------------------------------------------------------------
        'Build the update script
        '----------------------------------------------------------------------------------------------------------------
        If (adoRow.RecordCount > 0) Then
            command.Append("UPDATE ")
            command.Append("[").Append(strTableName).Append("]")
            command.Append(" SET ")

            'Iterate through the new values
            For Each Field As ADODB.Field In adoRow.Fields
                command.Append("[").Append(Field.Name).Append("] = ?, ")
            Next

            'Remove the last comma and append WHERE
            command.Length = command.Length - 2
            command.Append(" WHERE ")

            'Add PK columns to WHERE clause
            For Each column As DataColumn In columns
                If IsPrimaryKeyColumn(Data.Tables(0), column) Then
                    command.Append("[").Append(column.ColumnName).Append("] = ? AND ")
                    hasPK = True
                End If
            Next

            'Remove the last AND
            command.Length = command.Length - 4
        End If
        '----------------------------------------------------------------------------------------------------------------

        If hasPK = False Then
            Return vbNullString
        End If

        Return command.ToString()
    End Function

End Module

