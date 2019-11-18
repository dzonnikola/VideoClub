using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Video_klub
{
    class Program:DataBase
    {
        static void Main(string[] args)
        {
            #region Instanciranje objekata klasa
            Admin admin = new Admin();
            Helper helper = new Helper();
            var db = new Program();
            Clan clan = new Clan();
            Film film = new Film();
            #endregion

            int brojac = 0;

            while (true)
            {
                helper.unosPodataka(admin);
                if (helper.proveriUnetePodatke(admin) == false)
                    brojac++;
                else
                {
                    Console.WriteLine("****Uspesna prijava!****\n");
                    break;
                }

                if (brojac > 2)
                {
                    Console.WriteLine("Neuspesna prijava. Ispunili ste broj pokusaja.");
                    Environment.Exit(0);
                }
            }

            while (true)
            {
                int broj = helper.unesiOpciju();

                switch (broj)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        helper.unosPodataka(clan);
                        if (helper.proveriUnetePodatke(clan) == false)
                        {
                            Console.WriteLine("Neispravan unos podataka. ENTER - Pokusajte ponovo.");
                            Console.ReadLine();
                        }
                        else
                        {
                            db.InsertNovogClana(clan);
                        }
                        break;

                    case 2:
                        db.PrintTableClan();
                        helper.unosPodataka(clan);
                        if (helper.proveriUnetePodatke(clan) == false)
                        {
                            Console.WriteLine("Neispravan unos podataka. ENTER - Pokusajte ponovo.");
                            Console.ReadLine();
                        }
                        else
                        {
                            db.UpdateClana(clan);
                        }
                        break;
                    case 3:
                        helper.izdajFilm(clan, film);
                        db.IzdavanjeFilma(clan, film);
                        break;
                    case 4:
                        helper.razduziFilm(clan);
                        db.RazduziFilm(clan);
                        break;
                    case 5:
                        helper.pregledZaduzenja(clan);
                        db.pregledZaduzenja(clan, film);
                        break;
                    default:
                        Console.WriteLine("Niste uneli odgovarajući broj.");
                        break;
                }
            }
        }
    }
}

