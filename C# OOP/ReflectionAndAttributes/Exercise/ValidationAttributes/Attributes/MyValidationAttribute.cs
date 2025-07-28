using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public abstract class MyValidationAttribute : Attribute
{
    public abstract IEnumerable<string> Validate(string path, object val);
}