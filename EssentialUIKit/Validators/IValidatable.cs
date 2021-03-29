using System.Collections.Generic;
using System.ComponentModel;

namespace EssentialUIKit.Validators
{
    /// <summary>
    /// this interface used for validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatable<T> : INotifyPropertyChanged
    {
        #region Property

        /// <summary>
        /// Gets or Sets the Validations
        /// </summary>
        List<IValidationRule<T>> Validations { get; }

        /// <summary>
        /// Gets or Sets the Errors
        /// </summary>
        List<string> Errors { get; }

        /// <summary>
        /// Gets or Sets the IsValid
        /// </summary>
        bool IsValid { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// method for check the email
        /// </summary>
        /// <returns>returns bool value</returns>
        bool Validate();

        #endregion
    }
}
