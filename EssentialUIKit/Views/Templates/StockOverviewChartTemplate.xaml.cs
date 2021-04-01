using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Stock overview chart section expander template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockOverviewChartTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockOverviewChartTemplate"/> class.
        /// </summary>
        public StockOverviewChartTemplate()
        {
            this.InitializeComponent();
        }
    }
}