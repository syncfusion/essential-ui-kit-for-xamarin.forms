using EssentialUIKit.Models.Navigation;
using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for suggestion page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SuggestionViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command suggestionCommand;

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
        /// Gets or sets a collection of values to be displayed in the suggestion page.
        /// </summary>
        [DataMember(Name = "suggestionList")]
        public ObservableCollection<Suggestion> SuggestionList { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>   
        public Command SuggestionCommand
        {
            get
            {
                return this.suggestionCommand ?? (this.suggestionCommand = new Command(this.SuggestionClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the suggestion page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the suggestion button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SuggestionClicked(object obj)
        {
            SfButton button = obj as SfButton;
            if (button.Text == "FOLLOW")
            {
                button.Text = "FOLLOWED";
            }
            else if (button.Text == "FOLLOWED")
            {
                button.Text = "FOLLOW";
            }
        }

        #endregion

    }
}
