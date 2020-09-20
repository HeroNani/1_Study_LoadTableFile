using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhouzhibo
{
    public class Singleton<T> where T : new()
    {
        protected static readonly T m_sInstance = new T();
        protected Singleton() { }
        public static T S { get { return m_sInstance; } }
    }

    public interface IDdataTable
    {
        string GetName();
        void SetName(string name);
        void Init(string data);
        void InitFormBin(byte[] data, int offset, int count);
        byte[] ToBin();
        void Uninit();

        //bool ValidataData();
        //void BeforLoad();
        //void AfterLoad();
        //void NewTable();
        //bool IsLuaTable();

        TableManager GetTableManager();

        void SetTableManager(TableManager manager);
    }
}
