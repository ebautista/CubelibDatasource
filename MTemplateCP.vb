Imports CubelibDatasource.CDatasource

Module MTemplateCP

    Public Sub FindAndUpdateRowTemplateCP(ByRef adoRow As ADODB.Recordset, ByVal TableName As TemplateCPTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case TemplateCPTableType.Allow_Move
                adapter = New TEMPLATECPTableAdapters.Allow_MoveTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Allow_ID").Value)

            Case TemplateCPTableType.ButtonGroups
                adapter = New TEMPLATECPTableAdapters.ButtonGroupsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("BGroup_ID").Value)

            Case TemplateCPTableType.ButtonGroups2003
                adapter = New TEMPLATECPTableAdapters.ButtonGroups2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("BGroup_ID").Value)

            Case TemplateCPTableType.Buttons
                adapter = New TEMPLATECPTableAdapters.ButtonsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Button_ID").Value)

            Case TemplateCPTableType.Buttons2003
                adapter = New TEMPLATECPTableAdapters.Buttons2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("Button_ID").Value)

            Case TemplateCPTableType.ButtonTreeSettings
                adapter = New TEMPLATECPTableAdapters.ButtonTreeSettingsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("BTS_ID").Value)

            Case TemplateCPTableType.ButtonTreeSettings2003
                adapter = New TEMPLATECPTableAdapters.ButtonTreeSettings2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("BTS_ID").Value)

            Case TemplateCPTableType.CPUpgradeTracker
                adapter = New TEMPLATECPTableAdapters.CPUpgradeTrackerTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CPUpgradeTrack_ID").Value)

            Case TemplateCPTableType.Databases
                adapter = New TEMPLATECPTableAdapters.DatabasesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("DB_ID").Value)

            Case TemplateCPTableType.DBProperties
                AddToTrace("TemplateCPTableType.DBProperties does not have an update support.")

            Case TemplateCPTableType.DBProps
                AddToTrace("TemplateCPTableType.DBProps does not have an update support.")

            Case TemplateCPTableType.DBUpgradeTracker
                adapter = New TEMPLATECPTableAdapters.DBUpgradeTrackerTableAdapter
                table = adapter.GetByPK(adoRow.Fields("DBUpgradeTrack_ID").Value)

            Case TemplateCPTableType.DefaultViewColumns
                adapter = New TEMPLATECPTableAdapters.DefaultViewColumnsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("DVC_ID").Value, adoRow.Fields("TView_ID").Value)

            Case TemplateCPTableType.DefaultViewColumns2003
                adapter = New TEMPLATECPTableAdapters.DefaultViewColumns2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("DVC_ID").Value, adoRow.Fields("TView_ID").Value)

            Case TemplateCPTableType.DELETEITEM_LOG
                adapter = New TEMPLATECPTableAdapters.DELETEITEM_LOGTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case TemplateCPTableType.Developer_Settings
                AddToTrace("TemplateCPTableType.Developer_Settings does not have an update support.")

            Case TemplateCPTableType.Features
                adapter = New TEMPLATECPTableAdapters.FeaturesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Feature_ID").Value)

            Case TemplateCPTableType.Filter
                adapter = New TEMPLATECPTableAdapters.FilterTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Filter_ID").Value)

            Case TemplateCPTableType.FindViewColumns
                adapter = New TEMPLATECPTableAdapters.FindViewColumnsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("FVC_ID").Value)

            Case TemplateCPTableType.GroupNodes
                adapter = New TEMPLATECPTableAdapters.GroupNodesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("GNode_ID").Value)

            Case TemplateCPTableType.Licensee
                adapter = New TEMPLATECPTableAdapters.LicenseeTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Lic_ID").Value)

            Case TemplateCPTableType.LinkedTables
                adapter = New TEMPLATECPTableAdapters.LinkedTablesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Table_ID").Value)

            Case TemplateCPTableType.MainSettings
                adapter = New TEMPLATECPTableAdapters.MainSettingsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Setting_ID").Value)

            Case TemplateCPTableType.Nodes
                adapter = New TEMPLATECPTableAdapters.NodesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Node_ID").Value)

            Case TemplateCPTableType.Nodes2003
                adapter = New TEMPLATECPTableAdapters.Nodes2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("Node_ID").Value)

            Case TemplateCPTableType.PermDeletedArchivedDocs
                AddToTrace("TemplateCPTableType.PermDeletedArchivedDocs does not have an update support.")

            Case TemplateCPTableType.PrintBacklogTable
                adapter = New TEMPLATECPTableAdapters.PrintBacklogTableTableAdapter
                table = adapter.GetByPK(adoRow.Fields("PrintBacklogTable_ID").Value)

            Case TemplateCPTableType.PrintDocTypes
                adapter = New TEMPLATECPTableAdapters.PrintDocTypesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("PrintDoc_ID").Value)

            Case TemplateCPTableType.TemplateTreeLinks
                adapter = New TEMPLATECPTableAdapters.TemplateTreeLinksTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeLink_ID").Value)

            Case TemplateCPTableType.Trees
                adapter = New TEMPLATECPTableAdapters.TreesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Tree_ID").Value)

            Case TemplateCPTableType.Trees2003
                adapter = New TEMPLATECPTableAdapters.Trees2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("Tree_ID").Value)

            Case TemplateCPTableType.TreeSettings
                adapter = New TEMPLATECPTableAdapters.TreeSettingsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeSet_ID").Value)

            Case TemplateCPTableType.TreeSettings2003
                adapter = New TEMPLATECPTableAdapters.TreeSettings2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeSet_ID").Value)

            Case TemplateCPTableType.TreeTypeGroups
                adapter = New TEMPLATECPTableAdapters.TreeTypeGroupsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TTGroup_ID").Value)

            Case TemplateCPTableType.TreeTypes
                adapter = New TEMPLATECPTableAdapters.TreeTypesTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TreeType_ID").Value)

            Case TemplateCPTableType.TreeViews
                adapter = New TEMPLATECPTableAdapters.TreeViewsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TView_ID").Value)

            Case TemplateCPTableType.TreeViews2003
                adapter = New TEMPLATECPTableAdapters.TreeViews2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("TView_ID").Value)

            Case TemplateCPTableType.TVQueryDefs
                adapter = New TEMPLATECPTableAdapters.TVQueryDefsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("TVQ_ID").Value)

            Case TemplateCPTableType.TVQueryDefs2003
                adapter = New TEMPLATECPTableAdapters.TVQueryDefs2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("TVQ_ID").Value)

            Case TemplateCPTableType.Users
                adapter = New TEMPLATECPTableAdapters.UsersTableAdapter
                table = adapter.GetByPK(adoRow.Fields("User_ID").Value)

            Case TemplateCPTableType.UserViewColumns
                adapter = New TEMPLATECPTableAdapters.UserViewColumnsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("UVC_ID").Value)

            Case TemplateCPTableType.UserViewColumns2003
                adapter = New TEMPLATECPTableAdapters.UserViewColumns2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("UVC_ID").Value)

            Case TemplateCPTableType.UVCFormatCondition
                adapter = New TEMPLATECPTableAdapters.UVCFormatConditionTableAdapter
                table = adapter.GetByPK(adoRow.Fields("FC_ID").Value)

            Case TemplateCPTableType.UVCFormatCondition2003
                adapter = New TEMPLATECPTableAdapters.UVCFormatCondition2003TableAdapter
                table = adapter.GetByPK(adoRow.Fields("FC_ID").Value)

            Case TemplateCPTableType.Views
                adapter = New TEMPLATECPTableAdapters.ViewsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("View_ID").Value)

            Case TemplateCPTableType.WindowSettings
                adapter = New TEMPLATECPTableAdapters.WindowSettingsTableAdapter
                table = adapter.GetByPK(adoRow.Fields("Window_ID").Value)

            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowTemplateCP: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowTemplateCP(ByRef adoRow As ADODB.Recordset, ByVal TableName As TemplateCPTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case TemplateCPTableType.Allow_Move
                adapter = New TEMPLATECPTableAdapters.Allow_MoveTableAdapter
                table = New TEMPLATECP.Allow_MoveDataTable

            Case TemplateCPTableType.ButtonGroups
                adapter = New TEMPLATECPTableAdapters.ButtonGroupsTableAdapter
                table = New TEMPLATECP.ButtonGroupsDataTable

            Case TemplateCPTableType.ButtonGroups2003
                adapter = New TEMPLATECPTableAdapters.ButtonGroups2003TableAdapter
                table = New TEMPLATECP.ButtonGroups2003DataTable

            Case TemplateCPTableType.Buttons
                adapter = New TEMPLATECPTableAdapters.ButtonsTableAdapter
                table = New TEMPLATECP.ButtonsDataTable

            Case TemplateCPTableType.Buttons2003
                adapter = New TEMPLATECPTableAdapters.Buttons2003TableAdapter
                table = New TEMPLATECP.Buttons2003DataTable

            Case TemplateCPTableType.ButtonTreeSettings
                adapter = New TEMPLATECPTableAdapters.ButtonTreeSettingsTableAdapter
                table = New TEMPLATECP.ButtonTreeSettingsDataTable

            Case TemplateCPTableType.ButtonTreeSettings2003
                adapter = New TEMPLATECPTableAdapters.ButtonTreeSettings2003TableAdapter
                table = New TEMPLATECP.ButtonTreeSettings2003DataTable

            Case TemplateCPTableType.CPUpgradeTracker
                adapter = New TEMPLATECPTableAdapters.CPUpgradeTrackerTableAdapter
                table = New TEMPLATECP.CPUpgradeTrackerDataTable

            Case TemplateCPTableType.Databases
                adapter = New TEMPLATECPTableAdapters.DatabasesTableAdapter
                table = New TEMPLATECP.DatabasesDataTable

            Case TemplateCPTableType.DBProperties
                adapter = New TEMPLATECPTableAdapters.DBPropertiesTableAdapter
                table = New TEMPLATECP.DBPropertiesDataTable

            Case TemplateCPTableType.DBProps
                adapter = New TEMPLATECPTableAdapters.DBPropsTableAdapter
                table = New TEMPLATECP.DBPropsDataTable

            Case TemplateCPTableType.DBUpgradeTracker
                adapter = New TEMPLATECPTableAdapters.DBUpgradeTrackerTableAdapter
                table = New TEMPLATECP.DBUpgradeTrackerDataTable

            Case TemplateCPTableType.DefaultViewColumns
                adapter = New TEMPLATECPTableAdapters.DefaultViewColumnsTableAdapter
                table = New TEMPLATECP.DefaultViewColumnsDataTable

            Case TemplateCPTableType.DefaultViewColumns2003
                adapter = New TEMPLATECPTableAdapters.DefaultViewColumns2003TableAdapter
                table = New TEMPLATECP.DefaultViewColumns2003DataTable

            Case TemplateCPTableType.DELETEITEM_LOG
                adapter = New TEMPLATECPTableAdapters.DELETEITEM_LOGTableAdapter
                table = New TEMPLATECP.DELETEITEM_LOGDataTable

            Case TemplateCPTableType.Developer_Settings
                adapter = New TEMPLATECPTableAdapters.Developer_SettingsTableAdapter
                table = New TEMPLATECP.Developer_SettingsDataTable

            Case TemplateCPTableType.Features
                adapter = New TEMPLATECPTableAdapters.FeaturesTableAdapter
                table = New TEMPLATECP.FeaturesDataTable

            Case TemplateCPTableType.Filter
                adapter = New TEMPLATECPTableAdapters.FilterTableAdapter
                table = New TEMPLATECP.FilterDataTable

            Case TemplateCPTableType.FindViewColumns
                adapter = New TEMPLATECPTableAdapters.FindViewColumnsTableAdapter
                table = New TEMPLATECP.FindViewColumnsDataTable

            Case TemplateCPTableType.GroupNodes
                adapter = New TEMPLATECPTableAdapters.GroupNodesTableAdapter
                table = New TEMPLATECP.GroupNodesDataTable

            Case TemplateCPTableType.Licensee
                adapter = New TEMPLATECPTableAdapters.LicenseeTableAdapter
                table = New TEMPLATECP.LicenseeDataTable

            Case TemplateCPTableType.LinkedTables
                adapter = New TEMPLATECPTableAdapters.LinkedTablesTableAdapter
                table = New TEMPLATECP.LinkedTablesDataTable

            Case TemplateCPTableType.MainSettings
                adapter = New TEMPLATECPTableAdapters.MainSettingsTableAdapter
                table = New TEMPLATECP.MainSettingsDataTable

            Case TemplateCPTableType.Nodes
                adapter = New TEMPLATECPTableAdapters.NodesTableAdapter
                table = New TEMPLATECP.NodesDataTable

            Case TemplateCPTableType.Nodes2003
                adapter = New TEMPLATECPTableAdapters.Nodes2003TableAdapter
                table = New TEMPLATECP.Nodes2003DataTable

            Case TemplateCPTableType.PermDeletedArchivedDocs
                adapter = New TEMPLATECPTableAdapters.PermDeletedArchivedDocsTableAdapter
                table = New TEMPLATECP.PermDeletedArchivedDocsDataTable

            Case TemplateCPTableType.PrintBacklogTable
                adapter = New TEMPLATECPTableAdapters.PrintBacklogTableTableAdapter
                table = New TEMPLATECP.PrintBacklogTableDataTable

            Case TemplateCPTableType.PrintDocTypes
                adapter = New TEMPLATECPTableAdapters.PrintDocTypesTableAdapter
                table = New TEMPLATECP.PrintDocTypesDataTable

            Case TemplateCPTableType.TemplateTreeLinks
                adapter = New TEMPLATECPTableAdapters.TemplateTreeLinksTableAdapter
                table = New TEMPLATECP.TemplateTreeLinksDataTable

            Case TemplateCPTableType.Trees
                adapter = New TEMPLATECPTableAdapters.TreesTableAdapter
                table = New TEMPLATECP.TreesDataTable

            Case TemplateCPTableType.Trees2003
                adapter = New TEMPLATECPTableAdapters.Trees2003TableAdapter
                table = New TEMPLATECP.Trees2003DataTable

            Case TemplateCPTableType.TreeSettings
                adapter = New TEMPLATECPTableAdapters.TreeSettingsTableAdapter
                table = New TEMPLATECP.TreeSettingsDataTable

            Case TemplateCPTableType.TreeSettings2003
                adapter = New TEMPLATECPTableAdapters.TreeSettings2003TableAdapter
                table = New TEMPLATECP.TreeSettings2003DataTable

            Case TemplateCPTableType.TreeTypeGroups
                adapter = New TEMPLATECPTableAdapters.TreeTypeGroupsTableAdapter
                table = New TEMPLATECP.TreeTypeGroupsDataTable

            Case TemplateCPTableType.TreeTypes
                adapter = New TEMPLATECPTableAdapters.TreeTypesTableAdapter
                table = New TEMPLATECP.TreeTypesDataTable

            Case TemplateCPTableType.TreeViews
                adapter = New TEMPLATECPTableAdapters.TreeViewsTableAdapter
                table = New TEMPLATECP.TreeViewsDataTable

            Case TemplateCPTableType.TreeViews2003
                adapter = New TEMPLATECPTableAdapters.TreeViews2003TableAdapter
                table = New TEMPLATECP.TreeViews2003DataTable

            Case TemplateCPTableType.TVQueryDefs
                adapter = New TEMPLATECPTableAdapters.TVQueryDefsTableAdapter
                table = New TEMPLATECP.TVQueryDefsDataTable

            Case TemplateCPTableType.TVQueryDefs2003
                adapter = New TEMPLATECPTableAdapters.TVQueryDefs2003TableAdapter
                table = New TEMPLATECP.TVQueryDefs2003DataTable

            Case TemplateCPTableType.Users
                adapter = New TEMPLATECPTableAdapters.UsersTableAdapter
                table = New TEMPLATECP.UsersDataTable

            Case TemplateCPTableType.UserViewColumns
                adapter = New TEMPLATECPTableAdapters.UserViewColumnsTableAdapter
                table = New TEMPLATECP.UserViewColumnsDataTable

            Case TemplateCPTableType.UserViewColumns2003
                adapter = New TEMPLATECPTableAdapters.UserViewColumns2003TableAdapter
                table = New TEMPLATECP.UserViewColumns2003DataTable

            Case TemplateCPTableType.UVCFormatCondition
                adapter = New TEMPLATECPTableAdapters.UVCFormatConditionTableAdapter
                table = New TEMPLATECP.UVCFormatConditionDataTable

            Case TemplateCPTableType.UVCFormatCondition2003
                adapter = New TEMPLATECPTableAdapters.UVCFormatCondition2003TableAdapter
                table = New TEMPLATECP.UVCFormatCondition2003DataTable

            Case TemplateCPTableType.Views
                adapter = New TEMPLATECPTableAdapters.ViewsTableAdapter
                table = New TEMPLATECP.ViewsDataTable

            Case TemplateCPTableType.WindowSettings
                adapter = New TEMPLATECPTableAdapters.WindowSettingsTableAdapter
                table = New TEMPLATECP.WindowSettingsDataTable

            Case Else
                Throw New NotSupportedException("Error in InsertRowTemplateCP: Unsupported enum encountered: " + TableName.GetType.Name)
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
