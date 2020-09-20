using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhouzhibo
{
    public class DataTableBaseListGeneric<TableType, TableDataType,TableDataListType>: DataTableBase<TableType>
        where TableType : new()
        where TableDataType : new()
        where TableDataListType : new()
    {
        public Dictionary<int, TableDataType> m_data = new Dictionary<int, TableDataType>();


        public override void Init(string text)
        {
            if (m_data != null)
                m_data.Clear();

            Table table = new Table();
            if(!table.)
        }

        public IEnumerable<int> GetKeys()
        {
            return m_data.Keys;
        }

        public TableDataType GetData(int id)
        {
            TableDataType data;
            if(!m_data.TryGetValue(id, out data))
            {
                return default(TableDataType);
            }

            return data;
        }
    }
}
