namespace EssentialUIKit.Validators
{
    /// <summary>
    /// this interface used for validation 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationRule<T>
    {
        #region Property

        /// <summary>
        /// Gets or Sets the Validation Message.
        /// </summary>
        string ValidationMessage { get; set; }

        #endregion

        #region Method

        /// <summary>
        /// method for check the email
        /// </summary>
        /// <param name="value"></param>
        /// <returns>returns bool value</returns>
        bool Check(T value);

        #endregion
    }
}