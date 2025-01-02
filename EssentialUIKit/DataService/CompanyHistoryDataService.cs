using EssentialUIKit.ViewModels.Dashboard;
using System.Reflection;
using System.Runtime.Serialization.Json;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CompanyHistoryDataService
    {
        #region fields

        private static CompanyHistoryDataService instance;

        private CompanyHistoryViewModel companyHistoryViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CompanyHistoryDataService"/>.
        /// </summary>
        public static CompanyHistoryDataService Instance => instance ?? (instance = new CompanyHistoryDataService());

        /// <summary>
        /// Gets or sets the value of company history page view model.
        /// </summary>
        public CompanyHistoryViewModel CompanyHistoryViewModel =>
            this.companyHistoryViewModel ??
            (this.companyHistoryViewModel = PopulateData<CompanyHistoryViewModel>("timeline.json"));

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
