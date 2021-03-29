using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the payment failed
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentFailedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentFailedPage" /> class.
        /// </summary>
        public PaymentFailedPage()
        {
            this.InitializeComponent();
            this.BindingContext = PaymentFailedPageViewModel.BindingContext;
        }
    }
}