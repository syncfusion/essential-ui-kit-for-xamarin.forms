using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ContactUs
{
    /// <summary>
    /// Page to contact with user name, email and message
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUsPage
    {
        private double frameWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsPage" /> class.
        /// </summary>
        public ContactUsPage()
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
                if (Device.Idiom == TargetIdiom.Desktop || Device.Idiom == TargetIdiom.Tablet)
                {
                    this.frameWidth = width / 2;
                    MainStack.Orientation = StackOrientation.Horizontal;
                    MainFrame.VerticalOptions = LayoutOptions.FillAndExpand;
                    MainFrame.Margin = new Thickness(0);
                    MainFrame.CornerRadius = 0;
                    MainFrame.HasShadow = false;
                    MainFrameStack.VerticalOptions = LayoutOptions.StartAndExpand;
                    if (this.frameWidth > 0)
                    {
                        MainFrame.WidthRequest = this.frameWidth;
                        Map.WidthRequest = this.frameWidth;
                    }
                }
                else
                {
                    this.DefaultStyle(height);
                }
            }
            else
            {
                this.DefaultStyle(height);
            }
        }

        /// <summary>
        /// This default style method is called when the device is portrait mode.
        /// This method is also called when the android and ios devices are landscape mode
        /// </summary>
        /// <param name="height">The height</param>
        private void DefaultStyle(double height)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                MainFrame.HeightRequest = height / 2;
                Map.HeightRequest = height / 2;
                MainStack.Orientation = StackOrientation.Vertical;
                MainFrame.VerticalOptions = LayoutOptions.End;
                MainFrame.Margin = new Thickness(0);
                MainFrame.CornerRadius = 0;
                MainFrame.HasShadow = false;
                MainFrameStack.VerticalOptions = LayoutOptions.StartAndExpand;
                MainFrameStack.Margin = new Thickness(20, 0, 20, 0);
            }
            else
            {
                MainStack.Orientation = StackOrientation.Vertical;
                MainFrame.VerticalOptions = LayoutOptions.End;
                MainFrame.Margin = new Thickness(15, -50, 15, 15);
                MainFrameStack.VerticalOptions = LayoutOptions.EndAndExpand;
                MainFrame.CornerRadius = 5;
                MainFrame.HasShadow = true;
                MainFrameStack.Margin = new Thickness(0);
            }
        }
    }
}