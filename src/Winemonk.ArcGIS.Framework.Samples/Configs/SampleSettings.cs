using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winemonk.ArcGIS.Framework.Samples.Configs
{
    public class SampleSettings
    {
        public string Value1 { get; set; }
        public int Value2 { get; set; }
        public double Value3 { get; set; }
        public string[] Value4 { get; set; }
        public SubSampleSettings SubSampleSettings { get; set; }
    }
}
