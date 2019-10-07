using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Social
{
    /// <summary>
    /// Page to show the social profile with interests page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialProfileWithInterestsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialProfileWithInterestsPage" /> class.
        /// </summary>
        public SocialProfileWithInterestsPage()
        {
            InitializeComponent();
        }
    }
}