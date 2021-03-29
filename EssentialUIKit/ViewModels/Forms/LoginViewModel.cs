using EssentialUIKit.Validators;
using EssentialUIKit.Validators.Rules;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private ValidatableObject<string> email;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginViewModel" /> class.
        /// </summary>
        public LoginViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.SetProperty(ref this.email, value);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Email = new ValidatableObject<string>();
        }

        /// <summary>
        /// This method contains the validation rules
        /// </summary>
        private void AddValidationRules()
        {
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            this.Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
        }

        /// <summary>
        /// This method to validate the email
        /// </summary>
        /// <returns>returns bool value</returns>
        public bool IsEmailFieldValid()
        {
            bool isEmailValid = this.Email.Validate();
            return isEmailValid;
        }
        #endregion
    }
}
