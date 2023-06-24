using BibliothequeMusicale;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace BibliothequeMusicale
{
    // Classe NON-GRAPHIQUE.

    public class AlbumViewModel : ViewModelBase
    {
        private string _compositeur;
        private string _album;
        private string _albumimg;
        private ObservableCollection<PisteViewModel> _pistes;
        private PisteViewModel _nouvelpiste;
        private PisteViewModel? _pisteselection;


        public AlbumViewModel()
        {
            _compositeur = "";
            _album = "";
            _albumimg = "";
            _pistes = new ObservableCollection<PisteViewModel>();
            _nouvelpiste = new PisteViewModel() { Piste = "Première musique" };
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


        public PisteViewModel Nouvelpiste
        {
            get { return _nouvelpiste; }
        }

        public ICommand AjouterPisteCommandFenetre
        {
            get { return new RelayCommand(AjouterPisteFenetre); }
        }

        public void AjouterPisteFenetre()
        {
            if (_nouvelpiste.Piste == "")
            {
                return;
            }

            _nouvelpiste.NumPiste = Pistes.Count + 1;
            Pistes.Add(_nouvelpiste);
            _nouvelpiste = new PisteViewModel();
            OnPropertyChanged(nameof(Nouvelpiste));
        }

        public ICommand SupprimerPisteCommandFenetre
        {
            get { return new RelayCommand(SupprimerPisteFenetre); }
        }

        public PisteViewModel? Pisteselection
        {
            get { return _pisteselection; }
            set
            {
                _pisteselection = value;
                OnPropertyChanged(nameof(Pisteselection));
            }
        }

        public void SupprimerPisteFenetre()
        {
            if (_pisteselection != null)
            {
                Pistes.Remove(_pisteselection);
                for (int i = 0; i < Pistes.Count; i++)
                {
                    Pistes[i].NumPiste = i + 1;
                }
                Pisteselection = null;
            }
        }
    }
}
