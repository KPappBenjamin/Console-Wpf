using Nyelviskola_Lib;

DataStore.InitCSV();
DataStore.Instance!.ExportToJson();

Console.WriteLine("6. feladat: " +
    $"{DataStore.Instance.TanitasiAlkalmak.Count(x=>x.AdottHonapbanVane(2023,4))} " +
    $"alkalmat jegyeztek fel 2023. áprilisában.");

Console.Write("7. feladat: A tanár neve: ");
var nev = Console.ReadLine();
var keresettTanar = DataStore.Instance.Tanarok.FirstOrDefault(x => x.Nev == nev);
if(keresettTanar is null) 
    Console.WriteLine("Ilyen néven nem található tanár");
else 
{
    Console.WriteLine($"Telefon: {keresettTanar.Telefon}");
    Console.WriteLine($"Email: {keresettTanar.Email}");
}

Console.WriteLine("8. feladat: A 3 legtöbb órát tanító tanár:");
var list8 = DataStore.Instance.TanitasiAlkalmak
    .GroupBy(x=>x.TanarID)
    .Select(x=> new { id = x.Key, db = x.Count()})
    .OrderByDescending(x=>x.db)
    .Take(3)
    .ToList();
foreach(var item in list8)
{
    var tanar  = DataStore.Instance.Tanarok.First(x=>x.TanarID == item.id);
    var nyelv = DataStore.Instance.Nyelvek.First(x => x.NyelvID == tanar.NyelvID);
    Console.WriteLine($"\t{tanar} ({nyelv}): {item.db} alkalom");
}

Console.WriteLine("9. feladat: A 3 legtöbb pénzt kereső tanár:");
var list9 = DataStore.Instance.TanitasiAlkalmak
    .GroupBy(x => x.TanarID)
    .Select(x => new { id = x.Key, dij = x.Sum(y=>y.Dij) })
    .OrderByDescending(x => x.dij)
    .Take(3)
    .ToList();
foreach (var item in list9)
{
    var tanar = DataStore.Instance.Tanarok.First(x => x.TanarID == item.id);
    var nyelv = DataStore.Instance.Nyelvek.First(x => x.NyelvID == tanar.NyelvID);
    Console.WriteLine($"\t{tanar} ({nyelv}): {item.dij:C0} Ft");
}