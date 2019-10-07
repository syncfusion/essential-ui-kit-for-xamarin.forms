using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Social
{
    /// <summary>
    /// Page to show the social profile with card page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialProfileWithCardPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialProfileWithCardPage" /> class.
        /// </summary>
        public SocialProfileWithCardPage()
        {
            InitializeComponent();
        }
    }
}