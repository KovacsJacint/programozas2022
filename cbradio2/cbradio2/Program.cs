using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cbradio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            feladatok f = new feladatok();
        }
    }
    class feladatok
    {
        List<adatok> radio = new List<adatok>();
        public feladatok()
        {
            f2();
            f3();
            f4();
        }
        void f2()
        {
            string[] sorok = File.ReadAllLines("cb.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                radio.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3.feladat: Bejegyzések száma: {0} db",radio.Count);
        }
        void f4()
        {
            int adasdarab = 0;
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].Perc ==1 && radio[i].Adasdb==4)
                {
                    adasdarab++;
                }
            }
            Console.WriteLine("4.feladat: volt négy adást indító sofőr.",adasdarab);
        }
    }

    class adatok
    {
        public int Ora, Perc, Adasdb;
        public string Nev;
        public adatok(string sor)
        {
            string[] vag = sor.Split(';');
            Ora =Convert.ToInt32(vag[0]);
            Perc = Convert.ToInt32(vag[1]);
            Adasdb = Convert.ToInt32(vag[2]);
            Nev = vag[3];
        }
        
    }
}
