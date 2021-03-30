using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Catalog
{
    /// <summary>
    /// Model for navigation travel page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Travel : INotifyPropertyChanged
    {
        #region Fields

        private bool isFavourite;

        private string imagePath;

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
        [DataMember(Name = "imagePath")]
        public string ImagePath
        {
            get
            {
                return App.ImageServerPath + this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the travel place name.
        /// </summary>
        [DataMember(Name = "place")]
        public string Place { get; set; }

        /// <summary>
        /// Gets or sets the travel place details.
        /// </summary>
        [DataMember(Name = "details")]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the price of travel place.
        /// </summary>
        [DataMember(Name = "price")]
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
                this.NotifyPropertyChanged(nameof(this.IsFavourite));
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