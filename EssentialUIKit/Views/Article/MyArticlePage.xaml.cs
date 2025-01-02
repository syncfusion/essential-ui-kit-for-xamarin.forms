using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Article
{
    /// <summary>
    /// Article with comments page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyArticlePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyArticlePage"/> class.
        /// </summary>
        public MyArticlePage()
        {
            InitializeComponent();
        }
    }
}