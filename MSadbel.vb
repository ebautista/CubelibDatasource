﻿Imports CubelibDatasource.CDatasource
Imports ADODB
Imports System.Data.Common
Imports System.Text
Imports CubelibDatasource.CDatabaseProperty

Module MSadbel

    ' Generic method for creating and executing an update script using an ADODB.Recordeset Row
    Public Function FindAndUpdateRow(ByRef RecordsetToUpdate As CRecordset,
                                     ByVal TableName As IConvertible,
                            Optional ByVal Year As String = vbNullString) As Integer

        Dim adoRow As Recordset = RecordsetToUpdate.Recordset
        Dim source As New CDatasource
        Dim command As DbCommand
        Dim dataset As DataSet
        Dim fullUpdateClause As String
        Dim strTableName As String
        Dim columns As DataColumnCollection
        Dim aiList As List(Of String)
        Dim pkList As List(Of String)
        Dim notNullList As New List(Of String)()

        'Mark the row where to get the update value from
        adoRow.Bookmark = RecordsetToUpdate.BookMark

        'Get the TableName
        strTableName = GetTableName(adoRow, TableName)

        'Get the Table Schema
        dataset = getTableSchema(strTableName, GetDBInstanceTypeFromTableEnumType(TableName))
        columns = dataset.Tables(0).Columns

        '----------------------------------------------------------------------------------------------------------------
        'Get list of columns that are auto-incremented
        '----------------------------------------------------------------------------------------------------------------
        aiList = getAIColumns(dataset)
        '----------------------------------------------------------------------------------------------------------------

        '----------------------------------------------------------------------------------------------------------------
        'Get list of columns that are primary key
        '----------------------------------------------------------------------------------------------------------------
        pkList = getPKColumns(columns, dataset)
        '----------------------------------------------------------------------------------------------------------------

        'Generate the fullUpdateClause
        fullUpdateClause = CreateUpdateClause(strTableName, dataset, adoRow, aiList, pkList, notNullList)

        'Set the update command with the connection object 
        command = getConnectionObjectsNonQuery(fullUpdateClause, GetDBInstanceTypeFromTableEnumType(TableName), Year)

        'Set Update Paramater values
        For Each Field As ADODB.Field In adoRow.Fields
            If Not aiList.Contains(Field.Name) AndAlso notNullList.Contains(Field.Name) Then
                Dim param As DbParameter = CreateNewParameterADODB(adoRow, Field.Name, Field.Type)
                command.Parameters.Add(param)
            End If
        Next

        'Set WHERE clause values using PKs
        For Each column As DataColumn In columns
            If pkList.Count <= 0 Then
                AddToTrace("Error in MSadbel.FindAndUpdateRow() - Table being updated has no primary key.")
                Return MGlobal.FAILURE
            Else
                If IsPrimaryKeyColumn(dataset.Tables(0), column) Then
                    Dim param As DbParameter = CreateNewParameterADONET(adoRow, column.ColumnName, column.DataType)
                    command.Parameters.Add(param)
                End If
            End If
        Next

        Try
            command.ExecuteNonQuery()
        Catch ex As Exception
            AddToTrace("Error in MSadbel.FindAndUpdateRow() - " + ex.GetBaseException.Message)
            Return MGlobal.FAILURE
        End Try


        Return MGlobal.SUCCESS
    End Function

    ' Generic method for creating and executing an insert script using an ADODB.Recordeset Row
    Public Function InsertRow(ByRef RecordsetToUpdate As CRecordset,
                              ByVal TableName As IConvertible,
                     Optional ByVal Year As String = vbNullString) As Integer

        Dim adoRow As Recordset = RecordsetToUpdate.Recordset
        Dim source As New CDatasource
        Dim command As DbCommand
        Dim dataset As DataSet
        Dim fullInsertClause As String
        Dim strTableName As String

        'Mark the row where to get the insert value from
        adoRow.Bookmark = RecordsetToUpdate.BookMark

        'Get the TableName
        strTableName = GetTableName(adoRow, TableName)

        'Get the Table Schema
        dataset = getTableSchema(strTableName, GetDBInstanceTypeFromTableEnumType(TableName))

        'Generate the fullInsertClause
        fullInsertClause = CreateInsertClause(strTableName, dataset, adoRow)

        If fullInsertClause = vbNullString Then
            AddToTrace("Error in MSadbel.InsertRow() - ADO record does not contain a row to insert.", False)
            Return MGlobal.FAILURE
        End If

        'Set the insert command with the connection object 
        command = getConnectionObjectsNonQuery(fullInsertClause, GetDBInstanceTypeFromTableEnumType(TableName), Year)

        'Set Insert Paramater values
        For Each Field As ADODB.Field In adoRow.Fields
            Dim param As DbParameter = CreateNewParameterADODB(adoRow, Field.Name, Field.Type)
            command.Parameters.Add(param)
        Next

        Try
            command.ExecuteNonQuery()
        Catch ex As Exception
            AddToTrace("Error in MSadbel.InsertRow() - " + ex.GetBaseException.Message)
            Return MGlobal.FAILURE
        End Try


        Return MGlobal.SUCCESS
    End Function

    Private Function CreateUpdateClause(ByVal strTableName As String,
                                        ByRef Data As DataSet,
                                        ByRef adoRow As Recordset,
                                        ByRef aiList As List(Of String),
                                        ByRef pkList As List(Of String),
                                        ByRef notNullList As List(Of String)) As String

        Dim strSQL As String = vbNullString
        Dim command As New StringBuilder

        '----------------------------------------------------------------------------------------------------------------
        'Build the update script
        '----------------------------------------------------------------------------------------------------------------
        If (adoRow.RecordCount > 0) Then
            command.Append("UPDATE ")
            command.Append("[").Append(strTableName).Append("]")
            command.Append(" SET ")

            'Iterate through the new values
            For Each Field As ADODB.Field In adoRow.Fields
                If Not aiList.Contains(Field.Name) Then
                    If Not IsDBNull(Field.Value) Then
                        Select Case objProp.getDatabaseType()
                            Case DatabaseType.ACCESS
                                command.Append("[").Append(Field.Name).Append("] = ?, ")
                            Case DatabaseType.SQLSERVER
                                command.Append("[").Append(Field.Name).Append("] = @").Append(Field.Name.Replace(" ", "_").Replace("-", "_")).Append(", ")
                        End Select

                        notNullList.Add(Field.Name)
                    End If
                End If
            Next

            'Remove the last comma and append WHERE
            command.Length = command.Length - 2
            command.Append(" WHERE ")

            'Add PK columns to WHERE clause
            For Each column As DataColumn In Data.Tables(0).Columns
                If pkList.Count <= 0 Then

                    Return vbNullString
                Else
                    If pkList.Contains(column.ColumnName) Then
                        Select Case objProp.getDatabaseType()
                            Case DatabaseType.ACCESS
                                command.Append("[").Append(column.ColumnName).Append("] = ? AND ")
                            Case DatabaseType.SQLSERVER
                                command.Append("[").Append(column.ColumnName).Append("] = @PK_").Append(column.ColumnName.Replace(" ", "_").Replace("-", "_")).Append(" AND ")
                        End Select
                    End If
                End If
            Next

            'Remove the last AND
            command.Length = command.Length - 4
        End If
        '----------------------------------------------------------------------------------------------------------------

        Return command.ToString()
    End Function

    Private Function CreateInsertClause(ByVal strTableName As String,
                                        ByRef Data As DataSet,
                                        ByRef adoRow As Recordset) As String

        Dim strSQL As String = vbNullString
        Dim command As New StringBuilder
        Dim hasPK As Boolean = False
        Dim aiList As List(Of String)

        '----------------------------------------------------------------------------------------------------------------
        'Get list of columns that are auto-incremented
        '----------------------------------------------------------------------------------------------------------------
        aiList = getAIColumns(Data)
        '----------------------------------------------------------------------------------------------------------------

        '----------------------------------------------------------------------------------------------------------------
        'Build the insert script
        '----------------------------------------------------------------------------------------------------------------
        If (adoRow.RecordCount > 0) Then
            command.Append("INSERT INTO ")
            command.Append("[").Append(strTableName).Append("] ")
            command.Append("( ")

            'Iterate through the new values
            For Each Field As ADODB.Field In adoRow.Fields
                If Not aiList.Contains(Field.Name) Then
                    Select Case objProp.getDatabaseType()
                        Case DatabaseType.ACCESS
                            command.Append("[").Append(Field.Name).Append("], ")
                        Case DatabaseType.SQLSERVER
                            command.Append("[").Append(Field.Name).Append("], ")
                    End Select
                End If
            Next

            'Remove the last comma and append VALUES
            command.Length = command.Length - 2
            command.Append(") VALUES (")

            'Add values for columns
            For Each Field As ADODB.Field In adoRow.Fields
                If Not aiList.Contains(Field.Name) Then
                    Select Case objProp.getDatabaseType()
                        Case DatabaseType.ACCESS
                            command.Append("?, ")
                        Case DatabaseType.SQLSERVER
                            command.Append("@").Append(Field.Name.Replace(" ", "_").Replace("-", "_")).Append(", ")
                    End Select
                End If
            Next

            'Remove the last comma
            command.Length = command.Length - 2
            command.Append(") ")
        End If
        '----------------------------------------------------------------------------------------------------------------

        Return command.ToString()
    End Function

    Private Function getAIColumns(ByRef Data As DataSet) As List(Of String)
        Dim aiList As New List(Of String)()
        Dim columns As DataColumnCollection = Data.Tables(0).Columns

        For Each column As DataColumn In columns
            If column.AutoIncrement = True Then
                aiList.Add(column.ColumnName)
            End If
        Next

        Return aiList
    End Function

    Private Function getPKColumns(ByRef columns As DataColumnCollection, ByRef Data As DataSet) As List(Of String)
        Dim pkList As New List(Of String)()

        For Each column As DataColumn In columns
            If IsPrimaryKeyColumn(Data.Tables(0), column) Then
                pkList.Add(column.ColumnName)
            End If
        Next

        Return pkList
    End Function
End Module

