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
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if(CurrentFleet > 0)
            {
                if (randomNumber < 20)
            {
                MessageBox.Show("Natrafiłeś na rój asteroid, tracisz 10 statków");

                if (CurrentFleet >= 10)
                {
                    CurrentFleet = CurrentFleet - 10;
                }
                else
                {
                    CurrentFleet = 0;
                }
                User updateUser = LoginView.currentUser;
                updateUser.Fleet = CurrentFleet;
                UsersRepository.Update(updateUser);
            }

            else if (randomNumber is >= 20 and < 60)
            {
                MessageBox.Show("Pusta przestrzeń");
            }

            else if (randomNumber is >=60 and > 70)
            {
                MessageBox.Show("Natrafiłeś na kosmicznych piratów - Przygotuj się do walki!");
                Random randomEnemy = new Random();
                int randomEnemyFleet = randomEnemy.Next(0, 21);

                if (randomEnemyFleet > CurrentFleet)
                {
                    MessageBox.Show("Przegrałeś! Tracisz wszystkie statki");
                    CurrentFleet = 0;
                }

                else if (randomEnemyFleet == CurrentFleet)
                {
                    MessageBox.Show("Bitwa nierozstrzygnięta! Udało Ci się uciec ale tracisz 5 statków");

                    if (CurrentFleet >= 5)
                    {
                        CurrentFleet = CurrentFleet - 5;
                    }
                    else
                    {
                        CurrentFleet = 0;
                    }

                    User updateUser = LoginView.currentUser;
                    updateUser.Fleet = CurrentFleet;
                    UsersRepository.Update(updateUser);
                }

                else
                {
                    MessageBox.Show("Wygrałeś! Piraci zostali rozbici");
                }
            }

            else
            {
                MessageBox.Show("Trafiłeś na ruiny opuszczonej stacji kosmicznej! dostajesz 100 sztuk stali");
                CurrentStock = CurrentStock + 100;
                User updateUser = LoginView.currentUser;
                updateUser.Stock = CurrentStock;
                UsersRepository.Update(updateUser);
            }

            }

            else
            {
                MessageBox.Show("Nie masz floty!");
            }

        }
    }
}
