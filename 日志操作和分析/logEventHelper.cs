using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace AnalysisLog
{
    public class logEventHelper
    {
        /// <summary>  
        /// 记录windows日志  
        /// </summary>  
        /// <param name="source">日志来源（自己命名）</param>  
        /// <param name="message">日志内容</param>  
        /// <param name="eventID">事件编号</param>  
        /// <param name="logName">  
        /// 可选项为1."Application"应用程序；2."Security"安全；3."System"系统</param>  
        public static void RecordWindowsLog(string source, string message
            , int eventID = 65500, string logName = "Application")
        {
            if (bool.Equals(EventLog.SourceExists(source), false))
            {
                EventLog.CreateEventSource(source, logName);
            }
            EventLog.WriteEntry(source, message, EventLogEntryType.Information, eventID);
        }


        /// <summary>  
        /// 读取windows日志（这个方法的根据指定的事件编号筛选的，也可用其他参数筛选，自行修改）  
        /// </summary>  
        /// <param name="eventID">事件编号</param>  
        /// <param name="logName">  
        /// 可选项为1."Application"应用程序；2."Security"安全；3."System"系统</param>  
        /// <returns>返回读取到的记录，每行表示一条记录</returns>  
        public static string ReadWindowsLog(int eventID, string logName = "Application")
        {
            EventLog eventlog = new EventLog();
            eventlog.Log = logName;
            EventLogEntryCollection eventLogEntryCollection = eventlog.Entries;
            StringBuilder sb = new StringBuilder();
            foreach (EventLogEntry entry in eventLogEntryCollection)
            {
                //这边可以自行改条件  
                if (eventID == entry.InstanceId)
                {
                    sb.AppendFormat("消息:{0};时间:{1};来源:{2};类型:{3};"+"\\t"
                        , entry.Message
                        , entry.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss.fff")
                        , entry.Source
                        , entry.EntryType.ToString());
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        /// <summary>  
        /// 读取其他指定服务的日志（非windows日志）  
        /// </summary>  
        /// <param name="logName">日志名称</param>  
        /// <returns>指定服务的日志</returns>  
        public static string ReadOtherServiceLog(string logName)
        {
            EventLogReader eventLogReader = new EventLogReader(logName);
            EventRecord eventRecord = eventLogReader.ReadEvent();
            StringBuilder sb = new StringBuilder();
            while (eventRecord != null)
            {
                sb.AppendFormat("TaskDisplayName:{0},OpcodeDisplayName:{1},Keywords:{1}"
                    , eventRecord.TaskDisplayName
                    , eventRecord.OpcodeDisplayName
                    , eventRecord.Keywords);
                sb.AppendLine();
                eventRecord = eventLogReader.ReadEvent();
            }
            return sb.ToString();
        }

       
        /// <summary>  
        /// 读取windows日志（这个方法的根据指定的事件编号筛选的，也可用其他参数筛选，自行修改）  
        /// </summary>   
        /// <param name="logName">  
        /// 可选项为1."Application"应用程序；2."Security"安全；3."System"系统</param>  
        /// <returns>返回读取到的记录，每行表示一条记录</returns>  
        public static string ReadWindowsLog2(string logName = "Application")
        {
            EventLog eventlog = new EventLog();
            eventlog.Log = logName;
            EventLogEntryCollection eventLogEntryCollection = eventlog.Entries;
            StringBuilder sb = new StringBuilder();
            foreach (EventLogEntry entry in eventLogEntryCollection)
            {
                sb.AppendFormat("消息:{0};时间:{1};来源:{2};类型:{3};" + "\\t"
                    , entry.Message
                    , entry.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    , entry.Source
                    , entry.EntryType.ToString());
                sb.AppendLine();               
            }
            return sb.ToString();
        }
    }
}
