using Microsoft.Win32;
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
    /// Logique d'interaction pour AjoutTitre.xaml
    /// </summary>
    public partial class AjoutTitre : Window
    {
        List<Tracks> listeMorceaux;
        enregFichier sauvegarde;
        Tracks nouveauMorceau;
        public AjoutTitre()
        {
            InitializeComponent();
            listeMorceaux = new List<Tracks>();
            sauvegarde = new enregFichier();
            if (sauvegarde.TestExistenceFichier() == true)
            {
                listeMorceaux = sauvegarde.recuperationListe();
            }
            

        }

        private void boutonAjouter_Click(object sender, RoutedEventArgs e)
        {

            string chemin = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                chemin = openFileDialog.FileName;
                nouveauMorceau = new Tracks(textboxTitre.Text, textboxArtiste.Text, textboxAlbum.Text, chemin);
                listeMorceaux.Add(nouveauMorceau);
                if (sauvegarde.sauveListe(listeMorceaux) == true)
                    MessageBox.Show("Les données ont été enregistrées");
                else
                    MessageBox.Show("Une erreur est survenue, les données n'ont pas été enregistrées");


            }
        }

        private void boutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
