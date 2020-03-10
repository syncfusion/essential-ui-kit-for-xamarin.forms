using System.Collections.Generic;
using EssentialUIKit.Models.Detail;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// View model for data table 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class DataTableViewModel : BaseViewModel
    {
        #region Fields

        private List<DataTable> items;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableViewModel" /> class.
        /// </summary>
        public DataTableViewModel()
        {
            this.Items = new List<DataTable>
            {
                new DataTable
                {
                    ImagePath = "Liverpool-FC.png",
                    SerialNumber = "1",
                    ClubName = "LIV",
                    GoldPoints = "+28",
                    Points = "49",
                    MatchResults = new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "Leicester-City.png",
                    SerialNumber = "2",
                    ClubName = "LEI",
                    GoldPoints = "+29",
                    Points = "39",
                    MatchResults = new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#b2b8c2" }
                },
                new DataTable
                {
                    ImagePath = "Manchester-City.png",
                    SerialNumber = "3",
                    ClubName = "MCI",
                    GoldPoints = "+28",
                    Points = "49",
                    MatchResults = new string[5]{ "#7ed321", "#b2b8c2", "#7ed321", "#ff4a4a", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "Chelsea.png",
                    SerialNumber = "4",
                    ClubName = "CHE",
                    GoldPoints = "+6",
                    Points = "29",
                    MatchResults = new string[5]{ "#ff4a4a", "#ff4a4a", "#7ed321", "#ff4a4a", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "Tottenham-Hotspur.png",
                    SerialNumber = "5",
                    ClubName = "TOT",
                    GoldPoints = "+8",
                    Points = "26",
                    MatchResults = new string[5]{ "#7ed321", "#7ed321", "#ff4a4a", "#7ed321", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "manchester-united-logo.png",
                    SerialNumber = "6",
                    ClubName = "MUN",
                    GoldPoints = "+6",
                    Points = "25",
                    MatchResults = new string[5]{ "#b2b8c2", "#b2b8c2", "#7ed321", "#7ed321", "#b2b8c2" }
                },
                new DataTable
                {
                    ImagePath = "Sheffield-United.png",
                    SerialNumber = "7",
                    ClubName = "SHU",
                    GoldPoints = "+5",
                    Points = "525",
                    MatchResults = new string[5]{ "#b2b8c2", "#b2b8c2", "#ff4a4a", "#7ed321", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "Wolverhampton-Wanderers.png",
                    SerialNumber = "8",
                    ClubName = "WOL",
                    GoldPoints = "+3",
                    Points = "24",
                    MatchResults = new string[5]{ "#7ed321", "#b2b8c2", "#7ed321", "#b2b8c2", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "Crystal-Palace.png",
                    SerialNumber = "9",
                    ClubName = "CRY",
                    GoldPoints = "-4",
                    Points = "23",
                    MatchResults = new string[5]{ "#ff4a4a", "#7ed321", "#7ed321", "#b2b8c2", "#b2b8c2" }
                },
                new DataTable
                {
                   ImagePath = "Arsenal.png",
                    SerialNumber = "10",
                    ClubName = "ARS",
                    GoldPoints = "-3",
                    Points = "22",
                    MatchResults = new string[5]{ "#b2b8c2", "#b2b8c2", "#ff4a4a", "#7ed321", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "Newcastle-United.png",
                    SerialNumber = "11",
                    ClubName = "NEW",
                    GoldPoints = "-7",
                    Points = "22",
                    MatchResults = new string[5]{ "#ff4a4a", "#b2b8c2", "#7ed321", "#7ed321", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "Burnley.png",
                    SerialNumber = "12",
                    ClubName = "BUR",
                    GoldPoints = "-7",
                    Points = "21",
                    MatchResults = new string[5]{ "#7ed321", "#ff4a4a", "#ff4a4a", "#ff4a4a", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "Brighton-and-Hove-Albion.png",
                    SerialNumber = "13",
                    ClubName = "BHA",
                    GoldPoints = "-4",
                    Points = "20",
                    MatchResults = new string[5]{ "#ff4a4a", "#ff4a4a", "#7ed321", "#b2b8c2", "#b2b8c2" }
                },
                new DataTable
                {
                    ImagePath = "AFC-Bournemouth.png",
                    SerialNumber = "14",
                    ClubName = "BOU",
                    GoldPoints = "-5",
                    Points = "19",
                    MatchResults = new string[5]{ "#ff4a4a", "#ff4a4a", "#ff4a4a", "#ff4a4a", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "West-Ham-United.png",
                    SerialNumber = "15",
                    ClubName = "WHU",
                    GoldPoints = "-9",
                    Points = "19",
                    MatchResults = new string[5]{ "#ff4a4a", "#7ed321", "#ff4a4a", "#ff4a4a", "#7ed321" }
                },
                new DataTable
                {
                    ImagePath = "Everton.png",
                    SerialNumber = "16",
                    ClubName = "EVE",
                    GoldPoints = "-9",
                    Points = "18",
                    MatchResults = new string[5]{ "#ff4a4a", "#ff4a4a", "#ff4a4a", "#7ed321", "#b2b8c2" }
                },
                new DataTable
                {
                    ImagePath = "Aston-Villa.png",
                    SerialNumber = "17",
                    ClubName = "AVL",
                    GoldPoints = "-7",
                    Points = "15",
                    MatchResults = new string[5]{ "#7ed321", "#b2b8c2", "#ff4a4a", "#ff4a4a", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "southampton-football-club-vector-logo.png",
                    SerialNumber = "18",
                    ClubName = "SOU",
                    GoldPoints = "-18",
                    Points = "15",
                    MatchResults = new string[5]{ "#b2b8c2", "#7ed321", "#7ed321", "#ff4a4a", "#ff4a4a" }
                },
                new DataTable
                {
                    ImagePath = "Norwich-City.png",
                    SerialNumber = "19",
                    ClubName = "NOR",
                    GoldPoints = "-17",
                    Points = "12",
                    MatchResults = new string[5]{ "#7ed321", "#b2b8c2", "#ff4a4a", "#ff4a4a", "#b2b8c2" }
                },
                new DataTable
                {
                    ImagePath = "Watford.png",
                    SerialNumber = "20",
                    ClubName = "WAT",
                    GoldPoints = "-23",
                    Points = "9",
                    MatchResults = new string[5]{ "#ff4a4a", "#ff4a4a", "#ff4a4a", "#b2b8c2", "#ff4a4a" }
                },
            };
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the items.
        /// </summary>
        public List<DataTable> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                if (this.items == value)
                {
                    return;
                }

                this.items = value;
                this.NotifyPropertyChanged();
            }
        }
       
        #endregion
    }
}
