using System.Collections.Generic;
using pwiforms2.Models;

namespace PwiForms.ViewModels
{
    public class PositionListViewModel
    {
        public string StationName { get; set; }
        public List<MeasurementPosition> Positions { get; set; }
        public List<string> PositionValuse { get; set; }
        public string AirIndex { get; set; }
    }
}