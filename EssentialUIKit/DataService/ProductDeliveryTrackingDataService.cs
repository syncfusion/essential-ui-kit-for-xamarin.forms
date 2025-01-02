using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Tracking;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ProductDeliveryTrackingDataService
    {
        #region fields

        private static ProductDeliveryTrackingDataService instance;

        private ProductDeliveryTrackingViewModel productDeliveryTrackingViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="ProductDeliveryTrackingDataService"/> class.
        /// </summary>
        private ProductDeliveryTrackingDataService()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="ProductDeliveryTrackingDataService"/>.
        /// </summary>
        public static ProductDeliveryTrackingDataService Instance => instance ?? (instance = new ProductDeliveryTrackingDataService());

        /// <summary>
        /// Gets or sets the value of product delivery tracking page view model.
        /// </summary>
        public ProductDeliveryTrackingViewModel ProductDeliveryTrackingViewModel =>
            (this.productDeliveryTrackingViewModel = PopulateData<ProductDeliveryTrackingViewModel>("deliverytracking.json"));

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
