using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASPNET_SmartCity_MathiasThomassen_201706287.Models
{
    public class Sensor
    {
        
        public string SensorId { get; set; }
        public int LocationId { get; set; }
        public string TreeSort { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
