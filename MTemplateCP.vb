Imports CubelibDatasource.CDatasource

Module MTemplateCP

    Public Sub FindAndUpdateRowTemplateCP(ByRef adoRow As ADODB.Recordset, ByVal TableName As TemplateCPTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case TemplateCPTableType.Allow_Move
            Case TemplateCPTableType.ButtonGroups
            Case TemplateCPTableType.ButtonGroups2003
            Case TemplateCPTableType.Buttons
            Case TemplateCPTableType.Buttons2003
            Case TemplateCPTableType.ButtonTreeSettings
            Case TemplateCPTableType.ButtonTreeSettings2003
            Case TemplateCPTableType.CPUpgradeTracker
            Case TemplateCPTableType.Databases
            Case TemplateCPTableType.DBProperties
            Case TemplateCPTableType.DBProps
            Case TemplateCPTableType.DBUpgradeTracker
            Case TemplateCPTableType.DefaultViewColumns
            Case TemplateCPTableType.DefaultViewColumns2003
            Case TemplateCPTableType.DELETEITEM_LOG
            Case TemplateCPTableType.Developer_Settings
            Case TemplateCPTableType.Features
            Case TemplateCPTableType.Filter
            Case TemplateCPTableType.FindViewColumns
            Case TemplateCPTableType.GroupNodes
            Case TemplateCPTableType.Licensee
            Case TemplateCPTableType.LinkedTables
            Case TemplateCPTableType.MainSettings
            Case TemplateCPTableType.Nodes
            Case TemplateCPTableType.Nodes2003
            Case TemplateCPTableType.PermDeletedArchivedDocs
            Case TemplateCPTableType.PrintBacklogTable
            Case TemplateCPTableType.PrintDocTypes
            Case TemplateCPTableType.TemplateTreeLinks
            Case TemplateCPTableType.Trees
            Case TemplateCPTableType.Trees2003
            Case TemplateCPTableType.TreeSettings
            Case TemplateCPTableType.TreeSettings2003
            Case TemplateCPTableType.TreeTypeGroups
            Case TemplateCPTableType.TreeTypes
            Case TemplateCPTableType.TreeViews
            Case TemplateCPTableType.TreeViews2003
            Case TemplateCPTableType.TVQueryDefs
            Case TemplateCPTableType.TVQueryDefs2003
            Case TemplateCPTableType.Users
            Case TemplateCPTableType.UserViewColumns
            Case TemplateCPTableType.UserViewColumns2003
            Case TemplateCPTableType.UVCFormatCondition
            Case TemplateCPTableType.UVCFormatCondition2003
            Case TemplateCPTableType.Views
            Case TemplateCPTableType.WindowSettings

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
            Case TemplateCPTableType.ButtonGroups
            Case TemplateCPTableType.ButtonGroups2003
            Case TemplateCPTableType.Buttons
            Case TemplateCPTableType.Buttons2003
            Case TemplateCPTableType.ButtonTreeSettings
            Case TemplateCPTableType.ButtonTreeSettings2003
            Case TemplateCPTableType.CPUpgradeTracker
            Case TemplateCPTableType.Databases
            Case TemplateCPTableType.DBProperties
            Case TemplateCPTableType.DBProps
            Case TemplateCPTableType.DBUpgradeTracker
            Case TemplateCPTableType.DefaultViewColumns
            Case TemplateCPTableType.DefaultViewColumns2003
            Case TemplateCPTableType.DELETEITEM_LOG
            Case TemplateCPTableType.Developer_Settings
            Case TemplateCPTableType.Features
            Case TemplateCPTableType.Filter
            Case TemplateCPTableType.FindViewColumns
            Case TemplateCPTableType.GroupNodes
            Case TemplateCPTableType.Licensee
            Case TemplateCPTableType.LinkedTables
            Case TemplateCPTableType.MainSettings
            Case TemplateCPTableType.Nodes
            Case TemplateCPTableType.Nodes2003
            Case TemplateCPTableType.PermDeletedArchivedDocs
            Case TemplateCPTableType.PrintBacklogTable
            Case TemplateCPTableType.PrintDocTypes
            Case TemplateCPTableType.TemplateTreeLinks
            Case TemplateCPTableType.Trees
            Case TemplateCPTableType.Trees2003
            Case TemplateCPTableType.TreeSettings
            Case TemplateCPTableType.TreeSettings2003
            Case TemplateCPTableType.TreeTypeGroups
            Case TemplateCPTableType.TreeTypes
            Case TemplateCPTableType.TreeViews
            Case TemplateCPTableType.TreeViews2003
            Case TemplateCPTableType.TVQueryDefs
            Case TemplateCPTableType.TVQueryDefs2003
            Case TemplateCPTableType.Users
            Case TemplateCPTableType.UserViewColumns
            Case TemplateCPTableType.UserViewColumns2003
            Case TemplateCPTableType.UVCFormatCondition
            Case TemplateCPTableType.UVCFormatCondition2003
            Case TemplateCPTableType.Views
            Case TemplateCPTableType.WindowSettings

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
