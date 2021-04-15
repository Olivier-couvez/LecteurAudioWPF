using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLecteurAudio
{
    class LecteurMp3 : ILecteurAudio
    {

        bool ILecteurAudio.LectureEnCours => throw new NotImplementedException();

        bool ILecteurAudio.EstEnPause => throw new NotImplementedException();

        void ILecteurAudio.Lire(string cheminFichier)
        {
            throw new NotImplementedException();
        }

        void ILecteurAudio.Pause()
        {
            throw new NotImplementedException();
        }

        void ILecteurAudio.ReprendreLecture()
        {
            throw new NotImplementedException();
        }

        void ILecteurAudio.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
