using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DotNet.Utilities.Excel
{
    public class ReadExcelData
    {
        public void ReadExcelData() { }

        private void ReadExcel(string pPath)
        {
            //List<DTO_Admin_Account_Info> DeleteList = DAL_Admin_Account_Info.DeleteAllList();
            string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pPath + ";Extended Properties=Excel 12.0;";
            OleDbConnection oleCon = new OleDbConnection(conn);
            oleCon.Open();

            string SqlPersonDate = "select * from [Sheet1$]";
            OleDbDataAdapter CommandPersonDate = new OleDbDataAdapter(SqlPersonDate, oleCon);
            DataSet DsPersonDate = new DataSet();
            CommandPersonDate.Fill(DsPersonDate, "[Sheet1$]");
            oleCon.Close();

            int eCount = DsPersonDate.Tables["[Sheet1$]"].Rows.Count;
            for (int i = 0; i < eCount; i++)
            {
                string Account = DsPersonDate.Tables["[Sheet1$]"].Rows[i][0].ToString().Trim().ToLower();
                string Name = DsPersonDate.Tables["[Sheet1$]"].Rows[i][1].ToString().Trim();
                string Department = DsPersonDate.Tables["[Sheet1$]"].Rows[i][2].ToString().Trim();
                string Email = DsPersonDate.Tables["[Sheet1$]"].Rows[i][3].ToString().Trim();
                string Phone = DsPersonDate.Tables["[Sheet1$]"].Rows[i][4].ToString().Trim();
                string ManageAccount = DsPersonDate.Tables["[Sheet1$]"].Rows[i][5].ToString().Trim();
                //一条一条读出Excel中的数据，然后做相关操作

            }

        }
    }

}
