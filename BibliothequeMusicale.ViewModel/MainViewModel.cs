using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace BibliothequeMusicale
{
    public interface IMainView
    {
        void Fenetre(AlbumViewModel? Selection);
    }

    public class MainViewModel : ViewModelBase
    {
        private readonly IMainView _view;
        private readonly ObservableCollection<AlbumViewModel> _albums;
        private readonly ObservableCollection<PisteViewModel> _pistes;
        private AlbumViewModel _nouveau;
        private AlbumViewModel? _selection;
        private PisteViewModel _nouvelpiste;
        private PisteViewModel? _pisteselection;

        public MainViewModel(IMainView view)
        {
            _view = view;
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
            get { return new ReadOnlyObservableCollection<PisteViewModel>(_pistes); }
        }

        public ReadOnlyObservableCollection<AlbumViewModel> Albums
        {
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

        public ICommand SupprimerPisteCommand
        {
            get { return new RelayCommand(SupprimerPiste); }
        }

        public void SupprimerPiste()
        {
            if (_selection != null && _pisteselection != null)
            {
                _selection.Pistes.Remove(_pisteselection);
                Pisteselection = null;
            }
        }

        public ICommand OuvrirFenetreCommand
        {
            get { return new RelayCommand(OuvrirFenetre); }
        }

        public void OuvrirFenetre()
        {
            if (Selection != null)
            {
                _view.Fenetre(Selection);
            }
        }
    }
}