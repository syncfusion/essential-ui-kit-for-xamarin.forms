using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Feedback.Templates
{
    /// <summary>
    /// The Default view for detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabletView
    {
        public TabletView()
        {
            this.InitializeComponent();
            this.ProductImage.Source = App.BaseImageUrl + "Shoe1.png";
        }
    }
}