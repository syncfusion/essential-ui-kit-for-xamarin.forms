using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public static BindableProperty CommandParameterProperty =
         BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Bindable property to set the ParentEelementProperty, and it is a bindable property..
        /// </summary>
        public static BindableProperty ChildElementProperty =
         BindableProperty.Create(nameof(ChildElement), typeof(object), typeof(ItemTemplateButtonBehavior));

        /// <summary>
        /// Bindable property to set the ChildEelementProperty, and it is a bindable property..
        /// </summary>
        public static BindableProperty ParentElementProperty =
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
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Command parameter.
        /// </summary>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Parent element.
        /// </summary>
        public object ParentElement
        {
            get { return GetValue(ParentElementProperty); }
            set { this.SetValue(ParentElementProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Child element.
        /// </summary>
        public object ChildElement
        {
            get { return GetValue(ChildElementProperty); }
            set { this.SetValue(ChildElementProperty, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding sfbutton to view.
        /// </summary>
        /// <param name="comboBox">The ComboBox</param>
        protected override void OnAttachedTo(SfButton button)
        {
            if (button != null)
            {
                base.OnAttachedTo(button);
                button.Clicked += Button_Clicked;
            }
        }
        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="comboBox">The comboBox</param>
        protected override void OnDetachingFrom(SfButton button)
        {
            if (button != null)
            {
                base.OnDetachingFrom(button);
                button.Clicked -= Button_Clicked;
            }
        }

        /// <summary>
        /// Invoked when button is clicked.
        /// </summary>
        /// <param name="comboBox">The comboBox</param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            SfButton sfButton = sender as SfButton;
           
            // Animate the item when remove from list.
            if (ParentElement != null && ChildElement != null)
            {
                StackLayout mainStack = null;
                SfListView mainListview = null;
                var selectedElement = ChildElement as Grid;
                if (ParentElement is StackLayout)
                {
                    mainStack = ParentElement as StackLayout; 
                    selectedIndex = mainStack.Children.IndexOf(selectedElement);
                    childrenCount = mainStack.Children.Count;
                }
                else if (ParentElement is SfListView)
                {
                    mainListview = ParentElement as SfListView;
                    selectedIndex = mainListview.Children.IndexOf(selectedElement);
                    childrenCount = mainListview.Children.Count;
                }
                if (mainStack != null || mainListview != null)
                {
                    await selectedElement.TranslateTo(-100, 0, 100);
                    await selectedElement.FadeTo(0, 20);

                    List<Task> animations = new List<Task>();

                    for (int i = selectedIndex + 1; i < childrenCount; i++)
                    {
                        VisualElement elementToMove;
                        elementToMove = mainStack == null? mainListview.Children[i] : mainStack.Children[i];
                        var boundsToMoveTo = elementToMove.Bounds;
                        boundsToMoveTo.Top -= selectedElement.Height;
                        animations.Add(elementToMove.LayoutTo(boundsToMoveTo, 200, Easing.Linear));
                    }
                    await selectedElement.FadeTo(0, 20);
                    await Task.WhenAll(animations);
                }
            }

            if (this.Command == null)
                return;
            this.Command.Execute(sfButton.CommandParameter);
        }
        
        #endregion
    }
}
