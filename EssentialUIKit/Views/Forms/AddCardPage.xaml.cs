using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Forms
{
    /// <summary>
    /// Page to show Add new card.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCardPage : ContentPage
	{
		public AddCardPage ()
		{
			InitializeComponent ();
            CustomDatePicker.DataSource = new ObservableCollection<object>() { "I" };
        }
        private void Calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            CustomDatePicker.Text = e.DateAdded[0].Date.ToString("MM/yy");
            CustomDatePicker.IsDropDownOpen = false;
        }
    }
}