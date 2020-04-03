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
            BindableProperty.Create(nameof(Tapped), typeof(bool), typeof(TapAnimationGrid), false, BindingMode.TwoWay,
                null, propertyChanged: OnTapped);

        ICommand tappedCommand;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TapAnimationGrid" /> class.
        /// </summary>
        public TapAnimationGrid () => Initialize();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command value.
        /// </summary>
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the command parameter value.
        /// </summary>
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Gets or sets the tapped value.
        /// </summary>
        public bool Tapped
        {
            get => (bool)GetValue(TappedProperty);
            set => SetValue(TappedProperty, value);
        }

        /// <summary>
        /// Gets or sets the tapped command.
        /// </summary>
        public ICommand TappedCommand => tappedCommand
                ?? ( tappedCommand = new Command(() =>
                {
                    if (Tapped)
                    {
                        Tapped = false;
                    }
                    else
                    {
                        Tapped = true;
                    }
                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                }) );

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when control is initialized.
        /// </summary>
        void Initialize ()
        {
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = TappedCommand
            });
        }
        /// <summary>
        /// Invoked when tap on the item.
        /// </summary>
        static async void OnTapped (BindableObject bindable, object oldValue, object newValue)
        {
            var grid = (TapAnimationGrid)bindable;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // To make the selected item color changes for 100 milliseconds.
            await Task.Delay(100);
            Application.Current.Resources.TryGetValue("Gray-White", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }
        #endregion
    }
}
