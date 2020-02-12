using System;
using System.Windows.Input;
using Syncfusion.XForms.Expander;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the SfExpander Control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ExpanderCommandBehavior : Behavior<SfExpander>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ExpanderCommandBehavior));

        /// <summary>
        /// Gets or sets the CommandParameterProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ExpanderCommandBehavior));

        /// <summary>
        /// Gets or sets the child element Property, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty ChildElementProperty =
            BindableProperty.Create(nameof(ChildElement), typeof(object), typeof(ExpanderCommandBehavior));

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
        /// Gets or sets the Child element.
        /// </summary>
        public object ChildElement
        {
            get { return this.GetValue(ChildElementProperty); }
            set { this.SetValue(ChildElementProperty, value); }
        }

        /// <summary>
        /// Gets the SegmentedControl.
        /// </summary>
        public SfExpander ExpanderControl { get; private set; }

        #endregion

        #region Method

        /// <summary>
        /// Invoked when adding segmentedControl to the view.
        /// </summary>
        /// <param name="expander">Segmented Control</param>
        protected override void OnAttachedTo(SfExpander expander)
        {
            if (expander != null)
            {
                base.OnAttachedTo(expander);
                this.ExpanderControl = expander;
                expander.BindingContextChanged += this.OnBindingContextChanged;
                expander.Expanded += Expander_Expanded;
                expander.Collapsed += Expander_Collapsed;
            }
        }


        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="expander">Segmented Control</param>
        protected override void OnDetachingFrom(SfExpander expander)
        {
            if (expander != null)
            {
                base.OnDetachingFrom(expander);
                expander.BindingContextChanged -= this.OnBindingContextChanged;
                expander.Expanded -= this.Expander_Expanded;
                expander.Collapsed -= Expander_Collapsed;
                this.ExpanderControl = null;
            }
        }

        /// <summary>
        /// Invoked when segmentedControl binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.ExpanderControl.BindingContext;

            // Set animation for header content.
            if (this.ExpanderControl != null && this.ExpanderControl.IsExpanded)
            {
                SetAnimation(this.ExpanderControl);
            }
        }

        /// <summary>
        /// Invoked when selection is changed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Selection Changed Event Args</param>
        private void Expander_Expanded(object sender, ExpandedAndCollapsedEventArgs e)
        {
            // Set default value for header content
            SetDefaultValue();

            // Set animation for header content.
            if(sender != null && sender is SfExpander)
            {
                SetAnimation(sender as SfExpander);
            }

            if (this.Command == null)
            {
                return;
            }

            if (this.Command.CanExecute(CommandParameter))
            {
                this.Command.Execute(CommandParameter);
            }
        }

        /// <summary>
        /// Set animation for header content.
        /// </summary>
        private void SetAnimation(SfExpander expander)
        {
            var expanderHeader = (expander as SfExpander).Header as Grid;
            if (expanderHeader != null && expanderHeader.Children != null && expanderHeader.Children.Count > 0)
            {
                var headerContent = expanderHeader.Children[0];
                headerContent.ScaleTo(1.25, 350, Easing.Linear);
                headerContent.TranslateTo(5, 0, 350, Easing.Linear);
            }
        }

        /// <summary>
        /// Set default value for header content.
        /// </summary>
        private void SetDefaultValue(SfExpander expander = null)
        {
            if (expander != null)
            {
                var expanderHeader = (expander as SfExpander).Header as Grid;
                if (expanderHeader != null && expanderHeader.Children != null && expanderHeader.Children.Count > 0)
                {
                    var headerContent = expanderHeader.Children[0];
                    headerContent.ScaleTo(1, 350, Easing.Linear);
                    headerContent.TranslateTo(0, 0, 350, Easing.Linear);
                }
            }
            else
            {
                if(this.ChildElement != null)
                {
                    var parentLayout = this.ChildElement as StackLayout;
                    if (parentLayout != null && parentLayout.Children != null && parentLayout.Children.Count >0 && parentLayout.Children[0] is Frame)
                    {
                        foreach (Frame frame in parentLayout.Children)
                        {
                            expander = frame.Content as SfExpander;
                            if (expander != null && expander.IsExpanded)
                            {
                                var expanderHeader = (expander as SfExpander).Header as Grid;
                                if (expanderHeader != null && expanderHeader.Children != null && expanderHeader.Children.Count > 0)
                                {
                                    var headerContent = expanderHeader.Children[0];
                                    headerContent.ScaleTo(1, 350, Easing.Linear);
                                    headerContent.TranslateTo(0, 0, 350, Easing.Linear);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Invoked when expander is collapsed.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Expander Collapsed Event Args</param>
        private void Expander_Collapsed(object sender, ExpandedAndCollapsedEventArgs e)
        {
            // Set default value for header content after collapsed.
            if (sender != null && sender is SfExpander)
            {
                SetDefaultValue(sender as SfExpander);
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