using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Social
{
    /// <summary>
    /// Page to show the social profile with connections page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialProfileWithConnectionsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialProfileWithConnectionsPage" /> class.
        /// </summary>
        public SocialProfileWithConnectionsPage()
        {
            InitializeComponent();
        }
    }
}