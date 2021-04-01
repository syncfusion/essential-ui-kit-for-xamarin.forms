using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.Feedback;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Feedback
{
    /// <summary>
    /// ViewModel for feedback page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class FeedbackViewModel : BaseViewModel
    {
        #region Fields  

        private static FeedbackViewModel feedbackViewModel;

        private Command filterCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        #endregion

        #region Constructor

        public FeedbackViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of feedback view model.
        /// </summary>
        public static FeedbackViewModel BindingContext =>
            feedbackViewModel = PopulateData<FeedbackViewModel>("feedback.json");

        /// <summary>
        /// Gets or sets the value for feedback info.
        /// </summary>
        [DataMember(Name = "feedbackInfo")]
        public ObservableCollection<Review> FeedbackInfo { get; set; }

        /// <summary>
        /// Gets the value for filter command.
        /// </summary>
        public Command FilterCommand
        {
            get
            {
                return this.filterCommand ?? (this.filterCommand = new Command(this.OnFilterTapped));
            }
        }

        /// <summary>
        /// Gets the value for sort command.
        /// </summary>
        public Command SortCommand
        {
            get
            {
                return this.sortCommand ?? (this.sortCommand = new Command(this.OnSortTapped));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
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
        /// Invoked when the sort button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnSortTapped(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the filter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnFilterTapped(object obj)
        {
            // Do something
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