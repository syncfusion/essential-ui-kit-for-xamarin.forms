using System;
using System.Windows.Input;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors.Detail
{
    /// <summary>
    /// This class extends the behavior of the SfSegmentedControl to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SegmentedControlBehavior : Behavior<SfSegmentedControl>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(SegmentedControlBehavior));

        /// <summary>
        /// Gets or sets the CommandParameterProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(SegmentedControlBehavior));

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the CommandParameter.
        /// </summary>
        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets the SegmentedControl.
        /// </summary>
        public SfSegmentedControl SegmentedControl { get; private set; }

        #endregion

        #region Method

        /// <summary>
        /// Invoked when adding segmentedControl to the view.
        /// </summary>
        /// <param name="segmentedControl">Segmented Control</param>
        protected override void OnAttachedTo(SfSegmentedControl segmentedControl)
        {
            base.OnAttachedTo(segmentedControl);
            this.SegmentedControl = segmentedControl;
            segmentedControl.BindingContextChanged += this.OnBindingContextChanged;
            segmentedControl.SelectionChanged += this.OnSelectionChanged;
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="segmentedControl">Segmented Control</param>
        protected override void OnDetachingFrom(SfSegmentedControl segmentedControl)
        {
            base.OnDetachingFrom(segmentedControl);
            segmentedControl.BindingContextChanged -= this.OnBindingContextChanged;
            segmentedControl.SelectionChanged -= this.OnSelectionChanged;
            this.SegmentedControl = null;
        }

        /// <summary>
        /// Invoked when segmentedControl binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.SegmentedControl.BindingContext;
        }

        /// <summary>
        /// Invoked when selection is changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Selection Changed Event Args</param>
        private void OnSelectionChanged(object sender, Syncfusion.XForms.Buttons.SelectionChangedEventArgs e)
        {
            if (this.Command == null)
            {
                return;
            }

            if (this.Command.CanExecute(e))
            {
                this.Command.Execute(e);
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