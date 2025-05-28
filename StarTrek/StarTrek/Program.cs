using StarTrek_Lib;

DataStore.InitCSV();

Console.WriteLine($"4. feladat: {DataStore.Instance?.Urhajok
    .Count(x => x.UrhajoNev.Contains("Enterprise"))} űrhajó nevében szerepel az Enterprise név.");

Console.Write($"5. feladat: A szerep neve: ");
string szerepInput = Console.ReadLine()!;
int? szerepAzonosito = DataStore.Instance?.HajoSzerepek.FirstOrDefault(x => x.SzerepNev == szerepInput)?.SzerepId;

if ( szerepAzonosito is null)
{
    Console.WriteLine("\tIlyen szerep nincs az adatbázisban.");
}
else
{
    int? osztalyokSzama = DataStore.Instance.HajoOsztalyok.Count(x => x.SzerepId == szerepAzonosito);
    Console.WriteLine($"\t{osztalyokSzama} hajóosztály rendeltetése a megadott szerep.");
}

Console.WriteLine($"6. feladat:");
var lista6 = DataStore.Instance.Urhajok
    .GroupBy(x=>x.OsztalyId)
    .Select(x=> new { id = x.Key, db = x.Count() })
    .OrderByDescending(x=>x.db)
    .Take(3)
    .ToList();

foreach (var item in lista6)
{
    var ostaly = DataStore.Instance?.HajoOsztalyok.First(x=>x.OsztalyId == item.id);
    Console.WriteLine($"\t{ostaly.OsztalyNev}: {item.db} űrhajó");
}