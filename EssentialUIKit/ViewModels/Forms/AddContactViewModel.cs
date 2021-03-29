using System;
using EssentialUIKit.Validators;
using EssentialUIKit.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add contact page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AddContactViewModel : LoginViewModel
    {
        #region Fields

        private DateTime date = DateTime.Now;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="AddContactViewModel" /> class.
        /// </summary>
        public AddContactViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.SubmitCommand = new Command(this.SubmitButtonClicked);
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the first name from user in the Add Contact page.
        /// </summary>
        public ValidatableObject<string> FirstName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the last name from user in the Add Contact page.
        /// </summary>
        public ValidatableObject<string> LastName { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker that gets the date from user in the Add Contact page.
        /// </summary>
        public DateTime Date 
        {
            get
            {
                return this.date;
            }

            set
            {
                if (this.date == value)
                {
                    return;
                }

                this.SetProperty(ref this.date, value);
            }
        }

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
        /// Intialize the methods for validation
        /// </summary>
        private void InitializeProperties()
        {
            this.FirstName = new ValidatableObject<string>();
            this.LastName = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation Rules for firstname and lastname
        /// </summary>
        private void AddValidationRules()
        {
            this.FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
            this.LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
        }

        /// <summary>
        /// check the fields are valid or not
        /// </summary>
        /// <returns>returns bool value</returns>
        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isFirstNameValid = this.FirstName.Validate();
            bool isLastNameValid = this.LastName.Validate();
            return isFirstNameValid && isLastNameValid && isEmailValid;
        }

        /// <summary>
        /// Invoked when the submit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SubmitButtonClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                // Do Something
            }
        }

        #endregion
    }
}
