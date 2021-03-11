using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gewinnspiel.classes;
using Gewinnspiel.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace Gewinnspiel.Forms
{
    
    public partial class frmLogin : Form
    {
        internal static frmLogin frmLog;
        public frmLogin()
            
        {
            InitializeComponent();
            frmLog = this;
        }

        #region Variablen
        internal string pwCode;
        internal bool foundUser;
        internal Teilnehmer activeUser;
        internal List<Teilnehmer> teilnehmerListe;
        internal List<Spiel> gewinnspielListe;
        internal XmlSerializer serializerTeiln;
        internal XmlSerializer serializerSpiele;
        internal frmAdmin frmAd;
        internal frmTeilnehmer frmTeil;
        

        
        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            teilnehmerListe = new List<Teilnehmer>();
            gewinnspielListe = new List<Spiel>();
            serializerSpiele = new XmlSerializer(gewinnspielListe.GetType());
            serializerTeiln = new XmlSerializer(teilnehmerListe.GetType());


        }

        #region Methoden

        internal String verschluesselnSHA512(string text)
        {
            string temp;
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(text);
            byte[] result = sha512.ComputeHash(textToHash);
            return temp= System.BitConverter.ToString(result);
        }

        #endregion

        private void btnRegistrieren_Click(object sender, EventArgs e)
        {

        }
    }
}
