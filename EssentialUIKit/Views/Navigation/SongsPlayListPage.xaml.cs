using EssentialUIKit.DataService;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to show the Songs play list page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongsPlayListPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongsPlayListPage" /> class.
        /// </summary>
        public SongsPlayListPage()
        {
            this.InitializeComponent();
            this.BindingContext = SongsPlayListDataService.Instance.SongsPlayListViewModel;
        }
    }
}