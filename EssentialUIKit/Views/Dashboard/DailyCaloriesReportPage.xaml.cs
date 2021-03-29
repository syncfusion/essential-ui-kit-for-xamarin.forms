using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard
{
    /// <summary>
    /// Page to show the daily calories report.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyCaloriesReportPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyCaloriesReportPage" /> class.
        /// </summary>
        public DailyCaloriesReportPage()
        {
            this.InitializeComponent();
        }
    }
}