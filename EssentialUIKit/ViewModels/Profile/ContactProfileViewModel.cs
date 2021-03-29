using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.UserProfile;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for Individual profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ContactProfileViewModel : BaseViewModel
    {
        #region Field

        private static ContactProfileViewModel contactProfileViewModel;

        private ObservableCollection<Model> profileInfo;

        private string profileImage;

        private Command statusCommand;

        private Command editCommand;

        private Command viewAllCommand;

        private Command mediaImageCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ContactProfileViewModel" /> class.
        /// </summary>
        static ContactProfileViewModel()
        {
        }

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the value of contact profile view model.
        /// </summary>
        public static ContactProfileViewModel BindingContext =>
            contactProfileViewModel = PopulateData<ContactProfileViewModel>("profile.json");

        /// <summary>
        /// Gets or sets a collection of profile info.
        /// </summary>
        [DataMember(Name = "profileInfo")]
        public ObservableCollection<Model> ProfileInfo
        {
            get
            {
                return this.profileInfo;
            }

            set
            {
                this.SetProperty(ref this.profileInfo, value);
            }
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        [DataMember(Name = "contactProfileImage")]
        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the status of the profile is clicked.
        /// </summary>
        public Command StatusCommand
        {
            get
            {
                return this.statusCommand ?? (this.statusCommand = new Command(this.StatusClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand
        {
            get
            {
                return this.editCommand ?? (this.editCommand = new Command(this.EditButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the view all button is clicked.
        /// </summary>
        public Command ViewAllCommand
        {
            get
            {
                return this.viewAllCommand ?? (this.viewAllCommand = new Command(this.ViewAllButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the media image is clicked.
        /// </summary>
        public Command MediaImageCommand
        {
            get
            {
                return this.mediaImageCommand ?? (this.mediaImageCommand = new Command(this.MediaImageClicked));
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
        /// Invoked when the status of the profile is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void StatusClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the edit button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the view all button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ViewAllButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the media image is clicked.
        /// </summary>
        private void MediaImageClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}