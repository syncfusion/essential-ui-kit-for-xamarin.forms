using EssentialUIKit.ViewModels.Navigation;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SuggestionDataService
    {
        #region fields

        private static SuggestionDataService instance;

        private SuggestionViewModel suggestionViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="SuggestionDataService"/>.
        /// </summary>
        public static SuggestionDataService Instance => instance ?? (instance = new SuggestionDataService());

        /// <summary>
        /// Gets or sets the value of suggestion page view model.
        /// </summary>
        public SuggestionViewModel SuggestionViewModel =>
            this.suggestionViewModel ??
            (this.suggestionViewModel = PopulateData<SuggestionViewModel>("navigation.json"));

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

            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }

        #endregion
    }
}