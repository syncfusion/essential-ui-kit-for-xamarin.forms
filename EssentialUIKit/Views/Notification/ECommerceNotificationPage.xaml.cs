using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Notification
{
    /// <summary>
    /// Page to display E-Commerce notifications list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ECommerceNotificationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ECommerceNotificationPage" /> class.
        /// </summary>
        public ECommerceNotificationPage()
        {
            this.InitializeComponent();
            this.BindingContext = ECommerceNotificationDataService.Instance.ECommerceNotificationViewModel;
        }
    }
}