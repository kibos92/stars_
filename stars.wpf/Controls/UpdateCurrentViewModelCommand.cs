using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using stars.wpf.ViewModels;

namespace stars.wpf.Controls
{
   public class UpdateCurrentViewModelCommand : ICommand
   {
       public event EventHandler CanExecuteChanged;

       private INavigator _navigator;

       public UpdateCurrentViewModelCommand(INavigator navigator)
       {
           _navigator = navigator;
       }
       public bool CanExecute(object parameter)
       {
           return true;
       }
       public void Execute(object parameter)
       {
           if (parameter is ViewType)
           {
               ViewType viewType = (ViewType) parameter;

               switch (viewType)
               {
                    case ViewType.Login:
                        _navigator.CurrentViewModel = new LoginViewModel();
                        break;
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Buildings:
                        _navigator.CurrentViewModel = new BuildingsViewModel();
                        break;
                    case ViewType.Fleet:
                        _navigator.CurrentViewModel = new FleetViewModel();
                        break;
                    case ViewType.Adventure:
                        _navigator.CurrentViewModel = new AdventureViewModel();
                        break;
               }
           }
       }
   }
}
