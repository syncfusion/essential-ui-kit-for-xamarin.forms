using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for transaction chart data in my wallet page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class TransactionChartData
    {
        #region Constructor

        /// <summary>
        /// Method for transaction chart data.
        /// </summary>
        /// <param name="section">The section</param>
        /// <param name="incomeValue">The income value</param>
        /// <param name="expenseValue">The expense value</param>
        /// <param name="difference">The difference</param>
        public TransactionChartData(string section, double incomeValue, double expenseValue, double difference)
        {
            this.Section = section;
            this.Income = incomeValue;
            this.Expense = expenseValue;
            this.Difference = difference;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the X-value.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the income value.
        /// </summary>
        public double Income { get; set; }

        /// <summary>
        /// Gets or sets the expense value.
        /// </summary>
        public double Expense { get; set; }

        /// <summary>
        /// Gets or sets the gap value for data.
        /// </summary>
        public double Difference { get; set; }

        #endregion
    }
}