using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace DigestAuthCalc
{
  public class QopToStringConverter : MarkupExtension, IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return ((Enum)value).GetAttributeOfType<DisplayAttribute>().Name;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return EnumHelper.GetValueByAttributeNameOfType<Qop, DisplayAttribute>((string)value);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      return this;
    }
  }
}
