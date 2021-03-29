using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// Customizes the tap animation effects of the grid control.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TapAnimationGrid : Grid
    {
        #region Fields

        /// <summary>
        /// Gets or sets the CommandProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TapAnimationGrid), null);

        /// <summary>
        /// Gets or sets the CommandParameterProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TapAnimationGrid), null);

        /// <summary>
        /// Gets or sets the TappedProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty TappedProperty =
            BindableProperty.Create(
                nameof(Tapped), typeof(bool), typeof(TapAnimationGrid), false, BindingMode.TwoWay, null, propertyChanged: OnTapped);

        private ICommand tappedCommand;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TapAnimationGrid" /> class.
        /// </summary>
        public TapAnimationGrid() => this.Initialize();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command value.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command parameter value.
        /// </summary>
        public object CommandParameter
        {
            get => this.GetValue(CommandParameterProperty);
            set => this.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Gets or sets the tapped value.
        /// </summary>
        public bool Tapped
        {
            get => (bool)this.GetValue(TappedProperty);
            set => this.SetValue(TappedProperty, value);
        }

        /// <summary>
        /// Gets or sets the tapped command.
        /// </summary>
        public ICommand TappedCommand => this.tappedCommand
                ?? (this.tappedCommand = new Command(() =>
                {
                    if (this.Tapped)
                    {
                        this.Tapped = false;
                    }
                    else
                    {
                        this.Tapped = true;
                    }

                    if (this.Command != null)
                    {
                        this.Command.Execute(this.CommandParameter);
                    }
                }));

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when tap on the item.
        /// </summary>
        private static async void OnTapped(BindableObject bindable, object oldValue, object newValue)
        {
            var grid = (TapAnimationGrid)bindable;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // To make the selected item color changes for 100 milliseconds.
            await Task.Delay(100).ConfigureAwait(true);
            Application.Current.Resources.TryGetValue("Gray-Bg", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        /// <summary>
        /// Invoked when control is initialized.
        /// </summary>
        private void Initialize()
        {
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = TappedCommand,
            });
        }

        #endregion
    }
}
