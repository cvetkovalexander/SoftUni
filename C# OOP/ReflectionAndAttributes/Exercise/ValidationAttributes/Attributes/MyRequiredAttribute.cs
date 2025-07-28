using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes;

public class MyRequiredAttribute : MyValidationAttribute
{
    public override IEnumerable<string> Validate(string path, object val)
    {
        if (val is null)
            yield return $"{path} should not be null.";
    }
}