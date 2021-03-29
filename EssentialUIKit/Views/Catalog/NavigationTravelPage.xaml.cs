using EssentialUIKit.ViewModels.Catalog;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
{
    /// <summary>
    /// Page to display the travel page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationTravelPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationTravelPage"/> class.
        /// </summary>
        public NavigationTravelPage()
        {
            this.InitializeComponent();
            this.BindingContext = NavigationTravelPageViewModel.BindingContext;
        }
    }
}