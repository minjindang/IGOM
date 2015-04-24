Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace SYS.Logic
    Public Class FavoriteDAO
        Inherits BaseDAO

        Public Function Insert(fav As Favorite) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", fav.Orgcode)
            d.Add("Id_card", fav.Id_card)
            d.Add("Func_id", fav.Func_id)
            d.Add("Change_userid", fav.Change_userid)
            d.Add("Change_date", fav.Change_date)

            Return InsertByExample("SYS_Favorite", d)
        End Function

        Public Function Delete(fav As Favorite) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", fav.Orgcode)
            d.Add("Id_card", fav.Id_card)

            Return DeleteByExample("SYS_Favorite", d)
        End Function

        Public Function GetData(orgcode As String, idCard As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Id_card", idCard)
            Return GetDataByExample("SYS_Favorite", d)
        End Function
    End Class
End Namespace