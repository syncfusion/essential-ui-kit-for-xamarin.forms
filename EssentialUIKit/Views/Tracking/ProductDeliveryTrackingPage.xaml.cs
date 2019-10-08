using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Tracking
{
    /// <summary>
    /// Page to show the product delivery tracking.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDeliveryTrackingPage 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDeliveryTrackingPage" /> class.
        /// </summary>
        public ProductDeliveryTrackingPage()
        {
            InitializeComponent();
            this.BindingContext = ProductDeliveryTrackingDataService.Instance.ProductDeliveryTrackingViewModel;
        }
    }
}