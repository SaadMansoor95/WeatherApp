using System;
using System.Windows.Input;
using WeatherApp.View;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel WeatherViewModel { get; set; }

        //This event will fire on query change.
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public SearchCommand(WeatherViewModel weatherViewModel)
        {
            WeatherViewModel = weatherViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            //Every time query parameter changes it fires
            //OnPropertyChange(nameof(Query)) which in turn fire CanExecute
            var query = parameter as string;

            return !string.IsNullOrWhiteSpace(query);
        }

        public void Execute(object? parameter)
        {
            WeatherViewModel.MakeQuery();
        }
    }
}