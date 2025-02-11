using ArcGIS.Desktop.Framework.Dialogs;

namespace Winemonk.ArcGIS.Framework.Samples.Services
{
    [RegisterService(typeof(ISampleService))]
    public class SampleService : ISampleService
    {
        public void HelloWorld()
        {
            MessageBox.Show("Hello World!", "Hello");
        }
    }
}
