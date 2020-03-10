using Xamarin.Forms;
using EssentialUIKit.Models.Dashboard;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard.Selectors
{
    /// <summary>
    /// Implements the company history data template selector class.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class CompanyHistoryDataSelectors : DataTemplateSelector
    {
        #region Properties
     
        /// <summary>
        /// Gets or sets the Header text template.
        /// </summary>
        public DataTemplate Header { get; set; }

        /// <summary>
        /// Gets or sets the Content text template.
        /// </summary>
        public DataTemplate Content { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the Header or Content text template.
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="container">The bindable object</param>
        /// <returns>Returns the data template</returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Event)item).Description != null? Content : Header;
        }

        #endregion
    }
}
