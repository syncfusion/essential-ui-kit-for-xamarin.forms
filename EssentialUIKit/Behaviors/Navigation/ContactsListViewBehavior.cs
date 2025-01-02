using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Syncfusion.DataSource;
using System.Globalization;

namespace EssentialUIKit.Behaviors.Navigation
{
    /// <summary>
    /// This class extends the behavior of SfListView control to group the contact names list in alphabetical order.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactsListViewBehavior : Behavior<Syncfusion.ListView.XForms.SfListView>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView listView;

        #endregion

        #region Overrides
        /// <summary>
        /// Invoked when adding the SfListView to view.
        /// </summary>
        /// <param name="bindable">The SfListView</param>

        protected override void OnAttachedTo(Syncfusion.ListView.XForms.SfListView bindable)
        {
            if (bindable != null)
            {
                listView = bindable;
                listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
                {
                    PropertyName = "Name",
                    KeySelector = (object obj1) =>
                    {
                        var item = (obj1 as Models.Navigation.Contact);
                        return item.Name[0].ToString(CultureInfo.CurrentCulture);
                    },
                });
                base.OnAttachedTo(bindable);
            }
        }

        /// <summary>
        /// Invoked when the list view is detached. 
        /// </summary>
        /// <param name="bindable">The SfListView</param>

        protected override void OnDetachingFrom(Syncfusion.ListView.XForms.SfListView bindable)
        {
            listView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }
}