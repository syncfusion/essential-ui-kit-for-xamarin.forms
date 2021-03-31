using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to display song list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongsPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongsPage" /> class.
        /// </summary>
        public SongsPage()
        {
            this.InitializeComponent();
            this.BindingContext = SongsDataService.Instance.SongsViewModel;
        }
    }
}