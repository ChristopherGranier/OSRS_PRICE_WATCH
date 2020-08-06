using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace OSRS_PRICE_WATCH.Models
{
    public static class TitleCase
    {


    public static string ToTitleCase(this string title)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
    }

}
}
