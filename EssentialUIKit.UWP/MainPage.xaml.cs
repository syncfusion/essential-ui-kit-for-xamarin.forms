using Syncfusion.ListView.XForms.UWP;

namespace EssentialUIKit.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            SfListViewRenderer.Init();
            Syncfusion.SfMaps.XForms.UWP.SfMapsRenderer.Init();
            this.LoadApplication(new EssentialUIKit.App());
        }
    }
}
