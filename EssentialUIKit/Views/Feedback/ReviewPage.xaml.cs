using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Feedback
{
    /// <summary>
    /// Page to get review from customer
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage
    {
        public ReviewPage()
        {
            InitializeComponent();
            this.ProductImage.Source = App.BaseImageUrl + "Image1.png";
        }
    }
}