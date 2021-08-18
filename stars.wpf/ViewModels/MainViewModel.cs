using stars.database.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using stars.database;
using stars.database.entities;
using stars.wpf.Commands;

namespace stars.wpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string LoginVm { set; get; }
        public string PasswordVm { set; get; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserRepository UsersRepository = new(new AppDbContext());

        public void CheckLogin(object obj)
        {
            User user = UsersRepository.GetByLoginAndPassword(LoginVm, PasswordVm);

            if (user != null)
            {
                MessageBox.Show("zalogowano");
            }

            else
            {
                MessageBox.Show("nie zalogowano");
                UsersRepository.Add(new User() {Login = LoginVm, Password = PasswordVm});
            }
        }

        public ICommand LoginCommand { get; set; }

        public MainViewModel()
        {
            LoginCommand = new RelayCommand(CheckLogin);
        }
    }
}
