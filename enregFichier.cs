using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    class enregFichier
    {
        private string nomFichier;
        private List<Tracks> lesMorceaux;

        public enregFichier()
        {
            nomFichier = "C:\\temps\\Musique\\listemorceaux.bin";
        }

        /// <summary>
        /// Cette méthode vérifie si le fichier bin existe déjà 
        /// </summary>
        /// <returns></returns>
        /// 
        public bool TestExistenceFichier()
        {
            return File.Exists(nomFichier);

        }
        /// <summary>
        /// Cette méthode permet de récupérer la liste des morceaux qui ont été enregistrées dans le fichier bin
        /// </summary>
        /// <returns> retourne la liste morceaux</returns>
        /// 
        public List<Tracks> recuperationListe()
        {
            Stream testFileStream = File.OpenRead(nomFichier); // on ouvre le fichier en lecture
            BinaryFormatter deserialiseur = new BinaryFormatter();
            lesMorceaux = (List<Tracks>)deserialiseur.Deserialize(testFileStream);
            testFileStream.Close();
            return lesMorceaux;
        }

        public bool sauveListe(List<Tracks> listmor)
        {
            bool testCreation = false;
            try
            {
                Stream testFileStream = File.Create(nomFichier);
                BinaryFormatter serialiseur = new BinaryFormatter();
                serialiseur.Serialize(testFileStream, listmor);
                testFileStream.Close();
                testCreation = true;

            }
            catch (FileNotFoundException erreur)
            {
                MessageBox.Show("une erreur est survenue : " + erreur.Message);
                testCreation = false;
            }
            catch (UnauthorizedAccessException erreur)
            {
                MessageBox.Show("problème d'autorisation d'accès au fichier: " + erreur.Message);
                testCreation = false;
            }

            return testCreation;

        }
        internal List<Tracks> LesMorceaux { get => lesMorceaux; set => lesMorceaux = value; }
    }
}
