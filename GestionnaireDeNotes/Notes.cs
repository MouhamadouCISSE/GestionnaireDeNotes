using MySql.Data.MySqlClient;
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
    public partial class Notes : Form
    {
        MySqlDataAdapter adpt;
        DataTable dt;
        int ID;


        public Notes()
        {
            InitializeComponent();
            dispay();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            matricule.Text = null;
            nom.Text = null;
            prenom.Text = null;
            developpement.Text = null;
            mathematiques.Text = null;
            donnees.Text = null;
            reseaux.Text = null;
            management.Text = null;
            langue.Text = null;
        }
        public void dispay()
        {
            adpt = new MySqlDataAdapter();
            dt = new DataTable();
            DBConnect dbconnect = new DBConnect();
            adpt = dbconnect.listEtudiant();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void dispay(string matricule)
        {
            adpt = new MySqlDataAdapter();
            dt = new DataTable();
            DBConnect dbconnect = new DBConnect();
            adpt = dbconnect.listEtudiant(matricule);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnValider_Click(object sender, EventArgs e)
        { 
            if (matricule.Text == "" || nom.Text == "" || prenom.Text == "" || developpement.Text == "" || mathematiques.Text == "" || donnees.Text == "" || reseaux.Text == "" || management.Text == "" || langue.Text == "")
            {
                MessageBox.Show(" Veuillez remplir tous les champs");

            }
            else
            {
                Etudiant etudiant = new Etudiant();

                etudiant.Matricule = int.Parse(matricule.Text);
                etudiant.Nom = nom.Text;
                etudiant.Prenom = prenom.Text;
                etudiant.Developpement = int.Parse(developpement.Text);
                etudiant.Mathematiques = int.Parse(mathematiques.Text);
                etudiant.Donnees = int.Parse(donnees.Text);
                etudiant.Reseaux= int.Parse(reseaux.Text);
                etudiant.Management = int.Parse(management.Text);
                etudiant.Langue = int.Parse(langue.Text);

                // Inserer à la base
                DBConnect dbconnect = new DBConnect();
                dbconnect.Insert(etudiant);

                MessageBox.Show(" Etudiant Ajouté ");
                clear();
                dispay();
            }
        
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (matricule.Text == "" || nom.Text == "" || prenom.Text == "" || developpement.Text == "" || mathematiques.Text == "" || donnees.Text == "" || reseaux.Text == "" || management.Text == "" || langue.Text == "")
            {
                MessageBox.Show(" Veuillez remplir tous les champs");

            }
            else
            {
                // Inserer à la base
                DBConnect dbconnect = new DBConnect();
                dbconnect.Delete(ID);

                MessageBox.Show(" Etudiant supprimé ");
                clear();
                dispay();
            }
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (matricule.Text == "" || nom.Text == "" || prenom.Text == "" || developpement.Text == "" || mathematiques.Text == "" || donnees.Text == "" || reseaux.Text == "" || management.Text == "" || langue.Text == "")
            {
                MessageBox.Show(" Veuillez remplir tous les champs");

            }
            else
            {
                Etudiant etudiant = new Etudiant();

                etudiant.Matricule = int.Parse(matricule.Text);
                etudiant.Nom = nom.Text;
                etudiant.Prenom = prenom.Text;
                etudiant.Developpement = int.Parse(developpement.Text);
                etudiant.Mathematiques = int.Parse(mathematiques.Text);
                etudiant.Donnees = int.Parse(donnees.Text);
                etudiant.Reseaux = int.Parse(reseaux.Text);
                etudiant.Management = int.Parse(management.Text);
                etudiant.Langue = int.Parse(langue.Text);

                // Inserer à la base
                DBConnect dbconnect = new DBConnect();
                dbconnect.Update(etudiant, ID);

                MessageBox.Show(" Etudiant Modifié ");
                clear();
                dispay();
            }
        }

        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            dispay();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
            matricule.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            nom.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            prenom.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            developpement.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            mathematiques.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            donnees.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            reseaux.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            management.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            langue.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            int cmp = 0;
            string rech;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == textBoxRechercher.Text)
                {
                    rech = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    MessageBox.Show("il existe!!");
                    dispay(rech);

                    cmp = 1;
                }

            }
            if (cmp == 0)
            {
                MessageBox.Show("n'existe Pas");
            }
        }
    }
}
