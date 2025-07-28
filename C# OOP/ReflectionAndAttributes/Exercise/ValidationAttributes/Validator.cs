using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes;

public static class Validator
{
    public static IEnumerable<string> Validate(object obj)
        => Validate(obj, null);

    public static IEnumerable<string> Validate(object obj, string prefixPath)
    {
        if (obj is null) throw new ArgumentNullException(nameof(obj));

        Type type = obj.GetType();

        foreach (PropertyInfo property in type.GetProperties())
        {
            MyValidationAttribute[] validationAttributes = property.GetCustomAttributes<MyValidationAttribute>().ToArray();
            if (validationAttributes.Length == 0) continue;

            if (!property.CanRead)
                throw new InvalidOperationException(
                    $"Property \"{property.Name}\" for type \"{type.FullName}\" does not define a get accessor and cannot be validated.");

            string path = property.Name;
            if (!string.IsNullOrWhiteSpace(prefixPath))
                path = $"{prefixPath}.{path}";
            object value = property.GetValue(obj);
            foreach (MyValidationAttribute attribute in validationAttributes)
            {
                foreach (string error in attribute.Validate(path, value))
                    yield return error;
            }
        }
    }
}