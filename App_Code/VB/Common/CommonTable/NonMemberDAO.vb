Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class NonMemberDAO
        Inherits BaseDAO
        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        '依人員類別找人
        Public Function Select_NonEmployee_type_NonMemberData(ByVal NonEmployee_type As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "select distinct m.*,forg.Orgcode_name,forg.Depart_name " + _
                    "from NonMember m  " + _
                    "left join fsc_depart_emp de on m.Personnel_id = de.personnel_id  " + _
                    "left join FSCorg forg on de.orgcode = forg.Orgcode and de.depart_id = forg.Depart_id  " + _
                    "where NonEmployee_type=@NonEmployee_type "
            Dim ps() As SqlParameter = {New SqlParameter("@NonEmployee_type", NonEmployee_type)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace