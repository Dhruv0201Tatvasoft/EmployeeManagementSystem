using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementSystem.Models
{
  public class ProjectModel:INotifyPropertyChanged
    {
        private string code;
        public string Code
        {
            get { return code; }
            set { code = value; OnPropertyChanged("Code"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {  name = value; OnPropertyChanged("Name"); }
        }

        private DateTime startingDate;
        public DateTime StartingDate
        {
            get { return startingDate; }
            set { startingDate = value; OnPropertyChanged("StartingDate"); }
        }

        private DateTime? endingDate;
        public DateTime? EndingDate
        {
            get { return endingDate; }
            set { endingDate = value; OnPropertyChanged("EndingDate"); }
        }
        private List<int> associatedTechnologies;
        public List<int> AssociatedTechnologies
        {
            get { return associatedTechnologies; }
            set { associatedTechnologies = value; OnPropertyChanged("AssociatedTechnologies"); }
        }
        private List<EmployeeModel> associatedEmployees;
        public List<EmployeeModel> AssociatedEmployees
        {
            get
            {
                return associatedEmployees;
            }
            set
            {
                associatedEmployees = value;
                OnPropertyChanged("AssociatedEmployees");
            }
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
