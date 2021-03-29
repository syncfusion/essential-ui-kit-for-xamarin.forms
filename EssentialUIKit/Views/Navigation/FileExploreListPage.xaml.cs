using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to display the file explorer list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileExploreListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileExploreListPage" /> class.
        /// </summary>
        public FileExploreListPage()
        {
            this.InitializeComponent();
            this.BindingContext = FileExploreDataService.Instance.FileExploreViewModel;
        }
    }
}