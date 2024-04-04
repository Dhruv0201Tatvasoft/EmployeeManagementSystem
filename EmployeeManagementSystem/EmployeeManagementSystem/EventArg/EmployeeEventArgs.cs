using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.EventArg
{
    internal class EmployeeEventArgs:EventArgs
    {
        public EmployeeModel Employee { get; }
        public EmployeeEventArgs(EmployeeModel emp)
        {
            this.Employee = emp;
        }
    }
}
