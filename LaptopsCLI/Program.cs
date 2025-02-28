using LaptopsCLI;
using System.Text;

List<Laptop> laptopok = new();
using 
    StreamReader sr = new StreamReader(
        path: @"..\..\..\src\laptops.txt",
        encoding: Encoding.UTF8) ;
sr.ReadLine();
while (!sr.EndOfStream)
{
    laptopok.Add(new Laptop(sr.ReadLine()));
}
sr.Close();

foreach (var item in laptopok)
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("\n5. feladat");
for (int i = 0; i < laptopok.Count; i++)
{
    Console.WriteLine($"{i+1}. {laptopok[i].ToString()} | {Math.Round(laptopok[i].Price * 4.12, 0)} HUF ");
}

Console.WriteLine("\n6. feladat");
var hatodik = laptopok.Where(x => x.CPU.Contains("Intel Core i7") 
    && x.Storage.Contains("SSD")).ToList();

for (int i = 0; i < hatodik.Count; i++)
{
    Console.WriteLine($"[{i+1}] {hatodik[i].ToString()}");
}
var atlagAr = hatodik.Average(x => x.Price);
Console.WriteLine($"Laptopok átlag ára: {atlagAr} INR");

Console.WriteLine("\n7. feladat - Fájlba írás");

var olcso = laptopok.Where(x=>x.Category.CategoryName.Contains("Gaming")). OrderBy(x => x.Price).ToList().Take(20);

using (StreamWriter sw = new StreamWriter(path: @"..\..\..\src\cheap.txt"))
{
    foreach (var item in olcso)
    {
        sw.WriteLine($"{item.Manufacturer.ManufacturerName} {item.Model}\n\t{item.CPU}\n\t{item.Storage}\n\t{item.Screen}\n");
    }
}
