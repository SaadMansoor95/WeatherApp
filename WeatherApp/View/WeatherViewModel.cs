using System.ComponentModel;

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
                OnPropertyChange(query); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
