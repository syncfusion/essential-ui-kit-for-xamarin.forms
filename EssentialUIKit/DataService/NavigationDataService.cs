using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Navigation;

namespace EssentialUIKit.DataService
{
    public class NavigationDataService
    {
        #region fields

        private static NavigationDataService instance;

        private NavigationViewModel navigationViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="NavigationDataService"/>.
        /// </summary>
        public static NavigationDataService Instance => instance ?? (instance = new NavigationDataService());

        /// <summary>
        /// Gets or sets the value of navigation page view model.
        /// </summary>
        public NavigationViewModel NavigationViewModel =>
            this.navigationViewModel ??
            (this.navigationViewModel = PopulateData<NavigationViewModel>("navigation.json"));

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
