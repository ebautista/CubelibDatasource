Imports CubelibDatasource.CDatasource

Module MScheduler

    Public Sub FindAndUpdateRowScheduler(ByRef adoRow As ADODB.Recordset, ByVal TableName As SchedulerTableType)

        Dim table As DataTable = Nothing
        Dim adapter As ITableAdapter(Of DataTable) = Nothing

        Select Case TableName
            Case SchedulerTableType.Archiver_Properties
                AddToTrace("SchedulerTableType.Archiver_Properties does not have an update support.")

            Case SchedulerTableType.DBProperties
                AddToTrace("SchedulerTableType.DBProperties does not have an update support.")

            Case SchedulerTableType.EDIProperties
                adapter = New SCHEDULERTableAdapters.EDIPropertiesTableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("EDIPROP_ID").Value))

            Case SchedulerTableType.Error_Code_Maintenance
                AddToTrace("SchedulerTableType.Error_Code_Maintenance does not have an update support.")

            Case SchedulerTableType.Error_Reports_Pending
                adapter = New SCHEDULERTableAdapters.Error_Reports_PendingTableAdapter
                table = adapter.GetByPK(adoRow.Fields("CODE").Value)

            Case SchedulerTableType.LOGID_SCHEDULE
                AddToTrace("SchedulerTableType.LOGID_SCHEDULE does not have an update support.")

            Case SchedulerTableType.MAINTENANCE_PROC_SETTINGS
                AddToTrace("SchedulerTableType.MAINTENANCE_PROC_SETTINGS does not have an update support.")

            Case SchedulerTableType.PLDA_Archiver_Properties
                AddToTrace("SchedulerTableType.PLDA_Archiver_Properties does not have an update support.")

            Case SchedulerTableType.PLDA_MESSAGES_QUEUE
                AddToTrace("SchedulerTableType.PLDA_MESSAGES_QUEUE does not have an update support.")

            Case SchedulerTableType.PLDAProperties
                adapter = New SCHEDULERTableAdapters.PLDAPropertiesTableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("PLDAPROP_ID").Value))

            Case SchedulerTableType.PRINTBOXES
                adapter = New SCHEDULERTableAdapters.PRINTBOXESTableAdapter
                table = adapter.GetByPK(adoRow.Fields("LOGID").Value)

            Case SchedulerTableType.PRINTDATA
                AddToTrace("SchedulerTableType.PRINTDATA does not have an update support.")

            Case SchedulerTableType.PRINTER_DEFINITION
                AddToTrace("SchedulerTableType.PRINTER_DEFINITION does not have an update support.")

            Case SchedulerTableType.ReceivingCycles
                adapter = New SCHEDULERTableAdapters.ReceivingCyclesTableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("RecCyc_ID").Value))

            Case SchedulerTableType.REMOTEFILE
                adapter = New SCHEDULERTableAdapters.REMOTEFILETableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("REMOTEFILE_ID").Value))

            Case SchedulerTableType.SEGMENT
                adapter = New SCHEDULERTableAdapters.SEGMENTTableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("Segment_ID").Value))

            Case SchedulerTableType.SENDITEMS
                adapter = New SCHEDULERTableAdapters.SENDITEMSTableAdapter
                table = adapter.GetByPK(Convert.ToInt32(adoRow.Fields("LOGID").Value))

            Case SchedulerTableType.SETUP
                AddToTrace("SchedulerTableType.SETUP does not have an update support.")

            Case SchedulerTableType.TASK_SCHEDULE
                adapter = New SCHEDULERTableAdapters.TASK_SCHEDULETableAdapter
                table = adapter.GetByPK(adoRow.Fields("TASK CODE").Value)

            Case Else
                Throw New NotSupportedException("Error in FindAndUpdateRowScheduler: Unsupported enum encountered: " + TableName.GetType.Name)
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

    Public Sub InsertRowScheduler(ByRef adoRow As ADODB.Recordset, ByVal TableName As SchedulerTableType)
        Dim adapter As ITableAdapter(Of DataTable) = Nothing
        Dim table As DataTable = Nothing
        Dim rowToInsert As DataRow = Nothing

        Select Case TableName
            Case SchedulerTableType.Archiver_Properties
                adapter = New SCHEDULERTableAdapters.Archiver_PropertiesTableAdapter
                table = New SCHEDULER.Archiver_PropertiesDataTable

            Case SchedulerTableType.DBProperties
                adapter = New SCHEDULERTableAdapters.DBPropertiesTableAdapter
                table = New SCHEDULER.DBPropertiesDataTable

            Case SchedulerTableType.EDIProperties
                adapter = New SCHEDULERTableAdapters.EDIPropertiesTableAdapter
                table = New SCHEDULER.EDIPropertiesDataTable

            Case SchedulerTableType.Error_Code_Maintenance
                adapter = New SCHEDULERTableAdapters.Error_Code_MaintenanceTableAdapter
                table = New SCHEDULER.Error_Code_MaintenanceDataTable

            Case SchedulerTableType.Error_Reports_Pending
                adapter = New SCHEDULERTableAdapters.Error_Reports_PendingTableAdapter
                table = New SCHEDULER.Error_Reports_PendingDataTable

            Case SchedulerTableType.LOGID_SCHEDULE
                adapter = New SCHEDULERTableAdapters.LOGID_SCHEDULETableAdapter
                table = New SCHEDULER.LOGID_SCHEDULEDataTable

            Case SchedulerTableType.MAINTENANCE_PROC_SETTINGS
                adapter = New SCHEDULERTableAdapters.MAINTENANCE_PROC_SETTINGSTableAdapter
                table = New SCHEDULER.MAINTENANCE_PROC_SETTINGSDataTable

            Case SchedulerTableType.PLDA_Archiver_Properties
                adapter = New SCHEDULERTableAdapters.PLDA_Archiver_PropertiesTableAdapter
                table = New SCHEDULER.PLDA_Archiver_PropertiesDataTable

            Case SchedulerTableType.PLDA_MESSAGES_QUEUE
                adapter = New SCHEDULERTableAdapters.PLDA_MESSAGES_QUEUETableAdapter
                table = New SCHEDULER.PLDA_MESSAGES_QUEUEDataTable

            Case SchedulerTableType.PLDAProperties
                adapter = New SCHEDULERTableAdapters.PLDAPropertiesTableAdapter
                table = New SCHEDULER.PLDAPropertiesDataTable

            Case SchedulerTableType.PRINTBOXES
                adapter = New SCHEDULERTableAdapters.PRINTBOXESTableAdapter
                table = New SCHEDULER.PRINTBOXESDataTable

            Case SchedulerTableType.PRINTDATA
                adapter = New SCHEDULERTableAdapters.PRINTDATATableAdapter
                table = New SCHEDULER.PRINTDATADataTable

            Case SchedulerTableType.PRINTER_DEFINITION
                adapter = New SCHEDULERTableAdapters.PRINTER_DEFINITIONTableAdapter
                table = New SCHEDULER.PRINTER_DEFINITIONDataTable

            Case SchedulerTableType.ReceivingCycles
                adapter = New SCHEDULERTableAdapters.ReceivingCyclesTableAdapter
                table = New SCHEDULER.ReceivingCyclesDataTable

            Case SchedulerTableType.REMOTEFILE
                adapter = New SCHEDULERTableAdapters.REMOTEFILETableAdapter
                table = New SCHEDULER.REMOTEFILEDataTable

            Case SchedulerTableType.SEGMENT
                adapter = New SCHEDULERTableAdapters.SEGMENTTableAdapter
                table = New SCHEDULER.SEGMENTDataTable

            Case SchedulerTableType.SENDITEMS
                adapter = New SCHEDULERTableAdapters.SENDITEMSTableAdapter
                table = New SCHEDULER.SENDITEMSDataTable

            Case SchedulerTableType.SETUP
                adapter = New SCHEDULERTableAdapters.SETUPTableAdapter
                table = New SCHEDULER.SETUPDataTable

            Case SchedulerTableType.TASK_SCHEDULE
                adapter = New SCHEDULERTableAdapters.TASK_SCHEDULETableAdapter
                table = New SCHEDULER.TASK_SCHEDULEDataTable

            Case Else
                Throw New NotSupportedException("Error in InsertRowScheduler: Unsupported enum encountered: " + TableName.GetType.Name)
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
