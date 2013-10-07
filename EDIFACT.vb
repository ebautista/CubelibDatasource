Partial Class EDIFACT
End Class

Namespace EDIFACTTableAdapters
    
    Partial Public Class DATA_NCTSTableAdapter
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
End Namespace
