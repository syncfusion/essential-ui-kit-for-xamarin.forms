using EssentialUIKit.DataService;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
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

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.ListViewTile.LayoutManager is GridLayout)
                {
                    (this.ListViewTile.LayoutManager as GridLayout).SpanCount = 2;
                }
            }
            else
            {
                if (this.ListViewTile.LayoutManager is GridLayout)
                {
                    (this.ListViewTile.LayoutManager as GridLayout).SpanCount = 4;
                }
            }
        }
    }
}