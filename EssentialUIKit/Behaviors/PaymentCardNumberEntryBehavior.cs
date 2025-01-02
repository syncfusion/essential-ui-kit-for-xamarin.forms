using System;
using EssentialUIKit.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the BorderlessEntryBehavior control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentCardNumberEntryBehavior : Behavior<BorderlessEntry>
    {
        #region Properties

        /// <summary>
        /// Gets the BorderlessEntry.
        /// </summary>
        public BorderlessEntry BorderlessEntry { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding the borderlessEntry to view.
        /// </summary>
        /// <param name="borderlessEntry">The borderlessEntry</param>
        protected override void OnAttachedTo(BorderlessEntry borderlessEntry)
        {
            if (borderlessEntry != null)
            {
                base.OnAttachedTo(borderlessEntry);
                this.BorderlessEntry = borderlessEntry;
                borderlessEntry.BindingContextChanged += this.OnBindingContextChanged;
                borderlessEntry.TextChanged += this.OnTextChanged;
            }
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="borderlessEntry">The borderlessEntry</param>
        protected override void OnDetachingFrom(BorderlessEntry borderlessEntry)
        {
            if (borderlessEntry != null)
            {
                base.OnDetachingFrom(borderlessEntry);
                borderlessEntry.BindingContextChanged -= this.OnBindingContextChanged;
                borderlessEntry.TextChanged -= this.OnTextChanged;
                this.BorderlessEntry = null;
            }
        }

        /// <summary>
        /// Invoked when comboBox binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.BorderlessEntry.BindingContext;
        }

        /// <summary>
        /// Invoked when entry text is changed.
        /// </summary>
        /// <param name="sender">The borderlessEntry</param>
        /// <param name="e">The Text Changed Event args</param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                return;
            }

            if ((e.OldTextValue == null || e.NewTextValue.Length > e.OldTextValue.Length) &&
                e.NewTextValue.Length % 5 == 4 && e.NewTextValue.Length != 19)
            {
                ((Entry)sender).Text = string.Concat(e.NewTextValue, "-");
            }
            else
            {
                ((Entry)sender).Text = e.NewTextValue;
            }
        }

        /// <summary>
        /// Invoked when binding context is changed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.OnBindingContextChanged();
        }

        #endregion
    }
}
