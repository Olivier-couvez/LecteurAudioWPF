using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLecteurAudio.Modeles
{
    [Serializable]
    public class Tracks
    {
        protected string titre;
        protected string artiste;
        protected string album;
        protected string chemin;


        public Tracks(string _titre, string _artiste, string _album, string _chemin)
        {
            titre = _titre;
            artiste = _artiste;
            album = _album;
            chemin = _chemin;
        }

        public string Titre { get; set; }
        public string Artiste { get; set; }
        public string Album { get; set; }
        public string Chemin { get; set; }

        public string[] Getinfos()
        {
            string[] liste = { titre, artiste, album, chemin };

            return liste;
        }
    }
}
