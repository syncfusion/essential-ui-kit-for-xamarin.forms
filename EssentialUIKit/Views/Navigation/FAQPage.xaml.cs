using EssentialUIKit.DataService;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to show the FAQ page details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAQPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FAQPage" /> class.
        /// </summary>
        public FAQPage()
        {
            this.InitializeComponent();
            this.BindingContext = FAQDataService.Instance.FAQViewModel;
        }
    }
}