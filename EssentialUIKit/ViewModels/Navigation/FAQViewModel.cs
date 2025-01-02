using EssentialUIKit.Models.Navigation;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for FAQ page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class FAQViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="FAQViewModel"/> class.
        /// </summary>
        public FAQViewModel()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the FAQ page.
        /// </summary>
        [DataMember(Name = "questions")]
        public ObservableCollection<FAQ> Questions { get; set; }

        #endregion

    }
}
