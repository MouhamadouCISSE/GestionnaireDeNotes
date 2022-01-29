using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireDeNotes
{
    internal class Etudiant
    {
        // Les champs 
        private double matricule;
        private string nom;
        private string prenom;
        private double developpement;
        private double mathematiques;
        private double donnees;
        private double reseaux;
        private double management;
        private double langue;
    

    public Etudiant() { }

    public double Matricule { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public double Developpement { get; set; }
    public double Mathematiques { get; set; }
    public double Donnees { get; set; }
    public double Management { get; set; }
    public double Reseaux { get; set; }
    public double Langue { get; set; }

    }

}
