using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CascoInsurance.Util
{
    public class DataTableUtils
    {
        public static DataColumn CreateDataTableColumn(string name, string type)
        {
            var dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType(type);
            dataColumn.ColumnName = name;
            dataColumn.ReadOnly = true;
            return dataColumn;
        }
    }
}