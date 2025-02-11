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
        private readonly IOptionsMonitor<SampleSettings> _optionsMonitor;
        [InjectService]
        private readonly ILogger _logger;
        [InjectService]
        private readonly ISampleService _sampleService;

        public SamplePaneViewModel(CIMView view) : base(view)
        {
            this.InjectService();
            _optionsMonitor.OnChange(settings =>
            {
                string json = JsonSerializer.Serialize(_optionsMonitor.CurrentValue);
                FrameworkApplication.AddNotification(new Notification
                {
                    Title = "SampleSettings Changed!",
                    Message = json
                });
            });
        }

        public ICommand TestLogCommand => new RelayCommand(() =>
        {
            _logger?.LogTrace("LogTrace");
            _logger?.LogDebug("LogDebug");
            _logger?.LogInformation("LogInformation");
            _logger?.LogWarning("LogWarning");
            _logger?.LogError("LogError");
            _logger?.LogCritical("LogCritical");
        });
        public ICommand TestOptionsCommand => new RelayCommand(() =>
        {
            string json = JsonSerializer.Serialize(_optionsMonitor.CurrentValue);
            MessageBox.Show(json, "SampleSettings");
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
}
