using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Uzemanyag
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
        List<adatok> uzemanyagar = new List<adatok>();
        public int mink = 0;
        public feladatok()
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
        }
        
        void f2()
        {
            string[] sorok = File.ReadAllLines("uzemanyag.txt"); 
            for (int i = 0; i < sorok.Length; i++)
            {
                uzemanyagar.Add(new adatok(sorok[i]));
            }
            
        }
        void f3()
        {
            Console.WriteLine("3.feladat: Változások száma: {0}",uzemanyagar.Count);
        }

        
        void f4()
        {
             mink = uzemanyagar[0].kulonbseg();
            for (int i = 0; i < uzemanyagar.Count; i++)
            {
                if (uzemanyagar[i].kulonbseg()<mink)
                {
                    mink = uzemanyagar[i].kulonbseg();
                }
            }
            Console.WriteLine("4.feladat: Legkissebb változás: {0}",mink);
        }
        void f5()
        {
            List<int> kulobsegek = new List<int>();
            for (int i = 0; i < uzemanyagar.Count; i++)
            {
                if (uzemanyagar[i].kulonbseg()==mink)
                {
                    kulobsegek.Add(1);
                }
            }
            int szamologep = 0;
            for (int i = 0; i < kulobsegek.Count; i++)
            {
                szamologep = szamologep + kulobsegek[i];
            }
            Console.WriteLine("5. feladat: A legkisebb külömbség {0}",szamologep);
        }
        void f6()
        {
            bool volte = false;
            for (int i = 0; i < uzemanyagar.Count; i++)
            {
                if (uzemanyagar[i].szokonap())
                {
                    volte = true;
                    break;
                }
            }
            if(volte)
            {
                Console.WriteLine("6.feladat: Volt változás szökőnapon!");
            }
            else
            {
                Console.WriteLine("6.feladat: Nem volt változás szökőnapon!");
            }
        }   
        void f7()
        {
            StreamWriter ir = new StreamWriter("euro.txt");
            for (int i = 0; i < uzemanyagar.Count; i++)
            {
                ir.WriteLine(uzemanyagar[i].ujsor());
            }
            ir.Close();
        }
        void f8()
        {
            Console.Write("8. feladat: Kérem adja meg az évszámot [2011..2016]:");
            int beker = Convert.ToInt32(Console.ReadLine());
            while(2011>beker || 2016<beker)
            {
             
                Console.Write("8. feladat: Kérem adja meg az évszámot [2011..2016]:");
                beker = Convert.ToInt32(Console.ReadLine());
            }
           
        }
    }
    class adatok
    {
        //public DateTime datum;
        public string datum;
        public int benzin;
        public int diesel;
        public int ev, honap, nap;

        public adatok(string sor)
        {
            string[] vag = sor.Split(';');
            //datum = Convert.ToDateTime(vag[0]);
            datum = vag[0];
            benzin = Convert.ToInt32(vag[1]);
            diesel = Convert.ToInt32(vag[2]);
        }
        public int kulonbseg()
        {
            return Math.Abs(benzin - diesel);

        }
        public bool szokonap()
        {
            string[] vag = datum.Split('.');
            ev = Convert.ToInt32(vag[0]);
            honap = Convert.ToInt32(vag[1]);
            nap = Convert.ToInt32(vag[2]);
            if (ev % 4 == 0 && honap == 2 && nap == 24)
            {
                return true;
            }
            else
            {
                return false;
            } 
           
        }
        double euro = 307.7;
       public string ujsor()
        {
            return datum + ";" +Math.Round( benzin / euro,2)+";"+ Math.Round(diesel / euro,2);
        }
            public int Evnapja()
           {
            string[] vag = datum.Split('.');
            ev = Convert.ToInt32(vag[0]);
            honap = Convert.ToInt32(vag[1]);
            nap = Convert.ToInt32(vag[2]);
            int[]napokSzama = { 31,28,31,30,31,30,31,31,30,31,30,31};
            if (ev % 4 == 0)
            {
                napokSzama[1] = 29;              
            }
            int napdarab = 0;
            for (int i = 0; i < honap; i++)
            {
                napdarab += napokSzama[i];  
            }
            napdarab += nap;
            return napdarab;

        }
        public int napKulonbseg(int masikNapszam)
        {

        }
           

    }
    
}
