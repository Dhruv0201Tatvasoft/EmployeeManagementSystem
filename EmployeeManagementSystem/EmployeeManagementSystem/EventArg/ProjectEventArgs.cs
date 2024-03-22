using EmployeeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.EventArg
{
    internal class ProjectEventArgs:EventArgs
    {
        public ProjectModel project { get; }
        public ProjectEventArgs(ProjectModel project)
        {
            this.project = project;
        }
    }
}
