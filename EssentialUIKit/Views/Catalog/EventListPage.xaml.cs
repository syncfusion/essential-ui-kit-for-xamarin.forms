using EssentialUIKit.ViewModels.Catalog;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
{
    /// <summary>
    /// The event detail page 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventListPage
    {
        public EventListPage()
        {
            this.InitializeComponent();
            this.BindingContext = EventListViewModel.BindingContext;
        }
    }
}