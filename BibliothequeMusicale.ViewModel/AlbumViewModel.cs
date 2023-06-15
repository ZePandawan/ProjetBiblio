using BibliothequeMusicale;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeMusicale
{
    // Classe NON-GRAPHIQUE.

    public class AlbumViewModel : ViewModelBase
    {
        private string _compositeur;
        private string _album;
        private string _albumimg;

        public AlbumViewModel()
        {
            _compositeur = "";
            _album = "";
            _albumimg = "";
        }

        public override string ToString()
        {
            return CompoAlbum;
        }

        public string Compositeur
        {
            get { return _compositeur; }
            set
            {
                _compositeur = value;

                // nameof traduit un identificateur (ici le nom d'une propriété) en string
                OnPropertyChanged(nameof(Compositeur), nameof(CompoAlbum));
            }
        }

        public string Album
        {
            get { return _album; }
            set
            {
                _album = value;
                OnPropertyChanged(nameof(Album), nameof(CompoAlbum));
            }
        }

        public string Albumimg
        {
            get { return _albumimg; }
            set
            {
                _albumimg = value;

                // nameof traduit un identificateur (ici le nom d'une propriété) en string
                OnPropertyChanged(nameof(Albumimg));
            }
        }

        public string CompoAlbum
        {
            get { return $"{_compositeur}\n{_album}"; }
        }


    }
}
