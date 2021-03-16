using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gewinnspiel.classes
{
    public class Teilnehmer
    {
        private int teilnehmerID;
        private string vorname;
        private string nachname;
        private DateTime gebDatum;
        private char geschlecht;
        private string email;
        private string passwort;
        private bool deaktiviert;
        private bool admin;
        private int anzahlSpiele;

        //Klassenvariablen
        private static int autonum;
        private static int anzahl;

        //Konstruktor
        public Teilnehmer()
        {
            this.teilnehmerID = autonum;
            autonum++;
            anzahl++;
        }

        public Teilnehmer(string vorname, string nachname, DateTime gebDatum, char geschlecht, string email, string passwort, bool deaktiviert, bool admin, int anzahlSpiele)
        {
            teilnehmerID = autonum;
            autonum++;
            this.vorname = vorname;
            this.nachname = nachname;            this.gebDatum = gebDatum;
            this.geschlecht = geschlecht;
            this.email = email;
            this.passwort = passwort;
            this.deaktiviert = deaktiviert;
            this.admin = admin;
            this.anzahlSpiele = anzahlSpiele;

        }

        //Properties
        public int TeilnehmerID { get; set; }

        public String Vorname { get; set; }

        public String Nachname { get; set; }
        public DateTime GetDatum { get; set; }

        public char Geschlecht { get; set; }
        public String Email { get; set; }

        public String Passwort { get; set; }

        public bool Deaktiviert { get; set; }

        public bool Admin { get; set; }

        public int Anzahlspiele { get; set; }

        public static int Autonum { get; set; }

        public static int Anzahl { get; set; }

        public static int Autonom 
        {
        get { return autonum; }
        set { autonum = value; }
        }

        public override string ToString()
        {
            return teilnehmerID + " " + vorname + " " + nachname + " " + gebDatum + " " + geschlecht + " " + email + " " + passwort + " " + deaktiviert + " " + admin + " " + anzahlSpiele; 
        }




    }
}
