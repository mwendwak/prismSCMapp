using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace com.kinetics.prism.RepoUtil
{
    public static class PriscmUtil
    {
        static public string formatNameToUpper(string RawName)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(
                    RawName));
        }
    }
}