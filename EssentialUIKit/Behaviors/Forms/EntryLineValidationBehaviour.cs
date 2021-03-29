using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors.Forms
{
    /// <summary>
    /// This class extends the behavior of the Entry control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EntryLineValidationBehaviour : BehaviorBase<Entry>
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
        /// Gets or Sets the IsValid
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

        #region Methods

        /// <summary>
        /// This method for store the place holder color value
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            this.AssociatedObject.Focused += this.AssociatedObject_Focused;
        }

        private void AssociatedObject_Focused(object sender, FocusEventArgs e)
        {
            this.IsValid = true;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            this.AssociatedObject.Focused -= this.AssociatedObject_Focused;
        }

        #endregion

    }
}
