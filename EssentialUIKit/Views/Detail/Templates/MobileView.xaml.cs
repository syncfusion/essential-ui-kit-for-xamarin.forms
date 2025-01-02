using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Detail.Templates
{
    /// <summary>
    /// The Mobile view for detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MobileView
    {
        public MobileView()
        {
            InitializeComponent();
            this.ProductImage.Source = App.BaseImageUrl + "ReviewShoe.png";
            this.ProfileImage.Source = App.BaseImageUrl + "ProfileImage11.png";
        }
    }
}