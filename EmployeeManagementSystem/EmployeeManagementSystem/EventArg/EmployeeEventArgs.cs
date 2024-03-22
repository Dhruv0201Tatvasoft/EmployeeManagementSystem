using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.EventArg
{
    internal class EmployeeEventArgs:EventArgs
    {
        public EmployeeModel emp { get; }
        public EmployeeEventArgs(EmployeeModel emp)
        {
            this.emp = emp;
        }
    }
}
