﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;

namespace EmployeeManagementSystem.Behaviours
{
    class PieSeries:System.Windows.Controls.DataVisualization.Charting.PieSeries
    {
        protected override DataPoint CreateDataPoint()
        {
            return new PieDataPoint();
           
        }
    }
}
