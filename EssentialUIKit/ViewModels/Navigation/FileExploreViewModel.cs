﻿using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for file explorer list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class FileExploreViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command<object> categoryCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="FileExploreViewModel"/> class.
        /// </summary>
        public FileExploreViewModel()
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
        /// Gets the command that will be executed when an category button is selected.
        /// </summary>
        public Command<object> CategoryCommand
        {
            get
            {
                return this.categoryCommand ?? (this.categoryCommand = new Command<object>(this.CategorySelected));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in file explorer list page.
        /// </summary>
        [DataMember(Name = "fileExploreList")]
        public ObservableCollection<File> FileExploreList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the file explorer list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an category is selected from the file explorer list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void CategorySelected(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}