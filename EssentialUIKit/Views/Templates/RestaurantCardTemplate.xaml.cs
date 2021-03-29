using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Restaurant page card template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantCardTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantCardTemplate"/> class.
        /// </summary>
		public RestaurantCardTemplate()
        {
            this.InitializeComponent();
        }
    }
}