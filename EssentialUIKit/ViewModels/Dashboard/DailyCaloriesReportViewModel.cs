using System.Collections.Generic;
using System.Collections.ObjectModel;
using EssentialUIKit.Models.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for daily calories report.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DailyCaloriesReportViewModel : BaseViewModel
    {
        #region Field
        
        /// <summary>
        /// Gets or sets the selected session card item.
        /// </summary>
        public CaloriesCard SelectedSessionCaloriesCard { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="DailyCaloriesReportViewModel" /> class.
        /// </summary>
        public DailyCaloriesReportViewModel()
        {
            CardItems = new List<CaloriesCard>()
            {
                new CaloriesCard()
                {
                    Icon = "\ue750",
                    Session = "Breakfast",
                    EnableButton = true
                },
                new CaloriesCard()
                {
                    Icon = "\ue74e",
                    Session = "Lunch"
                },
                new CaloriesCard()
                {
                    Icon = "\ue74f",
                    Session = "Dinner"
                },
                new CaloriesCard()
                {
                    Icon = "\ue74b",
                    Session = "Snack"
                }
            };

            BreakfastCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 30, Nutrient = "Fiber", Indicator = "#5588fe"
                },
                new Calorie()
                {
                    Quantity = 260, Nutrient = "Protein", Indicator = "#7cf74c"
                },
                new Calorie()
                {
                    Quantity = 80, Nutrient = "Carbs", Indicator = "#fd50c8"
                },
                new Calorie()
                {
                    Quantity = 100, Nutrient = "Calcium", Indicator = "#ffdd7c"
                },
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fat", Indicator = "#fe6751"
                },
                new Calorie()
                {
                    Quantity = 60, Nutrient = "Vitamins", Indicator = "#7d46c2"
                },
            };

            DinnerCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 20, Nutrient = "Fibre", Indicator = "#5588fe"
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c"
                },
                new Calorie()
                {
                    Quantity = 50, Nutrient = "Carbs", Indicator = "#fd50c8"
                },
                new Calorie()
                {
                    Quantity = 140, Nutrient = "Calcium", Indicator = "#ffdd7c"
                },
                new Calorie()
                {
                    Quantity = 20, Nutrient = "Fat", Indicator = "#fe6751"
                },
                new Calorie()
                {
                    Quantity = 100, Nutrient = "Vitamins", Indicator = "#7d46c2"
                },

            };

            LunchCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fibre", Indicator = "#5588fe"
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c"
                },
                new Calorie()
                {
                    Quantity = 120, Nutrient = "Carbs", Indicator = "#fd50c8"
                },
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Calcium", Indicator = "#ffdd7c"
                },
                new Calorie()
                {
                    Quantity = 50, Nutrient = "Fat", Indicator = "#fe6751"
                },
                new Calorie()
                {
                    Quantity = 90, Nutrient = "Vitamins", Indicator = "#7d46c2"
                },

            };

            SnackCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fibre", Indicator = "#5588fe"
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c"
                },
                new Calorie()
                {
                    Quantity = 70, Nutrient = "Carbs", Indicator = "#fd50c8"
                },
                new Calorie()
                {
                    Quantity = 130, Nutrient = "Calcium", Indicator = "#ffdd7c"
                },
                new Calorie()
                {
                    Quantity = 60, Nutrient = "Fat", Indicator = "#fe6751"
                },
                new Calorie()
                {
                    Quantity = 80, Nutrient = "Vitamins", Indicator = "#7d46c2"
                },

            };

            SelectedSessionCaloriesCard = CardItems[0];

            this.SessionCommand = new Command(this.SessionButtonClicked);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the session button is clicked.
        /// </summary>
        public Command SessionCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the session card items collection.
        /// </summary>
        public List<CaloriesCard> CardItems { get; set; }

        /// <summary>
        /// Gets or sets the breakfast calories collection.
        /// </summary>
        public ObservableCollection<Calorie> BreakfastCalories { get; set; }

        /// <summary>
        /// Gets or sets the lunch calories collection.
        /// </summary>
        public ObservableCollection<Calorie> LunchCalories { get; set; }

        /// <summary>
        /// Gets or sets the dinner calories collection.
        /// </summary>
        public ObservableCollection<Calorie> DinnerCalories { get; set; }

        /// <summary>
        /// Gets or sets the snack calories collection.
        /// </summary>
        public ObservableCollection<Calorie> SnackCalories { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the session button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SessionButtonClicked(object obj)
        {
            // Do something
        }
        
        #endregion

    }
}
