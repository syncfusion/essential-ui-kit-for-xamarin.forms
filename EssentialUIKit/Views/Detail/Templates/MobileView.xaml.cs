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
            this.InitializeComponent();
            this.ProductImage.Source = App.ImageServerPath + "ReviewShoe.png";
            this.ProfileImage.Source = App.ImageServerPath + "ProfileImage11.png";
        }
    }
}