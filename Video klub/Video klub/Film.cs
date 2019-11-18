using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_klub
{
    class Film
    {
        #region Fields
        private int filmID;
        private string naziv;
        private string zanr;
        private DateTime godinaSnimanja;
        #endregion

        #region Properties
        public int FilmID { get { return filmID; } set { filmID = value; } }
        public string Naziv { get { return naziv; } set { naziv = value; } }
        public string Zanr { get { return zanr; } set { zanr = value; } }
        public DateTime GodinaSnimanja { get { return godinaSnimanja; } set { godinaSnimanja = value; } }
        #endregion

    }
}
