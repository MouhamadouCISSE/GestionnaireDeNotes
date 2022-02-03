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
    public partial class Bulletin : Form
    {
        MySqlDataAdapter adpt;
        DataTable dt;
        

        public Bulletin()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
