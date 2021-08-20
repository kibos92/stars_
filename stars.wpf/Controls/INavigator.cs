using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using stars.wpf.ViewModels;

namespace stars.wpf.Controls
{
    public enum ViewType
    {
        Home,
        Buildings,
        Fleet,
        Adventure,
        Login
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }

    }
}
