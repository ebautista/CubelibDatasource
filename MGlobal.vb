Imports ADODB
Imports System.Data.Common

Module MGlobal
    Public Enum CrudType
        CREATE
        READ
        UPDATE
        DELETE
    End Enum

    Public Const ACCESS_DB_EXTENSION_97_2003 As String = ".mdb"

    Public Function TranslateType(ByVal columnType As Type) As DataTypeEnum

        Select Case columnType.UnderlyingSystemType.ToString()
            Case "System.Boolean"
                Return DataTypeEnum.adBoolean

            Case "System.Byte"
                Return DataTypeEnum.adUnsignedTinyInt

            Case "System.Char"
                Return DataTypeEnum.adChar

            Case "System.DateTime"
                Return DataTypeEnum.adDate

            Case "System.Decimal"
                Return DataTypeEnum.adCurrency

            Case "System.Double"
                Return DataTypeEnum.adDouble

            Case "System.Int16"
                Return DataTypeEnum.adSmallInt

            Case "System.Int32"
                Return DataTypeEnum.adInteger

            Case "System.Int64"
                Return DataTypeEnum.adBigInt

            Case "System.SByte"
                Return DataTypeEnum.adTinyInt

            Case "System.Single"
                Return DataTypeEnum.adSingle

            Case "System.UInt16"
                Return DataTypeEnum.adUnsignedSmallInt

            Case "System.UInt32"
                Return DataTypeEnum.adUnsignedInt

            Case "System.UInt64"
                Return DataTypeEnum.adUnsignedBigInt

            Case "System.String"
                Return DataTypeEnum.adVarChar

            Case Else
                Return DataTypeEnum.adVarChar

        End Select
    End Function

    Public objProp As New CDatabaseProperty
End Module
