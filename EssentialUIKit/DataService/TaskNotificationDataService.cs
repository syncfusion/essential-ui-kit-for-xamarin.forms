using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Notification;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service for task notification page to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TaskNotificationDataService
    {
        #region fields 

        private static TaskNotificationDataService taskNotificationDataService;

        private TaskNotificationViewModel taskNotificationViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="TaskNotificationDataService"/>.
        /// </summary>
        public static TaskNotificationDataService Instance => taskNotificationDataService ?? (taskNotificationDataService = new TaskNotificationDataService());

        /// <summary>
        /// Gets or sets the value of task notification page view model.
        /// </summary>
        public TaskNotificationViewModel TaskNotificationViewModel =>
            this.taskNotificationViewModel ??
            (this.taskNotificationViewModel = PopulateData<TaskNotificationViewModel>("notification.json"));

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