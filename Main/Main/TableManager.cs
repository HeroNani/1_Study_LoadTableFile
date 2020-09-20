using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zhouzhibo
{
    public class TableManager
    {
        string m_tableDir = "Package/Table";

        public Dictionary<string, TableInfo> m_tableMap = new Dictionary<string, TableInfo>();

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
            
        }
    }
}
