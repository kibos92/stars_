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
using stars.wpf.Controls;
using stars.wpf.Views;

namespace stars.wpf.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action CloseAction { get; set; }
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
                MessageBox.Show("Zalogowano!");
                MainWindow main = new MainWindow();
                main.Show();
                main.DataContext = new MainWindowViewModel();
                CloseAction();
            }

            else
            {
                MessageBox.Show("Zły login albo hasło!");
            }
        }

        public void CreateLogin(object ojb)
        {
            User user = UsersRepository.FindUserByLogin(LoginVm);

            if (user == null)
            {
                UsersRepository.Add(new User() { Login = LoginVm, Password = PasswordVm });
                MessageBox.Show("Rejestracja udana!");
            }
            else
            {
                MessageBox.Show("Konto już istnieje!");
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(CheckLogin);
            RegisterCommand = new RelayCommand(CreateLogin);
        }
    }
}