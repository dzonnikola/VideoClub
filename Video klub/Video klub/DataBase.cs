using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Video_klub
{
    class DataBase
    {

        protected SqlConnection connection = new SqlConnection(Konekcija.konekcioniString);

        /// <summary>
        /// Ispis clanova u bazi
        /// </summary>
        protected void PrintTableClan()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clan", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Broj Karte\t\t Ime \t\t Prezime \t\t Godina rodjenja \t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t\t | {1} \t | {2} \t\t {3}",
                        reader[0], reader[1], reader[2], reader[3]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Ispis filmova u bazi
        /// </summary>
        protected void PrintTableFilm()
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Film", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FilmID \t Naziv \t\t\t\t Zanr \t Godina snimanja");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t {1} \t\t\t\t\t {2} \t {3}",
                        reader[0], reader[1], reader[2], reader[3]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Kreiranje novog clana
        /// </summary>
        /// <param name="c"></param>
        protected void InsertNovogClana(Clan c)
        {
            try
            {
                connection.Open();
                SqlCommand insertClan = new SqlCommand("INSERT INTO Clan(BrojKarte, Ime, Prezime, DatumRodjenja) VALUES (@BrojKarte, @Ime, @Prezime, @DatumRodjenja)", connection);
                insertClan.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                insertClan.Parameters.Add(new SqlParameter("Ime", c.Ime));
                insertClan.Parameters.Add(new SqlParameter("Prezime", c.Prezime));
                insertClan.Parameters.Add(new SqlParameter("DatumRodjenja", c.DatumRodjenja));
                insertClan.ExecuteNonQuery();
                Console.WriteLine("Uspesan unos! Pritisnite ENTER za povratak na početni meni.");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Azuriranje postojeceg clana
        /// </summary>
        /// <param name="c"></param>
        protected void UpdateClana(Clan c)
        {
            try
            {
                connection.Open();
                SqlCommand editClan = new SqlCommand("Update Clan set Ime=@Ime, Prezime=@Prezime, DatumRodjenja=@DatumRodjenja where BrojKarte=@BrojKarte", connection);
                editClan.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                editClan.Parameters.Add(new SqlParameter("Ime", c.Ime));
                editClan.Parameters.Add(new SqlParameter("Prezime", c.Prezime));
                editClan.Parameters.Add(new SqlParameter("DatumRodjenja", c.DatumRodjenja));
                editClan.ExecuteNonQuery();
                Console.WriteLine("Uspešna izmena! Pritisnite ENTER za povratak na početni meni.");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Izdavanje filma clanu
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        protected void IzdavanjeFilma(Clan c, Film f)
        {
            try
            {
                connection.Open();
                puniVezu(c, f);
                SqlCommand izdavanjeFilma = new SqlCommand("UPDATE Clan SET DatumOd=@DatumOd, FilmID=@FilmID where BrojKarte=@BrojKarte", connection);
                izdavanjeFilma.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                izdavanjeFilma.Parameters.Add(new SqlParameter("DatumOd", c.DatumOd));
                izdavanjeFilma.Parameters.Add(new SqlParameter("FilmID", f.FilmID));
                izdavanjeFilma.ExecuteNonQuery();
                Console.WriteLine("Film izdat! Pritisnite ENTER za povratak na početni meni.");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Razduzivanje filma clanu
        /// </summary>
        /// <param name="c"></param>
        protected void RazduziFilm(Clan c)
        {
            try
            {
                connection.Open();
                SqlCommand razduzivanjeFilma = new SqlCommand("UPDATE Clan SET DatumDo=@DatumDo, FilmID=@FilmID WHERE BrojKarte=@BrojKarte", connection);
                razduzivanjeFilma.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                razduzivanjeFilma.Parameters.Add(new SqlParameter("DatumDo", c.DatumDo));
                razduzivanjeFilma.Parameters.Add(new SqlParameter("FilmID", DBNull.Value));
                razduzivanjeFilma.ExecuteNonQuery();

                SqlCommand brisiVezu = new SqlCommand("DELETE FROM IznajmljeniFilmovi WHERE BrojKarte=@BrojKarte", connection);
                brisiVezu.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                brisiVezu.ExecuteNonQuery();

                SqlCommand DateDiff = new SqlCommand("SELECT DATEDIFF (day, c.DatumOd,c.DatumDo) FROM Clan c WHERE BrojKarte=@BrojKarte", connection);
                DateDiff.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                if ((int)DateDiff.ExecuteScalar() < 0)
                {
                    Console.WriteLine("Greska u unosu datuma! Datum razduzenja mora biti veci od datuma izdavanja!");
                    Console.WriteLine("Pritisnite ENTER za povratak na pocetni meni.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Film je bio izdat " + DateDiff.ExecuteScalar() + " dana.");
                    Console.WriteLine("Film razduzen! Pritisnite ENTER za povratak na početni meni.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Pregled zaduzenja clana
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        protected void pregledZaduzenja(Clan c, Film f)
        {
            try
            {
                connection.Open();
                SqlCommand ProveriZaduzenja = new SqlCommand("SELECT f.Naziv, i.DatumOd FROM IznajmljeniFilmovi i JOIN Film f on i.FilmID = f.FilmID JOIN Clan c on i.BrojKarte = c.BrojKarte WHERE c.BrojKarte = @BrojKarte", connection);
                ProveriZaduzenja.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                using (SqlDataReader reader = ProveriZaduzenja.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        Console.WriteLine("\nNaziv filma\t\tDatumIzdavanja");
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}\t\t\t{1}",
                            reader[0], reader[1]));
                        }
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Izabrani clan nema zaduzenja.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Metod koji puni vezu izmedju tabele Clan i Film i poziva se unutar funkcije u klasi DataBase
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        private void puniVezu(Clan c, Film f)
        {
            try
            {
                SqlCommand popuniVezu = new SqlCommand("INSERT INTO IznajmljeniFilmovi(BrojKarte, FilmID, DatumOd) VALUES (@BrojKarte, @FilmID, @DatumOd)", connection);
                popuniVezu.Parameters.Add(new SqlParameter("BrojKarte", c.BrojKarte));
                popuniVezu.Parameters.Add(new SqlParameter("FilmID", f.FilmID));
                popuniVezu.Parameters.Add(new SqlParameter("DatumOd", c.DatumOd));
                popuniVezu.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Greska : " + ex.Message);
            }
        }
    }
}