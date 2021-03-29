using EssentialUIKit.DataService;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosPage : ContentPage
    {
        public PhotosPage()
        {
            this.InitializeComponent();

            this.BindingContext = PhotosDataService.Instance.PhotosViewModel;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.listView.LayoutManager is GridLayout)
                {
                    (this.listView.LayoutManager as GridLayout).SpanCount = 3;
                }
            }
            else
            {
                if (this.listView.LayoutManager is GridLayout)
                {
                    (this.listView.LayoutManager as GridLayout).SpanCount = 5;
                }
            }
        }
    }
}