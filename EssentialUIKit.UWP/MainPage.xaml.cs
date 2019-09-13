using Syncfusion.ListView.XForms.UWP;

namespace EssentialUIKit.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            SfListViewRenderer.Init();
            new Syncfusion.SfMaps.XForms.UWP.SfMapsRenderer();
            LoadApplication(new EssentialUIKit.App());
        }
    }
}
