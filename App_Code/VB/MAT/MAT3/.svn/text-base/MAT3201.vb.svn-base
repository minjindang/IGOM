Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT3201 
        Dim imDAO As InventoryMain

        Public Sub New() 
            imDAO = New InventoryMain()
        End Sub

        Public Function IsInventoring(orgCode As String) As Boolean 
            Return Not imDAO.GetMemoStar(orgCode) Is Nothing
        End Function

        Public Sub Insert(orgCode As String, InvStart_date As String, Expected_date As String, ModUser_id As String)
            imDAO.Insert(orgCode, InvStart_date, Expected_date, "", "*", "", ModUser_id, Now)
        End Sub

    End Class
End Namespace
