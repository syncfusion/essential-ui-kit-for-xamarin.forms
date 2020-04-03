using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Social
{
    /// <summary>
    /// Page to show the social profile.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialProfileWithMessagePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialProfileWithMessagePage" /> class.
        /// </summary>
        public SocialProfileWithMessagePage()
        {
            InitializeComponent();
        }
    }
}