using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors
{
    /// <summary>
    /// This class extends the behavior of the EntryBehavior control to invoke a command when an event occurs.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EntryMaskedBehavior : Behavior<Entry>
    {
        #region Fields

        /// <summary>
        /// Property used to bind mask for entry to validate the user input. 
        /// </summary>
        public static readonly BindableProperty MaskProperty =
          BindableProperty.Create(nameof(Mask), typeof(string), typeof(EntryMaskedBehavior), string.Empty, BindingMode.Default, null, OnMaskChanged);

        /// <summary>
        /// Property used to set prefix text for entry field. 
        /// </summary>
        public static readonly BindableProperty PrefixProperty =
          BindableProperty.Create(nameof(Prefix), typeof(string), typeof(EntryMaskedBehavior), string.Empty, BindingMode.Default, null, OnPrefixChanged);

        private IDictionary<int, char> positions;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the mask format of the entry.
        /// </summary>
        public string Mask
        {
            get { return (string)this.GetValue(MaskProperty); }
            set { this.SetValue(MaskProperty, value); }
        }

        public string Prefix
        {
            get { return (string)this.GetValue(PrefixProperty); }
            set { this.SetValue(PrefixProperty, value); }
        }

        #endregion

        #region Methods

        private static void OnMaskChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as EntryMaskedBehavior).SetPositions();
        }

        private static void OnPrefixChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        protected override void OnAttachedTo(Entry entry)
        {
            if (entry != null)
            {
                entry.TextChanged += this.OnEntryTextChanged;
                entry.Focused += this.OnEntryFocused;
                base.OnAttachedTo(entry);
            }
        }

        private void OnEntryFocused(object sender, FocusEventArgs e)
        {
            (sender as Entry).Text = this.Prefix;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            if (entry != null)
            {
                entry.TextChanged -= this.OnEntryTextChanged;
                entry.Focused -= this.OnEntryFocused;
                base.OnDetachingFrom(entry);
            }
        }

        private void SetPositions()
        {
            if (string.IsNullOrEmpty(this.Mask))
            {
                this.positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < this.Mask.Length; i++)
            {
                if (this.Mask[i] != 'X')
                {
                    list.Add(i, this.Mask[i]);
                }
            }

            this.positions = list;
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;

            var text = entry.Text;

            if (string.IsNullOrWhiteSpace(text) || this.positions == null)
            {
                return;
            }

            if (text.Length > this.Mask.Length)
            {
                entry.Text = text.Remove(text.Length - 1);
                return;
            }

            foreach (var position in this.positions)
            {
                if (text.Length >= position.Key + 1)
                {
                    var value = position.Value.ToString();
                    if (text.Substring(position.Key, 1) != value)
                    {
                        text = text.Insert(position.Key, value);
                    }
                }
            }

            if (entry.Text != text)
            {
                entry.Text = text;
            }
        }

        #endregion
    }
}
