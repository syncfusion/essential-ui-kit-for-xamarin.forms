using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Bookmarks
{
    /// <summary>
    /// Model for Article templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Article : INotifyPropertyChanged
    {
        #region Fields

        private bool isBookmarked;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the article image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the article name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article author name.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the article publish date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the article read time.
        /// </summary>
        public string AverageReadingTime { get; set; }

        /// <summary>
        /// Gets or sets the article description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked.
        /// </summary>
        public bool IsBookmarked
        {
            get
            {
                return this.isBookmarked;
            }

            set
            {
                this.isBookmarked = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}