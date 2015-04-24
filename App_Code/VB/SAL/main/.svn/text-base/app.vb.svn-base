Imports Microsoft.VisualBasic

Namespace SALARY.Logic
    Public Class app

        Public Shared FilePath As String = "~/sa/Trans/SaLoadm/"

        Public Shared Function LoginCheckData() As String
            Return pub.HashSHA1(pub.AppSettings("LoginCheckData"))
        End Function

        Public Shared Function GetBaseTypeText(ByVal BaseType As String) As String
            Dim rv As String = ""
            Select Case BaseType
                Case "1"
                    rv = "個人"
                Case "2"
                    rv = "外僑"
                Case "3"
                    rv = "事業機關"
                Case Else
                    rv = "(尚未設定)"
            End Select
            ' 個人\外僑\事業機關\(尚未設定)
            Return rv
        End Function

        'Public Shared Function GetUnitDep(ByVal orgid) As String
        '    Dim rv As String = ""
        '    Try
        '        Using ta As New dt_SaUnit_TableAdapters.SAUNIT_TableAdapter
        '            Using t As dt_SaUnit_.SAUNIT_DataTable = ta.GetDataByOrgid(orgid)
        '                If t.Rows.Count > 0 Then
        '                    rv = t(0)("Unit_Dep").ToString
        '                End If
        '            End Using
        '        End Using
        '    Catch ex As Exception

        '    End Try
        '    Return rv
        'End Function


        '取得非員工編號新代碼
        Public Shared Function GetNewSEQNO() As String
            Dim sabase As New SABASETableAdapters.SAL_SABASETableAdapter
            Dim newSEQNO As String = sabase.GetDataByNewSEQNO.Rows(0)("BASE_SEQNO")
            If String.IsNullOrEmpty(newSEQNO) Then
                newSEQNO = "#00001"
            Else
                newSEQNO = "#" & (CInt(newSEQNO.Substring(1, 5).ToString()) + 1).ToString().PadLeft(5, "0")
            End If
            Return newSEQNO
        End Function
        Public Shared Function GetMemoSelected(ByVal orgid, ByVal seqno) As String
            Dim rv As String = "1"
            'If Not String.IsNullOrEmpty(orgid) And Not String.IsNullOrEmpty(seqno) Then
            '    Using ta As New dt_SABASE_TableAdapters.Memo_Sel_TableAdapter
            '        Using t As dt_SABASE_.Memo_Sel_DataTable = ta.GetData(orgid, seqno)
            '            If t.Rows.Count > 0 Then
            '                rv = t(0)("memo_sel").ToString
            '            End If
            '        End Using
            '    End Using
            'End If
            Return rv
        End Function

        Public Shared Function GetSQL_seqno(ByVal v_seqno)
            Dim rv As String = "''"

            If v_seqno <> "" Then
                Dim data As String() = Split(v_seqno, ", ")

                For i As Integer = 0 To data.Length - 1
                    If i = 0 Then
                        rv = "'" & data(i) & "'"
                    Else
                        rv &= ", '" & data(i) & "'"
                    End If
                Next
            Else

            End If

            Return rv
        End Function

        Public Shared Function GetSaCode_Desc1(ByVal code_sys, ByVal code_type, ByVal code_no) As String

            Dim rv As String = ""

            Using ta As New dt_SaCode_TableAdapters.SACODE_TableAdapter
                Using t As dt_SaCode_.SACODE_DataTable = ta.GetDataByCode2(code_sys, code_type, code_no)
                    If t.Rows.Count > 0 Then
                        rv = t(0)("Code_Desc1").ToString
                    End If
                End Using
            End Using

            Return rv

        End Function

        Public Shared Function GetSaCode_Desc1(ByVal code_sys, ByVal code_kind, ByVal code_type, ByVal code_no) As String

            Dim rv As String = ""

            Using ta As New dt_SaCode_TableAdapters.SACODE_TableAdapter
                Using t As dt_SaCode_.SACODE_DataTable = ta.GetDataByCode1(code_sys, code_kind, code_type, code_no)
                    If t.Rows.Count > 0 Then
                        rv = t(0)("Code_Desc1").ToString
                    End If
                End Using
            End Using

            Return rv

        End Function

        Public Shared Function GetSaproj_Name(ByVal orgid, ByVal proj_no) As String

            Dim rv As String = ""

            Using ta As New dt_SaProj_TableAdapters.SAPROJ_TableAdapter
                Using t As dt_SaProj_.SAPROJ_DataTable = ta.GetDataByCode(orgid, proj_no)
                    If t.Rows.Count > 0 Then
                        rv = t(0)("Proj_Code_Name").ToString
                    End If
                End Using
            End Using

            Return rv

        End Function

        'Public Shared Function GetSaDept_Desc(ByVal orgid, ByVal dep_no) As String

        '    Dim rv As String = ""

        '    Using ta As New dt_SaDept_TableAdapters.SADEPT_TableAdapter
        '        Using t As dt_SaDept_.SADEPT_DataTable = ta.GetDataByDeptNo(orgid, dep_no)
        '            If t.Rows.Count > 0 Then
        '                rv = t(0)("Dept_Desc").ToString
        '            End If
        '        End Using
        '    End Using

        '    Return rv

        'End Function

        ' 取得操作人員姓名
        'Public Shared Function GetUserName(ByVal userid) As String
        '    Dim rv As String = ""

        '    Using ta As New dt_SAROLE_NEW_TableAdapters.main_TableAdapter
        '        Using t As dt_SAROLE_NEW_.main_DataTable = ta.GetDataByUserID(userid)
        '            If t.Rows.Count > 0 Then
        '                rv = t(0)("Role_Employees_Name").ToString
        '            End If
        '        End Using
        '    End Using

        '    Return rv
        'End Function

        ' 取得操作人員姓名
        'Public Shared Function GetUserName(ByVal orgid, ByVal userid) As String
        '    Dim rv As String = ""

        '    Using ta As New dt_SAROLE_NEW_TableAdapters.SAROLE_NEW_TableAdapter
        '        Using t As dt_SAROLE_NEW_.SAROLE_NEW_DataTable = ta.GetDataById(orgid, userid)
        '            If t.Rows.Count > 0 Then
        '                rv = t(0)("Role_Employees_Name").ToString
        '            End If
        '        End Using
        '    End Using

        '    Return rv
        'End Function

        '顯示國曆日期時間
        Public Shared Function show_date_time(ByVal date_time) As String
            Dim rv As String = ""
            Dim tt As String = ""
            tt = date_time.ToString

            If tt = "" Then
                rv = ""
            Else
                rv = (Left(tt, 4) - 1911) & "/" & Mid(tt, 5, 2) & "/" & Mid(tt, 7, 2) & " " & Mid(tt, 9, 2) & ":" & Mid(tt, 11, 2) & ":" & Mid(tt, 13, 2)
            End If

            Return rv
        End Function

        '顯示國曆日期
        Public Shared Function show_date(ByVal v_date) As String
            Dim rv As String = ""
            Dim tt As String = ""
            tt = v_date.ToString

            If tt = "" Then
                rv = ""
            Else
                rv = (Left(tt, 4) - 1911) & "/" & Mid(tt, 5, 2) & "/" & Mid(tt, 7, 2)
            End If

            Return rv
        End Function

        Public Shared Function Date_str(ByVal str) As String

            Dim rv As String = ""

            Select Case str.ToString.Length
                Case 4
                    rv = (Left(str, 4) - 1911) & "年"
                Case 6
                    rv = (Left(str, 4) - 1911) & "年" & Mid(str, 5, 2) & "月"
                Case 8
                    rv = (Left(str, 4) - 1911) & "年" & Mid(str, 5, 2) & "月" & Mid(str, 7, 2) & "日"

            End Select

            Return rv

        End Function

        Public Shared Function trans_payodOrgidStr(ByVal v_orgid) As String
            Dim rv As String
            If v_orgid = "379150000I" Then
                '--環保局
                rv = " PAYOD_ORGID in ('379150000I','8900000001','8900000002','8900000003','8900000004'," & _
                                     "'8900000006','8900000007','8900000008','8900000009','8900000010'," & _
                                     "'8900000011','8900000012','8900000013','8900000014','8900000015'," & _
                                     "'8900000016','8900000041','8900000042','890000005','890000006') "
            ElseIf v_orgid = "379135000C" Then
                '--少年警察隊 
                rv = " PAYOD_ORGID in ('379135000C','9300000001') "
            Else
                rv = " PAYOD_ORGID = '" & v_orgid & "' "
            End If
            Return rv
        End Function

        Public Shared Function trans_upempOrgidStr(ByVal v_orgid) As String
            Dim rv As String
            If v_orgid = "379150000I" Then
                '--環保局
                rv = " UPEMP_ORGID in ('379150000I','8900000001','8900000002','8900000003','8900000004'," & _
                                     "'8900000006','8900000007','8900000008','8900000009','8900000010'," & _
                                     "'8900000011','8900000012','8900000013','8900000014','8900000015'," & _
                                     "'8900000016','8900000041','8900000042','890000005','890000006') "
            ElseIf v_orgid = "379135000C" Then
                '--少年警察隊 
                rv = " UPEMP_ORGID in ('379135000C','9300000001') "
            Else
                rv = " UPEMP_ORGID = '" & v_orgid & "' "
            End If
            Return rv
        End Function

        Public Shared Function trans_baseOrgidStr(ByVal v_orgid) As String
            Dim rv As String
            If v_orgid = "379150000I" Then
                '--環保局
                rv = " BASE_ORGID in ('379150000I','8900000001','8900000002','8900000003','8900000004'," & _
                                     "'8900000006','8900000007','8900000008','8900000009','8900000010'," & _
                                     "'8900000011','8900000012','8900000013','8900000014','8900000015'," & _
                                     "'8900000016','8900000041','8900000042','890000005','890000006') "
            ElseIf v_orgid = "379135000C" Then
                '--少年警察隊 
                rv = " BASE_ORGID in ('379135000C','9300000001') "
            Else
                rv = " BASE_ORGID = '" & v_orgid & "' "
            End If
            Return rv
        End Function

        Public Shared Function show_edit(ByVal v_role) As String
            Dim rv As String = "False"

            If v_role = "001" Then
                rv = "True"
            End If

            Return rv
        End Function

        'Public Shared Sub ReBuildMenuItemAsSitemapFile()
        '    Dim o As New SiteMapFile()
        '    o.BuildSitemapFile("~/Web.sitemap")
        '    o = Nothing
        'End Sub


    End Class
End Namespace
