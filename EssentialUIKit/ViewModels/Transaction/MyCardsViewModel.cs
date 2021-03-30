using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.Transaction;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for my cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MyCardsViewModel : BaseViewModel
    {
        #region fields

        private static MyCardsViewModel myCardsViewModel;

        private Command addCardCommand;

        private Command menuCommand;

        #endregion

        #region Constructor 

        public MyCardsViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of my cards page view model.
        /// </summary>
        public static MyCardsViewModel BindingContext =>
            myCardsViewModel = PopulateData<MyCardsViewModel>("transaction.json");

        [DataMember(Name = "cardDetails")]
        public ObservableCollection<Card> CardDetails { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the more button is clicked.
        /// </summary>
        public Command MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command(this.MenuButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand
        {
            get
            {
                return this.addCardCommand ?? (this.addCardCommand = new Command(this.AddCardButtonClicked));
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
        /// Invoked when the more button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddCardButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
