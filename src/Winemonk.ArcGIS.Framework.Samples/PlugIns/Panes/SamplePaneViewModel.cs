using System.Text.Json;
using System.Windows.Input;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Dialogs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Winemonk.ArcGIS.Framework.Samples.Configs;
using Winemonk.ArcGIS.Framework.Samples.Services;

namespace Winemonk.ArcGIS.Framework.Samples.PlugIns.Panes
{
    internal class SamplePaneViewModel : ViewStatePane, IInjectable
    {
        private const string _viewPaneID = "Winemonk_ArcGIS_Framework_Samples_PlugIns_Panes_SamplePane";

        [InjectService]
        private readonly IOptionsMonitor<SampleSettings> _optionsMonitor1;
        [InjectService]
        private readonly IOptionsMonitor<SubSampleSettings> _optionsMonitor2;
        [InjectService]
        private readonly ILogger _logger1;
        [InjectService]
        private readonly ILogger<SamplePaneViewModel> _logger2;
        [InjectService]
        private readonly TestLogService _testLogService;
        [InjectService]
        private readonly ISampleService _sampleService;

        public SamplePaneViewModel(CIMView view) : base(view)
        {
            this.InjectService();
            _optionsMonitor1.OnChange(settings =>
            {
                string json = JsonSerializer.Serialize(_optionsMonitor1.CurrentValue);
                FrameworkApplication.AddNotification(new Notification
                {
                    Title = "SampleSettings Changed!",
                    Message = json
                });
            });
        }

        public ICommand TestLogCommand => new RelayCommand(() =>
        {
            _logger1?.LogTrace("Default Logger LogTrace");
            _logger1?.LogDebug("Default Logger LogDebug");
            _logger1?.LogInformation("Default Logger LogInformation");
            _logger1?.LogWarning("Default Logger LogWarning");
            _logger1?.LogError("Default Logger LogError");
            _logger1?.LogCritical("Default Logger LogCritical");

            _logger2?.LogTrace("Not configured Logger Class LogTrace");
            _logger2?.LogDebug("Not configured Logger Class LogDebug");
            _logger2?.LogInformation("Not configured Logger Class LogInformation");
            _logger2?.LogWarning("Not configured Logger Class LogWarning");
            _logger2?.LogError("Not configured Logger Class LogError");
            _logger2?.LogCritical("Not configured Logger Class LogCritical");

            _testLogService?.WriteLog();
        });
        public ICommand TestOptionsCommand => new RelayCommand(() =>
        {
            string json1 = JsonSerializer.Serialize(_optionsMonitor1.CurrentValue);
            string json2 = JsonSerializer.Serialize(_optionsMonitor2.CurrentValue);
            MessageBox.Show(json1 + "\n\n" + json2, "Settings");
        });
        public ICommand TestInjectCommand => new RelayCommand(() =>
        {
            _sampleService?.HelloWorld();
        });

        #region Pane Overrides
        public override CIMView ViewState
        {
            get
            {
                _cimView.InstanceID = (int)InstanceID;
                return _cimView;
            }
        }
        #endregion Pane Overrides
    }

    public class TestLogClass
    {

        public static void WriteLog()
        {

        }
    }
}
