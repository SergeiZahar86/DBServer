using Microsoft.Data.Sqlite;
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

        SqliteConnection conn;

        public DBServiceHandler(SqliteConnection conn)
        {
            this.conn = conn;
        }
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
            List<Row> rows = new List<Row>();
            try
            {
                var cmd = this.conn.CreateCommand();
                cmd.CommandText = "select * from RegistrationUsers";
                var ret = cmd.ExecuteReader();
                //textbox.Text = "";
                while (ret.Read())
                {
                    Row row = new Row();
                    row.ID = ret.GetInt32(0);
                    row.Login = ret.GetString(1);
                    row.Password = ret.GetString(2);
                    rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rows;
        }

        public void addUser(string log, string password)
        {
           //throw new NotImplementedException();
        }
    }
}
