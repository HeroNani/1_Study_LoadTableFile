using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace Zhouzhibo
{
    public class TableManager
    {
        string m_tableDir = "Package/Table/";

        public Dictionary<string, TableInfo> m_tableMap = new Dictionary<string, TableInfo>();
        protected List<IDdataTable> m_unloadList = new List<IDdataTable>();

        public void RegisterTable<T>() where T : new()
        {
            string fileName = string.Format("{0}.bytes", typeof(T).Name);
            RegisterTable<T>(fileName);
        }

        public void RegisterTable<T>(string fileName) where T : new()
        {
            RegisterTable((IDdataTable)Singleton<T>.S, fileName);
        }

        public void RegisterTable(IDdataTable table, string fileName)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);

            if (m_tableMap.ContainsKey(name))
                return;
            table.SetName(name);

            TableInfo tableInfo = new TableInfo()
            {
                m_fileName = fileName,
                m_table = table,
                m_registIndex = m_tableMap.Count
            };
            m_tableMap.Add(name, tableInfo);
        }

        public IEnumerable InitFromText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            foreach (var v in m_tableMap.Values)
            {
                Console.WriteLine("Start Load Table: {0}", v.m_fileName);
                InitTextByFileName(v.m_table, v.m_fileName);
            }
        }

        protected void InitTextByFileName(IDdataTable table, string fileName)
        {
            string filePath = Path.Combine(m_tableDir, fileName);

            table.SetTableManager(this);

            if (File.Exists(filePath))
            {
                using(var fs = File.Open(filePath,FileMode.Open,FileAccess.Read,FileShare.Read))
                {
                    using(var sr = new StreamReader(fs,Encoding.GetEncoding("GBK")))
                    {
                        string data = sr.ReadToEnd();
                        table.Init(data);
                    }
                }
                m_unloadList.Add(table);
            }
            else
            {
                Console.WriteLine("文件不存在:{0}", filePath);
            }

        }
    }
}
