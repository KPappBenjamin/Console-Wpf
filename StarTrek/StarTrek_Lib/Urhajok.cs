using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek_Lib
{
    public class Urhajok
    {
        public int UrhajoId { get; init; }
        public string Azonosito { get; init; }
        public string UrhajoNev { get; init; }
        public int OsztalyId { get; init; }
        public int FajId { get; init; }

        public Urhajok(string adatSor)
        {
            string[] adatReszek = adatSor.Split(';');

            UrhajoId = int.Parse(adatReszek[0]);
            Azonosito = adatReszek[1];
            UrhajoNev = adatReszek[2];
            OsztalyId = int.Parse(adatReszek[3]);
            FajId = int.Parse(adatReszek[4]);
        }

        public override string ToString()
        {
            return UrhajoNev;
        }
    }
}
