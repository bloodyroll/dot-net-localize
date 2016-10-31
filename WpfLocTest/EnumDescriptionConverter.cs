using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;


namespace WpfLocTest
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var e = value as Enum;
            if (e != null)
            {
                string description = GetEnumDescription(e);

                if (parameter is bool && (bool)parameter && description != null)
                {
                    description = description.ToLower();
                }

                return description;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty((string)value)
                       ? Binding.DoNothing
                       : value;
        }

        private static string GetEnumDescription(Enum obj)
        {
            if (obj != null)
            {
                FieldInfo field = obj.GetType().GetField(obj.ToString());

                if (field != null)
                {
                    foreach (object attribute in field.GetCustomAttributes(false))
                    {
                        var descriptionAttribute = attribute as DescriptionAttribute;
                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}