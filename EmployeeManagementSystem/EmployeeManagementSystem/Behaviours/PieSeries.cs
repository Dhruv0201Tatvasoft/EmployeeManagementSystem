using System.Windows.Controls.DataVisualization.Charting;

namespace EmployeeManagementSystem.Behaviours
{
    class PieSeries:System.Windows.Controls.DataVisualization.Charting.PieSeries
    {
        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        protected override DataPoint CreateDataPoint()
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            return new PieDataPoint();
           
        }
    }
}
