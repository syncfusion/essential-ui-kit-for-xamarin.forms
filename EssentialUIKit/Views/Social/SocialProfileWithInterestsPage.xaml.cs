using EssentialUIKit.ViewModels.Social;
using Syncfusion.ListView.XForms;
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
            this.InitializeComponent();
            this.BindingContext = SocialProfileViewModel.BindingContext;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width < height)
            {
                if (this.listView.LayoutManager is GridLayout)
                {
                    (this.listView.LayoutManager as GridLayout).SpanCount = 3;
                }
            }
            else
            {
                if (this.listView.LayoutManager is GridLayout)
                {
                    (this.listView.LayoutManager as GridLayout).SpanCount = 5;
                }
            }
        }
    }
}