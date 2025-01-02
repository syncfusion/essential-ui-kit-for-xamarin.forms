using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for daily calories report page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Calorie
    {
        #region Property

        /// <summary>
        /// Gets or sets the property that has been displays the quantity.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the nutrients.
        /// </summary>
        public string Nutrient { get; set; }
        
        /// <summary>
        /// Gets or sets the property that has been bound with button which displays the card items.
        /// </summary>
        public string Indicator { get; set; }

        #endregion
    }
}
