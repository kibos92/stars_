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
using stars.database;
using stars.database.entities;

namespace stars.wpf.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public UserRepository UsersRepository = new UserRepository(new AppDbContext());
        public void LoginUser(string username, string password)
        {
            var checkUser = (UsersRepository.GetByLoginAndPassword(username, password));

            if (checkUser != null)
            {

            }

            else
            {
                UsersRepository.Add(new User(){Login = username, Password = password});
            }
        }
    }
}
