using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class is extended from SfPopupLayout to show the popup.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SfPopupView : SfPopupLayout
    {
        /// <summary>
        /// To show the popup layout.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void ShowPopUp(string title = null, string content = null, string buttonText = null)
        {
            DataTemplate templateView;
            Grid layout;

            templateView = new DataTemplate(() =>
            {
                layout = new Grid();
                layout.Margin = new Thickness(10,0,10,0);
                layout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                layout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Label popupContent = new Label();
                popupContent.Text = content;
                popupContent.HorizontalTextAlignment = TextAlignment.Center;
                popupContent.VerticalTextAlignment = TextAlignment.Center;
                popupContent.VerticalOptions = LayoutOptions.Center;
                var fontFamily = Device.RuntimePlatform == Device.iOS ? "Montserrat-SemiBold" :
   Device.RuntimePlatform == Device.Android ? "Montserrat-SemiBold.ttf#Montserrat-SemiBold" : "Assets/Montserrat-SemiBold.ttf#Montserrat-SemiBold";
                popupContent.FontFamily = fontFamily;
                layout.Children.Add(popupContent,0,0);

                if (buttonText != null)
                {
                    SfButton button = new SfButton();
                    button.Text = buttonText;
                    button.Margin = new Thickness(20,0,20,20);
                    button.VerticalOptions = LayoutOptions.End;
                    layout.Children.Add(button,0,1);
                }
                return layout;
            });

            this.PopupView.ShowHeader = false;
            this.PopupView.ShowFooter = false;
            this.PopupView.HeightRequest = 130;
            this.PopupView.ShowCloseButton = false;
            this.PopupView.AcceptButtonText = "OK";

            // Adding ContentTemplate of the SfPopupLayout
            this.PopupView.ContentTemplate = templateView;

            this.Show();
        }
    }
}
