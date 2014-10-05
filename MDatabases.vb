
Imports System.Data.Common
Imports System.Data.SqlClient

Module MDatabases

    Public Function CheckDatabaseExists_F(ByVal Server As String, _
                                          ByVal DatabaseName As String) As Boolean

        Dim conTemp As DbConnection
        Dim cmdText As String
        Dim sqlCmd As SqlCommand
        Dim bRet As Boolean = False

        conTemp = getConnection("master", g_objDatabaseProperty, False)
        'conTemp.Open()

        cmdText = ("SELECT * FROM master.dbo.sysdatabases where name='" + DatabaseName + "'")

        sqlCmd = New SqlCommand(cmdText, conTemp)

        Using reader As SqlDataReader = sqlCmd.ExecuteReader
            bRet = reader.HasRows

            reader.Close()
        End Using

        sqlCmd.Dispose()

        conTemp.Close()
        conTemp.Dispose()


        Return bRet

    End Function

End Module
