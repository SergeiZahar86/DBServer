using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServer
{
    class DBServiceHandler : DBService.Iface
    {
        bool DBService.ISync.addRow(Row row)
        {
            return true;
        }

        bool DBService.ISync.delRow(int ID)
        {
            return true;
        }

        bool DBService.ISync.editRow(Row row)
        {
            return true;
        }

        List<Row> DBService.ISync.listRow()
        {
            List<Row> list = new List<Row>();
            Row row = new Row();
            row.ID = 1;
            row.Login = "sergei";
            row.Password = "zahar";
            list.Add(row);
            return list;
        }
    }
}
