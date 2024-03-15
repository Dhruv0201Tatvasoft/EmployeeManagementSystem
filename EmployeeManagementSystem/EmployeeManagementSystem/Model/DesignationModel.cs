using System.ComponentModel;

namespace EmployeeManagementSystem.Models
{
    public class DesignationModel:INotifyPropertyChanged
    {
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
    
