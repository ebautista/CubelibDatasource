Partial Class SADBEL
End Class

Namespace SADBELTableAdapters
    
    Partial Public Class PLDA_IMPORT_HEADERTableAdapter
        Implements ITableAdapter(Of DataTable)

        Public Function GetByPK(ParamArray pk() As Object) As DataTable Implements ITableAdapter(Of DataTable).GetByPK
            Return Me.GetDataByPK(pk(0), Convert.ToDouble(pk(1)))
        End Function

        Public Function RowUpdate(row As DataRow) As Integer Implements ITableAdapter(Of DataTable).RowUpdate
            Return Update(row)
        End Function

        Public Function TableUpdate(table As DataTable) As Integer Implements ITableAdapter(Of DataTable).TableUpdate
            Return Update(table)
        End Function
    End Class
End Namespace

Namespace CubelibDatasource.SADBELTableAdapters
    
    Partial Public Class BOX_DEFAULT_COMBINED_NCTS_ADMINTableAdapter
    End Class
End Namespace
