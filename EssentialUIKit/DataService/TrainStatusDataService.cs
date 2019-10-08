using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Tracking;

namespace EssentialUIKit.DataService
{
    public class TrainStatusDataService
    {
        #region Fields

        private static TrainStatusDataService instance;

        private TrainStatusPageViewModel trainStatusPageViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="TrainStatusDataService"/>.
        /// </summary>
        public static TrainStatusDataService Instance => instance ?? (instance = new TrainStatusDataService());

        /// <summary>
        /// Gets or sets the value of train status page view model.
        /// </summary>
        public TrainStatusPageViewModel TrainStatusPageViewModel =>
            (this.trainStatusPageViewModel = PopulateData<TrainStatusPageViewModel>("trainstatus.json"));

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
