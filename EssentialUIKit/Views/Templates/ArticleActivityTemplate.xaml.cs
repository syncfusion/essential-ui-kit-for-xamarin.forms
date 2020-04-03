using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// article activity template.
    /// </summary>
    [Preserve(AllMembers = true)]

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleActivityTemplate : StackLayout
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object),
         typeof(ArticleActivityTemplate), null);

        /// <summary>
        /// Gets or sets the parent bindingcontext.
        /// </summary>
        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleActivityTemplate"/> class.
        /// </summary>
        public ArticleActivityTemplate()
        {
            InitializeComponent();
        }
    }
}