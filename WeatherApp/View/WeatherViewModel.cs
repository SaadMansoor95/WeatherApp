using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.View
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions? _currrentConditions;

        public CurrentConditions? CurrrentConditions
        {
            get => _currrentConditions;
            set
            {
                _currrentConditions = value;
                OnPropertyChanged(nameof(CurrrentConditions));
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
                GetCurrentConditions();
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public WeatherViewModel()
        {
            /*
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };
                CurrrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly cloudy",
                    HasPrecipitation = true,
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "21"
                        }
                    }
                };
            }
            */
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();

            CurrrentConditions = await AccWeatherHelper.GetConditions(SelectedCity.Key);
        }

        public async void MakeQuery()
        {
            var cities = await AccWeatherHelper.GetCities(Query);

            Cities.Clear();

            if (cities == null) return;
            foreach (var city in cities)
                Cities.Add(city);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}