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
    }
}
