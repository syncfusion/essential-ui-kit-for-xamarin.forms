using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Dashboard;
using Model = EssentialUIKit.Models.Dashboard.Transaction;
using System.Linq;

namespace EssentialUIKit.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for my wallet page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class MyWalletViewModel : BaseViewModel
    {
        #region Fields

        private int selectedIndex;

        private double totalBalance;

        private string[] days, weeks, months, xValues;

        private ObservableCollection<Model> weekListItems;

        private ObservableCollection<Model> monthListItems;

        private ObservableCollection<Model> yearListItems;

        private ObservableCollection<Model> listItems;

        public ObservableCollection<TransactionChartData> ChartData { get; set; }

        public ObservableCollection<Model> DataSource { get; set; }

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MyWalletViewModel" /> class.
        /// </summary>
        public MyWalletViewModel()
        {
            WeekData();
            MonthData();
            YearData();
            days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            weeks = new string[] { "Week 1", "Week 2", "Week 3", "Week 4" };
            months = new string[] { "Jan", "Mar", "May", "Jul", "Sep", "Nov" };
            ChartData = new ObservableCollection<TransactionChartData>();
            DataSource = new ObservableCollection<Model>()
            {
                new Model(){ Duration = "Week" },
                new Model(){ Duration = "Month" },
                new Model(){ Duration = "Year" },
            };
            ListItems = WeekListItems;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the my wallet items collection in a week.
        /// </summary>
        public ObservableCollection<Model> WeekListItems
        {
            get
            {
                return this.weekListItems;
            }

            set
            {
                this.weekListItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the my wallet items collection in a month.
        /// </summary>
        public ObservableCollection<Model> MonthListItems
        {
            get
            {
                return this.monthListItems;
            }

            set
            {
                this.monthListItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the my wallet items collection in a year.
        /// </summary>
        public ObservableCollection<Model> YearListItems
        {
            get
            {
                return this.yearListItems;
            }

            set
            {
                this.yearListItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the my wallet items collection.
        /// </summary>
        public ObservableCollection<Model> ListItems
        {
            get
            {
                return this.listItems;
            }

            set
            {
                this.listItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets the selected index of combobox.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                this.selectedIndex = value;
                UpdateListViewData();
            }
        }

        /// <summary>
        /// Gets or sets the total balance remaining in the wallet.
        /// </summary>
        public double TotalBalance
        {
            get
            {
                return totalBalance;
            }
            set
            {
                this.totalBalance = value;
                this.NotifyPropertyChanged();
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Week data collection.
        /// </summary>
        private void WeekData()
        {
            weekListItems = new ObservableCollection<Model>()
            {
                new Model()
                {
                    ProfileImage = "ProfileImage1.png",
                    Name = "Phillip Estrada",
                    Title = "Cash Back",
                    Amount = 50,
                    Date = new DateTime(2019, 1, 7),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 50,
                    Date = new DateTime(2019, 1, 7),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage="ProfileImage11.png",
                    Name = "Essie Hansen",
                    Title = "XXXXXXX6585",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "Refund",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Recharge",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage2.png",
                    Name = "Alta Sims",
                    Title = "Cash Back",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 4),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 40.25,
                    Date = new DateTime(2019, 1, 4),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage3.png",
                    Name = "Blake Moore",
                    Title = "XXXXXXX6585",
                    Amount = 45,
                    Date = new DateTime(2019, 1, 3),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 55,
                    Date = new DateTime(2019, 1, 3),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage4.png",
                    Name = "Chase Blair",
                    Title = "Refund",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 2),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 2),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage5.png",
                    Name = "Bernard Daniels",
                    Title = "Cash Back",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 1),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 1),
                    IsCredited = false
                }
            };
        }

        /// <summary>
        /// Month data collection.
        /// </summary>
        private void MonthData()
        {
            monthListItems = new ObservableCollection<Model>()
            {
                new Model()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "Refund",
                    Amount = 85,
                    Date = new DateTime(2019, 1, 28),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 15.75,
                    Date = new DateTime(2019, 1, 26),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "XXXXXXX6585",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 20),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Delivery Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 18),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage9.png",
                    Name = "Bettie Conlon",
                    Title = "Refund",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 12),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 10),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage11.png",
                    Name = "Essie Hansen",
                    Title = "Cashback",
                    Amount = 30,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food order Bill",
                    Amount = 70,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = false
                },
            };
        }

        /// <summary>
        /// Year data collection.
        /// </summary>
        private void YearData()
        {
            yearListItems = new ObservableCollection<Model>()
            {
                new Model()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "XXXXXXX6585",
                    Amount = 65,
                    Date = new DateTime(2019, 11, 24),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Delivery Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 11, 2),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "XXXXXXX6585",
                    Amount = 70,
                    Date = new DateTime(2019, 9, 21),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 30.50,
                    Date = new DateTime(2019, 9, 8),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage2.png",
                    Name = "Alta Sims",
                    Title = "XXXXXXX6585",
                    Amount = 50,
                    Date = new DateTime(2019, 7, 18),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 50,
                    Date = new DateTime(2019, 7, 12),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage3.png",
                    Name = "Blake Moore",
                    Title = "Refund",
                    Amount = 35,
                    Date = new DateTime(2019, 5, 21),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 65,
                    Date = new DateTime(2019, 5, 15),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage4.png",
                    Name = "Chase Blair",
                    Title = "XXXXXXX6585",
                    Amount = 20,
                    Date = new DateTime(2019, 3, 15),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 80,
                    Date = new DateTime(2019, 3, 5),
                    IsCredited = false
                },
                new Model()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "Cashback",
                    Amount = 85,
                    Date = new DateTime(2019, 1, 26),
                    IsCredited = true
                },
                new Model()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 15,
                    Date = new DateTime(2019, 1, 13),
                    IsCredited = false
                }
            };
        }

        /// <summary>
        /// Method for update the listview items.
        /// </summary>
        private void UpdateListViewData()
        {
            switch (SelectedIndex)
            {
                case 0:
                    ListItems = WeekListItems;
                    xValues = days;
                    break;
                case 1:
                    ListItems = MonthListItems;
                    xValues = weeks;
                    break;
                case 2:
                    ListItems = YearListItems;
                    xValues = months;
                    break;
                default:
                    break;
            }
            UpdateChartData();
        }

        /// <summary>
        /// Method for update the chart data.
        /// </summary>
        private void UpdateChartData()
        {
            ChartData.Clear();
            TotalBalance = 0;

            var incomeCollection = ListItems.Where(item => item.IsCredited).ToList();
            var expenseCollection = ListItems.Where(item => !item.IsCredited).ToList();

            for (int i = 0; i < incomeCollection.Count; i++)
            {
                TotalBalance += incomeCollection[i].Amount;
                TotalBalance -= expenseCollection[i].Amount;
                ChartData.Add(new TransactionChartData(xValues[i], incomeCollection[i].Amount, expenseCollection[i].Amount, 4));
            }
        }

        /// <summary>
        /// Invoked when an item is selected from the my wallet page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}