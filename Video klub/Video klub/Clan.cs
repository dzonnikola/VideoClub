using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_klub
{
    class Clan
    {

        #region Fields
        private string brojKarte;
        private string ime;
        private string prezime;
        private DateTime datumRodj;
        private DateTime datumOd;
        private DateTime datumDo;
        #endregion

        #region Properties
        public string BrojKarte { get { return brojKarte; } set { brojKarte = value;} }
        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public DateTime DatumRodjenja { get { return datumRodj;} set{ datumRodj = value; } }
        public DateTime DatumOd { get { return datumOd; } set { datumOd = value; } }
        public DateTime DatumDo { get { return datumDo; } set { datumDo = value; } }
        #endregion
    }
}
