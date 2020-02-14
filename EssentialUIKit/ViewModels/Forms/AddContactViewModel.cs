using EssentialUIKit.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    public class AddContactViewModel : LoginViewModel
    {
        #region Fields

        private object country;

        private object state;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="AddContactViewModel" /> class.
        /// </summary>
        public AddContactViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitButtonClicked);

            Countries = new List<CountryModel>();
            Countries.Add(new CountryModel()
            {
                Country = "Australia",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Brazil",
                States = new string[] { "Bahia", "Ceara", "Goias", "Maranhao" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Canada",
                States = new string[] { "Manitoba", "Ontario", "Quebec", "Yukon" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "India",
                States = new string[] { "Assam", "Gujarat", "Haryana", "Tamil Nadu" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "USA",
                States = new string[] { "California", "Florida", "New York", "Washington" }
            });
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

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the Country from user.
        /// </summary>
        public object Country
        {
            get { return country; }
            set
            {
                country = value;
                State = null;
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the State from user.
        /// </summary>
        public object State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the collection property, which contains the countries data. 
        /// </summary>
        public List<CountryModel> Countries { get; set; }

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
