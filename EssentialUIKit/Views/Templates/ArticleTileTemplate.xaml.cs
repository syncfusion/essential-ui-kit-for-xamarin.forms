using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Article tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleTileTemplate : Grid
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static readonly BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(ArticleTileTemplate), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleTileTemplate"/> class.
        /// </summary>
        public ArticleTileTemplate()
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