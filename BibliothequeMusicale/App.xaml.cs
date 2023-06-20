using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BibliothequeMusicale
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IMainView
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Remplace StartupUri="MainWindow.xaml" dans le source XAML :
            //
            MainWindow w = new MainWindow();
            w.DataContext = new MainViewModel(this); 
            w.Show();
        }

        public void Fenetre(AlbumViewModel? selection)
        {
            FenetreAlbum fenetre = new FenetreAlbum(selection);
            fenetre.Show();
        }
    }
}
