using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EssentialUIKit.Models.Dashboard;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for stock overview page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StockOverviewViewModel : BaseViewModel
    {
        #region Field

        private ObservableCollection<Stock> items;

        private int selectedDataVariantIndex;

        private ObservableCollection<ChartModel> threeMonthData;

        private ObservableCollection<ChartModel> sixMonthData;

        private ObservableCollection<ChartModel> nineMonthData;

        private ObservableCollection<ChartModel> yearData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="StockOverviewViewModel" /> class.
        /// </summary>
        public StockOverviewViewModel()
        {
            this.GetChartData();
            var variants = new List<string> { "3M", "6M", "9M", "1Y" };
            this.items = new ObservableCollection<Stock>()
            {
                new Stock()
                {
                    Category = "NSEI",
                    CategoryValue = 20.35,
                    SubCategory = "NIFTY 50",
                    SubCategoryValue = 6164.34,
                    ChartData = this.sixMonthData,
                    DataVariants = variants,
                    IsSelected = true,
                },
                new Stock()
                {
                    Category = "BSESN",
                    CategoryValue = 26.32,
                    SubCategory = "S&P BSE SENSEX",
                    SubCategoryValue = 5649.43,
                    ChartData = this.sixMonthData,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "AAPL",
                    CategoryValue = 26.32,
                    SubCategory = "APPLE INC",
                    SubCategoryValue = 5649.43,
                    ChartData = this.sixMonthData,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "SBUCX",
                    CategoryValue = 26.32,
                    SubCategory = "STARSSBUCKS CORP",
                    SubCategoryValue = 5649.43,
                    ChartData = this.sixMonthData,
                    DataVariants = variants,
                },
            };

            this.ProfileImage = App.ImageServerPath + "ProfileImage1.png";
            this.DataVariantCommand = new Command(this.DataVariantClicked);
            this.SelectionCommand = new Command(this.ItemClicked);
            this.MenuCommand = new Command(this.MenuButtonClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileImageClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the selected data variant index.
        /// </summary>
        public int SelectedDataVariantIndex
        {
            get
            {
                return this.selectedDataVariantIndex;
            }

            set
            {
                this.SetProperty(ref this.selectedDataVariantIndex, value);
            }
        }

        /// <summary>
        /// Gets the stock items collection.
        /// </summary>
        public ObservableCollection<Stock> Items
        {
            get
            {
                return this.items;
            }

            private set
            {
                this.SetProperty(ref this.items, value);
            }
        }

        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command that will be executed when the data variant for chart is clicked.
        /// </summary>
        public Command DataVariantCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the expand the stock item.
        /// </summary>
        public Command SelectionCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the profile image is clicked.
        /// </summary>
        public Command ProfileSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

            this.sixMonthData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(4), 4508),
                new ChartModel(dateTime.AddDays(6), 4157),
                new ChartModel(dateTime.AddDays(8), 4062),
                new ChartModel(dateTime.AddDays(10), 4587),
                new ChartModel(dateTime.AddDays(12), 4642),
                new ChartModel(dateTime.AddDays(14), 4205),
                new ChartModel(dateTime.AddDays(16), 4678),
                new ChartModel(dateTime.AddDays(18), 4402),
                new ChartModel(dateTime.AddDays(20), 4650),
                new ChartModel(dateTime.AddDays(22), 4704),
                new ChartModel(dateTime.AddDays(24), 4680),
                new ChartModel(dateTime.AddDays(26), 5351),
                new ChartModel(dateTime.AddDays(28), 5385),
                new ChartModel(dateTime.AddDays(30), 5289),
                new ChartModel(dateTime.AddDays(32), 4703),
                new ChartModel(dateTime.AddDays(34), 4718),
                new ChartModel(dateTime.AddDays(36), 4430),
                new ChartModel(dateTime.AddDays(38), 4308),
                new ChartModel(dateTime.AddDays(40), 4212),
                new ChartModel(dateTime.AddDays(42), 4643),
                new ChartModel(dateTime.AddDays(44), 5620),
                new ChartModel(dateTime.AddDays(46), 5432),
                new ChartModel(dateTime.AddDays(48), 5339),
                new ChartModel(dateTime.AddDays(50), 5718),
                new ChartModel(dateTime.AddDays(52), 5450),
                new ChartModel(dateTime.AddDays(54), 5578),
                new ChartModel(dateTime.AddDays(56), 5337),
                new ChartModel(dateTime.AddDays(58), 5317),
                new ChartModel(dateTime.AddDays(60), 5204),
                new ChartModel(dateTime.AddDays(64), 4922),
                new ChartModel(dateTime.AddDays(68), 4878),
                new ChartModel(dateTime.AddDays(72), 4975),
                new ChartModel(dateTime.AddDays(76), 4900),
                new ChartModel(dateTime.AddDays(80), 5312),
                new ChartModel(dateTime.AddDays(84), 5283),
                new ChartModel(dateTime.AddDays(88), 5390),
                new ChartModel(dateTime.AddDays(92), 5550),
                new ChartModel(dateTime.AddDays(96), 5620),
                new ChartModel(dateTime.AddDays(100), 5430),
                new ChartModel(dateTime.AddDays(104), 5522),
                new ChartModel(dateTime.AddDays(108), 5604),
                new ChartModel(dateTime.AddDays(112), 5837),
                new ChartModel(dateTime.AddDays(116), 5720),
                new ChartModel(dateTime.AddDays(120), 5703),
                new ChartModel(dateTime.AddDays(124), 5904),
                new ChartModel(dateTime.AddDays(128), 6110),
                new ChartModel(dateTime.AddDays(132), 6280),
                new ChartModel(dateTime.AddDays(136), 6217),
                new ChartModel(dateTime.AddDays(140), 5830),
                new ChartModel(dateTime.AddDays(144), 5742),
                new ChartModel(dateTime.AddDays(148), 5701),
                new ChartModel(dateTime.AddDays(152), 5640),
                new ChartModel(dateTime.AddDays(156), 5780),
                new ChartModel(dateTime.AddDays(160), 6232),
                new ChartModel(dateTime.AddDays(164), 6150),
                new ChartModel(dateTime.AddDays(168), 6183),
                new ChartModel(dateTime.AddDays(172), 5630),
                new ChartModel(dateTime.AddDays(176), 5692),
                new ChartModel(dateTime.AddDays(180), 5680),
            };

            this.threeMonthData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(4), 4508),
                new ChartModel(dateTime.AddDays(6), 4157),
                new ChartModel(dateTime.AddDays(8), 4062),
                new ChartModel(dateTime.AddDays(10), 4587),
                new ChartModel(dateTime.AddDays(12), 4642),
                new ChartModel(dateTime.AddDays(14), 4205),
                new ChartModel(dateTime.AddDays(16), 4678),
                new ChartModel(dateTime.AddDays(18), 4402),
                new ChartModel(dateTime.AddDays(20), 4650),
                new ChartModel(dateTime.AddDays(22), 4704),
                new ChartModel(dateTime.AddDays(24), 4680),
                new ChartModel(dateTime.AddDays(26), 5351),
                new ChartModel(dateTime.AddDays(28), 5385),
                new ChartModel(dateTime.AddDays(30), 5289),
                new ChartModel(dateTime.AddDays(32), 4703),
                new ChartModel(dateTime.AddDays(34), 4718),
                new ChartModel(dateTime.AddDays(36), 4430),
                new ChartModel(dateTime.AddDays(38), 4308),
                new ChartModel(dateTime.AddDays(40), 4212),
                new ChartModel(dateTime.AddDays(42), 4643),
                new ChartModel(dateTime.AddDays(44), 5620),
                new ChartModel(dateTime.AddDays(46), 5432),
                new ChartModel(dateTime.AddDays(48), 5339),
                new ChartModel(dateTime.AddDays(50), 5718),
                new ChartModel(dateTime.AddDays(52), 5450),
                new ChartModel(dateTime.AddDays(54), 5578),
                new ChartModel(dateTime.AddDays(56), 5337),
                new ChartModel(dateTime.AddDays(58), 5317),
                new ChartModel(dateTime.AddDays(60), 5204),
                new ChartModel(dateTime.AddDays(64), 4922),
                new ChartModel(dateTime.AddDays(68), 4878),
                new ChartModel(dateTime.AddDays(72), 4975),
                new ChartModel(dateTime.AddDays(76), 4900),
                new ChartModel(dateTime.AddDays(80), 5312),
                new ChartModel(dateTime.AddDays(84), 5283),
                new ChartModel(dateTime.AddDays(88), 5390),
            };

            this.nineMonthData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(15), 4508),
                new ChartModel(dateTime.AddDays(30), 4157),
                new ChartModel(dateTime.AddDays(45), 4062),
                new ChartModel(dateTime.AddDays(60), 4587),
                new ChartModel(dateTime.AddDays(75), 4642),
                new ChartModel(dateTime.AddDays(90), 4205),
                new ChartModel(dateTime.AddDays(105), 4678),
                new ChartModel(dateTime.AddDays(120), 4402),
                new ChartModel(dateTime.AddDays(135), 4650),
                new ChartModel(dateTime.AddDays(150), 4704),
                new ChartModel(dateTime.AddDays(165), 4680),
                new ChartModel(dateTime.AddDays(180), 5351),
                new ChartModel(dateTime.AddDays(195), 5385),
                new ChartModel(dateTime.AddDays(210), 5289),
                new ChartModel(dateTime.AddDays(225), 4680),
                new ChartModel(dateTime.AddDays(240), 5351),
                new ChartModel(dateTime.AddDays(255), 5385),
                new ChartModel(dateTime.AddDays(260), 5289),
            };

            this.yearData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddMonths(1), 4508),
                new ChartModel(dateTime.AddMonths(2), 4157),
                new ChartModel(dateTime.AddMonths(3), 4062),
                new ChartModel(dateTime.AddMonths(4), 4587),
                new ChartModel(dateTime.AddMonths(5), 4642),
                new ChartModel(dateTime.AddMonths(6), 4205),
                new ChartModel(dateTime.AddMonths(7), 4678),
                new ChartModel(dateTime.AddMonths(8), 4402),
                new ChartModel(dateTime.AddMonths(9), 4650),
                new ChartModel(dateTime.AddMonths(10), 4704),
                new ChartModel(dateTime.AddMonths(11), 4680),
                new ChartModel(dateTime.AddMonths(12), 5351),
            };
        }

        /// <summary>
        /// Invoked when the data variant button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void DataVariantClicked(object obj)
        {
            var item = obj as Stock;
            switch (this.SelectedDataVariantIndex)
            {
                case 0:
                    {
                        item.ChartData = this.threeMonthData;
                        break;
                    }

                case 1:
                    {
                        item.ChartData = this.sixMonthData;
                        break;
                    }

                case 2:
                    {
                        item.ChartData = this.nineMonthData;
                        break;
                    }

                case 3:
                    {
                        item.ChartData = this.yearData;
                        break;
                    }
            }
        }

        /// <summary>
        /// Invoked when the menu button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the item is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ItemClicked(object obj)
        {
            var item = obj as Stock;
            foreach (var stock in this.Items)
            {
                if (item != stock)
                {
                    stock.IsSelected = false;
                }
            }
        }

        /// <summary>
        /// Invoked when the profile image is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ProfileImageClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
