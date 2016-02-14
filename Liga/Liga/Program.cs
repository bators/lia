using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Liga
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            var cl = new WebClient();
            var res = cl.DownloadString(new Uri("http://api.lod-misis.ru/testassignment"));
            var tbl = JArray.Parse(res)
                .Select(j => new
                {
                    PlayerName = j["PlayerName"],
                    Team = j["Team"],
                    Score = j["Score"]
                });
            foreach (var v in tbl.OrderByDescending(i => i.Score))
                
                Console.WriteLine(v.PlayerName + "\t" + v.Team + "\t" + v.Score); 
        Console.ReadKey();

        }
    }
}
