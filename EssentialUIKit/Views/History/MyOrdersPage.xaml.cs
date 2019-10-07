using EssentialUIKit.DataService;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.History
{
    /// <summary>
    /// Page to show the my order list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOrdersPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyOrdersPage" /> class.
        /// </summary>
        public MyOrdersPage()
        {
            InitializeComponent();
            this.BindingContext = MyOrdersDataService.Instance.MyOrdersPageViewModel;
        }
    }
}