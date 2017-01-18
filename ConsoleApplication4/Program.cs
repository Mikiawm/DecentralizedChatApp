using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.PeerToPeer;

namespace ChatApp.Ui
{
    class Program
    {
        static PeerNameRecordCollection records;

        static void Main(string[] args)
        {
            Console.Write("Peer Classifer to Resolve: ");
            string classifier = Console.ReadLine();

            PeerNameResolver resolver = new PeerNameResolver();
            
            try
            {
                records = resolver.Resolve(new PeerName(classifier, PeerNameType.Unsecured));
                DisplayResults();
            }
            catch(PeerToPeerException ex)
            {
                Console.WriteLine("PeerToPeer Exception: {0}", ex.Message);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void DisplayResults()
        {
           if(records.Any())
            {
                UnicodeEncoding encoder = new UnicodeEncoding();
                Console.WriteLine();

                foreach(var record in records)
                {
                    string data = record.Data != null ? encoder.GetString(record.Data) : string.Empty;

                    Console.WriteLine("***Peer {0}\n\r\tHost: {1}\n\r\tComment: {2}\n\r\tData: {3}", record.PeerName.ToString(), record.PeerName.PeerHostName, record.Comment, data);
                    foreach( var endpoint in record.EndPointCollection)
                    {
                        Console.WriteLine("\tEndpoint{0}, Port{1}", endpoint.Address, endpoint.Port);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
