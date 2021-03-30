using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the SfButton while deleting the list item with animation support.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ItemTemplateButtonBehavior : Behavior<SfButton>
    {
        #region Binable Properties

        /// <summary>
        /// Bindable property to set the CommandProperty, and it is a bindable property..
        /// </summary>
        public static readonly BindableProperty CommandProperty =
             BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Bindable property to set the CommandParameterProperty, and it is a bindable property..
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
         BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Bindable property to set the ParentEelementProperty, and it is a bindable property..
        /// </summary>
        public static readonly BindableProperty ChildElementProperty =
         BindableProperty.Create(nameof(ChildElement), typeof(object), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Bindable property to set the ChildEelementProperty, and it is a bindable property..
        /// </summary>
        public static readonly BindableProperty ParentElementProperty =
         BindableProperty.Create(nameof(ParentElement), typeof(object), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Gets or sets the selected index.
        /// </summary>
        private int selectedIndex;

        /// <summary>
        /// Gets or sets the items count.
        /// </summary>
        private int childrenCount;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Command parameter.
        /// </summary>
        public object CommandParameter
        {
            get { return this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Parent element.
        /// </summary>
        public object ParentElement
        {
            get { return this.GetValue(ParentElementProperty); }
            set { this.SetValue(ParentElementProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Child element.
        /// </summary>
        public object ChildElement
        {
            get { return this.GetValue(ChildElementProperty); }
            set { this.SetValue(ChildElementProperty, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding sfbutton to view.
        /// </summary>
        /// <param name="button">The button</param>
        protected override void OnAttachedTo(SfButton button)
        {
            if (button != null)
            {
                base.OnAttachedTo(button);
                button.Clicked += this.Button_Clicked;
            }
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="button">The button</param>
        protected override void OnDetachingFrom(SfButton button)
        {
            if (button != null)
            {
                base.OnDetachingFrom(button);
                button.Clicked -= this.Button_Clicked;
            }
        }

        /// <summary>
        /// Invoked when button is clicked.
        /// </summary>
        /// <param name="sender">The sender</param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            SfButton button = sender as SfButton;

            // Animate the item when remove from list.
            if (this.ParentElement != null && this.ChildElement != null)
            {
                StackLayout mainStack = null;
                SfListView mainListview = null;
                var selectedElement = this.ChildElement as Grid;
                if (this.ParentElement is StackLayout)
                {
                    mainStack = this.ParentElement as StackLayout;
                    this.selectedIndex = mainStack.Children.IndexOf(selectedElement);
                    this.childrenCount = mainStack.Children.Count;
                }
                else if (this.ParentElement is SfListView)
                {
                    mainListview = this.ParentElement as SfListView;
                    this.selectedIndex = mainListview.Children.IndexOf(selectedElement);
                    this.childrenCount = mainListview.Children.Count;
                }

                if (mainStack != null || mainListview != null)
                {
                    await selectedElement.TranslateTo(-100, 0, 200).ConfigureAwait(true);
                    await selectedElement.FadeTo(0, 20).ConfigureAwait(true);

                    List<Task> animations = new List<Task>();

                    for (int i = this.selectedIndex + 1; i < this.childrenCount; i++)
                    {
                        VisualElement elementToMove;
                        elementToMove = mainStack == null ? mainListview.Children[i] : mainStack.Children[i];
                        var boundsToMoveTo = elementToMove.Bounds;
                        boundsToMoveTo.Top -= selectedElement.Height;
                        animations.Add(elementToMove.LayoutTo(boundsToMoveTo, 200, Easing.Linear));
                    }

                    await selectedElement.FadeTo(0, 20).ConfigureAwait(true);
                    await Task.WhenAll(animations).ConfigureAwait(true);
                }
            }

            if (this.Command == null)
            {
                return;
            }

            this.Command.Execute(button.CommandParameter);
        }

        #endregion
    }
}
