using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EssentialUIKit.ViewModels.Forms
{
    public class AddProfileViewModel
    {
        #region Fields

        private Command<object> addContactCommand;

        private Command<object> addProfileCommand;

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that will be executed when an add profile button is clicked.
        /// </summary>
        public Command<object> AddProfileCommand
        {
            get
            {
                return this.addProfileCommand ?? (this.addProfileCommand = new Command<object>(this.AddProfileClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an add contact button is clicked.
        /// </summary>
        public Command<object> AddContactCommand
        {
            get
            {
                return this.addContactCommand ?? (this.addContactCommand = new Command<object>(this.AddContactClicked));
            }
        }
        #endregion

        #region Method

        /// <summary>
        /// Invoked when add contact button is clicked from the add profile page.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void AddContactClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when add profile button is clicked from the add profile page.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void AddProfileClicked(object obj)
        {
            // Do something
        }

        #endregion

    }
}
