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
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChange(nameof(Query));
                //OnPropertyChange("Query");
            }
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentCondition
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChange(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChange(nameof(SelectedCity));
                GetCurrentCondition();
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        public SearchCommand _searchCommand { get; set; }

        public WeatherViewModel()
        {
            //This line is to show data in design mode only
            //data will not be displayed when in running mode
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York",
                };

                CurrentCondition = new CurrentConditions
                {
                    WeatherText = "Partly Cloudy",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "17"
                        }
                    }
                };
            }

            //passing current WeatherViewModel to SearchCommand
            _searchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        public async void MakeQuery()
        {
            var cities = await AccWeatherHelper.GetCities(query);

            Cities.Clear();

            foreach (var item in cities)
                Cities.Add(item);
        }


        private async void GetCurrentCondition()
        {

            //Query = string.Empty;

            //if (Cities != null && Cities.Count > 0)
            //Cities.Clear();

            //if (selectedCity != null)
            CurrentCondition = await AccWeatherHelper.GetConditions(selectedCity.Key);

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
