using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ECommerce
{
    /// <summary>
    /// The Filter view
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterView" /> class.
        /// </summary>
        public FilterView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                this.FooterTemplate = (DataTemplate)this.Resources["LandscapeTemplate"];
            }
            else
            {
                this.FooterTemplate = (DataTemplate)this.Resources["PortraitTemplate"];
            }
        }
    }
}