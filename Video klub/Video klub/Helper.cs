using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_klub
{
    class Helper : DataBase
    {
        /// <summary>
        /// Provera unosa podataka Clana
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool proveriUnetePodatke(Clan c)
        {
            if (!c.Ime.All(char.IsLetter) || string.IsNullOrEmpty(c.Ime))
                return false;
            else if (!c.Prezime.All(char.IsLetter) || string.IsNullOrEmpty(c.Prezime))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Provera unosa podataka Admina
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool proveriUnetePodatke(Admin a)
        {
            if (string.IsNullOrEmpty(a.Username) || a.Username != "admin" || string.IsNullOrEmpty(a.Password) || a.Password != "admin")
                return false;
            else
                return true;
        }
        
        /// <summary>
        /// Unos podataka clana
        /// </summary>
        /// <param name="c"></param>
        public void unosPodataka(Clan c)
        {
            Console.WriteLine("Unesite broj clanske karte : ");
            c.BrojKarte = Console.ReadLine();
            Console.WriteLine("Unesite ime clana : ");
            c.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime clana: ");
            c.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite datum rodjenja u formatu ddMMyyyy: ");
            c.DatumRodjenja = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", null);
        }
        
        /// <summary>
        /// Unos podataka Admina
        /// </summary>
        /// <param name="a"></param>
        public void unosPodataka(Admin a)
        {
            Console.WriteLine("\t***Video Klub***\n");
            Console.WriteLine("Dobro dosli!\n");
            Console.WriteLine("Unesite svoje kredencijale za prijavu!\n");
            Console.WriteLine("Username : ");
            a.Username = Console.ReadLine();
            Console.WriteLine("Password : ");
            a.Password = Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Izbor operacije iz menija
        /// </summary>
        /// <returns></returns>
        public int unesiOpciju()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t****Izaberite operaciju****\n");
            Console.WriteLine("\t1 - Dodaj novog clana \t 2 - Izmeni postojeceg clana\n");
            Console.WriteLine("\t3 - Iznajmi film clanu \t 4 - Razduzi film\n");
            Console.WriteLine("\t5 - Prikazi zaduzenja po clanu \t 0 - Izlaz\n");
            int opcija = Convert.ToInt32(Console.ReadLine());
            return opcija;
        }

        /// <summary>
        /// Izdavanje filma
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        public void izdajFilm(Clan c, Film f)
        {
            Console.WriteLine("Izabrali ste opciju 3 - Iznajmi film clanu.\n");
            Console.WriteLine("Izaberite film: \n");
            PrintTableFilm();
            f.FilmID = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Unesite broj clanske karte : \n");
            PrintTableClan();
            Console.WriteLine();
            c.BrojKarte = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Unesite datum izdavanja filma u formatu ddMMyyyy: ");
            c.DatumOd = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", null);
            Console.WriteLine();
        }

        /// <summary>
        /// Razduzivanje filma korisnika
        /// </summary>
        /// <param name="c"></param>
        public void razduziFilm(Clan c)
        {
            Console.WriteLine("Izabrali ste opciju 4 - Razduzi film clanu.");
            Console.WriteLine("Unesite broj clanske karte : \n");
            PrintTableClan();
            c.BrojKarte = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Unesite datum razduzenja u formatu ddMMyyyy:");
            c.DatumDo = DateTime.ParseExact(Console.ReadLine(), "ddMMyyyy", null);
            Console.WriteLine("Pritisnite ENTER kako bi ste razduzili film!");
            Console.ReadLine();
        }

        /// <summary>
        /// Pregled zaduzenja korsinika
        /// </summary>
        /// <param name="c"></param>
        public void pregledZaduzenja(Clan c)
        {
            Console.WriteLine("Izabrali ste opciju 5 - Prikazi zaduzenja po clanu.");
            Console.WriteLine("Unesite broj clanske karte : \n");
            PrintTableClan();
            Console.WriteLine();
            c.BrojKarte = Console.ReadLine();
        }
    }
}
