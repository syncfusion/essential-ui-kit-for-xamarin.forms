using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the location denied
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDeniedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationDeniedPage" /> class.
        /// </summary>
        public LocationDeniedPage()
        {
            this.InitializeComponent();
            this.BindingContext = LocationDeniedPageViewModel.BindingContext;
        }
    }
}