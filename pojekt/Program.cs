using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using System.Diagnostics.Eventing.Reader;

namespace pojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> obsah = new List<string>();
            StreamReader sr = new StreamReader("C:\\ano\\projekt.txt");


            while (true) //nacitanie a ulozenie celeho obsahu do listu obsah
            {
                string riadok = sr.ReadToEnd();
                string[] tmp = riadok.Split('\n');
                foreach (string item in tmp)
                    obsah.Add(item);
                break;
            }
            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Zvoľte parameter pre zobrazenie:");
                Console.WriteLine("1 - Poradie podľa súboru");
                Console.WriteLine("2 - Názov");
                Console.WriteLine("3 - Cena");
                Console.WriteLine("4 - Žáner");
                Console.WriteLine("5 - Hodnotenie");
                Console.WriteLine("6 - Ukončiť");
                Console.WriteLine("------------------------------------");

                int vyber = int.Parse(Console.ReadLine());
                if (vyber == 6)
                {
                    Console.WriteLine("See you later");
                    break;
                }
                if (vyber == 1)
                {
                    foreach (var data in obsah) //vypisanie podla poradia v txt
                    {
                        Console.WriteLine(data);
                    }
                }
                else if (vyber == 2)
                {
                    foreach (var data in obsah.OrderBy(poradie => poradie.Split('-')[0]))//zoradi sa to podla nazvu od a po z
                        Console.WriteLine(data);
                }
                else if (vyber == 3)
                {
                    Console.WriteLine("zadaj min. cenu");
                    float minCena = float.Parse(Console.ReadLine());
                    Console.WriteLine("zadaj max cenu");
                    float maxCena = float.Parse(Console.ReadLine());
                    foreach (var data in obsah.OrderBy(poradie => poradie.Split('-')[1]))// zoradenie od najmensej po najvacsiu cenu 
                    {
                        float Cena = float.Parse(data.Split('-')[1]);
                        if (Cena >= minCena && Cena <= maxCena)
                            Console.WriteLine(data);
                    }
                }
                else if (vyber == 4)
                {
                    Console.WriteLine("zadaj žáner");
                    string zaner = Console.ReadLine();
                    foreach (var data in obsah.OrderBy(poradie => poradie.Split('-')[2])) // zoradenie podla zanra od a po z
                    {
                        string zaner_vtxt = data.Split('-')[2];
                        if (zaner_vtxt.Contains(zaner))
                            Console.WriteLine(data);
                    }
                }
                else if (vyber == 5)
                {
                    Console.WriteLine("zadaj min. hodnotenie");
                    float minhodnotenie = float.Parse(Console.ReadLine());
                    Console.WriteLine("zadaj max. hodnotenie");
                    float maxhodnotenie = float.Parse(Console.ReadLine());
                    foreach (var data in obsah.OrderBy(poradie => poradie.Split('-')[3])) // zoradenie podla hodnotenia od najmensieho 
                    {
                        float hodnotenie = float.Parse(data.Split('-')[3]);
                        if (hodnotenie >= minhodnotenie && hodnotenie <= maxhodnotenie)
                            Console.WriteLine(data);
                    }
                }
                else Console.WriteLine("Zadaj znovu, zle zadaný parameter");
            }
        }
    }
}
