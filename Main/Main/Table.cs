using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhouzhibo
{
    public class Table
    {
        protected List<string> m_fields;

        public bool InitFromString(string data)
        {
            int firstEnter = data.IndexOf("\r\n");

            string rawFields = data.Substring(0, firstEnter);

            string rawRows = data.Substring(firstEnter);

            string[] fields = rawFields.Split('\t');
            foreach(string f in fields)
            {
                string v = f.Trim();
                v = v.Trim('\"');

                if (string.IsNullOrEmpty(v))
                    continue;

                m_fields.Add(v);
            }
        }
    }
}
