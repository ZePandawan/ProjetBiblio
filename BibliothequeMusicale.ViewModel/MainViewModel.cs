using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace BibliothequeMusicale
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AlbumViewModel> _albums; // = List<...> + émission d'un évènement à chaque modification
        private readonly ObservableCollection<PisteViewModel> _pistes;
        private AlbumViewModel _nouveau;
        private AlbumViewModel? _selection;
        private PisteViewModel _nouvelpiste;
        private PisteViewModel? _pisteselection;

        public MainViewModel()
        {
            _nouveau = new AlbumViewModel() { Compositeur = "Ziak", Album = "CHROME", Albumimg = "" };
            _albums = new ObservableCollection<AlbumViewModel>();
            _nouvelpiste = new PisteViewModel() { Piste = "Première musique" };
            _pistes = new ObservableCollection<PisteViewModel>();
        }

        public AlbumViewModel Nouveau
        {
            get { return _nouveau; }
        }

        public PisteViewModel Nouvelpiste
        {
            get { return _nouvelpiste; }
        }

        public ReadOnlyObservableCollection<PisteViewModel> Pistes
        {
            // Depuis l'extérieur, cette collection n'est pas modifiable.
            get { return new ReadOnlyObservableCollection<PisteViewModel>(_pistes); }
        }
        public ReadOnlyObservableCollection<AlbumViewModel> Albums
        {
            // Depuis l'extérieur, cette collection n'est pas modifiable.
            get { return new ReadOnlyObservableCollection<AlbumViewModel>(_albums); }
        }

        public ICommand AjouterAlbumCommand
        {
            get { return new RelayCommand(Ajouter); }
        }

        public void Ajouter()
        {
            
            if (_nouveau.Album == "" && _nouveau.Compositeur == "")
            {
                return;
            }
            if (_nouveau.Albumimg == "")
            {
                _nouveau.Albumimg = "https://community.spotify.com/t5/image/serverpage/image-id/25294i2836BD1C1A31BDF2?v=v2";
            }

            _albums.Add(_nouveau);

            _nouveau = new AlbumViewModel();
            OnPropertyChanged(nameof(Nouveau));
        }


        public AlbumViewModel? Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                OnPropertyChanged(nameof(Selection));
            }
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

        public ICommand SupprimerAlbumCommand
        {
            get { return new RelayCommand(Supprimer); }
        }

        public void Supprimer()
        {
            if (_selection != null)
            {
                _albums.Remove(_selection);

                // Après suppression, vide la sélection.
                Selection = null;
            }
        }
        public ICommand AjouterPisteCommand
        {
            get { return new RelayCommand(AjouterPiste); }
        }

        public void AjouterPiste()
        {
            if (_nouvelpiste.Piste == "")
            {
                return;
            }
            if (_selection != null)
            {
                _selection.Pistes.Add(_nouvelpiste);
                _nouvelpiste = new PisteViewModel();
                OnPropertyChanged(nameof(Nouvelpiste));
            }
        }

        // Méthode pour supprimer une piste de l'album sélectionné
        public ICommand SupprimerPisteCommand
        {
            get { return new RelayCommand(SupprimerPiste); }
        }

        public void SupprimerPiste()
        {
            if (_selection != null && _pisteselection != null)
            {
                _selection.Pistes.Remove(_pisteselection);

                // Après suppression, vide la sélection.
                Pisteselection = null;
            }
        }

    }
}