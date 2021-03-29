using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for daily calories report page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CaloriesCard : INotifyPropertyChanged
    {
        #region fields

        /// <summary>
        /// To store the button checkable status.
        /// </summary>
        private bool isSelected;

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been bound with button which displays the card items.
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the icon.
        /// </summary>
        public string Icon { get; set; }

        public bool IsSelected
        {
            get { return this.isSelected; }

            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

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
