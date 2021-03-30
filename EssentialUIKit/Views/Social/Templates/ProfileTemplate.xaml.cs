using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Social.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileTemplate : ViewCell
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static readonly BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object), typeof(ProfileTemplate), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileTemplate"/> class.
        /// </summary>
        public ProfileTemplate()
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