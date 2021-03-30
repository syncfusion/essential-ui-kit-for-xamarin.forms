using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.Detail;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// View model for data table 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DataTableViewModel : BaseViewModel
    {
        #region Fields

        private static DataTableViewModel dataTableViewModel;

        private List<DataTableModel> listItems;

        private Command itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableViewModel" /> class.
        /// </summary>
        public DataTableViewModel()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of data table view model.
        /// </summary>
        public static DataTableViewModel BindingContext =>
            dataTableViewModel = PopulateData<DataTableViewModel>("detail.json");

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the items.
        /// </summary>
        [DataMember(Name = "dataTableList")]
        public List<DataTableModel> ListItems
        {
            get
            {
                return this.listItems;
            }

            set
            {
                if (this.listItems == value)
                {
                    return;
                }

                this.SetProperty(ref this.listItems, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that will be executed when the Comment button is clicked.
        /// </summary>
        public Command ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command(this.ItemClicked));
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

        private void ItemClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
