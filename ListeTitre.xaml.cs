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
using System.Windows.Shapes;
using WpfLecteurAudio.Modeles;

namespace WpfLecteurAudio
{

    /// <summary>
    /// Logique d'interaction pour ListeTitre.xaml
    /// </summary>
    public partial class ListeTitre : Window
    {
        List<Tracks> listeMorceaux;
        enregFichier sauvegarde;
        string[] infoLigne;
        public ListeTitre()
        {
            InitializeComponent();
            listeMorceaux = new List<Tracks>();
            sauvegarde = new enregFichier();
            if (sauvegarde.TestExistenceFichier() == true)
            {
                listeMorceaux = sauvegarde.recuperationListe();


                for (int i = 0; i < listeMorceaux.Count; i++)
                {
                    infoLigne = listeMorceaux.ElementAt(i).Getinfos();
                    listViewTitre.Items.Add(new MesItems { Titre = infoLigne[0], Artiste = infoLigne[1], Album = infoLigne[2], Chemin = infoLigne[3] });
                }
                
            }
        }

        private void btnQuitteré_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSuprimmer_Click(object sender, RoutedEventArgs e)
        {
            if (listViewTitre.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Voulez-vous vraiment supprimer ce morceau ?", "Suppression Morceau", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Mise à jour liste et sauvegarde !

                    listeMorceaux.RemoveAt(listViewTitre.SelectedIndex);

                    //enregistrement nouvelle liste

                    if (sauvegarde.sauveListe(listeMorceaux) == true)
                        MessageBox.Show("Les données ont été enregistrées");
                    else {
                        MessageBox.Show("Une erreur est survenue, les données n'ont pas été enregistrées");
                        this.Close();
                    }
                        
                    listViewTitre.Items.Clear();
                    for (int i = 0; i < listeMorceaux.Count; i++)
                    {
                        infoLigne = listeMorceaux.ElementAt(i).Getinfos();
                        listViewTitre.Items.Add(new MesItems { Titre = infoLigne[0], Artiste = infoLigne[1], Album = infoLigne[2], Chemin = infoLigne[3] });
                    }
                }
                else
                {
                    MessageBox.Show("Suppression annuler");
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas sélectionné de morceau !!", "ERREUR !", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
