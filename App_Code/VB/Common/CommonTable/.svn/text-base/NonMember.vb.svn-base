Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class NonMember
        Public DAO As NonMemberDAO
        Public Sub New()
            DAO = New NonMemberDAO()
        End Sub
        '依人員類別找人
        Public Function Select_NonEmployee_type_NonMemberData(ByVal NonEmployee_type As String) As DataTable
            Return DAO.Select_NonEmployee_type_NonMemberData(NonEmployee_type)
        End Function
    End Class
End Namespace