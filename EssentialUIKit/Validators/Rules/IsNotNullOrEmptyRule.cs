﻿using Xamarin.Forms.Internals;

namespace EssentialUIKit.Validators.Rules
{
    /// <summary>
    /// Validation rule for check the email has empty or null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Preserve(AllMembers = true)]
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the validation Message
        /// </summary>
        public string ValidationMessage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Check the Email has null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns>returns bool value</returns>
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = $"{value }";
            return !string.IsNullOrWhiteSpace(str);
        }
        #endregion

    }
}
