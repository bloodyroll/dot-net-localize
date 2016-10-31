using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;


namespace AppLocalizer
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as string[];
            if (values == null) return string.Empty;

            return values.Length <= Translate.CurrentLanguage ? string.Empty : values[Translate.CurrentLanguage];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class LanguageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strKey = value as string;
            return strKey == null ? string.Empty : Translate.Value(strKey);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public class LanguageDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var field = value.GetType().GetField(value.ToString());

            var desc = string.Empty;

            if (field != null)
            {
                foreach (object attribute in field.GetCustomAttributes(false))
                {
                    var descriptionAttribute = attribute as DescriptionAttribute;
                    if (descriptionAttribute != null)
                    {
                        desc = descriptionAttribute.Description;
                        break;
                    }
                }
            }


            return desc; //string.IsNullOrEmpty(desc) ? strKey : Translate.Value(strKey);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }





}