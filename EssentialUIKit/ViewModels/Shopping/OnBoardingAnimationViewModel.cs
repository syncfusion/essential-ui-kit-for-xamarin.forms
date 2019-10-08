using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EssentialUIKit.AppLayout.Views;
using EssentialUIKit.Models.Shopping;
using EssentialUIKit.Views.Shopping;
using Syncfusion.SfRotator.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Template = EssentialUIKit.AppLayout.Models.Template;

namespace EssentialUIKit.ViewModels.Shopping
{
    /// <summary>
    /// ViewModel for on-boarding gradient page with animation.
    /// </summary>
[Preserve(AllMembers = true)]
    public class OnBoardingAnimationViewModel : INotifyPropertyChanged
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
                    ImagePath = "ChooseGradient.svg",
                    Header = "CHOOSE",
                    Content = "Pick the item that is right for you",
                    RotatorItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "ConfirmGradient.svg",
                    Header = "ORDER CONFIRMED",
                    Content = "Your order is confirmed and will be on its way soon",
                    RotatorItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "DeliverGradient.svg",
                    Header = "DELIVERY",
                    Content = "Your item will arrive soon. Email us if you have any issues",
                    RotatorItem = new WalkthroughItemPage()
                }
            };

            // Set bindingcontext to content view.
            foreach (var boarding in this.Boardings)
            {
                boarding.RotatorItem.BindingContext = boarding;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public ObservableCollection<Boarding> Boardings
        {
            get
            {
                return this.boardings;
            }

            set
            {
                if (this.boardings == value)
                {
                    return;
                }

                this.boardings = value;
                this.OnPropertyChanged();
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

                this.nextButtonText = value;
                this.OnPropertyChanged();
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

                this.isSkipButtonVisible = value;
                this.OnPropertyChanged();
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

                this.selectedIndex = value;
                this.OnPropertyChanged();
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

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            if (Device.RuntimePlatform == "UWP")
            {
                Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                Template template = new Template();
                template.Name = "Login Page";
                template.PageName = "Views.Shopping.LoginPage";
                Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
            }
        }

        /// <summary>
        /// Invoked when the Done button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Next(object obj)
        {
            var itemCount = (obj as SfRotator).ItemsSource.Count();
            if (this.ValidateAndUpdateSelectedIndex(itemCount))
            {
                if (Device.RuntimePlatform == "UWP")
                {
                    Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    Template template = new Template();
                    template.Name = "Login Page";
                    template.PageName = "Views.Shopping.LoginPage";
                    Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
                }
            }
            else
            {
                this.MoveToNextPage();
            }
        }

        private void MoveToNextPage()
        {
            // Move to next page
        }

        #endregion
    }
}
