using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to show the suggestion page details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuggestionPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestionPage" /> class.
        /// </summary>
        public SuggestionPage()
        {
            this.InitializeComponent();
            this.BindingContext = SuggestionDataService.Instance.SuggestionViewModel;
        }
    }
}