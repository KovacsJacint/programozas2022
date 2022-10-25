using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data.Common;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }
    class feladat
    {
        List<adatok> versenyzok = new List<adatok>();
        public feladat()
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
            string[] sorok = File.ReadAllLines("ub2017egyeni.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                versenyzok.Add(new adatok(sorok[i]));
            }
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Egyéni indulók: {0} fő", versenyzok.Count);
        }
        void f4()
        {
            int seged = 0;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].kategoria == "Noi")
                {
                    if (versenyzok[i].tav == 100)
                    {
                        seged++;
                    }
                }
            }

            Console.WriteLine("4. feladat: Célba érkező női sportolók: {0} fő", seged);
        }
        void f5()
        {
            string beNev;

            Console.Write("5. feladat: Kérem a sportoló nevét:");
            beNev = Console.ReadLine();
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].nev != beNev)
                {
                    Console.Write("\tIndult egyéniben a sportoló?");
                    Console.WriteLine(" Nem");
                    Console.WriteLine("\tTeljesítette a teljes távo? Nem");


                    break;
                }
                else

                {

                    if (versenyzok[i].tav == 100)
                    {
                        Console.Write("\tIndult egyéniben a sportoló?");
                        Console.WriteLine(" Igen");
                        Console.WriteLine("\tTeljesítette a teljes távo? Igen");
                    }
                    else
                    {
                        Console.Write("\tIndult egyéniben a sportoló?");
                        Console.WriteLine(" Igen");

                        Console.WriteLine("\tTeljesítette a teljes távo? Nem");
                    }
                    break;
                }


            }





        }
        void f7()
        {
            int fo = 0;
            double ossz = 0;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].kategoria=="Ferfi" && versenyzok[i].tav ==100)
                {
                    fo++;
                    ossz = ossz + versenyzok[i].IdoOraban();
                    
                }
            }
            Console.WriteLine("7. feladat: Átlagos idő: {0}",ossz/fo);

        }
        void f8()
        {
            int ferfi = -1, no = -1;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].tav==100)
                {
                    if (versenyzok[i].kategoria=="Ferfi")
                    {
                        if (ferfi==-1)
                        {
                            ferfi = i;
                        }
                        else if (versenyzok[i].IdoOraban() < versenyzok[ferfi].IdoOraban())
                        {
                            ferfi = i;
                        }
                    }
                }
            }
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[i].tav == 100)
                {
                    if (versenyzok[i].kategoria == "Noi")
                    {
                        if (no == -1)
                        {
                            no = i;
                        }
                        else if (versenyzok[i].IdoOraban() < versenyzok[no].IdoOraban())
                        {
                            no = i;
                        }
                    }
                }
            }
            Console.WriteLine("8. feladta A verseny győztesei:");
            Console.WriteLine("Férfi: {0} {1} {2}",versenyzok[ferfi].nev, versenyzok[ferfi].szam, versenyzok[ferfi].ido);
            Console.WriteLine("Női: {0} {1} {2}",versenyzok[no].nev, versenyzok[no].szam, versenyzok[no].ido);
        }
    }

    class adatok
    {
        public string nev;
        public int szam;
        public string kategoria;
        public string ido;
        public int tav;
        public adatok(string sor)
        {
            string[] vag = sor.Split(';');
            nev = vag[0];
            szam = Convert.ToInt32(vag[1]);
            kategoria = vag[2];
            ido = vag[3];
            tav = Convert.ToInt32(vag[4]);
        }
        public int ora, perc, mp;
        public double IdoOraban()
        {

            string[] vag = ido.Split(':');
            ora = Convert.ToInt32(vag[0]);
            perc = Convert.ToInt32(vag[1]);
            mp = Convert.ToInt32(vag[2]);
            return Convert.ToDouble(ora*3600 +perc * 60 + mp)/3600;
        }
    }
}

