using System.Linq;

namespace BibliothequeMusicale
{
    public interface IMainView
    {
        
    }

    public class MainViewModel : ViewModelBase
    {
        private readonly IMainView _view;



        public MainViewModel(IMainView view)
        {

        }


    }
}