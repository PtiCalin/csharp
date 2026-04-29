
/* Fichier  : FormTp1    
	Auteure  : Charlie Bouchard (20077301), Charles Seguin (20341523)
	Cours    : IFT1179-A-H26 - Programmation en C#
	Trimestre: Hiver 2026
	But      : Integrer les fonctionalitees evenementielles de calcul au formulaire du projet "Epargne" afin
                d'afficher le rendement de divers investissement et presenter un sommaire des montants calcules
	Notes    : À partir des documents fournis dans le .zip "Epargne"   
	Dernière mise à jour : 2026-02-09
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epargne
{
    public partial class FormTp1 : Form
    {
        // Variables de classe
        double tauxMin;
        double taux;
        double montant;
        int nbCpg;
        int nbFonds;
        double totalFondsFinAnnee;
        
        public FormTp1()
        {
            InitializeComponent();
        }

        private void FormTp1_Load(object sender, EventArgs e)
        {
            // Initialisation des statistiques
            nbCpg = 0;
            nbFonds = 0;
            totalFondsFinAnnee = 0.0;
            tauxMin = double.MaxValue;
            // RadioButton par défaut
            cpgRadioButton.Checked = true;
        }

        // Gestion du bouton Calculer
        private void calculerButton_Click(object sender, EventArgs e)
        {
            // Valider Montant
            if (!double.TryParse(montantTextBox.Text, out montant))
            {
                MessageBox.Show("Le montant d'investissement n'est pas un nombre.");
                montantTextBox.Clear();
                montantTextBox.Focus();
                return;
            }

            // Valider le taux

            if (!double.TryParse(tauxTextBox.Text, out taux))
            {
                MessageBox.Show("Le rendement n'est pas un nombre.");
                tauxTextBox.Clear();
                tauxTextBox.Focus();
                return;
            }


            // Calculer la valeur de fin d’année
            double valeurFin = montant * (1 + taux / 100.0);
            // Mettre à jour les statistiques globales
            if (taux < tauxMin)
            {
                tauxMin = taux;
            }
            if (cpgRadioButton.Checked)
            {
                nbCpg++;
            }
            else
            {
                nbFonds++;
            }
            totalFondsFinAnnee += valeurFin;
            // Afficher le résultat dans le label
            string typePlacement;
            if
                (cpgRadioButton.Checked) typePlacement = "C'est un certificat de placement";
            else
                typePlacement = "C'est un fond commun";
            var message = typePlacement +
                "\n" + $"La valeur en debut d'annee est de {montant:F2}$\n" +
                $"Le taux d'interet pour l'annee est de {taux:F3}%\n" +
                $"La valeur du placement a la fin de l'annee est de {valeurFin:F2}$";

            affichageLabel.Text = message;
            // Vider les zones de texte
            montantTextBox.Clear();
            tauxTextBox.Clear();
        }

        // Gestion du bouton Sommaire
        private void sommaireButton_Click(object sender, EventArgs e)
        {
            // Préparer le texte
            StringBuilder sb = new StringBuilder();
            // Afficher le nombre de certificats (singulier/pluriel)
            if (nbCpg > 0)
            {
                if (nbCpg == 1)
                    sb.AppendLine("1 certificat de placement traite.");
                else
                    sb.AppendLine($"{nbCpg} certificats de placement traites.");
            }
            // Afficher la moyenne des fonds
            if (nbFonds > 0)
            {
                double moyenne = totalFondsFinAnnee / nbFonds;
                if (nbFonds == 1)
                    sb.AppendLine($"Valeur du fond: {moyenne:F2}$");
                else
                    sb.AppendLine($"Valeur moyenne des fonds: {moyenne:F2}$");
            }
            // Afficher le taux minimum
            if ((nbCpg + nbFonds) > 0)
            {
                sb.AppendLine($"Le taux d'interet minimum est {tauxMin:F3}%");
            }
            // Afficher le sommaire
            affichageLabel.Text = sb.ToString();
        }

        // Gestion du Bouton Quitter
        private void quitterButton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
