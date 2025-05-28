namespace StarTrek_Lib
{
    public class Fajok
    {
        public int FajId { get; set; }
        public string FajNev { get; set;}

        public Fajok(string adatSor)
        {
            string[] adatReszek = adatSor.Split(';');
            
            FajId = int.Parse(adatReszek[0]);
            FajNev = adatReszek[1];

        }
    }
}
