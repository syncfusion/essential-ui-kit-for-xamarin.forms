using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Validators
{
    /// <summary>
    /// This class contains the method to have validate the Pair fields
    /// </summary>
    /// <typeparam name="T"></typeparam>  
    [Preserve(AllMembers = true)]
    public class ValidatablePair<T> : IValidatable<ValidatablePair<T>>
    {
        #region Fields

        /// <summary>
        /// Gets or Sets isValid
        /// </summary>
        private bool isValid = true;

        #endregion

        #region PropertyChanged

        /// <summary>
        /// The PropertyChanged event declared.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or Sets the Validation
        /// </summary>
        public List<IValidationRule<ValidatablePair<T>>> Validations { get; } = new List<IValidationRule<ValidatablePair<T>>>();

        /// <summary>
        /// Gets or Sets IsValid
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

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        public List<string> Errors { get; private set; } = new List<string>();

        /// <summary>
        /// Gets or Sets Item1
        /// </summary>
        public ValidatableObject<T> Item1 { get; set; } = new ValidatableObject<T>();

        /// <summary>
        /// Gets or Sets Item2
        /// </summary>
        public ValidatableObject<T> Item2 { get; set; } = new ValidatableObject<T>();

        #endregion

        #region Methods

        /// <summary>
        /// Validate the Items
        /// </summary>
        /// <returns>returns bool value</returns>
        public bool Validate()
        {
            var item1IsValid = this.Item1.Validate();
            var item2IsValid = this.Item2.Validate();
            if (item1IsValid && item2IsValid)
            {
                this.Errors.Clear();
                IEnumerable<string> errors = this.Validations.Where(v => !v.Check(this))
                    .Select(v => v.ValidationMessage);
                this.Errors = errors.ToList();
                this.Item2.Errors.Clear();
                this.Item2.Errors.AddRange(this.Errors);
                this.Item2.IsValid = !this.Errors.Any();
            }

            this.IsValid = !this.Item1.Errors.Any() && !this.Item2.Errors.Any();
            return this.IsValid;
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
