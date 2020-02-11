using EssentialUIKit.Models.Shopping;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Helpers
{
    /// <summary>
    /// This is used to set different templates in payment view.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TransactionTemplateSelector : DataTemplateSelector
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate CardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate CommonTemplate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns Xamarin.Forms.DataTemplate.
        /// </summary>
        /// <param name="item">The Model</param>
        /// <param name="container">The bindable object</param>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var payment = item as Payment;

            if (payment != null && payment.CardNumber != null)
            {
                return this.CardTemplate;
            }
            else
            {
                return this.CommonTemplate;
            }
        }

        #endregion
    }
}