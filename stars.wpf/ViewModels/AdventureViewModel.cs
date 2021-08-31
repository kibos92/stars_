using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using stars.database;
using stars.database.repositories;
using stars.wpf.Commands;
using stars.wpf.Views;

namespace stars.wpf.ViewModels
{
    public class AdventureViewModel : ViewModelBase
    {
        public string CurrentLogin { set; get; }
        public int CurrentStock { set; get; }
        public int CurrentBuilding { set; get; }
        public int CurrentFleet { set; get; }

        public UserRepository UsersRepository = new(new AppDbContext());

        public ICommand ActionCommand { set; get; }

        public AdventureViewModel()
        {
            CurrentLogin = LoginView.currentUser.Login;
            CurrentStock = LoginView.currentUser.Stock;
            CurrentBuilding = LoginView.currentUser.Building;
            CurrentFleet = LoginView.currentUser.Fleet;

            ActionCommand = new RelayCommand(Action);
        }

        public void Action(object obj)
        {

        }
    }
}
