Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.TripleDES
Imports System.Security.Cryptography.TripleDESCryptoServiceProvider

Namespace SALARY.Logic

    Public Class DES_ECB

        Public Shared Function enCrypt(ByVal context As String, ByVal tirsKey As String) As String
            Dim rv As String

            Dim tdes As New TripleDESCryptoServiceProvider
            Dim keyByte() As Byte = ASCIIEncoding.ASCII.GetBytes(tirsKey)
            Dim contextByte() As Byte = Encoding.GetEncoding("Big5").GetBytes(context)

            tdes.Key = keyByte
            tdes.Mode = CipherMode.ECB

            Dim enCryptor As ICryptoTransform = tdes.CreateEncryptor

            rv = Convert.ToBase64String(enCryptor.TransformFinalBlock(contextByte, 0, contextByte.Length))

            Return rv
        End Function

        Public Shared Function deCrypt(ByVal context As String, ByVal tirsKey As String) As String
            Dim rv As String

            Dim tdes As New TripleDESCryptoServiceProvider
            Dim keyByte() As Byte = ASCIIEncoding.ASCII.GetBytes(tirsKey)
            Dim contextByte() As Byte = Convert.FromBase64String(context)

            tdes.Key = keyByte
            tdes.Mode = CipherMode.ECB

            Dim deCryptor As ICryptoTransform = tdes.CreateDecryptor()

            Dim txt() As Byte = deCryptor.TransformFinalBlock(contextByte, 0, contextByte.Length)

            rv = Encoding.GetEncoding("Big5").GetString(txt)

            Return rv
        End Function


        Public Shared Function enCryptFile(ByVal sourcefile As String, ByVal destinationfile As String, ByVal tirsKey As String) As Boolean
            Dim rv As Boolean = True

            Dim sr As StreamReader = New StreamReader(sourcefile, Encoding.GetEncoding("Big5"))
            Dim sw As StreamWriter = New StreamWriter(destinationfile, False, Encoding.GetEncoding("Big5"))

            Dim newstr As String = ""

            Dim str As String = sr.ReadToEnd.ToString

            Try
                newstr &= SALARY.Logic.DES_ECB.enCrypt(str, tirsKey)
            Catch ex As Exception
                rv = False
            End Try


            sw.Write(newstr)

            sr.Close()
            sr.Dispose()
            sw.Close()
            sw.Dispose()

            Return rv
        End Function

        Public Shared Function deCryptFile(ByVal sourcefile As String, ByVal destinationfile As String, ByVal tirsKey As String) As Boolean
            Dim rv As Boolean = True

            Dim sr As StreamReader = New StreamReader(sourcefile, Encoding.GetEncoding("Big5"))
            Dim sw As StreamWriter = New StreamWriter(destinationfile, False, Encoding.GetEncoding("Big5"))

            Dim newstr As String = ""

            Dim str As String = sr.ReadToEnd

            Try
                newstr &= SALARY.Logic.DES_ECB.deCrypt(str, tirsKey)
            Catch ex As Exception
                rv = False
            End Try

            sw.Write(newstr)

            sr.Close()
            sr.Dispose()
            sw.Close()
            sw.Dispose()

            Return rv
        End Function


        Public Shared Function toNCR(ByVal rawString As String) As String
            Dim sb As StringBuilder = New StringBuilder

            Dim big5 As Encoding = Encoding.GetEncoding("big5")

            For Each c As Char In rawString

                Dim cc As Char() = {c}

                Dim cInBig5 As String = big5.GetString(big5.GetBytes(cc))

                If c.ToString <> "?" And cInBig5 = "?" Then
                    sb.AppendFormat("&#{0};", Convert.ToInt32(c))
                Else
                    sb.Append(c)
                End If

            Next

            Return sb.ToString
        End Function

    End Class

End Namespace
