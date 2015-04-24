Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System

Public Class CryptographyData



    Public Function EncryptTextToFile(ByVal Data As String, ByVal FileName As String, ByVal Key() As Byte, ByVal IV() As Byte) As Boolean
        Dim reslute As Boolean = True
        Try

            ' Create or open the specified file.
            Dim fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

            ' Create a new Rijndael object.
            Dim RijndaelAlg As Rijndael = Rijndael.Create

            ' Create a CryptoStream using the FileStream 
            ' and the passed key and initialization vector (IV).
            Dim cStream As New CryptoStream(fStream, _
                                           RijndaelAlg.CreateEncryptor(Key, IV), _
                                           CryptoStreamMode.Write)

            ' Create a StreamWriter using the CryptoStream.
            Dim sWriter As New StreamWriter(cStream)

            Try

                ' Write the data to the stream 
                ' to encrypt it.
                sWriter.WriteLine(Data)
            Catch e As Exception
                reslute = False

            Finally

                ' Close the streams and
                ' close the file.
                sWriter.Close()
                cStream.Close()
                fStream.Close()

            End Try

        Catch e As CryptographicException
            reslute = False
        Catch e As UnauthorizedAccessException
            reslute = False
        End Try
        Return reslute
    End Function



    Public Function DecryptTextFromFile(ByVal FileName As String, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Try
            ' Create or open the specified file. 
            Dim fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

            ' Create a new Rijndael object.
            Dim RijndaelAlg As Rijndael = Rijndael.Create

            ' Create a CryptoStream using the FileStream 
            ' and the passed key and initialization vector (IV).
            Dim cStream As New CryptoStream(fStream, _
                                            RijndaelAlg.CreateDecryptor(Key, IV), _
                                            CryptoStreamMode.Read)

            ' Create a StreamReader using the CryptoStream.
            Dim sReader As New StreamReader(cStream)

            ' Read the data from the stream 
            ' to decrypt it.
            Dim val As String = Nothing

            Try

                val = sReader.ReadLine()

            Catch e As Exception

            Finally
                ' Close the streams and
                ' close the file.
                sReader.Close()
                cStream.Close()
                fStream.Close()


            End Try

            ' Return the string. 
            Return val

        Catch e As CryptographicException

            Return Nothing
        Catch e As UnauthorizedAccessException

            Return Nothing
        End Try
    End Function



    Public Function CryptographyString(ByVal path As String) As String
        Try
            ' Create a new Rijndael object to generate a key
            ' and initialization vector (IV).
            Dim RijndaelAlg As Rijndael = Rijndael.Create

            ' Create a string to encrypt.
            Dim sData As String = "Here is some data to encrypt."
            Dim FileName As String = path '"CText.txt"

            ' Encrypt text to a file using the file name, key, and IV.
            EncryptTextToFile(sData, FileName, RijndaelAlg.Key, RijndaelAlg.IV)

            ' Decrypt the text from a file using the file name, key, and IV.
            Dim Final As String = DecryptTextFromFile(FileName, RijndaelAlg.Key, RijndaelAlg.IV)
            Return Final

        Catch e As Exception
            Return ""
        End Try



    End Function

End Class
