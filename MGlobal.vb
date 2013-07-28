Imports ADODB
Imports System.Data.Common
Imports System.Data.OleDb

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

    'Public Function MapSystemToOle(ByVal columnType As Type) As OleDbType

    '    Select Case columnType.UnderlyingSystemType.ToString()
    '        Case "System.Boolean"
    '            Return OleDbType.Boolean

    '        Case "System.Byte"
    '            Return OleDbType.UnsignedTinyInt

    '        Case "System.Char"
    '            Return OleDbType.Char

    '        Case "System.DateTime"
    '            Return OleDbType.Date

    '        Case "System.Decimal"
    '            Return OleDbType.Currency

    '        Case "System.Double"
    '            Return OleDbType.Double

    '        Case "System.Int16"
    '            Return OleDbType.SmallInt

    '        Case "System.Int32"
    '            Return OleDbType.Integer

    '        Case "System.Int64"
    '            Return OleDbType.BigInt

    '        Case "System.SByte"
    '            Return OleDbType.TinyInt

    '        Case "System.Single"
    '            Return OleDbType.Single

    '        Case "System.UInt16"
    '            Return OleDbType.UnsignedSmallInt

    '        Case "System.UInt32"
    '            Return OleDbType.UnsignedInt

    '        Case "System.UInt64"
    '            Return OleDbType.UnsignedBigInt

    '        Case "System.String"
    '            Return OleDbType.VarChar

    '        Case Else
    '            Return OleDbType.VarChar

    '    End Select
    'End Function

    'Public Function MapAdoToOle(ByVal columnType As ADODB.DataTypeEnum) As OleDbType

    '    Select Case columnType
    '        Case DataTypeEnum.adBoolean
    '            Return OleDbType.Boolean

    '        Case DataTypeEnum.adUnsignedTinyInt
    '            Return OleDbType.UnsignedTinyInt

    '        Case DataTypeEnum.adChar
    '            Return OleDbType.Char

    '        Case DataTypeEnum.adDate
    '            Return OleDbType.Date

    '        Case DataTypeEnum.adCurrency
    '            Return OleDbType.Currency

    '        Case DataTypeEnum.adDouble
    '            Return OleDbType.Double

    '        Case DataTypeEnum.adSmallInt
    '            Return OleDbType.SmallInt

    '        Case DataTypeEnum.adInteger
    '            Return OleDbType.Integer

    '        Case DataTypeEnum.adBigInt
    '            Return OleDbType.BigInt

    '        Case DataTypeEnum.adTinyInt
    '            Return OleDbType.TinyInt

    '        Case DataTypeEnum.adSingle
    '            Return OleDbType.Single

    '        Case DataTypeEnum.adUnsignedSmallInt
    '            Return OleDbType.UnsignedSmallInt

    '        Case DataTypeEnum.adUnsignedInt
    '            Return OleDbType.UnsignedInt

    '        Case DataTypeEnum.adUnsignedBigInt
    '            Return OleDbType.UnsignedBigInt

    '        Case DataTypeEnum.adVarChar
    '            Return OleDbType.VarChar

    '        Case Else
    '            Return OleDbType.VarChar

    '    End Select
    'End Function

    Public objProp As New CDatabaseProperty
End Module
