using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for health profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
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
        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the category value.
        /// </summary>
        [DataMember(Name = "categoryValue")]
        public string CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the category image.
        /// </summary>
        [DataMember(Name = "categoryImage")]
        public string CategoryImage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="property">Property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}