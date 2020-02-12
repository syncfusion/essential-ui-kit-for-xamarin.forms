using System.Linq;
using EssentialUIKit.Themes;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout
{
    [Preserve(AllMembers = true)]
    public static class Extensions
    {
        public static void ApplyDarkTheme(this ResourceDictionary resources)
        {
            if (resources != null)
            {
                var mergedDictionaries = resources.MergedDictionaries;
                var lightTheme = mergedDictionaries.OfType<LightTheme>().FirstOrDefault();
                if (lightTheme != null)
                {
                    mergedDictionaries.Remove(lightTheme);
                }

                // mergedDictionaries.Add(new DarkTheme());
                AppSettings.Instance.IsDarkTheme = true;
            }
        }

        public static void ApplyLightTheme(this ResourceDictionary resources)
        {
            if (resources != null)
            {
                var mergedDictionaries = resources.MergedDictionaries;

                // var darkTheme = mergedDictionaries.OfType<DarkTheme>().FirstOrDefault();
                // if (darkTheme != null)
                // {
                //     mergedDictionaries.Remove(darkTheme);
                // }
                mergedDictionaries.Add(new LightTheme());
                AppSettings.Instance.IsDarkTheme = false;
            }
        }

        public static void ApplyColorSet(int index)
        {
            switch (index)
            {
                case 0:
                    ApplyColorSet1();
                    break;
                case 1:
                    ApplyColorSet2();
                    break;
                case 2:
                    ApplyColorSet3();
                    break;
                case 3:
                    ApplyColorSet4();
                    break;
                case 4:
                    ApplyColorSet5();
                    break;
            }
        }

        public static void ApplyColorSet1()
        {
            Application.Current.Resources["PrimaryColor"] = Color.FromHex("#f54e5e");
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromHex("#d0424f");
            Application.Current.Resources["PrimaryDarkenColor"] = Color.FromHex("#ab3641");
            Application.Current.Resources["PrimaryLighterColor"] = Color.FromHex("#edcacd");
            Application.Current.Resources["PrimaryLight"] = Color.FromHex("#ffe8f4");
            Application.Current.Resources["PrimaryGradient"] = Color.FromHex("e83f94");
        }

        public static void ApplyColorSet2()
        {
            Application.Current.Resources["PrimaryColor"] = Color.FromHex("#2f72e4");
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromHex("#1a5ac6");
            Application.Current.Resources["PrimaryDarkenColor"] = Color.FromHex("#174fb0");
            Application.Current.Resources["PrimaryLighterColor"] = Color.FromHex("#73a0ed");
            Application.Current.Resources["PrimaryLight"] = Color.FromHex("#cdddf9");
            Application.Current.Resources["PrimaryGradient"] = Color.FromHex("#00acff");
        }

        public static void ApplyColorSet3()
        {
            Application.Current.Resources["PrimaryColor"] = Color.FromHex("#5d4cf7");
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromHex("#4b3ae1");
            Application.Current.Resources["PrimaryDarkenColor"] = Color.FromHex("#3829ba");
            Application.Current.Resources["PrimaryLighterColor"] = Color.FromHex("#b5aefb");
            Application.Current.Resources["PrimaryLight"] = Color.FromHex("#eae8fe");
            Application.Current.Resources["PrimaryGradient"] = Color.FromHex("#aa9cfc");
        }

        public static void ApplyColorSet4()
        {
            Application.Current.Resources["PrimaryColor"] = Color.FromHex("#06846a");
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromHex("#056c56");
            Application.Current.Resources["PrimaryDarkenColor"] = Color.FromHex("#045343");
            Application.Current.Resources["PrimaryLighterColor"] = Color.FromHex("#98f0de");
            Application.Current.Resources["PrimaryLight"] = Color.FromHex("#ebf9f7");
            Application.Current.Resources["PrimaryGradient"] = Color.FromHex("#0ed342");
        }

        public static void ApplyColorSet5()
        {
            Application.Current.Resources["PrimaryColor"] = Color.FromHex("#d54008");
            Application.Current.Resources["PrimaryDarkColor"] = Color.FromHex("#a43106");
            Application.Current.Resources["PrimaryDarkenColor"] = Color.FromHex("#862805");
            Application.Current.Resources["PrimaryLighterColor"] = Color.FromHex("#fa9e7c");
            Application.Current.Resources["PrimaryLight"] = Color.FromHex("#fee7de");
            Application.Current.Resources["PrimaryGradient"] = Color.FromHex("#ff6374");
        }
    }
}