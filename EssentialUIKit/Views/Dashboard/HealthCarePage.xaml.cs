using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard
{
    /// <summary>
    /// Page to show the health care details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HealthCarePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCarePage" /> class.
        /// </summary>
        public HealthCarePage()
        {
            InitializeComponent();
        }
    }
}
