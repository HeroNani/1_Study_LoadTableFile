using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhouzhibo
{
    public abstract class DataTableBase<T> : Singleton<T>, IDdataTable where  T : new ()
    {
        string m_name;
        protected TableManagerCommon m_tableManager;

        public string GetName()
        {
            return m_name;
        }

        public void SetName(string name)
        {
            m_name = name;
        }

        public abstract void Init(string text);
        public abstract void InitFormBin(byte[] data, int offset, int count);
        public abstract byte[] ToBin();
        public abstract void Uninit();

        public TableManagerCommon GetTableManager()
        {
            return m_tableManager;
        }

        public void SetTableManager(TableManagerCommon manager)
        {
            m_tableManager = manager;
        }

        protected void LogError(Object primaryKey, string format, params Object[] args)
        {
            string msg = string.Format("ID{0}错误:{1}", primaryKey, format);
            Console.WriteLine(msg, args); //???这是什么操作？
        }
    }
}
