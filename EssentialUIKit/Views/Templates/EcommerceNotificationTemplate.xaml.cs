using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// E-commerce notification template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EcommerceNotificationTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcommerceNotificationTemplate"/> class.
        /// </summary>
		public EcommerceNotificationTemplate()
        {
            InitializeComponent();
        }
    }
}