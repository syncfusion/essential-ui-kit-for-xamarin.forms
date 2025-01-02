using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
{
    /// <summary>
    /// Page to list out article items.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleListPage" /> class.
        /// </summary>
        public ArticleListPage()
        {
            InitializeComponent();
        }
    }
}