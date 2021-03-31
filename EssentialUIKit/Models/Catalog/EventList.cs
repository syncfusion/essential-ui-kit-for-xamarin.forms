using System.Runtime.Serialization;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Catalog
{
    /// <summary>
    /// Model for Event list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class EventList
    {
        #region Fields

        private string imagePath;

        private Command favouriteCommand;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the event image path.
        /// </summary>
        [DataMember(Name = "imagePath")]
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        [DataMember(Name = "eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        [DataMember(Name = "eventDate")]
        public string EventDate { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        [DataMember(Name = "eventTime")]
        public string EventTime { get; set; }

        /// <summary>
        /// Gets or sets the event month.
        /// </summary>
        [DataMember(Name = "eventMonth")]
        public string EventMonth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event in the list is popular or not.
        /// </summary>
        [DataMember(Name = "isPopular")]
        public bool IsPopular { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the upcoming event in the list is upcoming or not.
        /// </summary>
        [DataMember(Name = "isUpcoming")]
        public bool IsUpcoming { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

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
                Application.Current.Resources.TryGetValue("Gray-White", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }
        #endregion
    }
}
