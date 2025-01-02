using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for health profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class HealthProfile : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been displays the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the category value.
        /// </summary>
        public string CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the category image.
        /// </summary>
        public string ImagePath { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}