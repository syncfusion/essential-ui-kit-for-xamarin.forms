using EssentialUIKit.ViewModels.Detail;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Detail
{
    /// <summary>
    /// Page to show my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAddressPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyAddressPage" /> class.
        /// </summary>
        public MyAddressPage()
        {
            this.InitializeComponent();
            this.BindingContext = MyAddressViewModel.BindingContext;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.myAddress.LayoutManager is GridLayout)
                {
                    (this.myAddress.LayoutManager as GridLayout).SpanCount = 1;
                }
            }
            else
            {
                if (this.myAddress.LayoutManager is GridLayout)
                {
                    (this.myAddress.LayoutManager as GridLayout).SpanCount = 2;
                }
            }
        }
    }
}