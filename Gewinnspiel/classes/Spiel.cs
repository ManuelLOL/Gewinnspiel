using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gewinnspiel.classes
{
    class Spiel
    {
        //Objektvariablen
        private int spielID;
        private string bezeichung;
        private string preis;
        private string wert;
        private List<Teilnehmer> listeTeilnehmer;
        private bool ausgelost;
        private string bildpfad;

        //Klassenvariablen
        public static int anzahl;
        public static int autonum = 1001;

        //Konstruktor
        public Spiel()
        {

        }
        public Spiel(string bezeichung, string preis, string wert,List<Teilnehmer>listeTeilnehmer, bool ausgelost, string bildpfad )
        {
            spielID = autonum;
            autonum++;
            this.bezeichung = bezeichung;
            this.preis = preis;
            this.wert = wert;
            this.listeTeilnehmer = listeTeilnehmer;
            this.ausgelost = ausgelost;
            this.bildpfad = bildpfad;

        }

        public int SpielID { get; set; }

        public string Bezeichung { get; set; }

        public string Preis { get; set; }

        public string Wert { get; set; }

        public  List<Teilnehmer> ListeTeilnehmer { get; set; }

        public bool Ausgelost { get; set; }

        public string Bildpfad { get; set; }

        public static int Autonum { get; set; }

        public static int Anzahl{ get; set; }
    }
}
