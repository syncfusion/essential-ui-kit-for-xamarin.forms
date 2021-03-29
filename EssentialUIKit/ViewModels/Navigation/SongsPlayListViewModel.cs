﻿using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for the Songs play list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SongsPlayListViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemSelectedCommand;

        private Command<object> menuCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SongsPlayListViewModel"/> class.
        /// </summary>
        public SongsPlayListViewModel()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an more button is selected.
        /// </summary>
        public Command<object> MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command<object>(this.MoreButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Songs play list page.
        /// </summary>
        [DataMember(Name = "songsPageList")]
        public ObservableCollection<Song> SongsPageList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the Songs play list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an more button is selected from the Songs play list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void MoreButtonClicked(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}
