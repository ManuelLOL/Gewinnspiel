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

        internal void serialisierenTeil()
        {
            try
            {
                FileStream fs = new FileStream("Teilnehmer.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serializerTeiln.Serialize(fs, teilnehmerListe);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Serialisieren der Teilnehmer: " + ex.Message);
            }
        }
        internal void deserialisierenTeil()
        {
            try
            {
                FileStream fs = new FileStream("Teilnehmer.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                teilnehmerListe = (List<Teilnehmer>)serializerTeiln.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Deserialisieren der Teilnehmer: " + ex.Message);
            }
        }

        internal void serialisierenSpiel()
        {
            try
            {
                FileStream fs = new FileStream("Gewinnspiele.xml", FileMode.Create, FileAccess.Write, FileShare.None);
                serializerSpiele.Serialize(fs, gewinnspielListe);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Serialisieren der Gewinnspiele: " + ex.Message);
            }
        }

        internal void deserialisierenSpiel()
        {
            try
            {
                FileStream fs = new FileStream("Gewinnspiele.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                gewinnspielListe = (List<Spiel>)serializerSpiele.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Deserialisieren der Gewinnspiele: " + ex.Message);
            }
        }

        #endregion

        private void btnRegistrieren_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text.Equals(" ")||txtPasswort.Equals(" "))
            {
                MessageBox.Show("Bitte füllen Sie sowohl Benutzer als auch Passwort aus!");
                return;
            }
            foreach (Teilnehmer t in teilnehmerListe)
            {
                if (txtEmail.Text.Equals(t.Email))
                {
                    MessageBox.Show("Diese Email-Adresse ist bereits registriert!");
                    return;
                }
            }

            frmTeilnehmerAdd frmReg = new frmTeilnehmerAdd();
            frmReg.Text = "Registrierung";
            frmReg.txtEmail.Text = txtEmail.Text;
            frmReg.txtPasswort.Text = txtPasswort.Text;
            frmReg.ShowDialog();
        }
    }
}
