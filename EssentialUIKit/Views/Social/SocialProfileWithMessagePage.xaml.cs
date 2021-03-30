using EssentialUIKit.ViewModels.Social;
using Syncfusion.ListView.XForms;
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