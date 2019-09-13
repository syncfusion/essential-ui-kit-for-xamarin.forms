using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using EssentialUIKit.DataService;

namespace EssentialUIKit.Views.ECommerce
{
    /// <summary>
    /// Page to show the catalog list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogListPage" /> class.
        /// </summary>
        public CatalogListPage()
        {
            this.InitializeComponent();
            this.BindingContext = CatalogDataService.Instance.CatalogPageViewModel;
        }
    }
}