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
        
        static void Main(string[] args)/*Добавить в main необходимые процедуры*/
        {
            DBServiceHandler service = new DBServiceHandler();
            DBService.Processor processor = new DBService.Processor(service);
            TServerTransport transport = new TServerSocket(9090, 1000);
            TServer server = new TSimpleServer(processor, transport);

            server.Serve();
        }
    }
}
