using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireDeNotes
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show(" Veuillez remplir tous les champs");

            }
            else
            {


                // Inserer à la base
                DBConnect dbconnect = new DBConnect();
                bool v;
                v = dbconnect.Login(textBoxUserName.Text, textBoxPassword.Text);

                if (v)
                {
                    MessageBox.Show(" Vous etes connecté ! ");

                    Notes notes = new Notes();
                    this.Hide();
                    notes.Show();

                }
                else
                {
                    MessageBox.Show(" Erreur ! identifiant ou mot de passe incorrect ");
                }



            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
