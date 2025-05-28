using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nyelviskola_Lib
{
    public class Tanar
    {
        public int TanarID { get; set; }
        public string Nev { get; set; }

        public int NyelvID { get; set; }
        public int Oradij { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public bool Net {  get; set; }

        [JsonPropertyName("net")]
        public int NetFormatum => Net ? 1 : 0;

        public Tanar(string adatSor) 
        {
            string[] adatReszek = adatSor.Split(';');
            TanarID = int.Parse(adatReszek[0]);
            Nev = adatReszek[1];
            NyelvID = int.Parse(adatReszek[2]);
            Oradij = int.Parse(adatReszek[3]);
            Telefon = adatReszek[4];
            Email = adatReszek[5];
            Net = adatReszek[6] == "1";
            
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
