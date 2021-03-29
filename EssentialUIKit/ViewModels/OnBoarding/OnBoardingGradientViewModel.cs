using System.Collections.ObjectModel;
using System.Windows.Input;
using EssentialUIKit.Models.OnBoarding;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.OnBoarding
{
    /// <summary>
    /// ViewModel for on-boarding gradient page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OnBoardingGradientViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Boarding> boardings;

        private string nextButtonText = "NEXT";

        private bool isSkipButtonVisible = true;

        private int selectedIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="OnBoardingGradientViewModel" /> class.
        /// </summary>
        public OnBoardingGradientViewModel()
        {
            this.Boardings = new ObservableCollection<Boarding>
            {
                new Boarding
                {
                    ImagePath = "ChooseGradient.svg",
                    Header = "CHOOSE",
                    Content = "Pick the item that is right for you",
                },
                new Boarding
                {
                    ImagePath = "ConfirmGradient.svg",
                    Header = "ORDER CONFIRMED",
                    Content = "Your order is confirmed and will be on its way soon",
                },
                new Boarding
                {
                    ImagePath = "DeliverGradient.svg",
                    Header = "DELIVERY",
                    Content = "Your item will arrive soon. Email us if you have any issues",
                },
            };

            this.SkipCommand = new Command(this.Skip);
            this.NextCommand = new Command(this.Next);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Skip button is clicked.
        /// </summary>
        public ICommand SkipCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Done button is clicked.
        /// </summary>
        public ICommand NextCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the boardings collection.
        /// </summary>
        public ObservableCollection<Boarding> Boardings
        {
            get
            {
                return this.boardings;
            }

            private set
            {
                this.SetProperty(ref this.boardings, value);
            }
        }

        public string NextButtonText
        {
            get
            {
                return this.nextButtonText;
            }

            set
            {
                if (this.nextButtonText == value)
                {
                    return;
                }

                this.SetProperty(ref this.nextButtonText, value);
            }
        }

        public bool IsSkipButtonVisible
        {
            get
            {
                return this.isSkipButtonVisible;
            }

            set
            {
                if (this.isSkipButtonVisible == value)
                {
                    return;
                }

                this.SetProperty(ref this.isSkipButtonVisible, value);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                if (this.selectedIndex == value)
                {
                    return;
                }

                this.SetProperty(ref this.selectedIndex, value);
                this.ValidateSelection();
            }
        }

        #endregion

        #region Methods

        private static void MoveToNextPage()
        {
            // Move to next page
        }

        private bool ValidateAndUpdateSelectedIndex()
        {
            if (this.selectedIndex >= this.Boardings.Count - 1)
            {
                return true;
            }

            this.SelectedIndex++;
            return false;
        }

        private void ValidateSelection()
        {
            if (this.selectedIndex < this.Boardings.Count - 1)
            {
                this.IsSkipButtonVisible = true;
                this.NextButtonText = "NEXT";
            }
            else
            {
                this.NextButtonText = "DONE";
                this.IsSkipButtonVisible = false;
            }
        }

        /// <summary>
        /// Invoked when the Skip button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Skip(object obj)
        {
            MoveToNextPage();
        }

        /// <summary>
        /// Invoked when the Done button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Next(object obj)
        {
            if (this.ValidateAndUpdateSelectedIndex())
            {
                Application.Current.MainPage.Navigation.PopAsync();
                MoveToNextPage();
            }
        }

        #endregion
    }
}