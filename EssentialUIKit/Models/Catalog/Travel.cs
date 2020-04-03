using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Catalog
{
    /// <summary>
    /// Model for navigation travel page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Travel : INotifyPropertyChanged
    {
        #region Fields

        private bool isFavourite;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the travel place image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the travel place name.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the travel place details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the price of travel place.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the place is favourite or not.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged(nameof(IsFavourite));
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