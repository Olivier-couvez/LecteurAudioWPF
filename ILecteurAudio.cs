using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLecteurAudio
{
    public interface ILecteurAudio
    {
        bool LectureEnCours { get; }
        bool EstEnPause { get; }
        void Lire(string cheminFichier);
        void Pause();
        void ReprendreLecture();
        void Stop();

    }
}
