using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nyelviskola_Lib
{
    public class TanitasiAlkalom
    {
        //alkalom_id;tanar_id;datum;kezdesido;orak_szama

        public int AlkalomID {  get; set; }
        public int TanarID { get; set; }

        [JsonIgnore] 
        public DateTime Datum { get; set; }
        [JsonPropertyName("datum")]
        public string DatumFormatum => Datum.ToString("yyyy-MM-dd");

        [JsonIgnore]
        public TimeSpan KezdesIdo { get; set; }
        [JsonPropertyName("kezdesido")]
        public string KezdesFormatum => Datum.Add(KezdesIdo).ToString("HH:mm:ss");

        public int OrakSzama { get; set; }

        static DateTime ParseDate(string str)
        {
            var split = str.Split('.');
            return new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }

        static TimeSpan ParseTime(string str)
        {
            var split = str.Split(':');
            return new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }

        public TanitasiAlkalom(string adatSor) 
        {
            string[] adatReszek = adatSor.Split(';');
            AlkalomID = int.Parse(adatReszek[0]);
            TanarID = int.Parse(adatReszek[1]);
            Datum = ParseDate(adatReszek[2]);
            KezdesIdo = ParseTime(adatReszek[3]);
            OrakSzama = int.Parse(adatReszek[4]);
        }

        [JsonIgnore]
        public int Dij =>
            OrakSzama * DataStore.Instance?.Tanarok?.
            FirstOrDefault(x => x.TanarID == TanarID)?.Oradij ?? 0;

        public bool AdottHonapbanVane(int ev, int honap)
        {
            return Datum.Year == ev && Datum.Month == honap;
        }
    }
}
