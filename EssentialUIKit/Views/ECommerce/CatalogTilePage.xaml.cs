using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using EssentialUIKit.DataService;

namespace EssentialUIKit.Views.ECommerce
{
    /// <summary>
    /// Page to show Catalog tile.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogTilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogTilePage" /> class.
        /// </summary>
        public CatalogTilePage()
        {
            this.InitializeComponent();
            this.BindingContext = CatalogDataService.Instance.CatalogPageViewModel;
        }        
    }
}