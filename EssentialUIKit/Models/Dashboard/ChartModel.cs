using System;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for chart template.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChartModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="dateTime">The dateTime Xvalue</param>
        /// <param name="value">YValue</param>
        public ChartModel(DateTime dateTime, double value)
        {
            this.DateTimeXValue = dateTime;
            this.YValue = value;
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been bound the chart X value.
        /// </summary>
        public DateTime DateTimeXValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound the chart Y value.
        /// </summary>       
        public double YValue { get; set; }

        #endregion
    }
}
