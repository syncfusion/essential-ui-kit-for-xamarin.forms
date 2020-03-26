using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Catalog
{
    /// <summary>
    /// Model for Event list page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EventList
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the event image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        public string EventDate { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        public string EventTime { get; set; }

        /// <summary>
        /// Gets or sets the event month.
        /// </summary>
        public string EventMonth { get; set; }

        /// <summary>
        /// Gets or sets the popular events in the list.
        /// </summary>
        public bool IsPopular { get; set; }

        /// <summary>
        /// Gets or sets the upcoming events in the list.
        /// </summary>
        public bool IsUpcoming { get; set; }

        #endregion

        #region Constructor

        public EventList()
        {
            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            var button = obj as SfButton;

            if (button == null)
            {
                return;
            }

            if (button.Text == "\ue701")
            {
                button.Text = "\ue732";
                Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                button.TextColor = (Color)retVal;
            }
            else
            {
                button.Text = "\ue701";
                Application.Current.Resources.TryGetValue("Gray-600", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }
        #endregion

    }
}
