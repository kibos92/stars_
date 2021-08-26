using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stars.wpf.Controls;

namespace stars.wpf.ViewModels
{
    public class MainWindowViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainWindowViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
