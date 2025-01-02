using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for Health care page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class HealthCare : INotifyPropertyChanged
    {
        #region Field
        
        private ObservableCollection<ChartDataPoint> chartData;

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
        public string CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the Category percentage.
        /// </summary>
        public string CategoryPercentage { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with SfChart Control, which displays the health care data visualization.
        /// </summary>
        public ObservableCollection<ChartDataPoint> ChartData
        {
            get
            {
                return chartData;
            }

            set
            {
                if (chartData == value)
                {
                    return;
                }

                chartData = value;
                this.OnPropertyChanged("ChartData");
            }
        }

        /// <summary>
        /// Gets or sets the property that has been displays the background gradient start.
        /// </summary>
        public string BackgroundGradientStart { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the background gradient end.
        /// </summary>
        public string BackgroundGradientEnd { get; set; }

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