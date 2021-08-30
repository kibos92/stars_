using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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
        public HomeViewModel()
        {
            CurrentLogin = LoginView.currentUser.Login;
            CurrentStock = LoginView.currentUser.Stock;
            CurrentBuilding = LoginView.currentUser.Building;
            CurrentFleet = LoginView.currentUser.Fleet;
        }
    }
}

