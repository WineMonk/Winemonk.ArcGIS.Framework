using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using DryIoc.Messages;
using DryIoc;
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
            IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("samplesettings.json", false, true)
                    .Build();
            string sampleSettings = typeof(SampleSettings).Name;
            string subSampleSettings = typeof(SubSampleSettings).Name;
            GisApp.App()
                .Configure<SampleSettings>(configuration.GetSection(sampleSettings))
                .Configure<SubSampleSettings>(configuration.GetSection($"{sampleSettings}:{subSampleSettings}"));
            GisApp.App().Container
                .Register(typeof(IMessageHandler<,>),
                          typeof(MiddlewareMessageHandler<,>),
                          setup: Setup.Decorator);
        }
    }
}
