using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ErrorAndEmpty
{
    /// <summary>
    /// ViewModel for payment failed page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class PaymentFailedPageViewModel : BaseViewModel
    {
        #region Fields

        private static PaymentFailedPageViewModel paymentFailedPageViewModel;

        private string imagePath;

        private string header;

        private string content;

        private Command tryAgain;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="PaymentFailedPageViewModel" /> class.
        /// </summary>
        public PaymentFailedPageViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of payment page view model.
        /// </summary>
        public static PaymentFailedPageViewModel BindingContext =>
            paymentFailedPageViewModel = PopulateData<PaymentFailedPageViewModel>("errorAndEmpty.json");

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        [DataMember(Name = "paymentFailedImagePath")]
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.SetProperty(ref this.imagePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        [DataMember(Name = "paymentFailedHeader")]
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                this.SetProperty(ref this.header, value);
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        [DataMember(Name = "paymentFailedContent")]
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.SetProperty(ref this.content, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the Try again button is clicked.
        /// </summary>
        public Command TryAgainCommand
        {
            get
            {
                return this.tryAgain ?? (this.tryAgain = new Command(this.TryAgain));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "EssentialUIKit.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        /// <summary>
        /// Invoked when the Try again button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void TryAgain(object obj)
        {
            // Do something
        }

        #endregion
    }
}
