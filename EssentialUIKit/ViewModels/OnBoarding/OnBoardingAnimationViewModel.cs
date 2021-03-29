using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using EssentialUIKit.Models.OnBoarding;
using EssentialUIKit.Views.OnBoarding;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.OnBoarding
{
    /// <summary>
    /// ViewModel for on-boarding gradient page with animation.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OnBoardingAnimationViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Boarding> boardings;

        private string nextButtonText = "NEXT";

        private bool isSkipButtonVisible = true;

        private int selectedIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="OnBoardingAnimationViewModel" /> class.
        /// </summary>
        public OnBoardingAnimationViewModel()
        {
            this.SkipCommand = new Command(this.Skip);
            this.NextCommand = new Command(this.Next);
            this.Boardings = new ObservableCollection<Boarding>
            {
                new Boarding()
                {
                    ImagePath = "ReSchedule.png",
                    Header = "RESCHEDULE",
                    Content = "Drag and drop meetings in order to reschedule them easily.",
                    RotatorView = new WalkthroughItemPage(),
                },
                new Boarding()
                {
                    ImagePath = "ViewMode.png",
                    Header = "VIEW MODE",
                    Content = "Display your meetings using four configurable view modes",
                    RotatorView = new WalkthroughItemPage(),
                },
                new Boarding()
                {
                    ImagePath = "TimeZone.png",
                    Header = "TIME ZONE",
                    Content = "Display meetings created for different time zones.",
                    RotatorView = new WalkthroughItemPage(),
                },
            };

            // Set bindingcontext to content view.
            foreach (var boarding in this.Boardings)
            {
                boarding.RotatorView.BindingContext = boarding;
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<Boarding> Boardings
        {
            get
            {
                return this.boardings;
            }

            private set
            {
                if (this.boardings == value)
                {
                    return;
                }

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
            }
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

        #region Methods

        private static void MoveToNextPage()
        {
            if (Device.RuntimePlatform == Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else if (Device.RuntimePlatform != Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private bool ValidateAndUpdateSelectedIndex(int itemCount)
        {
            if (this.SelectedIndex >= itemCount - 1)
            {
                return true;
            }

            this.SelectedIndex++;
            return false;
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
            if (this.ValidateAndUpdateSelectedIndex(this.Boardings.Count))
            {
                MoveToNextPage();
            }
        }

        #endregion
    }
}
