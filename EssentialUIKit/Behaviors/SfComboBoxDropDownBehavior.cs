using System;
using System.Reflection;
using System.Windows.Input;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the SfComboBox control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SfComboBoxDropDownBehavior : Behavior<SfComboBox>
    {
       

        #region Binable Properties

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SfComboBoxDropDownBehavior));
        #endregion

        #region Field

        private bool isCheckboxLoaded;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets the comboBox.
        /// </summary>
        public SfComboBox ComboBox { get; private set; }        

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding comboBox to view.
        /// </summary>
        /// <param name="comboBox">The ComboBox</param>
        protected override void OnAttachedTo(SfComboBox comboBox)
        {
            if (comboBox != null)
            {
                base.OnAttachedTo(comboBox);
                this.ComboBox = comboBox;
                comboBox.BindingContextChanged += this.OnBindingContextChanged;
                comboBox.SelectionChanged += this.SelectionChanged;
            }
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="comboBox">The comboBox</param>
        protected override void OnDetachingFrom(SfComboBox comboBox)
        {
            if (comboBox != null)
            {
                base.OnDetachingFrom(comboBox);
                comboBox.BindingContextChanged -= this.OnBindingContextChanged;
                comboBox.SelectionChanged -= this.SelectionChanged;
                this.ComboBox = null;
            }
        }

        /// <summary>
        /// Invoked when comboBox binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.ComboBox.BindingContext;
        }

        /// <summary>
        /// Invoked when selected item is changed.
        /// </summary>
        /// <param name="sender">The comboBox</param>
        /// <param name="e">The selection changed event args</param>
        private void SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            int totalQuantity;
            int.TryParse(e.Value.ToString(), out totalQuantity);

            var bindingContext = (sender as SfComboBox).BindingContext;

            PropertyInfo propertyInfo = bindingContext.GetType().GetProperty("TotalQuantity");
            propertyInfo.SetValue(bindingContext, totalQuantity);
            
            if (this.isCheckboxLoaded)
            {
                if (this.Command == null)
                {
                    return;
                }

                if (this.Command.CanExecute((sender as SfComboBox).BindingContext))
                {
                    this.Command.Execute((sender as SfComboBox).BindingContext);
                }
            }

            this.isCheckboxLoaded = true;
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
