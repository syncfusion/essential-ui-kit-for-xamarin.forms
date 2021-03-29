using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for Stock.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Stock : INotifyPropertyChanged
    {
        #region Field

        private bool isSelected;

        private IReadOnlyCollection<ChartModel> chartData;

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been displays the Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the Category value.
        /// </summary>
        public double CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the SubCategory.
        /// </summary>
        public string SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the SubCategory value.
        /// </summary>
        public double SubCategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with SfChart Control, which displays the items source for Stock.
        /// </summary>
        public IReadOnlyCollection<ChartModel> ChartData
        {
            get
            {
                return this.chartData;
            }

            set
            {
                if (this.chartData == value)
                {
                    return;
                }

                this.chartData = value;
                this.OnPropertyChanged("ChartData");
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfSegmented Control, which displays the Stock data variants.
        /// </summary>
        public IReadOnlyList<string> DataVariants { get; set; }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (this.isSelected == value)
                {
                    return;
                }

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