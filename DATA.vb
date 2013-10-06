Partial Class DATA
End Class

Namespace DATATableAdapters
    Partial Public Class MASTERTableAdapter
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

    Partial Public Class MASTEREDINCTSTableAdapter
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

    Partial Public Class MASTEREDINCTS2TableAdapter
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

    Partial Public Class MASTEREDINCTSIE44TableAdapter
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

    Partial Public Class MASTERNCTSTableAdapter
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

    Partial Public Class MASTERPLDATableAdapter
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

    Partial Public Class TEMPLATETREELINKSTableAdapter
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

