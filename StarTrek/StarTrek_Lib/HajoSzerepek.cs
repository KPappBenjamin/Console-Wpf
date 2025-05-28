using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek_Lib
{
    public class HajoSzerepek
    {
        public int SzerepId { get; init; }
        public string SzerepNev { get; init; }

        public HajoSzerepek(string adatSor)
        {
            string[] adatReszek = adatSor.Split(';');

            SzerepId = int.Parse(adatReszek[0]);
            SzerepNev = adatReszek[1];
        }

        public override string ToString()
        {
            return SzerepNev;
        }
    }
}
