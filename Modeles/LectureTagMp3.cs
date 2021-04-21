using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfLecteurAudio.Modeles
{
    class LectureTagMp3
    {
        private static byte idTagLenght = 3;
        private static byte titreTagLenght = 30;
        private static byte artisteTagLenght = 30;
        private static byte albumTagLenght = 30;
        private static byte anneeTagLenght = 4;
        private static byte commentTagLenght = 30;
        private static byte genreTagLenght = 1;

        public byte[] Id = new byte[idTagLenght];
        public byte[] Title = new byte[titreTagLenght];
        public byte[] Artist = new byte[artisteTagLenght];
        public byte[] Album = new byte[albumTagLenght];
        public byte[] Year = new byte[anneeTagLenght];
        public byte[] Comment = new byte[commentTagLenght];
        public byte[] Genre = new byte[genreTagLenght];


        public bool TagId3()
        {
            if (Encoding.Default.GetString(Id).Equals("TAG"))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder tag = new StringBuilder();

            tag.AppendLine(Encoding.Default.GetString(Id));
            tag.AppendLine(Encoding.Default.GetString(Title));
            tag.AppendLine(Encoding.Default.GetString(Artist));
            tag.AppendLine(Encoding.Default.GetString(Album));
            tag.AppendLine(Encoding.Default.GetString(Year));
            tag.AppendLine(Encoding.Default.GetString(Comment));
            tag.AppendLine(Encoding.Default.GetString(Genre));

            return tag.ToString();
        }
        public  string titleToString()
        {
            StringBuilder tag = new StringBuilder();

            tag.AppendLine(Encoding.Default.GetString(Title));

            return tag.ToString();
        }
        public string artistToString()
        {
            StringBuilder tag = new StringBuilder();

            tag.AppendLine(Encoding.Default.GetString(Artist));

            return tag.ToString();
        }
        public string albumToString()
        {
            StringBuilder tag = new StringBuilder();

            tag.AppendLine(Encoding.Default.GetString(Album));

            return tag.ToString();
        }

    }
}
