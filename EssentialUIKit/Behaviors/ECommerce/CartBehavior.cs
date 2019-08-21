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
        /// <param name="bindable">ContentPage</param>
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            bindablePage = bindable;
            bindable.Appearing += Bindable_Appearing;
        }

        /// <summary>
        /// Invoked when appearing the page.
        /// </summary>
        /// <param name="sender">ContentPage</param>
        /// <param name="e">EventArgs</param>
        private void Bindable_Appearing(object sender, EventArgs e)
        {
            if (bindablePage != null)
            {
                if (bindablePage.BindingContext is DetailPageViewModel)
                {
                    //TODO: Manage cart item count for detail page
                    //(bindablePage.BindingContext as DetailPageViewModel).CartItemCount
                }
                else if (bindablePage.BindingContext is CatalogPageViewModel)
                {
                    //TODO: Manage cart item count for catalog page
                    //(bindablePage.BindingContext as CatalogPageViewModel).CartItemCount
                }
            }
        }

        /// <summary>
        /// Invoked when exit from the page.
        /// </summary>
        /// <param name="bindable">ContentPage</param>
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Appearing -= Bindable_Appearing;
        }

        #endregion
    }
}
