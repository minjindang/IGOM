Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3202
        Public EPMDAO As PAY_ExaminePayer_main

        Public Sub New()
            EPMDAO = New PAY_ExaminePayer_main()
        End Sub

        Public Function Add(Payer_id As String, Payer_name As String) As String
            Dim msg As String

            Try
                msg = CheckPayerId(Payer_id)
                If String.IsNullOrEmpty(msg) Then
                    msg = CheckPayerName(Payer_name)
                End If

                If String.IsNullOrEmpty(msg) Then
                    EPMDAO.Add(LoginManager.OrgCode, Payer_id, Payer_name, LoginManager.UserId, Now)
                End If

                Return msg
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function Modify(Payer_id As String, Payer_name As String) As String
            Try
                EPMDAO.Modify(LoginManager.OrgCode, Payer_id, Payer_name, LoginManager.UserId, Now)
                Return ""
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Private Function CheckPayerId(Payer_id As String) As String
            Dim msg As String = String.Empty
            '付款人代號重複，請重新給號(可用代號:XXXX)。
            Dim dt As DataTable = EPMDAO.GetAll(Payer_id)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt = EPMDAO.GetAll()
                dt.DefaultView.Sort = "Payer_id desc"
                dt = dt.DefaultView.ToTable()
                msg = String.Format("付款人代號重複，請重新給號(可用代號:{0})。", (Convert.ToInt32(dt.Rows(0)("Payer_id")) + 1).ToString().PadLeft(4, "0"))
            End If
            Return msg
        End Function

        Private Function CheckPayerName(Payer_name As String) As String
            Dim msg As String = String.Empty
            Dim dt As DataTable = EPMDAO.GetAll("", Payer_name)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt = EPMDAO.GetAll()
                dt.DefaultView.Sort = "Payer_name desc"
                dt = dt.DefaultView.ToTable()
                msg = "付款人名稱重複。"
            End If
            Return msg
        End Function


    End Class

End Namespace

