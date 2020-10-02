using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServer /**/
{
    class DBServiceHandler : DBService.Iface /*Добавить класс реализующий интерфейс
    Iface и реализовать его методы*/
    {
        public DBServiceHandler()
        {
            global = GlobalServer.getInstance();
        }
        private GlobalServer global;
        List<Row> DATA = new List<Row>();
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
            /*
            List<Row> list = new List<Row>();
            Row row = new Row();
            row.ID = 1;
            row.Login = "sergei";
            row.Password = "zahar";
            list.Add(row);
            return list;
            */
            var cmd = global.getCmd();
            cmd.CommandText = "select * from RegistrationUsers";
            var ret = cmd.ExecuteReader();
            //textbox.Text = "";
            DATA.Clear();
            while (ret.Read())
            {
                int id = ret.GetInt32(0);
                String log_db = ret.GetString(1);
                String pass_db = ret.GetString(2);
                //textbox.Text = textbox.Text + id + " " + log_db + " " + pass_db + "\n";
                DATA.Add(new Row(id, log_db, pass_db));
            }
            return DATA;
        }
    }
}
