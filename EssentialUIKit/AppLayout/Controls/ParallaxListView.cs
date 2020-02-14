using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.Controls
{
    [Preserve(AllMembers = true)]
    public class ParallaxListView : ListView
    {
        public ParallaxListView() : base(ListViewCachingStrategy.RetainElement)
        {
            if (Device.RuntimePlatform != Device.iOS)
            {
                this.ItemSelected += this.ParallaxListView_ItemSelected;
            }
        }

        public event EventHandler<SelectedItemChangedEventArgs> SelectionChanged;

        public event EventHandler<ScrollChangedEventArgs> ScrollChanged;

        public double WidthInPixel { get; set; }

        public static void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
                ((ParallaxListView)sender)?.ScrollChanged?.Invoke((ParallaxListView)sender, e);
        }

        public static void OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            ParallaxListView listView = (ParallaxListView)sender;
            if (listView != null)
            {
                listView.SelectionChanged(sender, e);
                listView.SelectedItem = e.SelectedItem;
                listView.SelectedItem = null;
            }
        }

        public static void OnSelectionChanged(object sender, int index)
        {
            if (sender is ParallaxListView)
            {
                var listView = sender as ParallaxListView;
                OnSelectionChanged(sender, new SelectedItemChangedEventArgs((listView.ItemsSource as IList)[index], index));
            }
        }

        private void ParallaxListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OnSelectionChanged(this, e);
        }
    }

    public class ScrollChangedEventArgs : EventArgs
    {
        public ScrollChangedEventArgs(int position)
        {
            this.Position = position;
        }

        public int Position { get; set; }
    }
}