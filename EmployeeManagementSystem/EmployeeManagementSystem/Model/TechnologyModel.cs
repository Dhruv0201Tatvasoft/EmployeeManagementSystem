using System.ComponentModel;

namespace EmployeeManagementSystem.Model
{
    internal class TechnologyModel:INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; 
            OnPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
         
        }
        private bool isSelected;
        public bool IsSelected
        {
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
