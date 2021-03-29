using EssentialUIKit.Validators;
using EssentialUIKit.Validators.Rules;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AddProfileViewModel : BaseViewModel
    {
        #region Fields

        private ValidatableObject<string> firstName;

        private ValidatableObject<string> lastName;

        private Command<object> addContactCommand;

        private Command<object> addProfileCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializing the profile details.
        /// </summary>
        public AddProfileViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public ValidatableObject<string> FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.firstName == value)
                {
                    return;
                }

                this.SetProperty(ref this.firstName, value);
            }
        }

        /// <summary>
        /// Gets or Sets the LastName
        /// </summary>
        public ValidatableObject<string> LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.lastName == value)
                {
                    return;
                }

                this.SetProperty(ref this.lastName, value);
            }
        }

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
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.FirstName = new ValidatableObject<string>();
            this.LastName = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation rules for name fields
        /// </summary>
        private void AddValidationRules()
        {
            this.FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
            this.LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
        }

        /// <summary>
        /// Check the names are null or empty.
        /// </summary>
        /// <returns></returns>
        public bool AreNamesValid()
        {
            bool isFirstNameValid = this.FirstName.Validate();
            bool isLastNameValid = this.LastName.Validate();
            return isFirstNameValid && isLastNameValid;
        }

        /// <summary>
        /// Invoked when add contact button is clicked from the add profile page.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void AddContactClicked(object obj)
        {
            if (this.AreNamesValid())
            {
                // Do Something
            }
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
