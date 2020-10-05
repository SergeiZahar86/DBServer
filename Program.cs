using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace DBServer
{
    class Program
    {
        static SqliteConnection conn;
        

        static void Main(string[] args)/*Добавить в main необходимые процедуры*/
        {

            conn = new SqliteConnection("Data Source= C:/Projects/PublicTestThrift/DBServer/Registration.db");
            conn.Open();
            DBServiceHandler service = new DBServiceHandler(conn);
            DBService.Processor processor = new DBService.Processor(service);
            TServerTransport transport = new TServerSocket(9090, 1000);
            TServer server = new TSimpleServer(processor, transport);
            server.Serve();
        }
    }
}
