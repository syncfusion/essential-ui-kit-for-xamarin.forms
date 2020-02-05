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
    public class FAQDataService
    {
        #region fields

        private static FAQDataService instance;

        private FAQViewModel FAQsViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="FAQDataService"/>.
        /// </summary>
        public static FAQDataService Instance => instance ?? (instance = new FAQDataService());

        /// <summary>
        /// Gets or sets the value of FAQ page view model.
        /// </summary>
        public FAQViewModel FAQViewModel =>
            this.FAQsViewModel ??
            (this.FAQsViewModel = PopulateData<FAQViewModel>("navigation.json"));

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