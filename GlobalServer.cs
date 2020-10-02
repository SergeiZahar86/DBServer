using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBServer
{
    class GlobalServer
    {
        private static GlobalServer instance;
        private Semaphore sem;
        SqliteConnection conn;
        private String name = "";
        public string Name
        {
            get => name;
            set
            {
                sem.WaitOne();
                name = value;
                sem.Release();
            }
        }
        private GlobalServer()
        {
            this.sem = new Semaphore(0, 1);
            this.conn = new SqliteConnection("Data Source= C:/Projects/PublicTestThrift/DBServer/Registration.db");
            this.conn.Open();

        }
        public SqliteCommand getCmd()
        {
            return this.conn.CreateCommand();
        }
        public static GlobalServer getInstance()
        {
            if (instance == null) 
            { 
                instance = new GlobalServer(); 
            }
            return instance;
        }




    }

}
