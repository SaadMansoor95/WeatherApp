using System;
using System.Windows.Input;
using WeatherApp.View;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel _weatherViewModel { get; set; }

        //This event will fire on query change.
        public event EventHandler? CanExecuteChanged;

        public SearchCommand(WeatherViewModel weatherViewModel)
        {
            _weatherViewModel = weatherViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _weatherViewModel.MakeQuery();
        }
    }
}
