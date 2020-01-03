using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using EssentialUIKit.Models.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation.ContactsViewModel
{
    /// <summary>
    /// ViewModel for Setting page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ContactsViewModel : BaseViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsViewModel" /> class
        /// </summary>
        public ContactsViewModel()
        {
            this.BackButtonCommand = new Command(this.BackButtonClicked);
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }
        #endregion

        #region Method

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }
        #endregion
    }
}