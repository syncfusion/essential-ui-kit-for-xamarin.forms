using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Navigation;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for app usage page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AppUsageViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="AppUsageViewModel"/> class.
        /// </summary>
        public AppUsageViewModel()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in app usage list page.
        /// </summary>
        [DataMember(Name = "appUsagePageList")]
        public ObservableCollection<AppUsage> AppUsageList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the app usage list page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}