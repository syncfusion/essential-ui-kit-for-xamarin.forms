using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Product tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductTileTemplate : Grid
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static readonly BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(ProductTileTemplate), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTileTemplate"/> class.
        /// </summary>
        public ProductTileTemplate()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the parent bindingcontext.
        /// </summary>
        public object ParentBindingContext
        {
            get { return this.GetValue(ParentBindingContextProperty); }
            set { this.SetValue(ParentBindingContextProperty, value); }
        }
    }
}