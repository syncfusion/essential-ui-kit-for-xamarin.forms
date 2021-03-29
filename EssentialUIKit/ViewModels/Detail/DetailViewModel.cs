using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.Feedback;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DetailViewModel : BaseViewModel
    {
        #region Fields

        private static DetailViewModel detailViewModel;

        private List<string> images;

        private Command closeCommand;

        private Command profileCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        #endregion

        #region Constrctor

        /// <summary>
        /// Initializes a new instance for the <see cref="DetailViewModel" /> class.
        /// </summary>
        static DetailViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of detail view model.
        /// </summary>
        public static DetailViewModel BindingContext =>
            detailViewModel = PopulateData<DetailViewModel>("detail.json");

        /// <summary>
        /// Gets or sets the value for feedback info.
        /// </summary>
        [DataMember(Name = "feedbackInfo")]
        public ObservableCollection<Review> FeedbackInfo { get; set; }

        /// <summary>
        /// Gets or sets the value for images.
        /// </summary>
        [DataMember(Name = "images")]
        public List<string> Images
        {
            get
            {
                for (var i = 0; i < this.images.Count; i++)
                {
                    this.images[i] = this.images[i].Contains(App.ImageServerPath) ? this.images[i] : App.ImageServerPath + this.images[i];
                }

                return this.images;
            }

            set
            {
                if (this.images == value)
                {
                    return;
                }

                this.SetProperty(ref this.images, value);
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the close button is clicked.
        /// </summary>
        public Command CloseCommand
        {
            get
            {
                return this.closeCommand ?? (this.closeCommand = new Command(this.OnCloseButtonTapped));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the profile is clicked.
        /// </summary>
        public Command ProfileCommand
        {
            get
            {
                return this.profileCommand ?? (this.profileCommand = new Command(this.ProfileClicked));
            }
        }

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

        /// <summary>
        /// Gets or sets the command that will be executed when the sorting button is clicked.
        /// </summary>
        public Command SortCommand
        {
            get
            {
                return this.sortCommand ?? (this.sortCommand = new Command(this.OnSortTapped));
            }
        }

        #endregion

        #region Methods

        // Populates the data for view model from json file.
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
        /// Invoked when the close button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnCloseButtonTapped(object obj)
        {
            // Do Something
        }

        /// <summary>
        /// Invoked when the profile is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ProfileClicked(object obj)
        {
            // Do Something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the sorting button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnSortTapped(object obj)
        {
            // Do something
        }

        #endregion
    }
}
