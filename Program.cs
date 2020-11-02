using Microsoft.Data.Sqlite;
using Thrift.Server;
using Thrift.Transport;

namespace DBServer
{
    class Program
    {
        static SqliteConnection conn;
        

        static void Main(string[] args)/*Добавить в main необходимые процедуры*/
        {

            conn = new SqliteConnection(@"Data Source= ..\..\Registration.db");
            conn.Open();
            DBServiceHandler service = new DBServiceHandler(conn);
            DBService.Processor processor = new DBService.Processor(service);
            TServerTransport transport = new TServerSocket(9000, 1000);
            TServer server = new TSimpleServer(processor, transport);
            server.Serve();
        }
    }
}
