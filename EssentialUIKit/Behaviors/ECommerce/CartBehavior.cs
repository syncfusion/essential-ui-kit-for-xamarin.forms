using EssentialUIKit.ViewModels.ECommerce;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors.ECommerce
{
    /// <summary>
    /// This class extends the behavior of the catalog page and detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CartBehavior : Behavior<ContentPage>
    {
        #region Fields

        private ContentPage bindablePage;

        #endregion

        #region Method

        /// <summary>
        /// Invoked when adding catalog page and detail page.
        /// </summary>
        /// <param name="bindableContentPage">ContentPage</param>
        protected override void OnAttachedTo(ContentPage bindableContentPage)
        {
            base.OnAttachedTo(bindableContentPage);
            bindablePage = bindableContentPage;
            bindableContentPage.Appearing += Bindable_Appearing;
        }

        /// <summary>
        /// Invoked when appearing the page.
        /// </summary>
        /// <param name="sender">ContentPage</param>
        /// <param name="e">EventArgs</param>
        private void Bindable_Appearing(object sender, EventArgs e)
        {
           //Do something
        }

        /// <summary>
        /// Invoked when exit from the page.
        /// </summary>
        /// <param name="bindableContentPage">ContentPage</param>
        protected override void OnDetachingFrom(ContentPage bindableContentPage)
        {
            base.OnDetachingFrom(bindableContentPage);
            bindableContentPage.Appearing -= Bindable_Appearing;
        }

        #endregion
    }
}
