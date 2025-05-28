using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek_Lib
{
    public class HajoOsztalyok
    {
        public int OsztalyId { get; init; }
        public string OsztalyNev { get; init; }
        public int SzerepId { get; init; }

        public HajoOsztalyok(string adatSor)
        {
            string[] adatReszek = adatSor.Split(';');

            OsztalyId = int.Parse(adatReszek[0]);
            OsztalyNev = adatReszek[1];
            SzerepId = int.Parse(adatReszek[2]);
        }
    }
}
