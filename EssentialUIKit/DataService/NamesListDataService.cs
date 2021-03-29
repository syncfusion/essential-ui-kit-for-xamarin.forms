using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Navigation;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NamesListDataService
    {
        #region fields 

        private static NamesListDataService namesListDataService;

        private NamesListViewModel namesViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="NamesListDataService"/>.
        /// </summary>
        public static NamesListDataService Instance => namesListDataService ?? (namesListDataService = new NamesListDataService());

        /// <summary>
        /// Gets or sets the value of names list page view model.
        /// </summary>
        public NamesListViewModel NamesListViewModel =>
            this.namesViewModel ??
            (this.namesViewModel = PopulateData<NamesListViewModel>("navigation.json"));

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

        #endregion

    }
}
