using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BuildingsViewModel : ViewModelBase
    {
        public int CurrentStock { set; get; }
        public int CurrentBuilding { set; get; }
        public int CurrentReq { set; get; }

        public UserRepository UsersRepository = new(new AppDbContext());
        public ICommand BuildCommand { set; get; }

        public BuildingsViewModel()
        {
            CurrentStock = LoginView.currentUser.Stock;
            CurrentBuilding = LoginView.currentUser.Building;
            CurrentReq = LoginView.currentUser.ReqBuild;
            BuildCommand = new RelayCommand(BuildingUp);
        }

        public void BuildingUp(object obj)
        {
            if (CurrentStock >= CurrentReq)
            {
                CurrentBuilding++;
                CurrentStock = CurrentStock - CurrentReq;
                CurrentReq = CurrentBuilding + 10 + CurrentBuilding * 2;
                User updateUser = LoginView.currentUser;
                updateUser.Building = CurrentBuilding;
                updateUser.ReqBuild = CurrentReq;
                updateUser.Stock = CurrentStock;
                UsersRepository.Update(updateUser);
            }
            else
            {
                MessageBox.Show("Za mało surowców!");
            }
        }
    }
}
