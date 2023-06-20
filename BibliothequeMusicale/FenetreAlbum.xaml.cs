using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliothequeMusicale;


namespace BibliothequeMusicale
{
    /// <summary>
    /// Logique d'interaction pour FenetreAlbum.xaml
    /// </summary>
    public partial class FenetreAlbum : Window
    {
        private readonly AlbumViewModel _album;

        public FenetreAlbum(AlbumViewModel album)
        {
            InitializeComponent();

            _album = album;

            // Utilisez l'objet _album pour les liaisons de données dans la fenêtre.
            DataContext = _album;
        }
    }
}
