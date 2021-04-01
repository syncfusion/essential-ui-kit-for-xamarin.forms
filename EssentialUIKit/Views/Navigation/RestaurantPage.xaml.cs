using EssentialUIKit.DataService;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to show the Restaurant page details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage
    {
        public RestaurantPage()
        {
            this.InitializeComponent();
            this.BindingContext = RestaurantDataService.Instance.RestaurantViewModel;
        }
    }
}