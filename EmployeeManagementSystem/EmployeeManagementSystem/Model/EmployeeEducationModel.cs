using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    public class EmployeeEducationModel : INotifyPropertyChanged
    {

        private string qualification = string.Empty;

        public string Qualification
        {
            get { return qualification; }
            set { qualification = value; OnPropertyChanged("Qualification"); }
        }
        private string boardUniversity = string.Empty;

        public string BoardUniversity
        {
            get { return boardUniversity; }
            set { boardUniversity = value; OnPropertyChanged("BoardUniversity"); }
        }
        private string instituteName = string.Empty;

        public string InstituteName
        {
            get { return instituteName; }
            set { instituteName = value; OnPropertyChanged("InstituteName"); }
        }
        private string state = string.Empty;

        public string State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }
        private string passingYear = string.Empty;

        public string PassingYear
        {
            get { return passingYear; }
            set { passingYear = value; OnPropertyChanged("PassingYear"); }
        }
        private string percentage = string.Empty;


        public string Percentage
        {
            get { return percentage; }
            set { percentage = value; OnPropertyChanged("Percentage"); }
        }

      

        

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
