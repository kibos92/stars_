using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Accessibility;
using stars.database;
using stars.database.entities;
using stars.database.repositories;
using stars.wpf.Commands;
using stars.wpf.Views;

namespace stars.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string CurrentLogin { set; get; }
        public int CurrentStock { set; get; }
        public int CurrentBuilding { set; get; }
        public int CurrentFleet { set; get; }

        public UserRepository UsersRepository = new(new AppDbContext());

        public HomeViewModel()
        {
            CurrentLogin = LoginView.currentUser.Login;
            CurrentStock = LoginView.currentUser.Stock;
            CurrentBuilding = LoginView.currentUser.Building;
            CurrentFleet = LoginView.currentUser.Fleet;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CurrentStock = CurrentBuilding + CurrentStock;
            User updateUser = LoginView.currentUser;
            updateUser.Stock = CurrentStock;
            UsersRepository.Update(updateUser);
        }
    }
}

