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

            return $"{val.Value1} {OperandToString (val.Operand)} {val.Value2} =";
        }

        string OperandToString (Operand operand)
        {
            switch (operand)
            {
                case Operand.Add:
                    return "+";
                case Operand.Subtract:
                    return "-";
                case Operand.Multiply:
                    return "*";
                default:
                    throw new NotImplementedException ();
            }
        }

        public object ConvertBack (object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
}

