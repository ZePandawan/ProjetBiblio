﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BibliothequeMusicale
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AlbumViewModel> _albums; // = List<...> + émission d'un évènement à chaque modification

        private AlbumViewModel _nouveau;
        private AlbumViewModel? _selection;

        public MainViewModel()
        {

            _nouveau = new AlbumViewModel() { Compositeur = "Ziak", Album = "CHROME" };
            _albums = new ObservableCollection<AlbumViewModel>();

        }

        public AlbumViewModel Nouveau
        {
            get { return _nouveau; }
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
            if (_nouveau.Album == "" && _nouveau.Compositeur == "") return;

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
    }
}