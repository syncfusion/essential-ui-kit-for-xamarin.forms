using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Article list template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleListTemplate : Grid
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static readonly BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(ArticleListTemplate), null);

        /// <summary>
        /// Bindable property to set the parent element.
        /// </summary>
        public static readonly BindableProperty ParentElementProperty =
         BindableProperty.Create(nameof(ParentElement), typeof(object), typeof(ArticleListTemplate), null);

        /// <summary>
        /// Bindable property to set the child element.
        /// </summary>
        public static readonly BindableProperty ChildElementProperty =
         BindableProperty.Create(nameof(ChildElement), typeof(object), typeof(ArticleListTemplate), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleListTemplate"/> class.
        /// </summary>
		public ArticleListTemplate()
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

        /// <summary>
        /// Gets or sets the Parent element.
        /// </summary>
        public object ParentElement
        {
            get { return this.GetValue(ParentElementProperty); }
            set { this.SetValue(ParentElementProperty, value); }
        }

        /// <summary>
        /// Gets or sets the child element.
        /// </summary>
        public object ChildElement
        {
            get { return this.GetValue(ChildElementProperty); }
            set { this.SetValue(ChildElementProperty, value); }
        }
    }
}