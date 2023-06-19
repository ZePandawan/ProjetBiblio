using BibliothequeMusicale;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BibliothequeMusicale
{
    // Classe NON-GRAPHIQUE.

    public class AlbumViewModel : ViewModelBase
    {
        private string _compositeur;
        private string _album;
        private string _albumimg;
        private ObservableCollection<PisteViewModel> _pistes;

        public AlbumViewModel()
        {
            _compositeur = "";
            _album = "";
            _albumimg = "";
            _pistes = new ObservableCollection<PisteViewModel>();
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

        public ObservableCollection<PisteViewModel> Pistes
        {
            get { return _pistes; }
            set
            {
                _pistes = value;
                OnPropertyChanged(nameof(Pistes));
            }
        }

        

        /*public void AjouterPiste(PisteViewModel piste)
        {
            // Vérifiez si la piste n'existe pas déjà dans la collection
            if (!_pistes.Contains(piste))
            {
                _pistes.Add(piste);
            }
            
        }
        */
    }
}
