using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek_Lib
{
    public class DataStore
    {
        readonly List<Fajok> fajok;
        readonly List<HajoOsztalyok> hajoOsztalyok;
        readonly List<HajoSzerepek> hajoSzerepek;
        readonly List<Urhajok> urhajok;

        DataStore()
        {
            fajok = File.ReadAllLines("Input\\fajok.csv").Skip(1)
                .Select(x => new Fajok(x)).ToList();

            hajoOsztalyok = File.ReadAllLines("Input\\hajo_osztalyok.csv").Skip(1)
                .Select(x => new HajoOsztalyok(x)).ToList();    

            hajoSzerepek = File.ReadAllLines("Input\\hajo_szerepek.csv").Skip(1)
                .Select(x => new HajoSzerepek(x)).ToList();

            urhajok = File.ReadAllLines("Input\\urhajok.csv").Skip(1)
                .Select(x => new Urhajok(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Már inicializálva!");
            Instance = new DataStore();
        }

        public IEnumerable<Fajok> Fajok => fajok;
        public IEnumerable<HajoOsztalyok> HajoOsztalyok => hajoOsztalyok;
        public IEnumerable<HajoSzerepek> HajoSzerepek => hajoSzerepek;
        public IEnumerable<Urhajok> Urhajok=> urhajok;


 
    }
}
