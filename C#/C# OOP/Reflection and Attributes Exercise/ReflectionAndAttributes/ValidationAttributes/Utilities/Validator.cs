namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object value) 
        {
            if (value == null)
            {
                return false;
            }

            PropertyInfo[] properties = value.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(value)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
