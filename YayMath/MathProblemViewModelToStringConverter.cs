using System;
using System.Globalization;
using Xamarin.Forms;

namespace YayMath
{
    public class MathProblemViewModelToStringConverter : IValueConverter
    {
        public object Convert (object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            var val = (MathProblemViewModel)value;

            return string.Format ("{0} {1} {2} =",
                                 val.Value1,
                                 val.Operand == Operand.Add ? "+" : "-",
                                 val.Value2);
        }

        public object ConvertBack (object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}

