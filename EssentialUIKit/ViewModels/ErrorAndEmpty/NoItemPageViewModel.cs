using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ErrorAndEmpty
{
    /// <summary>
    /// ViewModel for no item page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NoItemPageViewModel : BaseViewModel
    {
        #region Fields

        private static NoItemPageViewModel noItemPageViewModel;

        private string imagePath;

        private string header;

        private string content;

        private Command goBackCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NoItemPageViewModel" /> class.
        /// </summary>
        static NoItemPageViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of no items page view model.
        /// </summary>
        public static NoItemPageViewModel BindingContext =>
            noItemPageViewModel = PopulateData<NoItemPageViewModel>("errorAndEmpty.json");

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        [DataMember(Name = "noItemImagePath")]
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
        [DataMember(Name = "noItemHeader")]
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
        [DataMember(Name = "noItemContent")]
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
        /// Gets or sets the command that is executed when the Go back button is clicked.
        /// </summary>
        public Command GoBackCommand
        {
            get
            {
                return this.goBackCommand ?? (this.goBackCommand = new Command(this.GoBack));
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
        /// Invoked when the Go back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GoBack(object obj)
        {
            // Do something
        }

        #endregion
    }
}
