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

namespace Gewinnspiel.Forms
{
    public partial class frmTeilnehmerAdd : Form
    {
        public frmTeilnehmerAdd()
        {
            InitializeComponent();
        }

        #region Variablen
        DateTime minus16Y;
        #endregion

        private void frmTeilnehmerAdd_Load(object sender, EventArgs e)
        {
            if (frmLogin.frmLog.activeUser==null)
            {
                cbAdmin.Visible = false;
                cbDeaktiviert.Visible = false;
                txtTeilnehmer.Text = Teilnehmer.Autonum.ToString();

            }
            else //Bearbeiten
            {
                if(frmLogin.frmLog.activeUser.Admin) //Ist admin
                {
                    cbAdmin.Visible = true;
                    cbDeaktiviert.Visible = true;

                }
                else //Ist nur Teilnehmer
                {
                    cbAdmin.Visible = false;
                    cbDeaktiviert.Visible = false;

                }

            }

        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (txtZuname.Text.Equals(" ")|| txtVorname.Equals(" ")||txtEmail.Equals(" "))
            {
                MessageBox.Show("Bitte füllen Sie sowohl Zuname, Vorname als auch Email aus!");
                return;
            }
            if (frmLogin.frmLog.activeUser == null && txtPasswort.Text.Equals(""))
            {
                MessageBox.Show("Bitte geben Sie ein Passwort ein!");
                return;
            }

            if (cbGeschleht.SelectedIndex==-1) //Kein Geschlecht ausgewählt
            {

            }

            minus16Y = DateTime.Now.AddYears(-16);
            if (dtpGebDat.Value.Date > minus16Y )
            {
                MessageBox.Show("Bitte wählen Sie Ihr Geburtsdatum aus, Sie müssen 16 Jahre alt sein!");
                return;
            }

            if (frmLogin.frmLog.activeUser==null)
            {
                Teilnehmer t = new Teilnehmer();
                t.Nachname = txtZuname.Text;
                t.Vorname = txtVorname.Text;
                t.Passwort = frmLogin.frmLog.verschluesselnSHA512(txtPasswort.Text);
                t.Email = txtEmail.Text;
                t.GetDatum = dtpGebDat.Value.Date;
                t.Geschlecht = Convert.ToChar(cbGeschleht.Text);
                t.Admin = false;
                t.Deaktiviert = false;
                frmLogin.frmLog.teilnehmerListe.Add(t);
                MessageBox.Show("Registrierung erflgreich!");
                
            }
            else
            {

            }
            frmLogin.frmLog.serialisierenTeil();
            this.Close();


        }
    }
}
