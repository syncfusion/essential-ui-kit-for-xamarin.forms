using EssentialUIKit.DataService;
using EssentialUIKit.ViewModels.Navigation;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page showing the list of selectable name with grouping.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableNamePage
    {
        public SelectableNamePage()
        {
            this.InitializeComponent();
            this.BindingContext = SelectableNamePageDataService.Instance.SelectableNamePage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Setting IsSelected property to false at entry time.
            if (this.BindingContext is SelectableNamePageViewModel)
            {
                var viewModel = this.BindingContext as SelectableNamePageViewModel;

                foreach (var item in viewModel.SelectableName)
                {
                    item.IsSelected = false;
                }
            }
        }
    }
}