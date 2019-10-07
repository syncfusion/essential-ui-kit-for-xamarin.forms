using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ECommerce
{
    /// <summary>
    /// The Category List page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryListPage" /> class.
        /// </summary>
        public CategoryListPage()
        {
            InitializeComponent();
            this.BindingContext = CategoryDataService.Instance.CategoryPageViewModel;
        }
    }
}