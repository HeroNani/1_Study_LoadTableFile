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
    }
}
