using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        }
    }
    class adatok
    {
        //public DateTime datum;
        public string datum;
        public int benzin;
        public int diesel;

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
        }

    }
    
}
