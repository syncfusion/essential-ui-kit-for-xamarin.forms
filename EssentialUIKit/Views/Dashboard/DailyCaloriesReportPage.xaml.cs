using System;
using System.Collections.ObjectModel;
using EssentialUIKit.Models.Dashboard;
using Syncfusion.SfGauge.XForms;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard
{
    /// <summary>
    /// Page to show the daily calories report.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyCaloriesReportPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyCaloriesReportPage" /> class.
        /// </summary>
        public DailyCaloriesReportPage()
        {
            InitializeComponent();

            UpdateGauge();
        }

        /// <summary>
        /// Update the diagrammatic layout based on the session data
        /// </summary>
        private void UpdateGauge()
        {
            Scale.Pointers.Clear();
            var ranges = new ObservableCollection<Pointer>();
            double rangeStart = 0;

            var items = SfListView.ItemsSource as ObservableCollection<Calorie>;
            var proteinRange = new RangePointer();

            for (int i = 0; i < items.Count; i++)
            {
                RangePointer range = new RangePointer()
                {
                    RangeStart = rangeStart,
                    Value = rangeStart + items[i].Quantity,
                    Offset = 0.9,
                    Thickness = 12,
                    EnableAnimation = false,
                    Color = Color.FromHex(items[i].Indicator)
                };

                if (items[i].Nutrient == "Protein")
                {
                    range.Offset = 0.93;
                    range.Thickness = 18;
                    range.RangeStart -= 3;
                    range.Value += 3;
                    range.RangeCap = RangeCap.Both;
                    proteinRange = range;
                }
                else
                {
                    ranges.Add(range);
                }
                
                rangeStart += items[i].Quantity;
            }

            Scale.EndValue = rangeStart;
            Scale.Pointers = ranges;
            Scale.Pointers.Add(proteinRange);
        }

        /// <summary>
        /// Invoked when session button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SessionButton_OnClicked(object sender, EventArgs e)
        {
            CalorieViewModel.SelectedSessionCaloriesCard.EnableButton = false;

            var context = (sender as SfButton).BindingContext as CaloriesCard;
            context.EnableButton = true;
            CalorieViewModel.SelectedSessionCaloriesCard = context;
            switch ((sender as SfButton).Text)
            {
                case "Breakfast":
                {
                    SfListView.ItemsSource = CalorieViewModel.BreakfastCalories;
                    UpdateGauge();
                    break;
                }
                case "Lunch":
                {
                    SfListView.ItemsSource = CalorieViewModel.LunchCalories;
                    UpdateGauge();
                    break;
                }
                case "Dinner":
                {
                    SfListView.ItemsSource = CalorieViewModel.DinnerCalories;
                    UpdateGauge();
                    break;
                }
                case "Snack":
                {
                    SfListView.ItemsSource = CalorieViewModel.SnackCalories;
                    UpdateGauge();
                    break;
                }
            }
        }
    }
}