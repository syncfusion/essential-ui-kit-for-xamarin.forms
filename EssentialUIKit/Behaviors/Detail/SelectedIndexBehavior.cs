using System;
using System.Windows.Input;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the SfComboBox to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SelectedIndexBehavior: Behavior<SfComboBox>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SelectedIndexBehavior));

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public SfComboBox ComboBox { get; private set; }

        #endregion

        #region Method

        /// <summary>
        /// Invoked when adding SfComboBox to the view.
        /// </summary>
        /// <param name="comboBox">comboBox Control</param>
        protected override void OnAttachedTo(SfComboBox comboBox)
        {
            if (comboBox != null)
            {
                base.OnAttachedTo(comboBox);
                this.ComboBox = comboBox;
                comboBox.BindingContextChanged += this.OnBindingContextChanged;
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="comboBox">comboBox Control</param>
        protected override void OnDetachingFrom(SfComboBox comboBox)
        {
            if (comboBox != null)
            {
                base.OnDetachingFrom(comboBox);
                comboBox.BindingContextChanged -= this.OnBindingContextChanged;
                comboBox.SelectionChanged -= this.ComboBox_SelectionChanged;
                this.ComboBox = null;
            }
        }

        /// <summary>
        /// Invoked when comboBox Control binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.ComboBox.BindingContext;
        }

        /// <summary>
        /// Invoked when selection is changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Selection Changed Event Args</param>
        private void ComboBox_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {            
            if (this.Command == null)
            {
                return;
            }
            
            if (this.Command.CanExecute(e.Value))
            {
                this.Command.Execute(e.Value);
            }
        }

        /// <summary>
        /// Invoked when binding context is changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.OnBindingContextChanged();
        }
        #endregion

    }
}
