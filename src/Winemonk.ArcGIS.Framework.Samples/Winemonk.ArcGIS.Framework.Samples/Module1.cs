using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using Microsoft.Extensions.Configuration;
using Winemonk.ArcGIS.Framework.Samples.Configs;

namespace Winemonk.ArcGIS.Framework.Samples
{
    internal class Module1 : Module, IRegistrable
    {
        private static Module1 _this = null;

        public static Module1 Current => _this ??= (Module1)FrameworkApplication.FindModule("Winemonk_ArcGIS_Framework_Samples_Module");

        public Module1()
        {
            this.RegisterService();
            GisApp.App().Configure<SampleSettings>(
                new ConfigurationBuilder()
                    .AddJsonFile("samplesettings.json", false, true)
                    .Build()
                    .GetSection(typeof(SampleSettings).Name)
                );
        }
    }
}
