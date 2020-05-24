using System;
using System.Data;
using System.IO;

namespace Eisp.Common
{
    public enum LogType : byte
    {
        Error = 0,
        Operation = 1,
        Other = 255
    }
    public class LogWriterBase
    {
        // 从日期获取Log文件名的格式
        public const string NAMERULE = "yyyyMMdd";
        protected static object Lock;

        static LogWriterBase()
        {
            Lock = new object();
        }

        protected LogWriterBase()
        {
        }

        /// <summary>
        /// 记录Log信息
        /// </summary>
        /// <param name="type">Log类型</param>
        /// <param name="host">产生Log的对象</param>
        /// <param name="param">对象产生Log时的属性状态</param>
        /// <param name="time">产生时间</param>
        /// <param name="abs">概述</param>
        /// <param name="desc">描述</param>
        /// <param name="resource">请求的资源</param>
        /// <param name="method">请求方式</param>
        /// <param name="ip">请求IP</param>
        /// <param name="agent">请求的客户端信息</param>
        public virtual void Write(LogType type, string sender, DateTime time, string desc, string code, string postdata, string cookie, string method, string ip, string agent)
        {
        }

        // 获取文件名
        protected string GetFileName(DateTime time)
        {
            return String.Format("{0:" + NAMERULE + "}.{1}", time, LogExtension);
        }

        // 获取路径
        protected string GetFolderName(string root, DateTime time)
        {
            return String.Format("{0}{1:yyyy}\\{1:MM}\\", root, time);
        }

        // 创建Log目录
        protected void EnsureFolderExist()
        {
            DateTime logtime = DateTime.Now;
            _LogName = this.GetFileName(logtime);
            _logFolder = this.GetFolderName(RootFolder, logtime);

            if (!Directory.Exists(LogFolder))
                Directory.CreateDirectory(LogFolder);
        }

        // 当前实例使用的Log文件名称
        private string _LogName;
        public string LogName
        {
            get { return _LogName; }
            set { _LogName = value; }
        }

        private string _logFolder;
        public string LogFolder
        {
            get { return _logFolder; }
            set { _logFolder = value; }
        }

        private string _logExtension;
        public string LogExtension
        {
            get { return _logExtension; }
            set { _logExtension = value; }
        }

        private string _rootFolder;
        public string RootFolder
        {
            get { return (_rootFolder.EndsWith("\\") ? _rootFolder : (_rootFolder + "\\")); }
            set { _rootFolder = value; }
        }
    }

    public class LogXmlWriter : LogWriterBase
    {
        public LogXmlWriter()
        {
        }

        /// <summary>
        /// 记录Log信息
        /// </summary>
        /// <param name="type">Log类型</param>
        /// <param name="host">产生Log的对象</param>
        /// <param name="param">对象产生Log时的属性状态</param>
        /// <param name="time">产生时间</param>
        /// <param name="abs">概述</param>
        /// <param name="desc">描述</param>
        /// <param name="resource">请求的资源</param>
        /// <param name="method">请求方式</param>
        /// <param name="ip">请求IP</param>
        /// <param name="agent">请求的客户端信息</param>
        public override void Write(LogType type, string sender, DateTime time, string desc, string code, string postdata, string cookie, string method, string ip, string agent)
        {
            lock (Lock)
            {
                DataSet ds = new DataSet("LogFile");
                try
                {
                    EnsureFolderExist();
                    string filepath = String.Format("{0}{1}", LogFolder, LogName);

                    if (!File.Exists(filepath))
                    {
                        DataTable dt = new DataTable("Log");
                        DataColumnCollection cols = dt.Columns;
                        cols.Add(new DataColumn("type", typeof(System.String)));
                        cols.Add(new DataColumn("time", typeof(System.String)));
                        cols.Add(new DataColumn("host", typeof(System.String)));
                        cols.Add(new DataColumn("description", typeof(System.String)));
                        cols.Add(new DataColumn("resource", typeof(System.String)));
                        cols.Add(new DataColumn("method", typeof(System.String)));
                        cols.Add(new DataColumn("postdata", typeof(System.String)));
                        cols.Add(new DataColumn("cookie", typeof(System.String)));
                        cols.Add(new DataColumn("ip", typeof(System.String)));
                        cols.Add(new DataColumn("agent", typeof(System.String)));

                        ds.Tables.Add(dt);
                    }
                    else
                    {
                        ds.ReadXml(filepath);
                    }

                    DataRow dr = ds.Tables[0].NewRow();
                    dr["type"] = (byte)type;
                    dr["time"] = time.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    dr["host"] = sender;
                    dr["description"] = desc;
                    dr["resource"] = code;
                    dr["method"] = method;
                    dr["postdata"] = postdata;
                    dr["cookie"] = cookie != null ? cookie : "";
                    dr["ip"] = ip;
                    dr["agent"] = agent;
                    ds.Tables[0].Rows.Add(dr);

                    ds.WriteXml(filepath);
                }
                catch (Exception err)
                {
#if DEBUG
                    throw err;
#endif
                }
                finally
                {
                    if (ds != null)
                    {
                        ds.Clear();
                        ds.Dispose();
                    }
                }
            }
        }



    }

    public class LogTextWriter : LogWriterBase
    {
        public LogTextWriter()
        {
        }

        public override void Write(LogType type, string sender, DateTime time, string desc, string code, string postdata, string cookie, string method, string ip, string agent)
        {
            lock (Lock)
            {
                StreamWriter sw = null;
                try
                {
                    EnsureFolderExist();
                    string filepath = String.Format("{0}{1}", LogFolder, LogName);

                    sw = new StreamWriter(filepath, true);
                    sw.WriteLine("[log]");
                    sw.WriteLine("type = {0}", (byte)type);
                    sw.WriteLine("time = {0:yyyy-MM-dd HH:mm:ss.fff}", time);
                    sw.WriteLine("host = {0}", sender);
                    sw.WriteLine("description = {0}", desc);
                    sw.WriteLine("resource = {0}", code);
                    sw.WriteLine("method = {0}", method);
                    sw.WriteLine("postdata = {0}", postdata);
                    sw.WriteLine("cookie = {0}", (cookie != null ? cookie : ""));
                    sw.WriteLine("ip = {0}", ip);
                    sw.WriteLine("agent = {0}", agent);
                    sw.WriteLine("");
                    sw.Flush();
                }
                catch (Exception err)
                {
#if DEBUG
                    throw err;
#endif
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                }
            }
        }
    }
}
