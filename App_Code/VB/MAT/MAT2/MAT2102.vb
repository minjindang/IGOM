Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT2102
        Public DAO As MAT2102DAO

        Public Sub New()
            DAO = New MAT2102DAO()
        End Sub
        Public Function MAT2102SelectData(ByVal ApplyRadioButtonSelectedValue As String, _
                                          ByVal SortRadioButtonListValue As String, _
                                          ByVal Material_detS As String, _
                                          ByVal Material_detE As String, _
                                          ByVal ReceiveS As String, _
                                          ByVal ReceiveE As String, _
                                          ByVal OrgCodeDropDownList As String, _
                                          ByVal User_name As String) As DataTable
            Dim dt As DataTable

            dt = DAO.MAT2102SelectData(ApplyRadioButtonSelectedValue, SortRadioButtonListValue, Material_detS, Material_detE, ReceiveS, ReceiveE, OrgCodeDropDownList, User_name)

            If dt Is Nothing Then Return Nothing
            Return dt
        End Function


    End Class
End Namespace