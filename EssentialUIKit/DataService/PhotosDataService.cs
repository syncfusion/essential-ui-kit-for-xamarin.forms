using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Navigation;

namespace EssentialUIKit.DataService
{
    public class PhotosDataService
    {
        #region fields

        private static PhotosDataService instance;

        private PhotosViewModel photosViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="PhotosDataService"/>.
        /// </summary>
        public static PhotosDataService Instance => instance ?? (instance = new PhotosDataService());

        /// <summary>
        /// Gets or sets the value of navigation page view model.
        /// </summary>
        public PhotosViewModel PhotosViewModel =>
            this.photosViewModel ??
            (this.photosViewModel = PopulateData<PhotosViewModel>("navigation.json"));

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
