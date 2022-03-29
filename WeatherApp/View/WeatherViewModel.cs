using System.ComponentModel;
using System.Windows;
using WeatherApp.Model;

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
            }
        }

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
                            Value = 17
                        }
                    }
                };
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
