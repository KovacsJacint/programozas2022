using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Első_Projekt_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //letrehoz();
            bekeres();
        }
        /*static void letrehoz()
        {
            string a = " ";
            StreamWriter ir = new StreamWriter("osztaly.txt");
            do
            {
                Console.Write("Kérek egy nevet: ");
                a = Console.ReadLine();
                ir.WriteLine(a);
              
            } while (a!=" ");
            ir.Close();
        }*/
  
        static void bekeres()
        {
            List<string> nevek = new List<string>();
            string[] sorok = File.ReadAllLines("osztaly.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                nevek.Add(sorok[i]);
            }
            Random rand = new Random();
            rand.Next();
        }
    }
    /*static void beker()
    {
        
    }*/
    


}
