using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using stars.database;
using stars.database.entities;
using stars.database.repositories;
using stars.wpf.Commands;
using stars.wpf.Views;

namespace stars.wpf.ViewModels
{
    public class FleetViewModel : ViewModelBase
    {
        public string CurrentLogin { set; get; }
        public int CurrentStock { set; get; }
        public int CurrentBuilding { set; get; }
        public int CurrentFleet { set; get; }

        public UserRepository UsersRepository = new(new AppDbContext());
        public ICommand BuyShipCommand { set; get; }

        public FleetViewModel()
        {
            CurrentLogin = LoginView.currentUser.Login;
            CurrentStock = LoginView.currentUser.Stock;
            CurrentBuilding = LoginView.currentUser.Building;
            CurrentFleet = LoginView.currentUser.Fleet;

            BuyShipCommand = new RelayCommand(FleetUp);

        }
        public void FleetUp(object obj)
        {
            CurrentFleet++;
            User updateUser = LoginView.currentUser;
            updateUser.Fleet = CurrentFleet;
            UsersRepository.Update(updateUser);
        }
    }
}
