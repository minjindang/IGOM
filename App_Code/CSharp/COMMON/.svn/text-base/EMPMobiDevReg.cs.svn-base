using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// EMPMobiDevReg 的摘要描述
/// </summary>
/// 
namespace EMPPLM.Logic
{
    public class EMPMobiDevReg
    {
        private EMPMobiDevRegDAO DAO;
        public EMPMobiDevReg()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMPMobiDevRegDAO();
        }
        public EMPMobiDevReg(SqlConnection conn)
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
            DAO = new EMPMobiDevRegDAO(conn);
        }

            // 查詢資料是否存在
        public bool isDataExists(
            string strIDCard,
            string strADID,
            string strUniqueID,
            string isRegisted
            )
        {
            return DAO.isDataExists(
                strIDCard,
                strADID,
                strUniqueID,
                isRegisted);
        }

            // 新增 EMP_MOBIDEV_REG
        public int insertEmpMobidevReg(
            string strIDCard,   // 
            string strADID,
            string strUniqueID,
            string strIsRegisted,
            string strChangeUserID
            , string strMobType
            )
        {
            return DAO.insertEmpMobidevReg(
             strIDCard,   // 
             strADID,
             strUniqueID,
             strIsRegisted,
             strChangeUserID
             , strMobType
             );
        }

            // 更新
        public int updateEmpMobidevReg(
            string strIDCard,   // 
            string strADID,
            string strUniqueID,
            string strIsRegisted,
            string strChangeUserID,
            string strUpdateConfirmDate // 是否更新 CONFIRM_DATE( Y/N )
            )
        {
            return DAO.updateEmpMobidevReg(
             strIDCard,   // 
             strADID,
             strUniqueID,
             strIsRegisted,
             strChangeUserID,
             strUpdateConfirmDate);
        }


        public string queryADIDByUniqueID(
            string strUniqueID,
            string strMobType
        )
        {
            return DAO.queryADIDByUniqueID(strUniqueID, strMobType);
        }

    }
}