using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.About;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.About
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AboutUsViewModel : BaseViewModel
    {
        #region Fields

        private static AboutUsViewModel aboutUsViewModel;

        private string productDescription;

        private string productVersion;

        private string productIcon;

        private string bannerImage;

        private Command itemSelectedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:EssentialUIKit.ViewModels.About.AboutUsViewModel"/> class.
        /// </summary>
        static AboutUsViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of about us page view model.
        /// </summary>
        public static AboutUsViewModel BindingContext =>
            aboutUsViewModel = PopulateData<AboutUsViewModel>("about.json");

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        [DataMember(Name = "bannerImage")]
        public string BannerImage
        {
            get
            {
                return App.ImageServerPath + this.bannerImage;
            }

            set
            {
                this.SetProperty(ref this.bannerImage, value);
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        [DataMember(Name = "productDescription")]
        public string ProductDescription
        {
            get
            {
                return this.productDescription;
            }

            set
            {
                this.SetProperty(ref this.productDescription, value);
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        [DataMember(Name = "productIcon")]
        public string ProductIcon
        {
            get
            {
                return App.ImageServerPath + this.productIcon;
            }

            set
            {
                this.SetProperty(ref this.productIcon, value);
            }
        }

        /// <summary>
        /// Gets or sets the product version.
        /// </summary>
        /// <value>The product version.</value>
        [DataMember(Name = "productVersion")]
        public string ProductVersion
        {
            get
            {
                return this.productVersion;
            }

            set
            {
                this.SetProperty(ref this.productVersion, value);
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        [DataMember(Name = "employeeDetails")]
        public ObservableCollection<AboutUsModel> EmployeeDetails { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected));
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
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}