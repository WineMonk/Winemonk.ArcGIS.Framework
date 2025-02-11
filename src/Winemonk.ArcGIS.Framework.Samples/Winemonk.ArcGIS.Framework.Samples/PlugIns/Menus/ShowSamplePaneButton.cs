using System.Collections.Generic;
using System.Linq;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace Winemonk.ArcGIS.Framework.Samples.PlugIns.Menus
{
    internal class ShowSamplePaneButton : Button
    {
        private const string _viewPaneID = "Winemonk_ArcGIS_Framework_Samples_PlugIns_Panes_SamplePane";
        protected override void OnClick()
        {
            List<Pane> panes = FrameworkApplication.Panes.Find(_viewPaneID);
            if (panes?.Count > 0)
            {
                panes.First().Activate();
                return;
            }
            var view = new CIMGenericView();
            view.ViewType = _viewPaneID;
            FrameworkApplication.Panes.Create(_viewPaneID, [view]);
        }
    }
}
