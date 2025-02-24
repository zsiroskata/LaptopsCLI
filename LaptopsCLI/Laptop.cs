using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LaptopsCLI
{
    internal class Laptop
    {
        public Category Category { get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }
        public Laptop(string sor) 
        {
            var s = sor.Split(';');

            /* CATEGORY CLASS*/
            int catCode = int.Parse(s[0]);
            string catName = s[1];
            Category = new Category(catCode, catName);

            CPU = s[2];

            /* MANUFACTURER CLASS*/
            int manCode = int.Parse(s[3]);
            string manName = s[4];
            Manufacturer = new Manufacturer(manCode, manName);

            Model = s[5];
            OS = s[6];
            Price = int.Parse(s[7]);
            Screen = s[8];
            Storage = s[9];

        }

        public override string ToString()
        {
            return $"{Category} | {Manufacturer} | {OS}";
        }

    }
}
