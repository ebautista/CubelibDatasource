Imports System.Data.SqlClient

Public Interface ITableAdapter(Of TDataTable As DataTable)
    Inherits IDisposable

    'Sub AttachTransaction(_transaction As IDbTransaction)
    'Function CreateTransaction() As IDbTransaction

    Function GetByPK(ByRef pk() As Object) As TDataTable
    Function UpdateRow(row As DataRow) As Integer
    'Function InsertRow(row As DataRow) As Integer
End Interface
