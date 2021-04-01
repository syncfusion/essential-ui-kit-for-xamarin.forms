using EssentialUIKit.ViewModels.Article;
using Syncfusion.ListView.XForms;
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
            this.InitializeComponent();
            this.BindingContext = MyArticlePageViewModel.BindingContext;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.CategoryTile.LayoutManager is GridLayout)
                {
                    (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 3;
                }
            }
            else
            {
                if (this.CategoryTile.LayoutManager is GridLayout)
                {
                    (this.CategoryTile.LayoutManager as GridLayout).SpanCount = 4;
                }
            }
        }
    }
}