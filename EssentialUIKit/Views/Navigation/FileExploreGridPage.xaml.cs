using EssentialUIKit.DataService;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to display the file explorer grid.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileExploreGridPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileExploreGridPage" /> class.
        /// </summary>
        public FileExploreGridPage()
        {
            this.InitializeComponent();
            this.BindingContext = FileExploreDataService.Instance.FileExploreViewModel;
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.FileExploreGrid.LayoutManager is GridLayout)
                {
                    (this.FileExploreGrid.LayoutManager as GridLayout).SpanCount = 3;
                }
            }
            else
            {
                if (this.FileExploreGrid.LayoutManager is GridLayout)
                {
                    (this.FileExploreGrid.LayoutManager as GridLayout).SpanCount = 5;
                }
            }
        }
    }
}