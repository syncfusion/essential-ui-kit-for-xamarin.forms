using Xamarin.Forms;
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
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    ErrorImage.IsVisible = false;
                }
            }
            else
            {
                ErrorImage.IsVisible = true;
            }
        }
    }
}