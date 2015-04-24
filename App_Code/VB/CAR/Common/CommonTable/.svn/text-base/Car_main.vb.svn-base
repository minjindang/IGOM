Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class Car_main
        Public DAO As Car_mainDAO

        Public Sub New()
            DAO = New Car_mainDAO
        End Sub

        Public Function GetData(ByVal orgCode As String) As DataTable
            Return DAO.GetData(orgCode)
        End Function


        Public Function GetCarData(ByVal ddlyy1 As String, ByVal ddlyy2 As String, ByVal BrandName As String, _
                                   ByVal ScrapDate As String, ByVal CarID As String) As DataTable
            Dim dt As DataTable

            dt = DAO.GetCarData(ddlyy1, ddlyy2, BrandName, ScrapDate, CarID)

            If dt Is Nothing Then Return Nothing
            Return dt

        End Function

        Public Function getDeleteData(ByVal Index As String, ByVal ddlyy1 As String, ByVal ddlyy2 As String, ByVal BrandName As String, _
                                   ByVal ScrapDate As String, ByVal CarID As String) As DataTable

            Dim dt As DataTable
            dt = DAO.getDeleteData(Index, ddlyy1, ddlyy2, BrandName, ScrapDate, CarID)
            If dt Is Nothing Then Return Nothing
            Return dt

        End Function

        'Public Function CAR0301_insert(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
        '                              ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
        '                               ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As Integer
        '    Return DAO.CAR0301_insert(carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg)
        'End Function

        Public Function CAR0301_update(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
                                  ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
                                   ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As Integer
            Return DAO.CAR0301_update(carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg)
        End Function

        Public Function CAR0301_GetCarData(ByVal CarID As String) As DataTable
            Dim dt As DataTable
            dt = DAO.CAR0301_GetCarData(CarID)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function checkCarid(ByVal carid As String) As DataTable

            Dim dt As DataTable
            dt = DAO.checkCarid(carid)
            If dt Is Nothing Then Return Nothing
            Return dt

        End Function

        'Public Function checkCaridData(ByVal carid As String) As Integer

        '    Return DAO.checkCaridData(carid)

        'End Function


        Public Function CAR0301_insertData(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
                                      ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
                                       ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As String
            Dim dt As DataTable
            Dim memo As String = ""
            dt = checkCarid(carid)

            If dt.Rows.Count > 0 Then
                memo = "車牌不可重複輸入。"
            Else
                memo = DAO.CAR0301_insertData(carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg)
            End If

            Return memo
        End Function

        'Public Function InsertGetData(ByVal Index As String, ByVal item As String, ByVal Next_id As String, ByVal Next_date As Date, ByVal Org_code As String) As String
        '    Dim dt As DataTable
        '    Dim memo As String = ""
        '    dt = SelectData(Index, memo)
        '    If dt.Rows.Count > 0 Then
        '        memo = "分類號編號不可重複輸入。"
        '    Else
        '        memo = DAO.MAT0305InsertGetData(Index, item, Next_id, Next_date, Org_code)
        '    End If
        '    Return memo
        'End Function


        Public Function GetcarName(orgCode As String, Optional Car_type As String = "") As DataTable
            Return DAO.GetcarName(orgCode, Car_type)
        End Function


        Public Function GetcarId(ByVal Carname As String) As DataTable
            Return DAO.GetcarId(Carname)
        End Function

        Public Function CAR1103_SELECT(ByVal ucCar_Type As String, ByVal ddlCar_Name As String, ByVal ddlCar_Id As String, ByVal rdo_Status As String) As DataTable
            Return DAO.CAR1103_SELECT(ucCar_Type, ddlCar_Name, ddlCar_Id, rdo_Status)
        End Function

        Public Function newlist(ByVal Orgcode As String) As DataTable
            Return DAO.newlist(Orgcode)
        End Function

        Public Function getAll(ByVal Carid As String) As DataTable
            Return DAO.getAll(Carid)
        End Function

        Public Function CAR1103_update(ByVal ucCar_Type As String, ByVal ddlCar_Name As String, ByVal Car_Id As String, _
                                           ByVal rdo_Status As String, ByVal rdo_Verify As String, ByVal used_Unit As String(), ByVal moduserid As String, ByVal moddate As String, ByVal modorg As String) As Integer
            Return DAO.CAR1103_update(ucCar_Type, ddlCar_Name, Car_Id, rdo_Status, rdo_Verify, used_Unit, moduserid, moddate, modorg)
        End Function

        Public Function Car_1104Select(ByVal Start_date As String, ByVal End_date As String, ByVal Car_name As String, _
                                          ByVal Car_id As String, ByVal Sort_style1 As String, ByVal Sort_style2 As String) As DataTable
            Return DAO.Car_1104Select(Start_date, End_date, Car_name, Car_id, Sort_style1, Sort_style2)
        End Function




    End Class
End Namespace

