Imports System.Data.SqlClient

Public Interface ITableAdapter(Of TDataTable As DataTable)
    Inherits IDisposable

    Function RowUpdate(row As DataRow) As Integer
    Function TableUpdate(table As DataTable) As Integer
    Function GetByPK(ParamArray pk() As Object) As TDataTable
End Interface
