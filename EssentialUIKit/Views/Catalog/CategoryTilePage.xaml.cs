using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
{
    /// <summary>
    /// The Category Tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryTilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryTilePage" /> class.
        /// </summary>
        public CategoryTilePage()
        {
            InitializeComponent();
            this.BindingContext = CategoryDataService.Instance.CategoryPageViewModel;
        }
    }
}