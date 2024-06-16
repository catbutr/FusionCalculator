using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Converters
{
    class ElementToIconConverter : IValueConverter
    {
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Almighty":
                    return "✺";
                case "Bind":
                    return "᯼᯼⏧᯼";
                case "Curse":
                    return "💀";
                case "Death":
                    return "💀";
                case "Dark":
                    return "💀";
                case "Fire":
                    return "🔥";
                case "Ice":
                    return "❄";
                case "Elec":
                    return "🗲";
                case "Force":
                    return "🌀";
                case "Expel":
                    return "☉";
                case "Phys":
                    return "⚔";
                case "Flying":
                    return "⚔";
                case "Punch":
                    return "⚔";
                case "Rush":
                    return "⚔";
                case "Gun":
                    return "🔫";
                case "Special":
                    return "𝆔";
                case "Recovery":
                    return "✚";
                case "Support":
                    return "✚";
                case "Energy":
                    return "⏧᯼";
                case "Nerve":
                    return "⏧᯼";
                default:
                    return "1";
            }
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
