using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.OnBoarding
{
    /// <summary>
    /// Page to display on-boarding gradient with animation
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnBoaringAnimationPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnBoaringAnimationPage" /> class.
        /// </summary>
        public OnBoaringAnimationPage()
        {
            InitializeComponent();
        }
    }
}