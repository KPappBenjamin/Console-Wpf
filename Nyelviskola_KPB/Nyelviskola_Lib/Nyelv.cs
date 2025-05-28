namespace Nyelviskola_Lib
{
    public class Nyelv
    {
        public int NyelvID { get; set; }
        public string NyelvNev { get; set; }

        public Nyelv(string adatSor) {
            string[] adatReszek = adatSor.Split(';');
            NyelvID = int.Parse(adatReszek[0]);
            NyelvNev = adatReszek[1];
        }

        public override string ToString()
        {
            return NyelvNev;
        }
    }
}
