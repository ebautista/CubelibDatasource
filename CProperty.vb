
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text

Public Enum PersistencePropertyType
    OUTPUT_FILE_PATH
    DATABASE
    SERVER_NAME
    USER_NAME
    PASSWORD
    MDB_PATH
    DEBUG
    SQL_SERVER_INTEGRATED_AUTHENTICATION
End Enum

Public Enum DBGeneralInstanceType
    DB_ARCHIVE_HISTORY
    DB_ARCHIVE_REPERTORY
    DB_ARCHIVE_EDI_HISTORY
    DB_CP_DATABASES
    DB_ALL
End Enum

Public Class CProperty


    Private Const PROPERTY_FILE_CRYPT_KEY As String = "[m??k???"

    Private Const PROPERTY_COMMENT As String = "#"
    Private Const KEY_VALUE_SEPARATOR As String = "="

    Private m_arrProperties() As String

    Private m_strPersistenceFilePath As String

    ' Function to generate a 64-bit key.
    Private Function GenerateKey() As String
        ' Create an instance of a symmetric algorithm. The key and the IV are generated automatically.
        Dim desCrypto As DESCryptoServiceProvider = DESCryptoServiceProvider.Create()

        ' Use the automatically generated key for encryption. 
        Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)

    End Function

    Friend Sub New(ByVal DestinationPath As String, _
                   ByVal DestinationFile As String, _
                   ByVal CPConfigContents As String)
        MyBase.New()

        Dim objReader As System.IO.StreamReader
        Dim xfile As System.IO.StreamWriter

        If Not File.Exists(DestinationPath.TrimEnd("\") + "\" + DestinationFile) And
            Not File.Exists(DestinationPath.TrimEnd("\") + "\" + DestinationFile.Replace(".dat", ".txt")) Then

            ' Creates a new file, if the file does not already exist.
            Try

                xfile = My.Computer.FileSystem.OpenTextFileWriter(DestinationPath.TrimEnd("\") + "\" + DestinationFile.Replace(".dat", ".txt"), True)
                xfile.WriteLine(CPConfigContents)
                xfile.Close()
                xfile.Dispose()

                objReader = New System.IO.StreamReader(DestinationPath.TrimEnd("\") + "\" + DestinationFile.Replace(".dat", ".txt"))
                m_arrProperties = objReader.ReadToEnd.Split(ControlChars.Cr)
                objReader.Close()
                objReader.Dispose()

                EncryptFile(DestinationPath.TrimEnd("\") + "\" + DestinationFile.Replace(".dat", ".txt"),
                            DestinationPath.TrimEnd("\") + "\" + DestinationFile,
                            PROPERTY_FILE_CRYPT_KEY)

                My.Computer.FileSystem.DeleteFile(DestinationPath.TrimEnd("\") + "\" + DestinationFile.Replace(".dat", ".txt"))

                m_strPersistenceFilePath = DestinationPath.TrimEnd("\") + "\" + DestinationFile

            Catch exPathTooLongException As PathTooLongException
                ' The pathname is too long
                AddToTrace("PathTooLongException in CProperty.New")

            Catch exIOException As IOException
                AddToTrace("IOException in CProperty.New. Either disk is full or file exists and is read-only.")
                ' Disk is full
                ' and
                ' file exists and is read-only

            End Try
        End If

    End Sub

    Public Sub New(ByVal filePath As String, ByVal propFileName As String)
        MyBase.New()
        Dim objReader As System.IO.StreamReader
        Dim decryptedFile As String

        'Dim tempKey As String
        'tempKey = GenerateKey()

        decryptedFile = IIf(filePath.EndsWith("\"), filePath + propFileName.Replace(".dat", ".txt"), filePath + "\" + propFileName.Replace(".dat", ".txt"))

        filePath = IIf(filePath.EndsWith("\"), filePath + propFileName, filePath + "\" + propFileName)

        'EncryptFile(decryptedFile, filePath, PROPERTY_FILE_CRYPT_KEY)

        Try

            DecryptFile(filePath, decryptedFile, PROPERTY_FILE_CRYPT_KEY)

            m_strPersistenceFilePath = filePath

            objReader = New System.IO.StreamReader(decryptedFile)
            m_arrProperties = objReader.ReadToEnd.Split(ControlChars.Cr)
            objReader.Close()
            objReader.Dispose()

            My.Computer.FileSystem.DeleteFile(decryptedFile)

        Catch ex As Exception
            m_arrProperties = My.Resources.persistence.Split(vbCrLf)
        End Try
    End Sub

    Public Function getPropertyKey(ByVal propertyPath As String) As String

        Dim blnNotFound As Boolean

        blnNotFound = False

        For Each prop As String In m_arrProperties
            If ((prop <> vbNullString) AndAlso Not prop.StartsWith(PROPERTY_COMMENT)) Then
                Dim arrKeyValue() As String = prop.Split(KEY_VALUE_SEPARATOR)
                If arrKeyValue.Length = 2 Then
                    If String.Equals(arrKeyValue(0).Trim.ToUpper, propertyPath.Trim.ToUpper) Then
                        blnNotFound = True

                        Return arrKeyValue(1)
                        Exit Function
                    End If
                End If
            End If
        Next

        getPropertyKey = ""
    End Function

    Public Sub setPropertyKey(ByVal propertyPath As String, _
                                   ByVal PropertyValue As String)

        Dim strFile As String

        Dim objReader As System.IO.StreamReader
        Dim blnFound As Boolean

        If IsPersistencePropertyValueValid(propertyPath, PropertyValue) Then

            Try
                blnFound = False

                DecryptFile(m_strPersistenceFilePath, m_strPersistenceFilePath.Replace(".dat", ".txt"), PROPERTY_FILE_CRYPT_KEY)

                My.Computer.FileSystem.DeleteFile(m_strPersistenceFilePath)

                strFile = ""
                For Each prop As String In m_arrProperties
                    If ((prop <> vbNullString) AndAlso Not prop.StartsWith(PROPERTY_COMMENT)) Then
                        Dim arrKeyValue() As String = prop.Split(KEY_VALUE_SEPARATOR)
                        If arrKeyValue.Length = 2 Then
                            If String.Equals(arrKeyValue(0).Trim.ToUpper, propertyPath.Trim.ToUpper) Then
                                strFile = strFile + arrKeyValue(0) & KEY_VALUE_SEPARATOR & PropertyValue + ControlChars.Cr
                                blnFound = True
                            Else
                                strFile = strFile + arrKeyValue(0) & KEY_VALUE_SEPARATOR & arrKeyValue(1) + ControlChars.Cr
                            End If
                        Else
                            strFile = strFile + prop + ControlChars.Cr

                        End If
                    Else
                        strFile = strFile + prop + ControlChars.Cr
                    End If
                Next

                If Not blnFound Then
                    strFile = strFile + propertyPath.Trim & KEY_VALUE_SEPARATOR & PropertyValue + ControlChars.Cr
                End If

                File.WriteAllText(m_strPersistenceFilePath.Replace(".dat", ".txt"), strFile)

                objReader = New System.IO.StreamReader(m_strPersistenceFilePath.Replace(".dat", ".txt"))
                m_arrProperties = objReader.ReadToEnd.Split(ControlChars.Cr)
                objReader.Close()
                objReader.Dispose()

                EncryptFile(m_strPersistenceFilePath.Replace(".dat", ".txt"),
                            m_strPersistenceFilePath,
                            PROPERTY_FILE_CRYPT_KEY)

                My.Computer.FileSystem.DeleteFile(m_strPersistenceFilePath.Replace(".dat", ".txt"))


            Catch ex As Exception

                AddToTrace("Exception in CProperty.setPropertyKey")
            End Try
        End If

    End Sub


    Private Sub EncryptFile(ByVal sInputFilename As String, _
                  ByVal sOutputFilename As String, _
                  ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, _
                                    FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        'Set secret key for DES algorithm.
        'A 64-bit key and an IV are required for this provider.
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the DES encryptor from this instance.
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()

        'Create the crypto stream that transforms the file stream by using DES encryption.
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Read the file text to the byte array.
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)

        'Write out the DES encrypted file.
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
        cryptostream.Dispose()

        desencrypt.Dispose()

        fsInput.Close()
        fsInput.Dispose()

    End Sub

    Private Sub DecryptFile(ByVal sInputFilename As String, _
        ByVal sOutputFilename As String, _
        ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()

        'A 64-bit key and an IV are required for this provider.
        'Set the secret key for the DES algorithm.
        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the file stream to read the encrypted file back.
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)

        'Create the DES decryptor from the DES instance.
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()

        'Create the crypto stream set to read and to do a DES decryption transform on incoming bytes.
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)

        'Print out the contents of the decrypted file.
        Dim fsDecrypted As New StreamWriter(sOutputFilename)

        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsDecrypted.Close()

        cryptostreamDecr.Close()
        cryptostreamDecr.Dispose()

        desdecrypt.Dispose()

        fsread.Close()
        fsread.Dispose()

    End Sub
End Class
