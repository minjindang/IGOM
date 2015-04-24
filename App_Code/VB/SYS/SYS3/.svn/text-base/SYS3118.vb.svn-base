Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO

Namespace SYS.Logic
    Public Class SYS3118

        Public Sub Update(orgcode As String, _
                          departId As String, _
                          fuFile As FileUpload, _
                          fileName As String, _
                          saveName As String, _
                          savePath As String, _
                          Start_date As String, _
                          End_date As String, _
                          removed_flag As String, _
                          id As String)

            Dim pf As New PaperFile()

            If fuFile.HasFile Then
                DeleteFile(id)  'delete real file

                Add(orgcode, departId, fuFile, Start_date, End_date, removed_flag) 'upload new file and insert data

                pf.DeleteById(id)   'delete data
            Else

                'update data
                pf.Orgcode = orgcode
                pf.DepartId = departId
                pf.FileName = fileName
                pf.RealName = saveName
                pf.Path = savePath
                pf.Start_date = Start_date
                pf.End_date = End_date
                pf.removed_flag = removed_flag
                pf.ChangeUserid = LoginManager.UserId
                pf.UpdateData(id)
            End If

        End Sub

        Public Sub Add(orgcode As String, _
                              departId As String, _
                              fuFile As FileUpload, _
                              Start_date As String, _
                              End_date As String, _
                              removed_flag As String)


            If fuFile.HasFile Then

                Dim folder As String = CommonFun.GetAppSetting("PaperForm")
                Dim yyy As String = (Now.Year - 1911).ToString().PadLeft(3, "0")
                Dim fileName As String = fuFile.FileName
                Dim ext As String = fileName.Split(".")(1)
                Dim saveName As String = Guid.NewGuid().ToString() & "." & ext
                Dim savePath As String = HttpContext.Current.Server.MapPath(folder) & orgcode & "\" & departId & "\" & yyy & "\"


                If Not Directory.Exists(savePath) Then
                    CommonFun.CreateDir(savePath)
                End If

                fuFile.SaveAs(savePath & saveName)

                Dim pf As New PaperFile()
                pf.Orgcode = orgcode
                pf.DepartId = departId
                pf.FileName = fileName
                pf.RealName = saveName
                pf.Path = savePath
                pf.Start_date = Start_date
                pf.End_date = End_date
                pf.removed_flag = removed_flag
                pf.ChangeUserid = LoginManager.UserId
                pf.InsertData()

            End If

        End Sub

        Public Sub DeleteFile(id As String)
            Dim pf As New SYS.Logic.PaperFile()
            Dim saveName As String = ""
            Dim savePath As String = ""

            Dim dt As DataTable = pf.GetDataById(id)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                saveName = dt.Rows(0)("Real_name").ToString()
                savePath = dt.Rows(0)("Path").ToString()
            End If

            If Directory.Exists(savePath) Then
                CommonFun.DeleteFile(savePath & saveName)
            End If

            pf.DeleteById(id)


        End Sub
    End Class
End Namespace