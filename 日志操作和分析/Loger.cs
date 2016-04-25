/*********************************************************


* 文件名  ：loger.cs
* 版本    ：1.0.0.0
* 功能描述：日志的管理

* 创建日期：2008.7.26 
* 修改记录：（序号，修改说明，日期，修改人）  
*********************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Threading;

namespace DotNet.Utilities
{
    public class Loger
    {
        string tableSpace = "\t";

        /*********************************************************		
         * 函数名  ：writeExceptionLog
         * 功能描述：写异常log信息
         * 返回值  ：Boolean
         * 参数    ：string strLog, 
         *           string thisURL, 
         *           string thisUser, 
         *           string UserID
         * 创建日期：2008-9-3
         * 修改记录：（序号，修改说明，日期，修改人）  
         *********************************************************/
        public static Boolean writeExceptionLog(string strLog, string thisURL, string thisUser, string UserID)
        {
            Boolean mark;
            //int pos = thisURL.IndexOf("localhost");
            string page = thisURL;

            Loger myLogUtil = new Loger();
            mark = myLogUtil.LogWrite(strLog, page, thisUser, UserID);
            return mark;
        }

        /*********************************************************		
         * 函数名  ：writeInfoLog
         * 功能描述：写info log信息
         * 返回值  ：Boolean
         * 参数    ：string strLog,  
         *          string userID, 
         *          string positionType
         * 创建日期：2008-9-3
         * 修改记录：（序号，修改说明，日期，修改人）  
         *********************************************************/
        public static Boolean writeInfoLog(string strLog, string loginid, string positionType)
        {
            Boolean mark;

            Loger myLogUtil = new Loger();
            mark = myLogUtil.LogWrite(strLog, "", loginid, positionType);
            return mark;

        }

        /*********************************************************		
         * 函数名  ：writeExceptionLog
         * 功能描述：写异常 log信息
         * 返回值  ：Boolean
         * 参数    ：string strLog
         * 创建日期：2008-9-3
         * 修改记录：（序号，修改说明，日期，修改人）  
         *********************************************************/
        public static Boolean writeExceptionLog(string strLog)
        {
            Boolean mark;

            Loger myLogUtil = new Loger();
            mark = myLogUtil.LogWrite(strLog, "", "", "");
            return mark;
        }

        /*********************************************************		
         * 函数名  ：LogWrite
         * 功能描述：向文件里写log信息
         * 返回值  ：Boolean
         * 参数    ：string strLog, 
         *          string page, 
         *          string thisUser, 
         *          string UserID
         * 创建日期：2008-9-3
         * 修改记录：（序号，修改说明，日期，修改人）  
         *********************************************************/
        public Boolean LogWrite(string strLog, string page, string thisUser, string UserID)
        {
            Boolean mark = true;
            string strYear = DateTime.Now.Year.ToString();
            string strMonth = DateTime.Now.Month.ToString();
            string strDay = DateTime.Now.Day.ToString();
            ;
            string strData = strYear;//+strMonth+strDay;

            if (DateTime.Now.Month < 10)
                strData += "0" + strMonth;
            else
                strData += strMonth;

            if (DateTime.Now.Day < 10)
                strData += "0" + strDay;
            else
                strData += strDay;

            string path1 = ConfigurationManager.AppSettings["LogPath"].ToString().Trim();
            string path2 = ".log";
            string path3 = path1 + @"\" + strData + path2;
            if (strMonth.Length == 1)
            {
                strMonth = "0" + strMonth;
            }

            if (!Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            string strTime = DateTime.Now.ToString();
            StreamWriter m_streamWriter = null;
            FileStream fs = null;
            try
            {
                lock (this)
                {
                    fs = new FileStream(path3, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                    m_streamWriter = new StreamWriter(fs);
                    m_streamWriter.Flush();

                    m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    m_streamWriter.WriteLine(strTime + tableSpace + UserID + tableSpace + thisUser + tableSpace + page + tableSpace + strLog);

                    m_streamWriter.Flush();
                    m_streamWriter.Close();
                    fs.Close();
                }
            }
            catch (IOException e)
            {
                if (m_streamWriter != null)
                {
                    m_streamWriter.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
                mark = false;
                throw e;
            }
            return mark;
        }

    }
}
