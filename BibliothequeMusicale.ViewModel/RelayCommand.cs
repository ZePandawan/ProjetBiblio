using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BibliothequeMusicale
{
    // ICommand représente une opération de l'application, lancée par un bouton, un menu...
    public class RelayCommand : ICommand // Représente une action reconnue par WPF
                                         // (par exemple suite au clic sur un bouton)
    {
        private readonly Action _action; // Représente une méthode void().

        public RelayCommand(Action action)
        {
            _action = action;
        }

        // En spécifiant add et remove, aucune liste de méthodes EventHandler n'est ajoutée à la classe.
        public event EventHandler? CanExecuteChanged
        {
            add { } // Méthode appelée lors de l'abonnement (+=)
            remove { } // Méthode appelée lors du désabonnement (-=)
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
