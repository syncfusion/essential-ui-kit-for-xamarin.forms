using Xamarin.Forms.Internals;

namespace EssentialUIKit.Validators.Rules
{
    /// <summary>
    /// Validation Rule to check the email is valid or not.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Preserve(AllMembers = true)]
    public class IsValidEmailRule<T> : IValidationRule<T>
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the Validation Message
        /// </summary>
        public string ValidationMessage { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// Check the email has valid or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns>returns bool value</returns>
        public bool Check(T value)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress($"{value}");
                return addr.Address == $"{value}";
            }
            catch
            {
                return false;
                throw;
            }
        }
        #endregion
    }
}
