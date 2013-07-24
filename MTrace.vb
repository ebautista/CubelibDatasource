Imports System.IO

Module MTrace

    Public G_strMdbPath As String

    Private Const CONST_PREFIX As String = "CubelibDataSource Error Log: "

    Public Sub AddToTrace(ByVal Message As String, Optional ByVal DebugOnly As Boolean = False)
        Dim fileReName As String = G_strMdbPath & "\DatasourceTracefile_" & Format(Now, "yyyyMMdd_hhmmss") & ".log"
        Dim fileName As String = G_strMdbPath & "\DatasourceTracefile.log"
        Dim info As New FileInfo(fileName)
        Dim sw As StreamWriter

        Try
            If (info.Exists) Then
                If info.Length < 360000 Then
                    sw = info.AppendText()
                Else
                    info.CopyTo(fileReName)
                    info.Delete()

                    sw = info.CreateText()
                End If

            Else
                sw = info.CreateText()
            End If

            If DebugOnly Then
                If objProp.printDebugTrace Then
                    sw.WriteLine(CONST_PREFIX & Format(Now, "yyyy-MM-dd hh:mm:ss") & " : " & Message)
                End If
            Else
                sw.WriteLine(CONST_PREFIX & Format(Now, "yyyy-MM-dd hh:mm:ss") & " : " & Message)
            End If

        Catch e As Exception
            Err.Clear()
        Finally
            If Not sw Is Nothing Then
                sw.Close()
            End If
        End Try

    End Sub

End Module
