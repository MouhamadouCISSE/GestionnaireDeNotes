using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionnaireDeNotes
{
    internal class DBConnect
    {
        private string user;
        private string password;
        private string dbName;
        private string server;
        private MySqlConnection conn;
        MySqlDataAdapter adpt;
        MySqlDataAdapter adptLogin;





        public DBConnect()
        {
            initilize();
        }

        // Créer la connexion à la base de données
        private void initilize()
        {
            user = "root";
            password = "";
            dbName = "dbesmt";
            server = "localhost";

            string connexion = "SERVER=" + server + ";"
                + "DATABASE=" + dbName + ";"
                + "UID=" + user + ";"
                + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connexion);
        }

        // ouvrir une connexion à la base de données client_ms
        private bool OpenConnexion()
        {
            try
            {
                conn.Open();
                return true;

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Problème de connnexion !!");
                        break;
                    case 1045:
                        MessageBox.Show("Login ou Mot de passe incorrect !");
                        break;
                }

                return false;
            }
        }
        public bool Login(string Username, string PassWord)
        {
            // définir la requête 
            string request = "SELECT * FROM responsable WHERE login='" + Username + "' and password='" + PassWord + "'";

            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                MySqlCommand cmd = new MySqlCommand(request, conn);
                adptLogin = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptLogin.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count == 0)
                {
                    return false;
                }


                this.conn.Close(); // fermer la session de connexion
            }

            return true;

        }

        public bool LoginEtudiant(string Username, string PassWord)
        {
            // définir la requête 
            string request = "SELECT * FROM etudiant WHERE matricule='" + Username + "' and matricule='" + PassWord + "'";

            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                MySqlCommand cmd = new MySqlCommand(request, conn);
                adptLogin = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adptLogin.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count == 0)
                {
                    return false;
                }


                this.conn.Close(); // fermer la session de connexion
            }

            return true;

        }



        public void Insert(Etudiant e)
        {
            // définir la requête 
            string request = "INSERT INTO etudiant(matricule, nom, prenom, developpement, mathematiques, donnees, reseaux, management, langue)"
                + " VALUES('" + e.Matricule + "', '" + e.Nom + "', '" + e.Prenom + "', '" + e.Developpement + "', '" + e.Mathematiques + "', '" + e.Donnees + "', '" + e.Reseaux + "', '" + e.Management + "', '" + e.Langue + "')";

            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                MySqlCommand cmd = new MySqlCommand(request, conn);
                cmd.ExecuteNonQuery(); // Exécter la requpete
                this.conn.Close(); // fermer la session de connexion
            }
        }

        public void Delete(int ID)
        {
            // définir la requête 
            string request = "DELETE FROM etudiant WHERE id = " + ID + " ";

            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                MySqlCommand cmd = new MySqlCommand(request, conn);
                cmd.ExecuteNonQuery(); // Exécter la requpete
                this.conn.Close(); // fermer la session de connexion
            }
        }
        
        public void Update(Etudiant e, int ID)
        {
            // définir la requête 
            string request = "UPDATE  etudiant SET matricule= '" + e.Matricule + "',nom= '" + e.Nom + "', prenom= '" + e.Prenom + "', developpement= '" + e.Developpement + "', mathematiques= '" + e.Mathematiques + "', donnees = '" + e.Donnees + "', reseaux = '" + e.Reseaux + "', management = '" + e.Management + "', langue = '" + e.Langue + "' WHERE id = " + ID + " ";


            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                MySqlCommand cmd = new MySqlCommand(request, conn);
                cmd.ExecuteNonQuery(); // Exécter la requpete
                this.conn.Close(); // fermer la session de connexion
            }

        }



        
        public MySqlDataAdapter listEtudiant()
        {

            string request = "SELECT * FROM etudiant";
            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                adpt = new MySqlDataAdapter(request, conn);

                this.conn.Close(); // fermer la session de connexion
            }
            return adpt;
        }

        public MySqlDataAdapter listEtudiant(string matricule)
        {

            string request = "SELECT * FROM etudiant WHERE matricule = '" + matricule + "'";
            if (this.OpenConnexion() == true) // vérifier si la connexion à été ouvert
            {
                adpt = new MySqlDataAdapter(request, conn);

                this.conn.Close(); // fermer la session de connexion
            }
            return adpt;
        }

        

    }
}
