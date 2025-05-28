using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nyelviskola_Lib
{
    public class DataStore
    {
        readonly List<Tanar> tanarok;
        readonly List<TanitasiAlkalom> tanitasiAlkalmak;
        readonly List<Nyelv> nyelvek;

        DataStore()
        {
            tanarok = File.ReadAllLines("Input\\tanar.csv").Skip(1).Select(x=>new Tanar(x)).ToList();
            tanitasiAlkalmak = File.ReadAllLines("Input\\tanitasi_alkalom.csv").Skip(1).
                Select(x => new TanitasiAlkalom(x)).ToList();
            nyelvek = File.ReadAllLines("Input\\nyelv.csv").Skip(1).Select(x => new Nyelv(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Mér inicializált");
            Instance = new DataStore();
        }

        public IEnumerable<Tanar> Tanarok => tanarok;
        public IEnumerable<TanitasiAlkalom> TanitasiAlkalmak => tanitasiAlkalmak;
        public IEnumerable<Nyelv> Nyelvek => nyelvek;

        static void ExportToJson<T>(IEnumerable<T> elemek, string fajnev)
        {
            var content = JsonSerializer.Serialize(elemek);
            File.WriteAllText(fajnev, content, Encoding.UTF8);
        }

        public void ExportToJson()
        {
            ExportToJson(nyelvek, "nyelv.json");
            ExportToJson(tanarok, "tanar.json");
            ExportToJson(tanitasiAlkalmak, "tanitasi_alkalom.json");
        }
    }
}
