using EssentialUIKit.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for Business Registration Form page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class BusinessRegistrationFormViewModel : BaseViewModel
    {

        #region Fields

        private object country;

        private object state;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRegistrationFormViewModel" /> class
        /// </summary>
        public BusinessRegistrationFormViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitClicked);

            Countries = new List<BusinessRegistrationFormModel>();
            Countries.Add(new BusinessRegistrationFormModel()
            {
                Country = "Australia",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" }
            });
            Countries.Add(new BusinessRegistrationFormModel()
            {
                Country = "Brazil",
                States = new string[] { "Bahia", "Ceara", "Goias", "Maranhao" }
            });
            Countries.Add(new BusinessRegistrationFormModel()
            {
                Country = "Canada",
                States = new string[] { "Manitoba", "Ontario", "Quebec", "Yukon" }
            });
            Countries.Add(new BusinessRegistrationFormModel()
            {
                Country = "India",
                States = new string[] { "Assam", "Gujarat", "Haryana", "Tamil Nadu" }
            });
            Countries.Add(new BusinessRegistrationFormModel()
            {
                Country = "USA",
                States = new string[] { "California", "Florida", "New York", "Washington" }
            });
        }
        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Full Name from user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Business Name from user.
        /// </summary>
        public string BusinessName { get; set; }
        
        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the Business from user.
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Email ID from user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Phone Number from user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the Street Address from user.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the City from user.
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
        public List<BusinessRegistrationFormModel> Countries { get; set; }


        #endregion 

        #region Comments

        /// <summary>
        /// Gets or sets the command is executed when the Submit button is clicked.
        /// </summary>
        public Command SubmitCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Submit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SubmitClicked(Object obj)
        {

        }

        #endregion
    }
}