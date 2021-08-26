using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using stars.database.entities;
using stars.wpf.Views;

namespace stars.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string CurrentLogin { set; get; }
        public HomeViewModel()
        {
            CurrentLogin = LoginView.currentUser.Login;
        }
    }
}

