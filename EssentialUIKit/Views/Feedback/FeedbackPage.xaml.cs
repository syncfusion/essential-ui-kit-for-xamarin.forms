using EssentialUIKit.ViewModels.Feedback;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Feedback
{
    /// <summary>
    /// Page to show feedback list
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage
    {
        public FeedbackPage()
        {
            this.InitializeComponent();
            this.BindingContext = FeedbackViewModel.BindingContext;
        }
    }
}