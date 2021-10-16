using System;
using System.Collections.Generic;
using System.Text;

namespace LttFlow.MeterReading.Dto
{
    public class ChartGroupDto
    {
        public string GroupName { get; set; }

        public decimal Value { get; set; }

        public string Date { get; set; }
    }
}
