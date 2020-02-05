using EssentialUIKit.Models.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{

    /// <summary>
    /// ViewModel for movies page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MoviesPageViewModel :  BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MoviesPageViewModel"/> class.
        /// </summary>
        public MoviesPageViewModel()
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
        /// Gets or sets a collction of value to be displayed in movies list page.
        /// </summary>
        [DataMember(Name = "moviesPageList")]
        public ObservableCollection<Movie> MoviesList { get; set; }
 
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the movies list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion


    }
}
