using System;
using Xamarin.Forms;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    public class AddContactViewModel : LoginViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="AddContactViewModel" /> class.
        /// </summary>
        public AddContactViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitButtonClicked);
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the first name from user in the Add Contact page.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the last name from user in the Add Contact page.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker that gets the date from user in the Add Contact page.
        /// </summary>
        public DateTime Date{ get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a combo box that gets the gender from user in the Add Contact page.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the phone number from user in the Add Contact page.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Address from user in the Add Contact page.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the city from user in the Add Contact page.
        /// </summary>
        public string City { get; set; }

        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command that will be executed when the submit button is clicked.
        /// </summary>
        public Command SubmitCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the submit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SubmitButtonClicked(object obj)
        {
            // Do something
        }

        #endregion

    }
}
