Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SAL.Logic
    Public Class PaySalChgNoticMain
        Private dao As PaySalChgNoticMainDAO

        Public Sub New()
            dao = New PaySalChgNoticMainDAO()
        End Sub

#Region "Property"
        Private _Employee_type As String
        Public Property Employee_type() As String
            Get
                Return _Employee_type
            End Get
            Set(ByVal value As String)
                _Employee_type = value
            End Set
        End Property
        Private _Id_card As String
        Public Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property
        Private _User_name As String
        Public Property User_name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Private _Org_code As String
        Public Property Org_code() As String
            Get
                Return _Org_code
            End Get
            Set(ByVal value As String)
                _Org_code = value
            End Set
        End Property
        Private _Depart_id As String
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Private _Title_code As String
        Public Property Title_code() As String
            Get
                Return _Title_code
            End Get
            Set(ByVal value As String)
                _Title_code = value
            End Set
        End Property
        Private _Assign_date As String
        Public Property Assign_date() As String
            Get
                Return _Assign_date
            End Get
            Set(ByVal value As String)
                _Assign_date = value
            End Set
        End Property
        Private _Assign_no As String
        Public Property Assign_no() As String
            Get
                Return _Assign_no
            End Get
            Set(ByVal value As String)
                _Assign_no = value
            End Set
        End Property
        Private _Join_date As String
        Public Property Join_date() As String
            Get
                Return _Join_date
            End Get
            Set(ByVal value As String)
                _Join_date = value
            End Set
        End Property
        Private _L3_code As String
        Public Property L3_code() As String
            Get
                Return _L3_code
            End Get
            Set(ByVal value As String)
                _L3_code = value
            End Set
        End Property
        Private _L1_code As String
        Public Property L1_code() As String
            Get
                Return _L1_code
            End Get
            Set(ByVal value As String)
                _L1_code = value
            End Set
        End Property
        Private _L2_code As String
        Public Property L2_code() As String
            Get
                Return _L2_code
            End Get
            Set(ByVal value As String)
                _L2_code = value
            End Set
        End Property
        Private _PtbPoint_nos As String
        Public Property PtbPoint_nos() As String
            Get
                Return _PtbPoint_nos
            End Get
            Set(ByVal value As String)
                _PtbPoint_nos = value
            End Set
        End Property
        Private _Ptb_amt As Double
        Public Property Ptb_amt() As Double
            Get
                Return _Ptb_amt
            End Get
            Set(ByVal value As Double)
                _Ptb_amt = value
            End Set
        End Property
        Private _Salary_point As String
        Public Property Salary_point() As String
            Get
                Return _Salary_point
            End Get
            Set(ByVal value As String)
                _Salary_point = value
            End Set
        End Property
        Private _Salary_amt As Double
        Public Property Salary_amt() As Double
            Get
                Return _Salary_amt
            End Get
            Set(ByVal value As Double)
                _Salary_amt = value
            End Set
        End Property
        Private _Rate_nos As Double
        Public Property Rate_nos() As Double
            Get
                Return _Rate_nos
            End Get
            Set(ByVal value As Double)
                _Rate_nos = value
            End Set
        End Property
        Private _Month_pay As Double
        Public Property Month_pay() As Double
            Get
                Return _Month_pay
            End Get
            Set(ByVal value As Double)
                _Month_pay = value
            End Set
        End Property
        Private _Fin_month As String
        Public Property Fin_month() As String
            Get
                Return _Fin_month
            End Get
            Set(ByVal value As String)
                _Fin_month = value
            End Set
        End Property
        Private _Fin_amt As Double
        Public Property Fin_amt() As Double
            Get
                Return _Fin_amt
            End Get
            Set(ByVal value As Double)
                _Fin_amt = value
            End Set
        End Property
        Private _Fin_people As String
        Public Property Fin_people() As String
            Get
                Return _Fin_people
            End Get
            Set(ByVal value As String)
                _Fin_people = value
            End Set
        End Property
        Private _Fin_people_amt As Double
        Public Property Fin_people_amt() As Double
            Get
                Return _Fin_people_amt
            End Get
            Set(ByVal value As Double)
                _Fin_people_amt = value
            End Set
        End Property
        Private _Fund_month As String
        Public Property Fund_month() As String
            Get
                Return _Fund_month
            End Get
            Set(ByVal value As String)
                _Fund_month = value
            End Set
        End Property
        Private _Fund_day As String
        Public Property Fund_day() As String
            Get
                Return _Fund_day
            End Get
            Set(ByVal value As String)
                _Fund_day = value
            End Set
        End Property
        Private _Fund_amt As Double
        Public Property Fund_amt() As Double
            Get
                Return _Fund_amt
            End Get
            Set(ByVal value As Double)
                _Fund_amt = value
            End Set
        End Property
        Private _Safety_month As String
        Public Property Safety_month() As String
            Get
                Return _Safety_month
            End Get
            Set(ByVal value As String)
                _Safety_month = value
            End Set
        End Property
        Private _Safety_day As String
        Public Property Safety_day() As String
            Get
                Return _Safety_day
            End Get
            Set(ByVal value As String)
                _Safety_day = value
            End Set
        End Property
        Private _Safety_amt As Double
        Public Property Safety_amt() As Double
            Get
                Return _Safety_amt
            End Get
            Set(ByVal value As Double)
                _Safety_amt = value
            End Set
        End Property
        Private _Mutual_month As String
        Public Property Mutual_month() As String
            Get
                Return _Mutual_month
            End Get
            Set(ByVal value As String)
                _Mutual_month = value
            End Set
        End Property
        Private _Mutual_amt As Double
        Public Property Mutual_amt() As Double
            Get
                Return _Mutual_amt
            End Get
            Set(ByVal value As Double)
                _Mutual_amt = value
            End Set
        End Property
        Private _House_type As String
        Public Property House_type() As String
            Get
                Return _House_type
            End Get
            Set(ByVal value As String)
                _House_type = value
            End Set
        End Property
        Private _Head_post_plus As String
        Public Property Head_post_plus() As String
            Get
                Return _Head_post_plus
            End Get
            Set(ByVal value As String)
                _Head_post_plus = value
            End Set
        End Property

        Private _Law_prof_plus As String
        Public Property Law_prof_plus() As String
            Get
                Return _Law_prof_plus
            End Get
            Set(ByVal value As String)
                _Law_prof_plus = value
            End Set
        End Property
        Private _General_prof_plus As String
        Public Property General_prof_plus() As String
            Get
                Return _General_prof_plus
            End Get
            Set(ByVal value As String)
                _General_prof_plus = value
            End Set
        End Property
        Private _Enviprotec_prof_plus As String
        Public Property Enviprotec_prof_plus() As String
            Get
                Return _Enviprotec_prof_plus
            End Get
            Set(ByVal value As String)
                _Enviprotec_prof_plus = value
            End Set
        End Property
        Private _Operator_prof_plus As String
        Public Property Operator_prof_plus() As String
            Get
                Return _Operator_prof_plus
            End Get
            Set(ByVal value As String)
                _Operator_prof_plus = value
            End Set
        End Property
        Private _East_taiwan_plus As String
        Public Property East_taiwan_plus() As String
            Get
                Return _East_taiwan_plus
            End Get
            Set(ByVal value As String)
                _East_taiwan_plus = value
            End Set
        End Property
        Private _Natimajproj_post_plus As String
        Public Property Natimajproj_post_plus() As String
            Get
                Return _Natimajproj_post_plus
            End Get
            Set(ByVal value As String)
                _Natimajproj_post_plus = value
            End Set
        End Property
        Private _Technical_staff As String
        Public Property Technical_staff() As String
            Get
                Return _Technical_staff
            End Get
            Set(ByVal value As String)
                _Technical_staff = value
            End Set
        End Property
        Private _Promo_desc As String
        Public Property Promo_desc() As String
            Get
                Return _Promo_desc
            End Get
            Set(ByVal value As String)
                _Promo_desc = value
            End Set
        End Property
        Private _Send_status As String
        Public Property Send_status() As String
            Get
                Return _Send_status
            End Get
            Set(ByVal value As String)
                _Send_status = value
            End Set
        End Property
        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Function Insert() As Boolean
            Return dao.Insert(Me) > 0
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Return dao.GetDataById(id)
        End Function

        Public Function GetObject(ByVal id As Integer) As PaySalChgNoticMain
            Dim dt As DataTable = GetDataById(id)
            Dim list As List(Of PaySalChgNoticMain) = CommonFun.ConvertToList(Of PaySalChgNoticMain)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function


        Public Function UpdateSendStatus(ByVal id As Integer, ByVal sendStatus As String) As Boolean

            Return dao.UpdateSendStatus(id, sendStatus) > 0
        End Function
    End Class
End Namespace