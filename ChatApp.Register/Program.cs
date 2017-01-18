using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Register
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(Cloud c in Cloud.GetAvailableClouds())
            {
                Console.WriteLine("Cloud {0}", c.Name);
            }
            Console.WriteLine();
            Console.Write("Enter Peer Name Classifier: ");

            string classifier = Console.ReadLine();

            PeerName peerName = new PeerName(classifier, PeerNameType.Unsecured);

            using (PeerNameRegistration registration = new PeerNameRegistration(peerName, 8080))
            {
                string timestamp = string.Format("Peer Created at: {0}", DateTime.Now.ToShortDateString());
                registration.Comment = timestamp;

                UnicodeEncoding encoder = new UnicodeEncoding();
                byte[] data = encoder.GetBytes(timestamp);
                registration.Data = data;

                try
                {
                    registration.Start();
                    Console.WriteLine("Peer Registration Successful.");
                    Console.WriteLine("Peer Host Name: {0}", registration.PeerName.PeerHostName);
                    Console.WriteLine("Press enter to exit");

                    Console.ReadLine();
                    registration.Stop();
                }
                catch(PeerToPeerException ex)
                {
                    Console.WriteLine("PeerToPeer Exception: {0}", ex);
                }
            }   
        }
    }
}
