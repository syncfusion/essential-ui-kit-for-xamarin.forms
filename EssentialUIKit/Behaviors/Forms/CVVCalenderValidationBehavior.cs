using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors.Forms
{
    /// <summary>
    /// This class extends the behavior of the date picker control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CVVCalenderValidationBehavior : BehaviorBase<DatePicker>
    {
        #region Fields

        /// <summary>
        /// Gets or sets the IsValidProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(EntryLineValidationBehaviour), true, BindingMode.TwoWay, null);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether it is valid or not.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return (bool)this.GetValue(IsValidProperty);
            }

            set
            {
                this.SetValue(IsValidProperty, value);
            }
        }

        #endregion

        #region Method

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            this.AssociatedObject.Focused += this.AssociatedObject_Focused;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            this.AssociatedObject.Focused -= this.AssociatedObject_Focused;
        }

        private void AssociatedObject_Focused(object sender, FocusEventArgs e)
        {
            this.IsValid = true;
        }

        #endregion
    }
}
