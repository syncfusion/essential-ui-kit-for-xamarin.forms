using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesListPage" /> class.
        /// </summary>
        public MoviesListPage()
        {
            this.InitializeComponent();
            this.BindingContext = MoviesDataService.Instance.MoviesPageViewModel;
        }
    }
}