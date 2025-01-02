using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EssentialUIKit.Models.Dashboard;
using Syncfusion.SfChart.XForms;
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

        ObservableCollection<ChartDataPoint> oneMonthData;

        ObservableCollection<ChartDataPoint> threeMonthData;

        ObservableCollection<ChartDataPoint> sixMonthData;

        ObservableCollection<ChartDataPoint> nineMonthData;

        ObservableCollection<ChartDataPoint> yearData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="StockOverviewViewModel" /> class.
        /// </summary>
        public StockOverviewViewModel()
        {
            GetChartData();
            var variants = new List<string> { "1M", "3M", "6M", "9M", "1Y" };
            items = new ObservableCollection<Stock>()
            {
                new Stock()
                {
                    Category = "NSEI",
                    CategoryValue = 20.35,
                    SubCategory = "NIFTY 50",
                    SubCategoryValue = 6164.34,
                    ChartData = sixMonthData,
                    DataVariants = variants,
                    IsExpandable = true
                },
                new Stock()
                {
                    Category = "BSESN",
                    CategoryValue = 26.32,
                    SubCategory = "S&P BSE SENSEX",
                    SubCategoryValue = 5649.43,
                    ChartData = sixMonthData,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "AAPL",
                    CategoryValue = 26.32,
                    SubCategory = "APPLE INC",
                    SubCategoryValue = 5649.43,
                    ChartData = sixMonthData,
                    DataVariants = variants,
                },
                new Stock()
                {
                    Category = "SBUCX",
                    CategoryValue = 26.32,
                    SubCategory = "STARSSBUCKS CORP",
                    SubCategoryValue = 5649.43,
                    ChartData = sixMonthData,
                    DataVariants = variants,
                }
            };

            this.ProfileImage = App.BaseImageUrl + "ProfileImage1.png";
            this.DataVariantCommand = new Command(this.DataVariantClicked);
            this.MenuCommand = new Command(this.MenuClicked);
            this.SelectionCommand = new Command(this.ItemClicked);
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
                return selectedDataVariantIndex;
            }

            set
            {
                selectedDataVariantIndex = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the stock items collection.
        /// </summary>
        public ObservableCollection<Stock> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Comments
        /// <summary>
        /// Gets or sets the command that will be executed when the data variant for chart is clicked.
        /// </summary>
        public Command DataVariantCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the expand the stock item.
        /// </summary>
        public Command SelectionCommand { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

            sixMonthData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 4478),
                new ChartDataPoint(dateTime.AddDays(4), 4508),
                new ChartDataPoint(dateTime.AddDays(6), 4157),
                new ChartDataPoint(dateTime.AddDays(8), 4062),
                new ChartDataPoint(dateTime.AddDays(10), 4587),
                new ChartDataPoint(dateTime.AddDays(12), 4642),
                new ChartDataPoint(dateTime.AddDays(14), 4205),
                new ChartDataPoint(dateTime.AddDays(16), 4678),
                new ChartDataPoint(dateTime.AddDays(18), 4402),
                new ChartDataPoint(dateTime.AddDays(20), 4650),
                new ChartDataPoint(dateTime.AddDays(22), 4704),
                new ChartDataPoint(dateTime.AddDays(24), 4680),
                new ChartDataPoint(dateTime.AddDays(26), 5351),
                new ChartDataPoint(dateTime.AddDays(28), 5385),
                new ChartDataPoint(dateTime.AddDays(30), 5289),
                new ChartDataPoint(dateTime.AddDays(32), 4703),
                new ChartDataPoint(dateTime.AddDays(34), 4718),
                new ChartDataPoint(dateTime.AddDays(36), 4430),
                new ChartDataPoint(dateTime.AddDays(38), 4308),
                new ChartDataPoint(dateTime.AddDays(40), 4212),
                new ChartDataPoint(dateTime.AddDays(42), 4643),
                new ChartDataPoint(dateTime.AddDays(44), 5620),
                new ChartDataPoint(dateTime.AddDays(46), 5432),
                new ChartDataPoint(dateTime.AddDays(48), 5339),
                new ChartDataPoint(dateTime.AddDays(50), 5718),
                new ChartDataPoint(dateTime.AddDays(52), 5450),
                new ChartDataPoint(dateTime.AddDays(54), 5578),
                new ChartDataPoint(dateTime.AddDays(56), 5337),
                new ChartDataPoint(dateTime.AddDays(58), 5317),
                new ChartDataPoint(dateTime.AddDays(60), 5204),
                new ChartDataPoint(dateTime.AddDays(64), 4922),
                new ChartDataPoint(dateTime.AddDays(68), 4878),
                new ChartDataPoint(dateTime.AddDays(72), 4975),
                new ChartDataPoint(dateTime.AddDays(76), 4900),
                new ChartDataPoint(dateTime.AddDays(80), 5312),
                new ChartDataPoint(dateTime.AddDays(84), 5283),
                new ChartDataPoint(dateTime.AddDays(88), 5390),
                new ChartDataPoint(dateTime.AddDays(92), 5550),
                new ChartDataPoint(dateTime.AddDays(96), 5620),
                new ChartDataPoint(dateTime.AddDays(100), 5430),
                new ChartDataPoint(dateTime.AddDays(104), 5522),
                new ChartDataPoint(dateTime.AddDays(108), 5604),
                new ChartDataPoint(dateTime.AddDays(112), 5837),
                new ChartDataPoint(dateTime.AddDays(116), 5720),
                new ChartDataPoint(dateTime.AddDays(120), 5703),
                new ChartDataPoint(dateTime.AddDays(124), 5904),
                new ChartDataPoint(dateTime.AddDays(128), 6110),
                new ChartDataPoint(dateTime.AddDays(132), 6280),
                new ChartDataPoint(dateTime.AddDays(136), 6217),
                new ChartDataPoint(dateTime.AddDays(140), 5830),
                new ChartDataPoint(dateTime.AddDays(144), 5742),
                new ChartDataPoint(dateTime.AddDays(148), 5701),
                new ChartDataPoint(dateTime.AddDays(152), 5640),
                new ChartDataPoint(dateTime.AddDays(156), 5780),
                new ChartDataPoint(dateTime.AddDays(160), 6232),
                new ChartDataPoint(dateTime.AddDays(164), 6150),
                new ChartDataPoint(dateTime.AddDays(168), 6183),
                new ChartDataPoint(dateTime.AddDays(172), 5630),
                new ChartDataPoint(dateTime.AddDays(176), 5692),
                new ChartDataPoint(dateTime.AddDays(180), 5680),
            };

            threeMonthData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 4478),
                new ChartDataPoint(dateTime.AddDays(4), 4508),
                new ChartDataPoint(dateTime.AddDays(6), 4157),
                new ChartDataPoint(dateTime.AddDays(8), 4062),
                new ChartDataPoint(dateTime.AddDays(10), 4587),
                new ChartDataPoint(dateTime.AddDays(12), 4642),
                new ChartDataPoint(dateTime.AddDays(14), 4205),
                new ChartDataPoint(dateTime.AddDays(16), 4678),
                new ChartDataPoint(dateTime.AddDays(18), 4402),
                new ChartDataPoint(dateTime.AddDays(20), 4650),
                new ChartDataPoint(dateTime.AddDays(22), 4704),
                new ChartDataPoint(dateTime.AddDays(24), 4680),
                new ChartDataPoint(dateTime.AddDays(26), 5351),
                new ChartDataPoint(dateTime.AddDays(28), 5385),
                new ChartDataPoint(dateTime.AddDays(30), 5289),
                new ChartDataPoint(dateTime.AddDays(32), 4703),
                new ChartDataPoint(dateTime.AddDays(34), 4718),
                new ChartDataPoint(dateTime.AddDays(36), 4430),
                new ChartDataPoint(dateTime.AddDays(38), 4308),
                new ChartDataPoint(dateTime.AddDays(40), 4212),
                new ChartDataPoint(dateTime.AddDays(42), 4643),
                new ChartDataPoint(dateTime.AddDays(44), 5620),
                new ChartDataPoint(dateTime.AddDays(46), 5432),
                new ChartDataPoint(dateTime.AddDays(48), 5339),
                new ChartDataPoint(dateTime.AddDays(50), 5718),
                new ChartDataPoint(dateTime.AddDays(52), 5450),
                new ChartDataPoint(dateTime.AddDays(54), 5578),
                new ChartDataPoint(dateTime.AddDays(56), 5337),
                new ChartDataPoint(dateTime.AddDays(58), 5317),
                new ChartDataPoint(dateTime.AddDays(60), 5204),
                new ChartDataPoint(dateTime.AddDays(64), 4922),
                new ChartDataPoint(dateTime.AddDays(68), 4878),
                new ChartDataPoint(dateTime.AddDays(72), 4975),
                new ChartDataPoint(dateTime.AddDays(76), 4900),
                new ChartDataPoint(dateTime.AddDays(80), 5312),
                new ChartDataPoint(dateTime.AddDays(84), 5283),
                new ChartDataPoint(dateTime.AddDays(88), 5390),
            };

            oneMonthData = new ObservableCollection<ChartDataPoint>(threeMonthData.Take(15));

            nineMonthData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 4478),
                new ChartDataPoint(dateTime.AddDays(15), 4508),
                new ChartDataPoint(dateTime.AddDays(30), 4157),
                new ChartDataPoint(dateTime.AddDays(45), 4062),
                new ChartDataPoint(dateTime.AddDays(60), 4587),
                new ChartDataPoint(dateTime.AddDays(75), 4642),
                new ChartDataPoint(dateTime.AddDays(90), 4205),
                new ChartDataPoint(dateTime.AddDays(105), 4678),
                new ChartDataPoint(dateTime.AddDays(120), 4402),
                new ChartDataPoint(dateTime.AddDays(135), 4650),
                new ChartDataPoint(dateTime.AddDays(150), 4704),
                new ChartDataPoint(dateTime.AddDays(165), 4680),
                new ChartDataPoint(dateTime.AddDays(180), 5351),
                new ChartDataPoint(dateTime.AddDays(195), 5385),
                new ChartDataPoint(dateTime.AddDays(210), 5289),
                new ChartDataPoint(dateTime.AddDays(225), 4680),
                new ChartDataPoint(dateTime.AddDays(240), 5351),
                new ChartDataPoint(dateTime.AddDays(255), 5385),
                new ChartDataPoint(dateTime.AddDays(260), 5289),
            };

            yearData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 4478),
                new ChartDataPoint(dateTime.AddMonths(1), 4508),
                new ChartDataPoint(dateTime.AddMonths(2), 4157),
                new ChartDataPoint(dateTime.AddMonths(3), 4062),
                new ChartDataPoint(dateTime.AddMonths(4), 4587),
                new ChartDataPoint(dateTime.AddMonths(5), 4642),
                new ChartDataPoint(dateTime.AddMonths(6), 4205),
                new ChartDataPoint(dateTime.AddMonths(7), 4678),
                new ChartDataPoint(dateTime.AddMonths(8), 4402),
                new ChartDataPoint(dateTime.AddMonths(9), 4650),
                new ChartDataPoint(dateTime.AddMonths(10), 4704),
                new ChartDataPoint(dateTime.AddMonths(11), 4680),
                new ChartDataPoint(dateTime.AddMonths(12), 5351)
            };
        }

        /// <summary>
        /// Invoked when the data variant button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void DataVariantClicked(object obj)
        {
            var item = obj as Stock;
            switch (SelectedDataVariantIndex)
            {
                case 0:
                    {
                        item.ChartData = oneMonthData;
                        break;
                    }
                case 1:
                    {
                        item.ChartData = threeMonthData;
                        break;
                    }
                case 2:
                    {
                        item.ChartData = sixMonthData;
                        break;
                    }
                case 3:
                    {
                        item.ChartData = nineMonthData;
                        break;
                    }
                case 4:
                    {
                        item.ChartData = yearData;
                        break;
                    }
            }
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ItemClicked(object obj)
        {
            var item = obj as Stock;
            foreach (var stock in Items)
            {
                if (item != stock)
                    stock.IsExpandable = false;
            }
        }

        #endregion
    }
}
