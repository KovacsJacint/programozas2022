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
            f5();
            f7();
            f8();
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
            Console.WriteLine("4.feladat: volt négy adást indító sofőr.", adasdarab);

        }
        void f5()
        {

            int adasok = 0;
            Console.Write("5.feladat: Kérek egy nevet: ");
           string nev= Console.ReadLine();         
            for (int i = 0; i < radio.Count; i++)
            {
                if (radio[i].Nev==nev)
                {
                    adasok += radio[i].Adasdb;
                }            
            }
            if (adasok==0)
            {
                Console.WriteLine("Nincs ilyen nevű sofőr!");
            }
            else
            {
                Console.WriteLine("\t {0} {1}x használta a CB-rádiót",nev,adasok);  
            }
        }
        void f7()
        {
            StreamWriter ir = new StreamWriter("cb2.txt");
            ir.WriteLine("Kezdes;Nev;Adasdb");
            for (int i = 0; i < radio.Count; i++)
            {
                ir.WriteLine("{0};{1};{2}", radio[i].AtszamolPercre(), radio[i].Nev, radio[i].Adasdb);
            }
            ir.Close();

        }
        void f8()
        {
            Console.WriteLine("8.feladat: Sofőrök száma: {0}");
            for (int i = 0; i < radio.Count; i++)
            {

            }
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

        public  int AtszamolPercre()
        {
            
            return (Ora * 60 + Perc);
        }

    }
}
