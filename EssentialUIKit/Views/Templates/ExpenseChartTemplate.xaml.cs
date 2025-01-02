using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Navigation tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseChartTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseChartTemplate"/> class.
        /// </summary>
		public ExpenseChartTemplate()
        {
            InitializeComponent();
        }
    }
}