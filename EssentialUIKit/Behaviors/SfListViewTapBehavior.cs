using System.Windows.Input;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the SfListView to invoke a command when an event occurs.
    /// </summary>
    public class SfListViewTapBehavior : Behavior<SfListView>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SfListViewTapBehavior));

        /// <summary>
        /// Gets or sets the Command.
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        #endregion

        #region Method

        /// <summary>
        /// Invoked when added sflistview to the page.
        /// </summary>
        /// <param name="bindableListView">The SfListView</param>
        protected override void OnAttachedTo(SfListView bindableListView)
        {
            if (bindableListView != null)
            {
                base.OnAttachedTo(bindableListView);
                bindableListView.ItemTapped += this.BindableListView_ItemTapped;
            }
        }
            
        /// <summary>
        /// Invoked when exit from the page.
        /// </summary>
        /// <param name="bindableListView">The SfListView</param>
        protected override void OnDetachingFrom(SfListView bindableListView)
        {
            if (bindableListView != null)
            {
                base.OnDetachingFrom(bindableListView);
                bindableListView.ItemTapped -= this.BindableListView_ItemTapped;
            }
        }

        /// <summary>
        /// Invoked when tapping the listview item.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">ItemTapped EventArgs</param>
        private void BindableListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (this.Command == null)
            {
                return;
            }

            if (this.Command.CanExecute(e.ItemData))
            {
                this.Command.Execute(e.ItemData);
            }
        }

        #endregion
    }
}
