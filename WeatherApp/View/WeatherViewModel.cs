using System.ComponentModel;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
