using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Forms
{
    /// <summary>
    /// Page to show the card payment.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPaymentPage : ContentPage
    {
        public CardPaymentPage()
        {
            this.InitializeComponent();
        }

        private void DatePicker_Clicked(object sender, System.EventArgs e)
        {
            datePicker.IsOpen = true;
        }

        private void DatePicker_OkButtonClicked(object sender, Syncfusion.XForms.Pickers.DateChangedEventArgs e)
        {
            pickerButton.Text = string.Format("{0:MM/yy}", e.NewValue);
        }
    }
}