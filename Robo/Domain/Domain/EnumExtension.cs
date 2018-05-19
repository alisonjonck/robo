using System.ComponentModel;
using System.Reflection;

namespace Domain
{
    public static class EnumExtension
    {
        public static string Description<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return source.ToString();
                }
            }
            return string.Empty;
        }
    }
}

