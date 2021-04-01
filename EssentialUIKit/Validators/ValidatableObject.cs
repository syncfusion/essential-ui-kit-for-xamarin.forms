using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Validators
{
    /// <summary>
    /// This class contains the method to validate the fields
    /// </summary>
    /// <typeparam name="T">Validatable object parameter</typeparam>
    [Preserve(AllMembers = true)]
    public class ValidatableObject<T> : IValidatable<T>
    {
        #region Fields

        /// <summary>
        /// Gets or Sets IsValid
        /// </summary>
        private bool isValid = true;

        /// <summary>
        /// Gets or Sets errors
        /// </summary>
        private List<string> errors = new List<string>();

        /// <summary>
        /// Gets or Sets CleanOnChange
        /// </summary>
        private bool cleanOnChange = true;

        /// <summary>
        /// Gets or Sets value
        /// </summary>
        private T value;

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        /// <summary>
        /// Gets or Sets the Validations
        /// </summary>
        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();

        /// <summary>
        /// Gets or Sets the Errors
        /// </summary>
        public List<string> Errors
        {
            get
            {
                return this.errors;
            }

            private set
            {
                this.errors = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is clean on change.
        /// </summary>
        public bool CleanOnChange
        {
            get
            {
                return this.cleanOnChange;
            }

            set
            {
                this.cleanOnChange = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public T Value
        {
            get => this.value;
            set
            {
                this.value = value;

                if (this.CleanOnChange)
                {
                    this.IsValid = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is valid or not.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }

            set
            {
                this.isValid = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// this method for validate the email
        /// </summary>
        /// <returns>returns bool value</returns>
        public virtual bool Validate()
        {
            this.Errors.Clear();

            IEnumerable<string> errors = this.Validations.Where(v => !v.Check(this.Value))
                .Select(v => v.ValidationMessage);

            this.Errors = errors.ToList();
            this.IsValid = !this.Errors.Any();

            return this.IsValid;
        }

        public override string ToString()
        {
            return $"{this.Value}";
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
