using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EssentialUIKit.Models.Dashboard;
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
        private bool enableButton = false;

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

        public bool EnableButton
        {
            get { return enableButton; }
            set
            {
                enableButton = value;
                this.OnPropertyChanged("EnableButton");
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
