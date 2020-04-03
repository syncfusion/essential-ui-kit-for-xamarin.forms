using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Profile
{
    /// <summary>
    /// Page to show the health profile.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HealthProfilePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthProfilePage" /> class.
        /// </summary>
        public HealthProfilePage()
        {
            InitializeComponent();
        }
    }
}