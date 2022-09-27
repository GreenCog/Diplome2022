using Antitriche_diplome.models.ApiModels;
using Antitriche_diplome.projet_eleve;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Antitriche_diplome.projet_eleve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool durantTest = false;
        private DateTime heureDebut;
        private DateTime heureFin;
        private Resultat resultatFinal;
        private EmetteurDonnees emetteur;
        private FormateurDonnees formateur;
        private SequenceurDonnees sequenceur;
        private CollecteurBucket collecteurBucket;
        private CollecteurDonnees collecteurDonnees;
        
        public MainWindow()
        {
            resultatFinal = new Resultat();
            formateur = new FormateurDonnees(resultatFinal);
            emetteur = new EmetteurDonnees();
            sequenceur = new SequenceurDonnees();
            collecteurBucket = new CollecteurBucket();
            
            InitializeComponent();


        }


        /// <summary>
        /// Lors du premier event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDemarreStop_Click(object sender, RoutedEventArgs e)
        {
            if (!durantTest)
            {
                if (VerifSiInputNonNull())
                {
                    heureDebut = DateTime.Now;
                    txtHeureDebut.Text = heureDebut.ToString("HH:mm");
                    heureDebut = heureDebut.AddHours(-2);

                    durantTest = !durantTest;

                    resultatFinal.Classe = txtClasse.Text;
                    resultatFinal.NomEleve = txtNom.Text;
                    resultatFinal.PrenomEleve = txtPrenom.Text;
                    resultatFinal.Test = txtTest.Text;
                    resultatFinal.Date = heureDebut;
                }
                else
                {
                    changerBtnDemarreStop();
                }
                

            }
            else
            {
                MessageBox.Show("Veuillez patientez que les données soient envoyées");
                //Affichage de l'heure actuelle et stockage de l'heure avec -2 heures
                heureFin = DateTime.Now;
                txtHeureFin.Text = heureFin.ToString("HH:mm");
                heureFin = heureFin.AddHours(-2);
                
                durantTest = !durantTest;
                
                //collecter les évènements des buckets en prenant la liste créee par le collecteur de bucket 
                collecteurDonnees = new CollecteurDonnees(heureDebut, formateur);
                
                collecteurDonnees.CollecterDonnees(collecteurBucket.BucketNames);
                

                //Retire les données qui ne sont pas dans la plage d'horaire et stock les données filtrées
                sequenceur.Sequence(formateur, heureDebut,heureFin, resultatFinal);
                

                await emetteur.Envoie(resultatFinal);
                
                
                MessageBox.Show("Données envoyées Bravo !");
            }
            changerBtnDemarreStop();

        }
        /// <summary>
        /// 
        /// </summary>
        private void changerBtnDemarreStop()
        {
            if (durantTest)
            {
                btnDemarreStop.Content = "Stop";
            }
            else
            {
                btnDemarreStop.Content = "Demarrer";
            }
        }

        private bool VerifSiInputNonNull()
        {
            if (txtClasse.Text != "")
            {
                if (txtNom.Text != "")
                {
                    if (txtPrenom.Text != "")
                    {
                        if (txtTest.Text != "")
                        {
                           return true;
                        }
                        else
                        {
                            MessageBox.Show("Veuillez renseignez le nom du test que vous avez effectué");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez renseignez votre prénom");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez renseignez votre nom");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseignez votre classe");
                return false;
            }
        }
       

        
    }
}
