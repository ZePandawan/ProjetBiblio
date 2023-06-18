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

        public PisteViewModel()
        {
            _piste = "";
        }

        public string Piste
        {
            get { return _piste; }
            set
            {
                _piste = value;

                // nameof traduit un identificateur (ici le nom d'une propriété) en string
                OnPropertyChanged(nameof(Piste));
            }
        }
    }
}
