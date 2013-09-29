Partial Class SCHEDULER
End Class

Namespace SCHEDULERTableAdapters
    Partial Public Class EDIPropertiesTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class Error_Reports_PendingTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(pk(0))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class PLDAPropertiesTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class PRINTBOXESTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class ReceivingCyclesTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class REMOTEFILETableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class SEGMENTTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(Convert.ToInt32(pk(0)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class SENDITEMSTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(pk(0))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

    Partial Public Class TASK_SCHEDULETableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(pk(0))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class

End Namespace

