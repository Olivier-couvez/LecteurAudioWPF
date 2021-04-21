using Microsoft.Graph;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        string chemin = "";
        string[] decoupe;
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

       
        private void boutonRechercheFichier_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                chemin = openFileDialog.FileName;

                const int SIZE = 128;
                byte[] data = new byte[SIZE];

                LectureTagMp3 tag = new LectureTagMp3();

                // Read data file .mp3

                string fileName = chemin.Replace("\\\\", "\\");

                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    file.Seek(-128, SeekOrigin.End);

                    file.Read(tag.Id, 0, tag.Id.Length);
                    file.Read(tag.Title, 0, tag.Title.Length);
                    file.Read(tag.Artist, 0, tag.Artist.Length);
                    file.Read(tag.Album, 0, tag.Album.Length);
                    file.Read(tag.Year, 0, tag.Year.Length);
                    file.Read(tag.Comment, 0, tag.Comment.Length);
                    file.Read(tag.Genre, 0, tag.Genre.Length);
                }
                if (tag.TagId3())
                {
                    //MessageBox.Show(tag.ToString());
                    string contentTexte;
                    contentTexte = tag.titleToString().Trim(new Char[] { '\r', '\n' });
                    textboxTitre.Text = contentTexte;
                    contentTexte = tag.artistToString().Trim(new Char[] { '\r', '\n' });
                    textboxArtiste.Text = contentTexte;
                    contentTexte = tag.albumToString().Trim(new Char[] { '\r', '\n' });
                    textboxAlbum.Text = contentTexte;         
                }
                else
                {
                    MessageBox.Show("Pas de TAG mp3 dans ce fichier !");
                    decoupe = chemin.Split('\\');
                    decoupe = decoupe[decoupe.Length - 1].Split('.');
                    textboxTitre.Text = decoupe[0];
                }
            }
        }

        private void boutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void boutonAjouter_Click(object sender, RoutedEventArgs e)
        {
            nouveauMorceau = new Tracks(textboxTitre.Text, textboxArtiste.Text, textboxAlbum.Text, chemin);
            listeMorceaux.Add(nouveauMorceau);
            if (sauvegarde.sauveListe(listeMorceaux) == true)
                MessageBox.Show("Les données ont été enregistrées");
            else
                MessageBox.Show("Une erreur est survenue, les données n'ont pas été enregistrées");
        }
    }
}
