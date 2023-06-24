using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMusicale
{
    public class PisteViewModel : ViewModelBase
    {
        private string _piste;
        //private string _pisteFenetre;
        private int _numPiste;

        public PisteViewModel()
        {
            _piste = "";
           // _pisteFenetre = "";
        }

        public string Piste
        {
            get { return _piste; }
            set
            {
                _piste = value;

                // nameof traduit un identificateur (ici le nom d'une propriété) en string
                OnPropertyChanged(nameof(Piste), nameof(_piste));
            }
        }

        /*public string PisteFenetre
        {
            get { return _pisteFenetre; }
            set
            {
                _pisteFenetre = value;

                // nameof traduit un identificateur (ici le nom d'une propriété) en string
                OnPropertyChanged(nameof(PisteFenetre), nameof(_pisteFenetre));
            }
        }*/
        public int NumPiste
        {
            get { return _numPiste; }
            set
            {
                _numPiste = value;
                OnPropertyChanged(nameof(NumPiste));
            }
        }

        public override string ToString()
        {
            return _piste;
        }
    }
}
