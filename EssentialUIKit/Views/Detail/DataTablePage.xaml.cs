using EssentialUIKit.ViewModels.Detail;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Detail
{
    /// <summary>
    /// Page showing the data table
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataTablePage : ContentPage
    {
        public DataTablePage()
        {
            this.InitializeComponent();
            this.BindingContext = DataTableViewModel.BindingContext;
        }
    }
}