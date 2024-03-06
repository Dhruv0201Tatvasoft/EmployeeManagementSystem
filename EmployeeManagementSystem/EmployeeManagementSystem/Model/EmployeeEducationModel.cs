using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    internal class EmployeeEducationModel:INotifyPropertyChanged
    {

		private string qualification;

		public string Qualification
		{
			get { return qualification; }
			set { qualification = value; OnPropertyChanged("Qualification"); }
		}
		private string boardUniversity;

		public string BoardUniversity
		{
			get { return boardUniversity; }
			set { boardUniversity = value; OnPropertyChanged("BoardUniversity"); }
		}
		private string instituteName;

		public string InstituteName
		{
			get { return instituteName; }
			set { instituteName = value; OnPropertyChanged("InstituteName"); }
		}
		private string state;

		public string State
		{
			get { return state; }
			set { state = value; OnPropertyChanged("State"); }
		}
		private string passingYear;

		public string PassingYear
		{
			get { return passingYear; }
			set { passingYear = value; OnPropertyChanged("PassingYear"); }
		}
		private string percentage;


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
