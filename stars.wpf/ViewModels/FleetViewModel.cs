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
        public int CurrentFleet { set; get; }
        public UserRepository UsersRepository = new(new AppDbContext());
        public ICommand BuyShipCommand { set; get; }

        public FleetViewModel()
        {
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
