using System;
using System.Windows.Input;
using WeatherApp.View;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel _weatherViewModel { get; set; }

        //This event will fire on query change.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(WeatherViewModel weatherViewModel)
        {
            _weatherViewModel = weatherViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            //Everytime query parameter changes it fires
            //OnPropertyChange(nameof(Query)) which in turn fire CanExecute
            string query = parameter as string;

            if (string.IsNullOrWhiteSpace(query))
                return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            _weatherViewModel.MakeQuery();
        }
    }
}
